using CleanArchitecture.Application.ResponseBase;
using CleanArchitecture.Application.UseCases.CreateUser;
using CleanArchitecture.Application.UseCases.DeleteUser;
using CleanArchitecture.Application.UseCases.GetAllUser;
using CleanArchitecture.Application.UseCases.GetUser;
using CleanArchitecture.Application.UseCases.UpdateUser;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IUserRepository _userRepository;

    public UsersController(IMediator mediator, IUserRepository userRepository)
    {
         _mediator= mediator;
         _userRepository = userRepository;
    }
         
    [HttpGet]
    public async Task<ActionResult<List<Response>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllUserRequest(), cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Response>> GetById(Guid? id)
    {
        if (id is null) return BadRequest();

        var response = await _mediator.Send(new GetUserRequest((Guid)id));

        if (response is null) return NotFound("Id " + id + " não encontrado!");


        return Ok(response);
    }

    /* Na Busca por email, não usei CQRS, Injetei o  
     Repository _userRepository onde está o contrato de busca por E-mail.*/
    [HttpGet("e-mail")]
    public async Task<ActionResult<Response>> GetByEmail( string email,CancellationToken cancellationToken)
    {
        var em = await _userRepository.GetByEmail(email, cancellationToken);
        if (em == null) return BadRequest("O E-Mail " + email + " não foi localizado !");
        return Ok(em);
    }
             
    [HttpPost]
    public async Task<ActionResult<Response>> Create(CreateUserRequest request,
                                                          CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
           
    [HttpPut("{id}")]
    public async Task<ActionResult<Response>>
        Update(Guid id, UpdateUserRequest request, CancellationToken cancellationToken)
    {
        
        if (id != request.Id)
           return BadRequest("Item não encontrado!");

        var response = await _mediator.Send(request, cancellationToken);
           return Ok(response);
    }      

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid? id,
                                           CancellationToken cancellationToken)
    {   
        if (id is null) return BadRequest("Item não localizado !");

        var deleteUserRequest = new DeleteUserRequest(id.Value);

        var response = await _mediator.Send(deleteUserRequest, cancellationToken);

        return Ok(response);
    }
}
