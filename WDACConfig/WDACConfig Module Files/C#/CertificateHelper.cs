using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Formats.Asn1; // to use the AsnReader and AsnWriter classes

namespace WDACConfig
{
    // a class to throw a custom exception when the certificate collection cannot be obtained during WDAC Simulation
    public class ExceptionFailedToGetCertificateCollection : Exception
    {
        public ExceptionFailedToGetCertificateCollection(string message, string functionName)
            : base($"{functionName}: {message}")
        {
        }
    }

    public class CertificateHelper
    {
        public static string GetTBSCertificate(X509Certificate2 cert)
        // Calculates the TBS value of a certificate
        {
            // Get the raw data of the certificate
            byte[] rawData = cert.RawData;

            // Create an ASN.1 reader to parse the certificate
            AsnReader asnReader = new AsnReader(rawData, AsnEncodingRules.DER);

            // Read the certificate sequence
            AsnReader certificate = asnReader.ReadSequence();

            // Read the TBS (To be signed) value of the certificate
            ReadOnlyMemory<byte> tbsCertificate = certificate.ReadEncodedValue();

            // Read the signature algorithm sequence
            AsnReader signatureAlgorithm = certificate.ReadSequence();

            // Read the algorithm OID of the signature
            string algorithmOid = signatureAlgorithm.ReadObjectIdentifier();

            // Define a hash function based on the algorithm OID
            HashAlgorithm hashFunction;
            switch (algorithmOid)
            {
                case "1.2.840.113549.1.1.4":
                    hashFunction = MD5.Create();
                    break;
                case "1.2.840.113549.1.1.5":
                case "1.3.14.3.2.29": //sha-1WithRSAEncryption
                    hashFunction = SHA1.Create();
                    break;
                case "1.2.840.113549.1.1.11":
                    hashFunction = SHA256.Create();
                    break;
                case "1.2.840.113549.1.1.12":
                    hashFunction = SHA384.Create();
                    break;
                case "1.2.840.113549.1.1.13":
                    hashFunction = SHA512.Create();
                    break;
                // These are less likely to be used since ConfigCI doesn't support their OIDs
                case "1.2.840.10040.4.3":
                    hashFunction = SHA1.Create();
                    break;
                case "2.16.840.1.101.3.4.3.2":
                    hashFunction = SHA256.Create();
                    break;
                case "2.16.840.1.101.3.4.3.3":
                    hashFunction = SHA384.Create();
                    break;
                case "2.16.840.1.101.3.4.3.4":
                    hashFunction = SHA512.Create();
                    break;
                case "1.2.840.10045.4.1":
                    hashFunction = SHA1.Create();
                    break;
                case "1.2.840.10045.4.3.2":
                    hashFunction = SHA256.Create();
                    break;
                case "1.2.840.10045.4.3.3":
                    hashFunction = SHA384.Create();
                    break;
                case "1.2.840.10045.4.3.4":
                    hashFunction = SHA512.Create();
                    break;
                default:
                    throw new Exception($"No handler for algorithm {algorithmOid}");
            }

            // Compute the hash of the TBS value using the hash function
            byte[] hash = hashFunction.ComputeHash(tbsCertificate.ToArray());

            // Convert the hash to a hex string
            string hexStringOutput = BitConverter.ToString(hash).Replace("-", "");

            return hexStringOutput;
        }

        public static string ConvertHexToOID(string hex)
        // Converts a hexadecimal string to an OID
        // Used for converting hexadecimal values found in the EKU sections of the WDAC policies to their respective OIDs.

        {
            if (string.IsNullOrEmpty(hex))
            {
                throw new ArgumentException("Hex string cannot be null or empty", nameof(hex));
            }

            // Convert the hexadecimal string to a byte array by looping through the string in pairs of two characters
            // and converting each pair to a byte using the base 16 (hexadecimal) system
            byte[] numArray = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length; i += 2)
            {
                numArray[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }

            // Change the first byte from 1 to 6 because the hexadecimal string is missing the tag and length bytes
            // that are required for the ASN.1 encoding of an OID
            // The tag byte indicates the type of the data, and for an OID it is 6
            // The length byte indicates the number of bytes that follow the tag byte
            // and for this example it is 10 (0A in hexadecimal)
            numArray[0] = 6;

            // Create an AsnReader object with the default encoding rules
            // This is a class that can read the ASN.1 BER, CER, and DER data formats
            // BER (Basic Encoding Rules) is the most flexible and widely used encoding rule
            // CER (Canonical Encoding Rules) is a subset of BER that ensures a unique encoding
            // DER (Distinguished Encoding Rules) is a subset of CER that ensures a deterministic encoding
            // The AsnReader object takes the byte array as input and the encoding rule as an argument
            AsnReader asnReader = new AsnReader(numArray, AsnEncodingRules.BER);

            // Read the OID as an ObjectIdentifier
            // This is a method of the AsnReader class that returns the OID as a string
            // The first two numbers are derived from the first byte of the encoded data
            // The rest of the numbers are derived from the subsequent bytes using a base 128 (variable-length) system
            string oid = asnReader.ReadObjectIdentifier();

            // Return the OID value as string
            return oid;
        }

        public static X509Certificate2Collection GetSignedFileCertificates(string filePath, X509Certificate2 x509Certificate2 = null)
        // gets all the certificates from a signed file or a certificate object and output a Collection
        {
            // Create an X509Certificate2Collection object
            X509Certificate2Collection certCollection = new X509Certificate2Collection();

            // If the FilePath parameter is used, import all the certificates from the files
            if (!string.IsNullOrEmpty(filePath))
            {
                try
                {
                    // If the FilePath parameter is used, import all the certificates from the file
                    certCollection.Import(filePath);
                }
                catch (Exception)
                {
                    // Throw a custom exception that will be caught by Invoke-WDACPolicySimulation cmdlets
                    throw new ExceptionFailedToGetCertificateCollection("Could not get the certificate collection of the file due to lack of necessary permissions.", "GetSignedFileCertificates");
                }
            }
            // If the CertObject parameter is used, add the certificate object to the collection
            else if (x509Certificate2 != null)
            {
                certCollection.Add(x509Certificate2);
            }

            return certCollection;
        }
    }
}
