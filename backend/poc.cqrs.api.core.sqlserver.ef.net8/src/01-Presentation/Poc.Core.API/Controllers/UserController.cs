using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using poc.core.api.net8.User;
using Poc.Contract.Command.User.Request;
using Poc.Contract.Command.User.Response;
using Poc.Contract.Query.User.EF.QueriesModel;
using Poc.Contract.Query.User.Request;
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
[ApiExplorerSettings(GroupName = "User")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<UserController> _logger;

    /// <summary>
    /// Construtor do controlador de registro.
    /// </summary>
    /// <param name="logger">Serviço para log de operações e erros.</param>
    /// <param name="mediator">Mediador para operações CQRS.</param>
    public UserController(ILogger<UserController> logger, IMediator mediator)
    {
        _mediator = mediator;
        _logger = logger;
    }

    /// <summary>
    /// Obtém uma lista com todos os registro.
    /// </summary>
    /// <response code="200">Retorna a lista de registro.</response>
    /// <response code="500">Quando ocorre um erro interno inesperado no servidor.</response>
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse<List<UserQueryModel>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    [Authorize(Roles = $"{RoleUserAuthConstants.User}, {RoleUserAuthConstants.GetUser}")]
    public async Task<IActionResult> GetAll()
        => (await _mediator.Send(new GetUserQuery())).ToActionResult();

    /// <summary>
    /// Obtém o registro pelo Id.
    /// </summary>
    /// <param name="id"></param>
    /// <response code="200">Retorna o registro.</response>
    /// <response code="400">Retorna lista de erros, se a requisição for inválida.</response>
    /// <response code="404">Quando nenhum registro é encontrado pelo Id fornecido.</response>
    /// <response code="500">Quando ocorre um erro interno inesperado no servidor.</response>
    [HttpGet("{id}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse<UserQueryModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    [Authorize(Roles = $"{RoleUserAuthConstants.User}, {RoleUserAuthConstants.GetUserById}")]
    public async Task<IActionResult> GetById(Guid id)
        => (await _mediator.Send(new GetUserByIdQuery(id))).ToActionResult();

    /// <summary>
    /// Cadastra um novo registro.
    /// </summary>
    /// <param name="command"></param>
    /// <response code="200">Retorna o Id do novo registro.</response>
    /// <response code="400">Retorna lista de erros, se a requisição for inválida.</response>
    /// <response code="500">Quando ocorre um erro interno inesperado no servidor.</response>
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse<CreateUserResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    [Authorize(Roles = $"{RoleUserAuthConstants.User}, {RoleUserAuthConstants.PostUser}")]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        => (await _mediator.Send(command)).ToActionResult();

    /// <summary>
    /// Atualiza um registro existente.
    /// </summary>
    /// <param name="command"></param>
    /// <response code="200">Retorna a resposta com a mensagem de sucesso.</response>
    /// <response code="400">Retorna lista de erros, se a requisição for inválida.</response>
    /// <response code="404">Quando nenhum registro é encontrado pelo Id fornecido.</response>
    /// <response code="500">Quando ocorre um erro interno inesperado no servidor.</response>
    [HttpPut]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    [Authorize(Roles = $"{RoleUserAuthConstants.User}, {RoleUserAuthConstants.PutUser}")]
    public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
        => (await _mediator.Send(command)).ToActionResult();

    /// <summary>
    /// Atualiza um registro existente.
    /// </summary>
    /// <param name="command"></param>
    /// <response code="200">Retorna a resposta com a mensagem de sucesso.</response>
    /// <response code="400">Retorna lista de erros, se a requisição for inválida.</response>
    /// <response code="404">Quando nenhum registro é encontrado pelo Id fornecido.</response>
    /// <response code="500">Quando ocorre um erro interno inesperado no servidor.</response>
    [HttpPut("updatepassword")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    [Authorize(Roles = $"{RoleUserAuthConstants.User}, {RoleUserAuthConstants.PutUser}")]
    public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordUserCommand command)
        => (await _mediator.Send(command)).ToActionResult();

    /// <summary>
    /// Atualiza um registro existente.
    /// </summary>
    /// <param name="command"></param>
    /// <response code="200">Retorna a resposta com a mensagem de sucesso.</response>
    /// <response code="400">Retorna lista de erros, se a requisição for inválida.</response>
    /// <response code="404">Quando nenhum registro é encontrado pelo Id fornecido.</response>
    /// <response code="500">Quando ocorre um erro interno inesperado no servidor.</response>
    [HttpPut("updateemail")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    [Authorize(Roles = $"{RoleUserAuthConstants.User}, {RoleUserAuthConstants.PutUser}")]
    public async Task<IActionResult> UpdateEmail([FromBody] UpdateEmailUserCommand command)
        => (await _mediator.Send(command)).ToActionResult();

    /// <summary>
    /// Atualiza um registro existente.
    /// </summary>
    /// <param name="command"></param>
    /// <response code="200">Retorna a resposta com a mensagem de sucesso.</response>
    /// <response code="400">Retorna lista de erros, se a requisição for inválida.</response>
    /// <response code="404">Quando nenhum registro é encontrado pelo Id fornecido.</response>
    /// <response code="500">Quando ocorre um erro interno inesperado no servidor.</response>
    [HttpPut("updaterole")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    [Authorize(Roles = $"{RoleUserAuthConstants.User}, {RoleUserAuthConstants.PutUser}")]
    public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleUserCommand command)
        => (await _mediator.Send(command)).ToActionResult();

    /// <summary>
    /// Deleta o registro pelo Id.
    /// </summary>
    /// <param name="id"></param>
    /// <response code="200">Retorna a resposta com a mensagem de sucesso.</response>
    /// <response code="400">Retorna lista de erros, se a requisição for inválida.</response>
    /// <response code="404">Quando nenhum registro é encontrado pelo Id fornecido.</response>
    /// <response code="500">Quando ocorre um erro interno inesperado no servidor.</response>
    [HttpDelete("{id}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    [Authorize(Roles = $"{RoleUserAuthConstants.User}, {RoleUserAuthConstants.DeleteUser}")]
    public async Task<IActionResult> Delete(Guid id)
        => (await _mediator.Send(new DeleteUserCommand(id))).ToActionResult();
}
