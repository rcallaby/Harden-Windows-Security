// MIT License
//
// Copyright (c) 2023-Present - Violet Hansen - (aka HotCakeX on GitHub) - Email Address: spynetgirl@outlook.com
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// See here for more information: https://github.com/HotCakeX/Harden-Windows-Security/blob/main/LICENSE
//

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AppControlManager.Others;

internal static partial class MeowParser
{

	// P/Invoke declaration to import the 'BCryptOpenAlgorithmProvider' function from 'bcrypt.dll'.
	// https://learn.microsoft.com/en-us/windows/win32/api/bcrypt/nf-bcrypt-bcryptopenalgorithmprovider
	[LibraryImport("bcrypt.dll", EntryPoint = "BCryptOpenAlgorithmProvider", SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static partial int BCryptOpenAlgorithmProvider(
	out IntPtr phAlgorithm, // Output parameter to receive the handle of the cryptographic algorithm.
	string pszAlgId, // The algorithm identifier (e.g., AES, SHA256, etc.).
	string? pszImplementation, // The implementation name (null for default).
	uint dwFlags); // Flags to control the function behavior.

	// P/Invoke declaration to import the 'BCryptCloseAlgorithmProvider' function from 'bcrypt.dll'.
	// Releases the algorithm handle acquired by 'BCryptOpenAlgorithmProvider'.
	// https://learn.microsoft.com/en-us/windows/win32/api/bcrypt/nf-bcrypt-bcryptclosealgorithmprovider
	[LibraryImport("bcrypt.dll", EntryPoint = "BCryptCloseAlgorithmProvider", SetLastError = true)]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static partial int BCryptCloseAlgorithmProvider(IntPtr hAlgorithm, uint dwFlags);

	// Defines a structure with sequential layout to match the native structure.
	// https://learn.microsoft.com/en-us/windows/win32/api/mscat/ns-mscat-cryptcatmember
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct MeowMemberCrypt
	{
		public uint StructureSize; // Size of the structure.
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Hashes; // The hashes associated with the catalog member.
		[MarshalAs(UnmanagedType.LPWStr)]
		public string FileName; // The file name of the catalog member.
		public Guid SubjectType; // The subject type GUID.
		public uint MemberFlags; // Flags associated with the member.
		public IntPtr IndirectDataStructure; // Pointer to the indirect data structure.
		public uint CertVersion; // The certificate version.
		private readonly uint Reserved1; // Reserved for future use.
		private readonly IntPtr Reserved2; // Reserved for future use.
	}


	/// <summary>
	/// A public static method that returns a HashSet of strings.
	/// </summary>
	/// <param name="SecurityCatalogFilePath"></param>
	/// <returns></returns>
	/// <exception cref="InvalidOperationException"></exception>
	internal static HashSet<string> GetHashes(string SecurityCatalogFilePath)
	{
		// Initializes a new HashSet to store the hashes.
		HashSet<string> OutputHashSet = [];

		IntPtr MainCryptProviderHandle = IntPtr.Zero; // Initializes the handle to zero.
		IntPtr MeowLogHandle = IntPtr.Zero; // Initializes the catalog context handle to zero.
		IntPtr KittyPointer = IntPtr.Zero; // Pointer to iterate through catalog members, initialized to zero.

		try
		{
			// Attempt to acquire a cryptographic context using the CNG API.
			int status = BCryptOpenAlgorithmProvider(out MainCryptProviderHandle, "SHA256", null, 0);

			if (status != 0)
			{
				// If the context is not acquired
				throw new InvalidOperationException($"BCryptOpenAlgorithmProvider failed with error code: {status}");
			}

			// Opens the catalog file and gets a handle to the catalog context.
			MeowLogHandle = WinTrust.CryptCATOpen(SecurityCatalogFilePath, 0, MainCryptProviderHandle, 0, 0);

			if (MeowLogHandle == IntPtr.Zero)
			{
				// If the handle is not obtained, capture the error code.
				int lastWin32Error = Marshal.GetLastWin32Error();
				Logger.Write($"CryptCATOpen failed with error code: {lastWin32Error}");
			}

			// Iterates through the catalog members.
			while ((KittyPointer = WinTrust.CryptCATEnumerateMember(MeowLogHandle, KittyPointer)) != IntPtr.Zero)
			{
				// Converts the pointer to a structure.
				MeowMemberCrypt member = Marshal.PtrToStructure<MeowMemberCrypt>(KittyPointer);

				// Adds the hashes to the HashSet.
				_ = OutputHashSet.Add(member.Hashes);
			}
		}
		finally
		{
			// Releases the cryptographic context and closes the catalog context in the finally block to ensure resources are freed.
			if (MainCryptProviderHandle != IntPtr.Zero)
			{
				// Attempt to close the algorithm provider handle.
				int closeStatus = BCryptCloseAlgorithmProvider(MainCryptProviderHandle, 0);

				// Check if the function succeeded by examining the NTSTATUS code.
				if (closeStatus != 0)
				{
					// Log the error if closing the handle failed.
					Logger.Write($"BCryptCloseAlgorithmProvider failed with error code: {closeStatus}");
				}
			}

			if (MeowLogHandle != IntPtr.Zero)
				_ = WinTrust.CryptCATClose(MeowLogHandle);
		}

		// Returns the HashSet containing the hashes.
		return OutputHashSet;
	}
}
