# $PSDefaultParameterValues only get read from scope where invocation occurs
# This is why this file is dot-sourced in every other component of the WDACConfig module at the beginning
$PSDefaultParameterValues = @{
    'Invoke-WebRequest:HttpVersion'        = '3.0'
    'Invoke-WebRequest:SslProtocol'        = 'Tls12,Tls13'
    'Invoke-RestMethod:HttpVersion'        = '3.0'
    'Invoke-RestMethod:SslProtocol'        = 'Tls12,Tls13'
    'Import-Module:Verbose'                = $false
    'Remove-Module:Verbose'                = $false
    'Export-ModuleMember:Verbose'          = $false
    'Add-Type:Verbose'                     = $false
    'Get-WinEvent:Verbose'                 = $false
    'Test-Path:ErrorAction'                = 'SilentlyContinue'
    'Confirm-CertCN:Verbose'               = $Verbose
    'Receive-CodeIntegrityLogs:Verbose'    = $Verbose
    'Get-FileRules:Verbose'                = $Verbose
    'Get-BlockRulesMeta:Verbose'           = $Verbose
    'Get-GlobalRootDrives:Verbose'         = $Verbose
    'Get-RuleRefs:Verbose'                 = $Verbose
    'Get-SignTool:Verbose'                 = $Verbose
    'Move-UserModeToKernelMode:Verbose'    = $Verbose
    'New-EmptyPolicy:Verbose'              = $Verbose
    'Set-LogSize:Verbose'                  = $Verbose
    'Test-FilePath:Verbose'                = $Verbose
    'Update-self:Verbose'                  = $Verbose
    'Write-ColorfulText:Verbose'           = $Verbose
    'New-SnapBackGuarantee:Verbose'        = $Verbose
    'Compare-SecureStrings:Verbose'        = $Verbose
    'Get-KernelModeDriversAudit:Verbose'   = $Verbose
    'Copy-CiRules:Verbose'                 = $Verbose
    'Get-TBSCertificate:Verbose'           = $Verbose
    'Get-SignerInfo:Verbose'               = $Verbose
    'Get-SignedFileCertificates:Verbose'   = $Verbose
    'Get-FileRuleOutput:Verbose'           = $Verbose
    'Get-CertificateDetails:Verbose'       = $Verbose
    'Get-NestedSignerSignature:Verbose'    = $Verbose
    'Compare-SignerAndCertificate:Verbose' = $Verbose
    'Remove-SupplementalSigners:Verbose'   = $Verbose
    'Get-ExtendedFileInfo:Verbose'         = $Verbose
    'Edit-CiPolicyRuleOptions:Verbose'     = $Verbose
    'New-AppxPackageCiPolicy:Verbose'      = $Verbose
}

