using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using MySql.Data.MySqlClient;
using System.IO;

namespace ServerModel
{
    public class HostInfoHelper
    {
        private object CheckParameter(string para)
        {
            if (para == string.Empty || para == null)
            {
                return DBNull.Value;
            }
            return para;
        }

        public void UploadInfoToDB(HostInfo host)
        {
            string cmdString = @"insert into t_hostinfo (HostName,UserName,DomainName,IPAddress,HostSerial,OSVersion,SendTime) 
                                    values(@HostName,@UserName,@DomainName,@IPAddress,@HostSerial,@OSVersion,@SendTime) on duplicate key update 
                                    HostName=@HostName,UserName=@UserName,DomainName=@DomainName,IPAddress=@IPAddress,OSVersion=@OSVersion,SendTime=@SendTime";
            MySqlParameter[] paras = new MySqlParameter[]
                {
                    new MySqlParameter("@HostName",CheckParameter(host.HostName)),
                    new MySqlParameter("@UserName",CheckParameter(host.UserName)),
                    new MySqlParameter("@DomainName",CheckParameter(host.DomainName)),
                    new MySqlParameter("@IPAddress",CheckParameter(host.IPAddress)),
                    new MySqlParameter("@HostSerial",CheckParameter(host.HostSerial)),
                    new MySqlParameter("@OSVersion",CheckParameter(host.OSVersion)),
                    new MySqlParameter("@SendTime",CheckParameter(host.SendTime))
                };

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ServerConfig.DBConnectionString))
                {
                    conn.Open();
                    MySqlHelper.ExecuteNonQuery(conn, cmdString, paras);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
