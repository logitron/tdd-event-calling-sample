using System;
using EventTesting.Main;
using Moq;
using Xunit;

namespace EventTesting.Test
{
    public class DeviceDetectionClient_Spec
    {
        [Fact]
        public void Raises_PlugAndPlayEvent()
        {
            var mock = new Mock<IDeviceDetectionClient>();
            mock.Raise(m => m.PlugAndPlayEvent += null, new PlugAndPlayEventArgs(true));
        }
    }
}
