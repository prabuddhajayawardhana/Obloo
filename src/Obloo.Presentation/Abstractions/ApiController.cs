using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Obloo.Presentation.Abstractions;

[ApiController]
public abstract class ApiController(ISender sender) : ControllerBase
{
    protected readonly ISender sender = sender;
}
