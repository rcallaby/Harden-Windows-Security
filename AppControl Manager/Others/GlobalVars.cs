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
using System.IO;
using Microsoft.Windows.ApplicationModel.Resources;

namespace AppControlManager.Others;

// This class defines constants and other variables used by the entire application
internal static class GlobalVars
{
	// Instantiate the ResourceLoader object to access the strings in the Resource.resw file
	internal static readonly ResourceLoader Rizz = new();

	// User Mode block rules
	internal static readonly Uri MSFTRecommendedBlockRulesURL = new("https://raw.githubusercontent.com/MicrosoftDocs/windows-itpro-docs/refs/heads/public/windows/security/application-security/application-control/app-control-for-business/design/applications-that-can-bypass-appcontrol.md");

	// Kernel Mode block rules
	internal static readonly Uri MSFTRecommendedDriverBlockRulesURL = new("https://raw.githubusercontent.com/MicrosoftDocs/windows-itpro-docs/refs/heads/public/windows/security/application-security/application-control/app-control-for-business/design/microsoft-recommended-driver-block-rules.md");

	// Storing the path to the Code Integrity Schema XSD file
	internal static readonly string CISchemaPath = Path.Combine(
		Environment.GetEnvironmentVariable("SystemDrive") + @"\",
		"Windows", "schemas", "CodeIntegrity", "cipolicy.xsd");

	// Storing the path to the AppControl Manager folder in the Program Files
	internal static readonly string UserConfigDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "AppControl Manager");

	// Storing the path to User Config JSON file in the AppControl Manager folder in the Program Files
	internal static readonly string UserConfigJson = Path.Combine(UserConfigDir, "UserConfigurations", "UserConfigurations.json");

	// Storing the path to the StagingArea folder in the AppControl Manager folder in the Program Files
	internal static readonly string StagingArea = Path.Combine(UserConfigDir, "StagingArea");

	// The directory where the logs will be stored
	internal static readonly string LogsDirectory = Path.Combine(UserConfigDir, "Logs");

	// The link to the file that contains the download link for the latest version of the AppControl Manager
	internal static readonly Uri AppUpdateDownloadLinkURL = new("https://raw.githubusercontent.com/HotCakeX/Harden-Windows-Security/refs/heads/main/AppControl%20Manager/MSIXBundleDownloadURL.txt");

	// The link to the file that contains the version number of the latest available version of the AppControl Manager
	internal static readonly Uri AppVersionLinkURL = new("https://raw.githubusercontent.com/HotCakeX/Harden-Windows-Security/refs/heads/main/AppControl%20Manager/version.txt");

	// The check for update button on the Update page uses this variable as the text/content for its button
	// It is dynamically updated on app launch when a new version is available
	internal static string updateButtonTextOnTheUpdatePage = "Check for update";

	// Handle of the main Window - acquired in the MainWindow.xaml.cs
	internal static nint hWnd;

	// The filters for the file pickers dialogs to select files based on specific extensions
	internal const string XMLFilePickerFilter = "XML file|*.xml";
	internal const string AnyFilePickerFilter = "Any file (*.*)|*.*";
	internal const string ExecutablesPickerFilter = "Executable file|*.exe";
	internal const string CertificatePickerFilter = "Certificate file|*.cer";
	internal const string EVTXPickerFilter = "EVTX log file|*.evtx";

	// Name of the special automatic supplemental policy
	internal const string AppControlManagerSpecialPolicyName = "AppControlManagerSupplementalPolicy";

	// Path to the AppControlManagerSpecialPolicyName.xml file
	internal static readonly string AppControlManagerSpecialPolicyPath = Path.Combine(AppContext.BaseDirectory, "Resources", $"{AppControlManagerSpecialPolicyName}.xml");

	// Path to the ISGBasedSupplementalPolicy.xml file
	internal static readonly string ISGOnlySupplementalPolicyPath = Path.Combine(AppContext.BaseDirectory, "Resources", "ISGBasedSupplementalPolicy.xml");

	// Path to the empty policy file in app resources
	internal static readonly string EmptyPolicyPath = Path.Combine(AppContext.BaseDirectory, "Resources", "EmptyPolicy.xml");

	// Path to the PS Script that creates a scheduled task
	internal static readonly string DriversBlockListAutoUpdaterScheduledTaskScriptFilePath = Path.Combine(AppContext.BaseDirectory, "Resources", "DriversBlockListAutoUpdaterScheduledTask.ps1");

	// Path to the PS Script that creates a scheduled task for SnapBack guarantee in Allow New Apps page
	internal static readonly string SnapBackGuaranteeScheduledTaskScriptFilePath = Path.Combine(AppContext.BaseDirectory, "Resources", "SnapBackGuaranteeScheduledTask.ps1");

	// Get the current OS version
	private static readonly Version CurrentOSVersion = Environment.OSVersion.Version;

	// Version for the build 24H2
	private static readonly Version VersionFor24H2 = new(10, 0, 26100, 0);

	// Determine whether the current OS is older than 24H2
	internal static bool IsOlderThan24H2 => CurrentOSVersion < VersionFor24H2;

	// The namespace of the App Control policies
	internal const string SiPolicyNamespace = "urn:schemas-microsoft-com:sipolicy";

	// When the the list of installed packaged apps is retrieved, this URI is used whenever an installed app doesn't have a valid URI logo path
	internal const string FallBackAppLogoURI = "ms-appx:///Assets/StoreLogo.backup.png";

	static GlobalVars()
	{
		// Ensure the directory exists
		if (!Directory.Exists(UserConfigDir))
		{
			_ = Directory.CreateDirectory(UserConfigDir);
		}
	}
}