# SIG # Begin signature block
# MIILkgYJKoZIhvcNAQcCoIILgzCCC38CAQExDzANBglghkgBZQMEAgEFADB5Bgor
# BgEEAYI3AgEEoGswaTA0BgorBgEEAYI3AgEeMCYCAwEAAAQQH8w7YFlLCE63JNLG
# KX7zUQIBAAIBAAIBAAIBAAIBADAxMA0GCWCGSAFlAwQCAQUABCB40mNe78ZCks9A
# jVDb72anJFOc7puuU2eOQ9Iy7l48qKCCB9AwggfMMIIFtKADAgECAhMeAAAABI80
# LDQz/68TAAAAAAAEMA0GCSqGSIb3DQEBDQUAME8xEzARBgoJkiaJk/IsZAEZFgNj
# b20xIjAgBgoJkiaJk/IsZAEZFhJIT1RDQUtFWC1DQS1Eb21haW4xFDASBgNVBAMT
# C0hPVENBS0VYLUNBMCAXDTIzMTIyNzExMjkyOVoYDzIyMDgxMTEyMTEyOTI5WjB5
# MQswCQYDVQQGEwJVSzEeMBwGA1UEAxMVSG90Q2FrZVggQ29kZSBTaWduaW5nMSMw
# IQYJKoZIhvcNAQkBFhRob3RjYWtleEBvdXRsb29rLmNvbTElMCMGCSqGSIb3DQEJ
# ARYWU3B5bmV0Z2lybEBvdXRsb29rLmNvbTCCAiIwDQYJKoZIhvcNAQEBBQADggIP
# ADCCAgoCggIBAKb1BJzTrpu1ERiwr7ivp0UuJ1GmNmmZ65eckLpGSF+2r22+7Tgm
# pEifj9NhPw0X60F9HhdSM+2XeuikmaNMvq8XRDUFoenv9P1ZU1wli5WTKHJ5ayDW
# k2NP22G9IPRnIpizkHkQnCwctx0AFJx1qvvd+EFlG6ihM0fKGG+DwMaFqsKCGh+M
# rb1bKKtY7UEnEVAsVi7KYGkkH+ukhyFUAdUbh/3ZjO0xWPYpkf/1ldvGes6pjK6P
# US2PHbe6ukiupqYYG3I5Ad0e20uQfZbz9vMSTiwslLhmsST0XAesEvi+SJYz2xAQ
# x2O4n/PxMRxZ3m5Q0WQxLTGFGjB2Bl+B+QPBzbpwb9JC77zgA8J2ncP2biEguSRJ
# e56Ezx6YpSoRv4d1jS3tpRL+ZFm8yv6We+hodE++0tLsfpUq42Guy3MrGQ2kTIRo
# 7TGLOLpayR8tYmnF0XEHaBiVl7u/Szr7kmOe/CfRG8IZl6UX+/66OqZeyJ12Q3m2
# fe7ZWnpWT5sVp2sJmiuGb3atFXBWKcwNumNuy4JecjQE+7NF8rfIv94NxbBV/WSM
# pKf6Yv9OgzkjY1nRdIS1FBHa88RR55+7Ikh4FIGPBTAibiCEJMc79+b8cdsQGOo4
# ymgbKjGeoRNjtegZ7XE/3TUywBBFMf8NfcjF8REs/HIl7u2RHwRaUTJdAgMBAAGj
# ggJzMIICbzA8BgkrBgEEAYI3FQcELzAtBiUrBgEEAYI3FQiG7sUghM++I4HxhQSF
# hqV1htyhDXuG5sF2wOlDAgFkAgEIMBMGA1UdJQQMMAoGCCsGAQUFBwMDMA4GA1Ud
# DwEB/wQEAwIHgDAMBgNVHRMBAf8EAjAAMBsGCSsGAQQBgjcVCgQOMAwwCgYIKwYB
# BQUHAwMwHQYDVR0OBBYEFOlnnQDHNUpYoPqECFP6JAqGDFM6MB8GA1UdIwQYMBaA
# FICT0Mhz5MfqMIi7Xax90DRKYJLSMIHUBgNVHR8EgcwwgckwgcaggcOggcCGgb1s
# ZGFwOi8vL0NOPUhPVENBS0VYLUNBLENOPUhvdENha2VYLENOPUNEUCxDTj1QdWJs
# aWMlMjBLZXklMjBTZXJ2aWNlcyxDTj1TZXJ2aWNlcyxDTj1Db25maWd1cmF0aW9u
# LERDPU5vbkV4aXN0ZW50RG9tYWluLERDPWNvbT9jZXJ0aWZpY2F0ZVJldm9jYXRp
# b25MaXN0P2Jhc2U/b2JqZWN0Q2xhc3M9Y1JMRGlzdHJpYnV0aW9uUG9pbnQwgccG
# CCsGAQUFBwEBBIG6MIG3MIG0BggrBgEFBQcwAoaBp2xkYXA6Ly8vQ049SE9UQ0FL
# RVgtQ0EsQ049QUlBLENOPVB1YmxpYyUyMEtleSUyMFNlcnZpY2VzLENOPVNlcnZp
# Y2VzLENOPUNvbmZpZ3VyYXRpb24sREM9Tm9uRXhpc3RlbnREb21haW4sREM9Y29t
# P2NBQ2VydGlmaWNhdGU/YmFzZT9vYmplY3RDbGFzcz1jZXJ0aWZpY2F0aW9uQXV0
# aG9yaXR5MA0GCSqGSIb3DQEBDQUAA4ICAQA7JI76Ixy113wNjiJmJmPKfnn7brVI
# IyA3ZudXCheqWTYPyYnwzhCSzKJLejGNAsMlXwoYgXQBBmMiSI4Zv4UhTNc4Umqx
# pZSpqV+3FRFQHOG/X6NMHuFa2z7T2pdj+QJuH5TgPayKAJc+Kbg4C7edL6YoePRu
# HoEhoRffiabEP/yDtZWMa6WFqBsfgiLMlo7DfuhRJ0eRqvJ6+czOVU2bxvESMQVo
# bvFTNDlEcUzBM7QxbnsDyGpoJZTx6M3cUkEazuliPAw3IW1vJn8SR1jFBukKcjWn
# aau+/BE9w77GFz1RbIfH3hJ/CUA0wCavxWcbAHz1YoPTAz6EKjIc5PcHpDO+n8Fh
# t3ULwVjWPMoZzU589IXi+2Ol0IUWAdoQJr/Llhub3SNKZ3LlMUPNt+tXAs/vcUl0
# 7+Dp5FpUARE2gMYA/XxfU9T6Q3pX3/NRP/ojO9m0JrKv/KMc9sCGmV9sDygCOosU
# 5yGS4Ze/DJw6QR7xT9lMiWsfgL96Qcw4lfu1+5iLr0dnDFsGowGTKPGI0EvzK7H+
# DuFRg+Fyhn40dOUl8fVDqYHuZJRoWJxCsyobVkrX4rA6xUTswl7xYPYWz88WZDoY
# gI8AwuRkzJyUEA07IYtsbFCYrcUzIHME4uf8jsJhCmb0va1G2WrWuyasv3K/G8Nn
# f60MsDbDH1mLtzGCAxgwggMUAgEBMGYwTzETMBEGCgmSJomT8ixkARkWA2NvbTEi
# MCAGCgmSJomT8ixkARkWEkhPVENBS0VYLUNBLURvbWFpbjEUMBIGA1UEAxMLSE9U
# Q0FLRVgtQ0ECEx4AAAAEjzQsNDP/rxMAAAAAAAQwDQYJYIZIAWUDBAIBBQCggYQw
# GAYKKwYBBAGCNwIBDDEKMAigAoAAoQKAADAZBgkqhkiG9w0BCQMxDAYKKwYBBAGC
# NwIBBDAcBgorBgEEAYI3AgELMQ4wDAYKKwYBBAGCNwIBFTAvBgkqhkiG9w0BCQQx
# IgQgLtZEjG4Hir5Ov+LjjyCq1LGLmduAy96YK/LU/IwY7XMwDQYJKoZIhvcNAQEB
# BQAEggIATyfVp/q41XdPAyWApvLvKtK6RKAcYMgPltPUMm/uVwu40IOh0GMVJM37
# VbrC3iBiEYMqyEaHRKOw96oPsdFP85q7y1AuzvmFzib7yYuoBj1A809BC/H3BmgX
# Krn6/JYflZXGNRrT2Tev4z1JTCOkq0fwUeZClHRzxAz0j7lP5wxKjIpZ77KB4Bx8
# i7gahZXczJtyqMW3FOLX24xk5mf0e89jdP+4bUYdx31oThqiPkOL2ntiBrZfONtC
# IcUKGbaoQY7C74yMs95ymIjPk9uZO7ZLGPnggWhm3sQPZolpkpgZpNPdqtBTF/aC
# OQ1Y7fRrEkpL/M0X36Rf7WNOTtto1RqL7/o2yOfxOfsezErC0+XJMx2cP1TJha0J
# nKAC5/l2gggCp/7NlBeMySdFtP/PAInorESKj0cysSxfZFLSYqm4ipn5kdni/fOQ
# Zf9F7ui9DyD6ompr3+javpkcUYJxB5LWQcFoWBq9T1kL/Zer7g5pwXtOZMsA1W2w
# Ib22wnYUQA2Q5wvDVCcOkfMAXduv8pnEphVEmaCQOvWfUiOXZviZz5GI2Bwjww8k
# XnlrC1JdV0N7dOLlbpv4zzDD2MvdaRke1+SrFFljR4m78QwhTcLCLl26aj8TSWhn
# //EAS3pO2i6lg5CfWRL8tLJ0wsKMzeM1aJIRkNHtonOmwcp756c=
# SIG # End signature block
