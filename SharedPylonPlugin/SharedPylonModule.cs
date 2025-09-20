using AssettoServer.Server.Plugin;
using Autofac;
using Microsoft.Extensions.Hosting;

namespace SharedPylonPlugin;

public class SharedPylonModule : AssettoServerModule
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<SharedPylonPlugin>().AsSelf().As<IHostedService>().SingleInstance();
    }
}
