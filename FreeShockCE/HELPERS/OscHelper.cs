using System.Net;
using FastOSC;

namespace FreeShockCE.HELPERS;

public static class OscHelper
{
    private static readonly OSCReceiver Receiver = new();
    public static void StartOscListener()
    {
        Receiver.Connect(new IPEndPoint(IPAddress.Loopback, 9001));
    }
}