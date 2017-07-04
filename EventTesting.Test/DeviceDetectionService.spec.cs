using System;
using EventTesting.Main;
using Moq;
using Xunit;

namespace EventTesting.Test
{
    public class DeviceDetectionService_Spec
    {
        [Fact]
        public void Raises_PlugAndPlayStringEvent_With_Yes()
        {
            var mockClient = new Mock<IDeviceDetectionClient>();
            var service = new DeviceDetectionService(mockClient.Object);

            string plugAndPlayStringEventArg = null;
            service.PlugAndPlayStringEvent += (s, e) =>
            {
                plugAndPlayStringEventArg = e.IsPluggedIn;
            };

            mockClient.Raise(c => c.PlugAndPlayEvent += null, new PlugAndPlayEventArgs(true));

            Assert.Equal("yes", plugAndPlayStringEventArg);
        }

        [Fact]
        public void Raises_PlugAndPlayStringEvent_With_No()
        {
            var mockClient = new Mock<IDeviceDetectionClient>();
            var service = new DeviceDetectionService(mockClient.Object);

            string plugAndPlayStringEventArg = null;
            service.PlugAndPlayStringEvent += (s, e) =>
            {
                plugAndPlayStringEventArg = e.IsPluggedIn;
            };

            mockClient.Raise(c => c.PlugAndPlayEvent += null, new PlugAndPlayEventArgs(false));

            Assert.Equal("no", plugAndPlayStringEventArg);
        }
    }
}
