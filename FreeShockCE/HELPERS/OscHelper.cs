using System.Net;
using System.Net.Sockets;
using FastOSC;

namespace FreeShockCE.HELPERS;

public static class OscHelper
{
    public static OSCReceiver Receiver = new();
    public static void StartOscListener()
    {
        Receiver.Connect(new IPEndPoint(IPAddress.Loopback, 9001));
    }
}