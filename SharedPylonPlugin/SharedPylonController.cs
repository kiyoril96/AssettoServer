using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace SharedPylonPlugin;


[ApiController]
[Route("/static/SharedPylonPlugin")]
public class SharedPylonController
{
    private static readonly string FlagsBasePath = Path.Join(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "wwwroot");

    [HttpGet("cone.zip")]
    public IActionResult GetConeModel()
    {
        return new PhysicalFileResult(Path.Join(FlagsBasePath, "cone.zip"), "application/octet-stream");
    }
}
