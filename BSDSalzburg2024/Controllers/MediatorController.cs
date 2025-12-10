namespace BSDSalzburg2024.Controllers;

using System;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

[Route("api/[controller]")]
[ApiController]
public class MediatorController
    : ControllerBase
{
    private readonly IMediator mediator;

    public MediatorController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("requestresponse")]
    public async Task<IActionResult> RequestWithResponse(string type, string request)
    {
        var requestJson = Encoding.UTF8.GetString(Convert.FromBase64String(request));
        var typeName = Encoding.UTF8.GetString(Convert.FromBase64String(type));
        var typeObject = Type.GetType(typeName);
        var query = JsonConvert.DeserializeObject(requestJson, typeObject);

        try
        {
            var response = await this.mediator.Send(query);
            var responseJson = JsonConvert.SerializeObject(response);
            return this.Ok(responseJson);
        }
        catch (ValidationException exception)
        {
            return this.BadRequest(JsonConvert.SerializeObject(exception.Errors));
        }
    }

    [HttpGet("request")]
    public async Task<IActionResult> RequestWithoutResponse(string type, string request)
    {
        var requestJson = Encoding.UTF8.GetString(Convert.FromBase64String(request));
        var typeName = Encoding.UTF8.GetString(Convert.FromBase64String(type));
        var typeObject = Type.GetType(typeName);
        var query = JsonConvert.DeserializeObject(requestJson, typeObject);

        try
        {
            await this.mediator.Send(query);
            return this.Ok();
        }
        catch (ValidationException exception)
        {
            return this.BadRequest(JsonConvert.SerializeObject(exception.Errors));
        }
    }
}
