using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace HA_OA
{
    class p
    {



        public static string DataBaseSeverName = "";
        public static string DataBaseServerIP = "B9FC1ED2DC62F4BDF5497C3C96670804CE5138D6B86D3FE3";
        public static string DataBase = "B9FC1ED2DC62F4BDB871E2DFAAC015A7";
        public static string DataBaseUid = "B9FC1ED2DC62F4BD165ABBC968B1E1FE";
        public static string DataBasePwd = "387F3D4BA2B3F17EB581D5A30D8437F3";


        #region 枚举


        public enum IPType
        {
            IPV4,
            IPV6
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
                if (iptype  == IPType.IPV4) 
                {
                    if (ip.ToString().Contains("."))
                        iplist.Add(ip.ToString());
                }
                if (iptype == IPType.IPV6 )
                {
                    if (!ip.ToString().Contains("."))
                        iplist.Add(ip.ToString());
                }
            }
            return iplist;
        }

        #endregion
    }




}
