using System;

namespace EventTesting.Main
{
    public class PlugAndPlayEventArgs : EventArgs
    {
        public bool IsPluggedIn { get; }

        public PlugAndPlayEventArgs(bool isPluggedIn)
        {
            IsPluggedIn = isPluggedIn;
        }
    }

    public interface IDeviceDetectionClient
    {
        event EventHandler<PlugAndPlayEventArgs> PlugAndPlayEvent;
    }
}