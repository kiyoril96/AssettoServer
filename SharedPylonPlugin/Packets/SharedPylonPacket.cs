using AssettoServer.Network.ClientMessages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SharedPylonPlugin.Packets;

[OnlineEvent(Key = "AS_ShardPylon")]

public class SharedPylonPacket : OnlineEvent<SharedPylonPacket>
{
    [OnlineEventField(Name = "position")]
    public Vector3 Position;
    [OnlineEventField(Name = "isphys")]
    public bool IsPhys ;
    [OnlineEventField(Name = "color")]
    public Vector4 Color;
}
