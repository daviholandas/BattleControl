using BattleControl.Core.Models;
using Xunit;

namespace BattleControl.Tests
{
    public class ClientModelTests
    {
        [Fact]
        public void Client_WhenCreatingClientMustReturnMachineName()
        {
            //Arrange
            var client = new ClientMachineInfo();
            //Act
            var clientMachineName = "Localhost";
            var name = client.Name;
            //Assert
            Assert.NotEqual(name, clientMachineName);
        }

        [Fact]
        public void Client_WhenCreatingClientMustReturnIPAddress()
        {
            //Arrange
            var client = new ClientMachineInfo();
            //Act
            var ipLocal = "192.168.88.150";
            var clientIP = client.IP;
            //Assert
            Assert.Equal(ipLocal, clientIP);
        }

        [Fact]
        public void Client_WhenCreatingClientMustReturnAntiVirusName()
        {
            //Arrange
            var client = new ClientMachineInfo();
            //Act
            var avLocal = "Avast";
            var clientAV = client.AntiVirusName;
            //Assert
            Assert.NotEqual(avLocal, clientAV);
        }

        [Fact]
        public void Client_WhenCreatingClientMustReturnOSVersion()
        {
            //Arrange
            var client = new ClientMachineInfo();
            //Act
            var osVersion = "Windows 10";
            var clientOSVersion = client.OSVersion;
            //Assert
            Assert.NotEqual(osVersion, clientOSVersion);
        }

        [Fact]
        public void Client_WhenCreatingClientMustReturnDotNetVersion()
        {
            //Arrange
            var client = new ClientMachineInfo();
            //Act
            var dotnetVersion = "3.1.200";
            var clientDotnetVersion = client.DotnetVersion;
            //Assert
            Assert.NotEqual(dotnetVersion, clientDotnetVersion);
        }

        [Fact]
        public void Client_WhenCreatingClientMustReturnHDInformation()
        {
            //Arrange
            var client = new ClientMachineInfo();
            //Act
            var freeSpace = client.HardDiskInfo["C-FreeSpace"];
            var totalSize = client.HardDiskInfo["C-TotalSize"];
            //Assert
            Assert.NotEqual(0, freeSpace);
            Assert.NotEqual(0, totalSize);
        }
    }
}