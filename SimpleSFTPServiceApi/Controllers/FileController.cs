using Microsoft.AspNetCore.Mvc;
using SimpleSFTPServiceApi.Services;

namespace SimpleSFTPServiceApi.Controllers;

[Route("file")]
[ApiController]
public class FileController(SftpService sftpService) : ControllerBase
{
    [HttpPost("connect")]
    public async Task<IActionResult> Connect()
    {
        var isConnect = await sftpService.IsConnected();

        if (isConnect)
            return Ok();
        return Problem();
    }
}