using AutoMapper;
using CleanArchitecture.Application.ResponseBase;
using CleanArchitecture.Application.UseCases.GetUser;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.tests.UserControllerMock;

public class UserMockController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserMockController(IMediator mediator, IUserRepository userRepository,
                  IMapper mapper)
    {
        _mediator = mediator;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    //===============================================================================================
    // Teste dos Status Codes do GetAll:

    [HttpGet]
    public ActionResult<List<Response>> GetAll()
    {
        return Ok(Response);
    }

    [HttpGet("notfound")]
    public ActionResult<List<Response>> GetAllNotFound()
    {
        if (Response is null)
        {
            return NotFound();
        }
        else
        {
            return Ok(Response);
        }

    }

    [HttpGet("badrequest")]
    public ActionResult<List<Response>> GetAllBadRequest()
    {
        try
        {
            throw new Exception();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    //===============================================================================================
    // Teste dos Status Codes do GetById:

    [HttpGet("{id}")]
    public ActionResult<Response> GetById(Guid? id)
    {

        if (id is null) return BadRequest();

        return Ok(Response);
    }

    [HttpGet("{id}")]
    public ActionResult<Response> GetBadRequestById(Guid? id)
    {
        if (id != Guid.NewGuid()) return BadRequest();

        var response = _mediator.Send(new GetUserRequest((Guid)id));

        if (response is null) return NotFound("Id " + id + " não encontrado!");

        return Ok(response);
    }

    [HttpGet("{id}")]
    public ActionResult<Response> GetNotFfoundById(Guid? id)
    {
        if (id == Guid.Empty) return NotFound();

        var response = _mediator.Send(new GetUserRequest((Guid)id));

        if (response is null) return NotFound("Id " + id + " não encontrado!");

        return Ok(response);
    }      
}

// AINDA NÃO TERMINEI OS TESTES UNITÁRIOS => PROCURANDO TEMPO...