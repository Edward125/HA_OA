using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.IO;

namespace HA_OA
{
    class p
    {



        public static string DataBaseSeverName = "B9FC1ED2DC62F4BDF5497C3C96670804CE5138D6B86D3FE3";
        public static string DataBaseServerIP = "";
        public static string DataBase = "B9FC1ED2DC62F4BDB871E2DFAAC015A7";
        public static string DataBaseUid = "B9FC1ED2DC62F4BD165ABBC968B1E1FE";
        public static string DataBasePwd = "387F3D4BA2B3F17EB581D5A30D8437F3";

        public static string ConnStr = string.Empty;
        public static string dKey = "Edward86";

        public static LoginIDInfo LoginID;

        #region 枚举


        public enum IPType
        {
            IPV4,
            IPV6
        }




        #endregion


        public class LoginIDInfo
        {
            public string Name { set; get; }
            public string Password { set; get; }
            public string Department { set; get; }
            public int Permission { set; get; }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static  bool downLoadBodyFile(string filePath)
        {

            if (!File.Exists(filePath))
            {
                byte[] template = Properties.Resources.bodysample;
                FileStream stream = new FileStream(filePath, FileMode.Create);
                try
                {
                    stream.Write(template, 0, template.Length);
                    stream.Close();
                    stream.Dispose();
                    File.SetAttributes(filePath, FileAttributes.Hidden);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Create Tempalte Fail,Message:" + ex.Message);
                    return false;
                }

            }
            return true;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool downLoadFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                byte[] template = Properties.Resources.sample;
                FileStream stream = new FileStream(filePath, FileMode.Create);
                try
                {
                    stream.Write(template, 0, template.Length);
                    stream.Close();
                    stream.Dispose();
                    File.SetAttributes(filePath, FileAttributes.Hidden);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Create Tempalte Fail,Message:" + ex.Message);
                    return false;
                }

            }
            return true;
        }


        #region KillExcel
        public static  void KillExcel()
        {
            System.Diagnostics.Process[] excelProcess = System.Diagnostics.Process.GetProcessesByName("EXCEL");
            foreach (System.Diagnostics.Process p in excelProcess)
                p.Kill();
        }
        #endregion



        #region 获取IP

        /// <summary>
        /// 获取IP地址,本机IP地址hostname=dns.gethostname(),返回一个IP list
        /// </summary>
        /// <param name="hostname">hostname</param>
        /// <returns>返回一个字符串类型的ip list</returns>
        public static List<string> getIP(string hostname)
        {
            List<string> iplist = new List<string>();
            System.Net.IPAddress[] addressList = Dns.GetHostAddresses(hostname);//会返回所有地址，包括IPv4和IPv6   
            foreach (IPAddress ip in addressList)
            {
                iplist.Add(ip.ToString());
            }
            return iplist;
        }

        /// <summary>
        /// 获取IP地址,本机IP地址hostname=dns.gethostname(),返回一个IP list
        /// </summary>
        /// <param name="hostname">hostname</param>
        /// <param name="iptype">ip地址的类型，IPV4,IPV6</param>
        /// <returns>返回一个字符串类型的ip list</returns>
        public static List<string> getIP(string hostname, IPType iptype)
        {
            List<string> iplist = new List<string>();
            IPAddress[] addressList = Dns.GetHostAddresses(hostname);
            foreach (IPAddress ip in addressList)
            {
                if (iptype == IPType.IPV4)
                {
                    if (ip.ToString().Contains("."))
                        iplist.Add(ip.ToString());
                }
                if (iptype == IPType.IPV6)
                {
                    if (!ip.ToString().Contains("."))
                        iplist.Add(ip.ToString());
                }
            }
            return iplist;
        }

        #endregion






        #region MySql

        /// <summary>
        /// 从数据库中查询数据
        /// </summary>
        /// <param name="connstr"></param>
        /// <param name="sql"></param>
        /// <param name="querykey"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool QueryDatabase(string connstr, string sql, string querykey, out List<string> result)
        {
            result = new List<string>();
            MySqlConnection conn = new MySqlConnection(connstr);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader re = cmd.ExecuteReader();
                if (re.HasRows)
                {
                    while (re.Read())
                        result.Add(re[querykey].ToString());
                }

            }
            catch (Exception)
            {
                //  MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }

            return true;
        }


        /// <summary>
        /// 从数据库中查询数据
        /// </summary>
        /// <param name="connstr"></param>
        /// <param name="sql"></param>
        /// <param name="querykey"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool QueryDatabase(string connstr, string sql, string querykey, out string result)
        {
            result = string.Empty;
            MySqlConnection conn = new MySqlConnection(connstr);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader re = cmd.ExecuteReader();
                if (re.HasRows)
                {
                    while (re.Read())
                    {
                        result = re[querykey].ToString();
                    }
                }

            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                conn.Close();
            }

            return true;
        }





        /// <summary>
        /// 根据登陆的ID获取ID相关信息
        /// </summary>
        /// <param name="connstr"></param>
        /// <param name="sql"></param>
        /// <param name="userid"></param>
        /// <param name="loginid"></param>
        /// <returns></returns>
        public static bool LoadUserInfo(string connstr, string sql, string userid, out LoginIDInfo loginid)
        {
            loginid = new LoginIDInfo();
            loginid.Name = userid;
            MySqlConnection conn = new MySqlConnection(connstr);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader re = cmd.ExecuteReader();
                if (re.HasRows)
                {
                    while (re.Read())
                    {
                        loginid.Password = (string)re["password"];
                        loginid.Permission = (int)re["permission"];
                        loginid.Department = (string)re["depname"];

                    }
                }

            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                conn.Close();
            }


            return true;
        }




        /// <summary>
        /// 插入数据到数据库
        /// </summary>
        /// <param name="connstr"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool InsertDate2Database(string connstr, string sql, out string ex)
        {
            ex = string.Empty;
            MySqlConnection conn = new MySqlConnection(connstr);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();//执行 
            }
            catch (Exception e)
            {
                ex = e.Message;

                return false;
            }
            finally
            {
                conn.Close();
            }


            return true;
        }




        /// <summary>
        /// 查询记录条数
        /// </summary>
        /// <param name="connstr"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int queryCount(string connstr, string sql)
        {

            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            var i = cmd.ExecuteScalar();
            conn.Close();
            try
            {
                return Convert.ToInt16(i);
            }
            catch (Exception )
            {
                return 0;
            }

        }

        /// <summary>
        /// 查询总和数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static double querySum(string connstr, string sql)
        {

            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            var i = cmd.ExecuteScalar();
            conn.Close();
            try
            {
                return Convert.ToDouble(i);
            }
            catch (Exception )
            {
                return 0.0;
         }

        #endregion


        }
    }
}

    




