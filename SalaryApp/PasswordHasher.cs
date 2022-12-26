using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System;
using System.Text;
using System.IO;
using System.Web.Security;

namespace SalaryApp
{
    public class Hasher
    {
        static string secretKey = "amogus228";

        [Obsolete]
        public static string Encrypt(string targetValue)
        {
            if (string.IsNullOrEmpty(targetValue))
            {
                return string.Empty;
            }

            var returnValue = new StringBuilder();
            var des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.Default.GetBytes(targetValue);
            // Устанавливаем вектор инициализации симметричного алгоритма, дважды хешируя пароль   
            des.Key = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile
                                                    (FormsAuthentication.HashPasswordForStoringInConfigFile(secretKey, "md5").
                                                        Substring(0, 8), "sha1").Substring(0, 8));
            // Устанавливаем секретный ключ алгоритма, дважды хешируя пароль   
            des.IV = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile
                                                    (FormsAuthentication.HashPasswordForStoringInConfigFile(secretKey, "md5")
                                                        .Substring(0, 8), "md5").Substring(0, 8));
            var ms = new MemoryStream();
            var cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            foreach (byte b in ms.ToArray())
            {
                returnValue.AppendFormat("{0:X2}", b);
            }
            return returnValue.ToString();
        }

        [Obsolete]
        public static string Decrypt(string targetValue)
        {
            if (string.IsNullOrEmpty(targetValue))
            {
                return string.Empty;
            }
            // Определить объект шифрования DES
            var des = new DESCryptoServiceProvider();
            int len = targetValue.Length / 2;
            var inputByteArray = new byte[len];
            int x, i;
            for (x = 0; x < len; x++)
            {
                i = Convert.ToInt32(targetValue.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }
            // Устанавливаем вектор инициализации симметричного алгоритма, дважды хешируя пароль   
            des.Key = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile
                                                    (FormsAuthentication.HashPasswordForStoringInConfigFile(secretKey, "md5").
                                                        Substring(0, 8), "sha1").Substring(0, 8));
            // Устанавливаем секретный ключ алгоритма, дважды хешируя пароль   
            des.IV = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile
                                                    (FormsAuthentication.HashPasswordForStoringInConfigFile(secretKey, "md5")
                                                        .Substring(0, 8), "md5").Substring(0, 8));
            // Определяем поток памяти
            var ms = new MemoryStream();
            // Определяем зашифрованный поток
            var cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.Default.GetString(ms.ToArray());
        }
    }
}