using AssettoServer.Network.ClientMessages;
using System.Numerics;

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

    [OnlineEventField(Name = "delete")]
    public bool Delete;
}
