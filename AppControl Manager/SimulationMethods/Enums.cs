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

namespace AppControlManager.SimulationMethods;

internal static class Enums
{
	internal enum MatchLevel
	{
		AllowAllRule, // The policy is a black list, contains allow all rules
		FileHash, // The file is allowed by Authenticode/Page/Flat hash
		CatalogHash, // The file is allowed by Signer and file's signature is on the system in a security catalog
		FilePath, // The file is allowed by its path
		WHQLFilePublisher,
		WHQLPublisher,
		WHQL,
		SignedVersion,
		FilePublisher,
		Publisher,
		PcaCertificateOrRootCertificate,
		LeafCertificate,
		NoMatch // File is Not allowed

	}

	internal enum SpecificFileNamMatchLevel
	{
		OriginalFileName,
		InternalName,
		ProductName,
		FileDescription,
		PackageFamilyName,
		Version,
		NotApplicable
	}
}
