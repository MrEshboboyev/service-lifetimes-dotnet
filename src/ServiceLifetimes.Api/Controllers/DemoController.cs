using Microsoft.AspNetCore.Mvc;
using ServiceLifetimes.Api.Interfaces;

namespace ServiceLifetimes.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DemoController(IServiceProvider serviceProvider) : ControllerBase
{
    private readonly IOperation _transientOperation = serviceProvider.GetRequiredService<IOperation>();
    private readonly IOperation _scopedOperation = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IOperation>();
    private readonly IOperation _singletonOperation = serviceProvider.GetService<IOperation>();

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            Transient = _transientOperation.OperationId,
            Scoped = _scopedOperation.OperationId,
            Singleton = _singletonOperation.OperationId
        });
    }
}
