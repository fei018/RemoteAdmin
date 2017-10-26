using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Common
{
    public class RASecurity
    {
        private string _password = "81DC9BDB52D04DC2036DBD8313ED055";

        public string Password { get; set; }

        public bool PasswordCheck(string password)
        {
            if (password == _password)
            {
                return true;
            }

            return false;
        }


        #region password to MD5 string
        private string PasswordEncrypt(string pass)
        {
            if (pass == null)
            {
                return null;
            }

            StringBuilder newpass = new StringBuilder();

            byte[] buffer = Encoding.UTF8.GetBytes(pass);

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bufferMD5 = md5.ComputeHash(buffer);
            foreach (byte b in bufferMD5)
            {
                newpass.Append(b.ToString("X"));
            }
            return newpass.ToString();
        }
        #endregion

        #region Regex Match
        private const string RegexChannelPort = @"^[0-9]|[1-9]\d{1,3}|[1-5]\d\d\d\d|[6][0-5][0-5][0-3][0-5]$"; //0 - 65535
        private const string RegexIPAddress = @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$"; //0.0.0.0 - 255.255.255.255

        public static bool IsChannelPort(string port)
        {
            if (port != null)
            {
                return Regex.IsMatch(port, RegexChannelPort);
            }
            return false;
        }

        public static bool IsIPAddress(string ip)
        {
            if (ip != null)
            {
                return Regex.IsMatch(ip, RegexIPAddress);
            }
            return false;
        }
        #endregion
    }
}
