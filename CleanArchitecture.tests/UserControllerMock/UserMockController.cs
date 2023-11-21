using AutoMapper;
using CleanArchitecture.Application.ResponseBase;
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

    [HttpGet]
    public ActionResult<List<Response>> GetAll()
    {
        return Ok(Response);
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
}

// AINDA NÃO TERMINEI OS TESTES UNITÁRIOS => PROCURANDO TEMPO....