using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poc.Contract.Command.Auth.Request;
using Poc.Contract.Command.Auth.Response;
using Poc.Core.API.Extensions;
using Poc.Core.API.Models;
using System.ComponentModel;
using System.Net.Mime;

namespace Poc.Core.API.Controllers;

/// <summary>
/// Controlador responsável por operações relacionadas a registro.
/// </summary>
[Route("api/v1/[controller]")]
[Produces("application/json")]
[ApiController]
[Description("Controller responsável por cadastrar registro.")]
[ApiExplorerSettings(GroupName = "Auth")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<AuthController> _logger;

    /// <summary>
    /// Construtor do controlador de registro.
    /// </summary>
    /// <param name="logger">Serviço para log de operações e erros.</param>
    /// <param name="mediator">Mediador para operações CQRS.</param>
    public AuthController(ILogger<AuthController> logger, IMediator mediator)
    {
        _mediator = mediator;
        _logger = logger;
    }

    /// <summary>
    /// Autentica usuario.
    /// </summary>
    /// <param name="command"></param>
    /// <response code="200">Retorna o Token.</response>
    /// <response code="400">Retorna lista de erros, se a requisição for inválida.</response>
    /// <response code="500">Quando ocorre um erro interno inesperado no servidor.</response>
    [HttpPost("login")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse<AuthTokenResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Auth([FromBody] AuthCommand command)
        => (await _mediator.Send(command)).ToActionResult();

    /// <summary>
    /// Reset senha usuario.
    /// </summary>
    /// <param name="command"></param>
    /// <response code="200">Retorna o Token.</response>
    /// <response code="400">Retorna lista de erros, se a requisição for inválida.</response>
    /// <response code="500">Quando ocorre um erro interno inesperado no servidor.</response>
    [HttpPost("resetpassword")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AuthResetPassword([FromBody] AuthResetPasswordCommand command)
        => (await _mediator.Send(command)).ToActionResult();

    /// <summary>
    /// Reset senha usuario.
    /// </summary>
    /// <param name="command"></param>
    /// <response code="200">Retorna o Token.</response>
    /// <response code="400">Retorna lista de erros, se a requisição for inválida.</response>
    /// <response code="500">Quando ocorre um erro interno inesperado no servidor.</response>
    [HttpPost("newpassword")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    //[Authorize(Roles = RoleUserAuthConstants.AuthReset)]
    public async Task<IActionResult> AuthNewPassword([FromBody] AuthNewPasswordCommand command, string token)
    {
        command.Token = token;
        return (await _mediator.Send(command)).ToActionResult();
    }

}
