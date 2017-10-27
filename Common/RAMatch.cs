using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Common
{
    public class RAMatch
    {
        #region Regex Match
        private const string RegexChannelPort = @"^([0-9]|[1-9]\d|[1-9]\d{2}|[1-9]\d{3}|[1-5]\d{4}|6[0-4]\d{3}|65[0-4]\d{2}|655[0-2]\d|6553[0-5])$"; //0 - 65535
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
