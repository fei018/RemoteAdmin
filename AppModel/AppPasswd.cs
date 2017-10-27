using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AppModel
{
    public class AppPasswd
    {
        //private string _password = "81DC9BDB52D04DC2036DBD8313ED055";

        public bool ToCheck(string password)
        {
            AppConfig config = new AppConfig();         
            if (this.ToMD5(password) == config.Password) return true;
            return false;
        }

        #region password to MD5 string
        private string ToMD5(string passwd)
        {
            StringBuilder newpass = new StringBuilder();

            byte[] buffer = Encoding.UTF8.GetBytes(passwd);

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bufferMD5 = md5.ComputeHash(buffer);
            foreach (byte b in bufferMD5)
            {
                newpass.Append(b.ToString("X"));
            }
            return newpass.ToString();
        }
        #endregion
    }
}
