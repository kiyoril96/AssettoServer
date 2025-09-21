using AssettoServer.Network.Tcp;
using AssettoServer.Server;
using AssettoServer.Server.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using SharedPylonPlugin.Packets;
using System.Reflection;


namespace SharedPylonPlugin;

public class SharedPylonPlugin : IHostedService
{
    private readonly EntryCarManager _entryCarManager;

    private List<SharedPylonPacket> pylonList;

    public SharedPylonPlugin(
        ACServerConfiguration serverConfiguration,
        CSPServerScriptProvider scriptProvider,
        CSPClientMessageTypeManager cspClientMessageTypeManager,
        EntryCarManager entryCarManager
        )
    {

        pylonList = [];
        _entryCarManager = entryCarManager;


        var luaPath = Path.Join(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "lua", "pylon.lua");
        Log.Debug("SharedPylonPlugin Test message");
        Log.Debug(luaPath);
        using var streamReader = new StreamReader(luaPath!);
        scriptProvider.AddScript(streamReader.ReadToEnd(), "pylon.lua");

        cspClientMessageTypeManager.RegisterOnlineEvent<SharedPylonPacket>(OnSharedPylonPacket);

    }

    private void OnSharedPylonPacket(ACTcpClient client, SharedPylonPacket packet)
    {
        if (client.IsAdministrator) {

            if (packet.Delete)
            {
                pylonList.Clear();
            }
            else {
                pylonList.Add(packet);
            }
            _entryCarManager.BroadcastPacket<SharedPylonPacket>(packet);
        }
    }

    public Task StartAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
