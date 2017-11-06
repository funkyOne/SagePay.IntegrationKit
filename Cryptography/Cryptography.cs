using System;
using System.Security.Cryptography;
using System.IO;

namespace SagePay.IntegrationKit
{
    public class Cryptography
    {
        //** Wrapper function do encrypt an encode a message **
        public static string EncryptAndEncode(string strIn, string encryptionPassword)
        {
            //** AES encryption, CBC blocking with PKCS5 padding then HEX encoding - DEFAULT **
            return "@" + byteArrayToHexString(aesEncrypt(strIn, encryptionPassword));
        }

        //** Wrapper function do decode then decrypt based on header of the encrypted field **
        public static string DecodeAndDecrypt(string strIn, string encryptionPassword)
        {
            string functionReturnValue;
            if (strIn.Substring(0, 1) == "@")
            {
                //** HEX decoding then AES decryption, CBC blocking with PKCS5 padding - DEFAULT **
                functionReturnValue = aesDecrypt(hexStringToBytes(strIn.Substring(1)), encryptionPassword);
            } 
            else 
            {
                throw new Exception("Unable to Decrypt message");
            }

            return functionReturnValue;
        }

        /// <summary>
        /// Encrypts input string using Rijndael (AES) algorithm with CBC blocking and PKCS7 padding.
        /// </summary>
        /// <param name="inputText">text string to encrypt </param>
        /// <returns>Encrypted text in Byte array</returns>
        /// <remarks>The key and IV are the same, and use SagePaySettings.EncryptionPassword.</remarks>
        private static byte[] aesEncrypt(string inputText, string encryptionPassword)
        {

            RijndaelManaged AES = new RijndaelManaged();
            byte[] outBytes = null;

            //set the mode, padding and block size for the key
            AES.Padding = PaddingMode.PKCS7;
            AES.Mode = CipherMode.CBC;
            AES.KeySize = 128;
            AES.BlockSize = 128;

            //convert key and plain text input into byte arrays
			System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("iso-8859-1");
			byte[] keyAndIvBytes = encoding.GetBytes(encryptionPassword);
			byte[] inputBytes = encoding.GetBytes(inputText);

            //create streams and encryptor object
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, AES.CreateEncryptor(keyAndIvBytes, keyAndIvBytes), CryptoStreamMode.Write);

            //perform encryption
            cryptoStream.Write(inputBytes, 0, inputBytes.Length);
            cryptoStream.FlushFinalBlock();

            //get encrypted stream into byte array
            outBytes = memoryStream.ToArray();

            //close streams
            memoryStream.Close();
            cryptoStream.Close();
            AES.Clear();

            return outBytes;
        }

        /// <summary>
        /// Decrypts input string from Rijndael (AES) algorithm with CBC blocking and PKCS7 padding.
        /// </summary>
        /// <param name="inputBytes">Encrypted binary array to decrypt</param>
        /// <returns>string of Decrypted data</returns>
        /// <remarks>The key and IV are the same, and use SagePaySettings.EncryptionPassword.</remarks>
        private static string aesDecrypt(byte[] inputBytes, string encryptionPassword)
        {

            RijndaelManaged AES = new RijndaelManaged();
			System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("iso-8859-1");
			byte[] keyAndIvBytes = encoding.GetBytes(encryptionPassword);
			byte[] outputBytes = new byte[inputBytes.Length + 1];

            //set the mode, padding and block size
            AES.Padding = PaddingMode.PKCS7;
            AES.Mode = CipherMode.CBC;
            AES.KeySize = 128;
            AES.BlockSize = 128;

            //create streams and decryptor object
            var memoryStream = new MemoryStream(inputBytes);
            var cryptoStream = new CryptoStream(memoryStream, AES.CreateDecryptor(keyAndIvBytes, keyAndIvBytes), CryptoStreamMode.Read);

            //perform decryption
            cryptoStream.Read(outputBytes, 0, outputBytes.Length);

            //close streams
            memoryStream.Close();
            cryptoStream.Close();
            AES.Clear();

            //convert decryted data into string, assuming original text was UTF-8 encoded
			return encoding.GetString(outputBytes);

        }

        /// <summary>
        /// Converts a string of characters representing hexadecimal values into an array of bytes
        /// </summary>
        /// <param name="strInput">A hexadecimal string of characters to convert to binary.</param>
        /// <returns>A byte array</returns>
        public static byte[] hexStringToBytes(string strInput)
        {

            int numBytes = (strInput.Length / 2);
            byte[] bytes = new byte[numBytes];

            for (int x = 0; x <= numBytes - 1; x++)
            {
                bytes[x] = System.Convert.ToByte(strInput.Substring(x * 2, 2), 16);
            }

            return bytes;

        }

        /// <summary>
        /// Converts an array of bytes into a hexadecimal string representation.
        /// </summary>
        /// <param name="ba">Array of bytes to convert</param>
        /// <returns>String of hexadecimal values.</returns>
        public static string byteArrayToHexString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", "");
        }
    }
}