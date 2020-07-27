using System;
using System.Collections.Generic;
using System.IO;
using System.Management;
using System.Net;
using System.Net.Sockets;

namespace BattleControl.Core.Models
{
    public class ClientMachineInfo : Entity
    {
        public string Name => Dns.GetHostName();

        public string IP
        {
            get
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                        return ip.ToString();
                }

                return "";
            }
        }

        public string AntiVirusName
        {
            get
            {
                var wmipathstr = @"\\" + Environment.MachineName + @"\root\SecurityCenter2";
                try
                {
                    var avName = "";
                    var searcher = new ManagementObjectSearcher(wmipathstr, "SELECT * FROM AntivirusProduct");
                    ManagementObjectCollection instances = searcher.Get();
                    foreach (var virusChecker in instances)
                    {
                        avName = virusChecker["displayName"].ToString();
                    }

                    return avName;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return "";
                }
            }
        }

        public string OSVersion => Environment.OSVersion.VersionString;

        public string DotnetVersion => Environment.Version.ToString();

        public Dictionary<string, long> HardDiskInfo
        {
            get
            {
                var drives = new Dictionary<string, long>();
                foreach (var drive in DriveInfo.GetDrives())
                {
                    if (drive.IsReady)
                    {
                        drives.Add($"{drive.Name.Substring(0, 1)}-TotalSize", drive.TotalSize);
                        drives.Add($"{drive.Name.Substring(0, 1)}-FreeSpace", drive.TotalFreeSpace);
                    }
                }

                return drives;
            }
        }
    }
}