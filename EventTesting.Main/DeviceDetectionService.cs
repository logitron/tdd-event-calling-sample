using System;

namespace EventTesting.Main
{
    public class PlugAndPlayStringEventArgs : EventArgs
    {
        public string IsPluggedIn { get; }

        public PlugAndPlayStringEventArgs(string isPluggedIn)
        {
            IsPluggedIn = isPluggedIn;
        }
    }

    public class DeviceDetectionService
    {
        public event EventHandler<PlugAndPlayStringEventArgs> PlugAndPlayStringEvent;

        public DeviceDetectionService(IDeviceDetectionClient client)
        {
            client.PlugAndPlayEvent += OnPlugAndPlayEvent;
        }

        private void OnPlugAndPlayEvent(object sender, PlugAndPlayEventArgs e)
        {
            var data = e.IsPluggedIn ? "yes" : "no";
            PlugAndPlayStringEvent?.Invoke(this, new PlugAndPlayStringEventArgs(data));
        }
    }
}