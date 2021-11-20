using Acme.Ports.Manager.Core.Ports;
using Acme.Ports.Manager.Core.Ships;
using Xunit;

namespace Acme.Ports.Manager.Tests.Core.Models
{
    public class PortTest
    {
        [Fact]
        public void PortsShouldBeEquals()
        {
            const string namePort = "Port of Shangai";
            var expectedPort = Port.Create(namePort);

            var newPort = expectedPort;
            
            Assert.True(expectedPort == newPort);
        }
        
        [Fact]
        public void PortsShouldNotBeEquals()
        {
            var expectedPort = Port.Create("Shangai");

            var newPort = Port.Create("London");
            
            Assert.False(expectedPort == newPort);
        }

        [Fact]
        public void DockShipSuccessfully()
        {
            var port = Port.Create("Shangai");
            var ship = Ship.Create("Mary Berling");
            
            port.DockShip(ship);

            Assert.Collection(port.DockedShips, dockerShip => Assert.Equal(dockerShip, ship));
        }
        
        [Fact]
        public void ShouldOnlyOneShipWhenDockedSameShipTwice()
        {
            var port = Port.Create("Shangai");
            var ship = Ship.Create("Mary Berling");
            
            port.DockShip(ship);
            port.DockShip(ship);

            Assert.Single(port.DockedShips);
        }
    }
}