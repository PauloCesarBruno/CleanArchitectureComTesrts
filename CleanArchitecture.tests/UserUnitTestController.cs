using AutoMapper;
using CleanArchitecture.Application.ProfileMapper;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Persistence.Context;
using CleanArchitecture.Persistence.Repositories;
using CleanArchitecture.tests.UserControllerMock;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.tests;

public class UserUnitTestController
{
    private IMapper mapper;
    private IUserRepository repository;

    public static DbContextOptions<AppDbContext> dbContextOptions { get; }

    public static string connectionString = "Data Source=userdb.db";
          
    static UserUnitTestController()
    {
        dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
             .UseSqlite(connectionString)
             .Options;
    }
          
    public UserUnitTestController()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new GetAllUserMapper());
        });

        // Instancia do AutoMapper:
        mapper = config.CreateMapper();
       
        var context = new AppDbContext(dbContextOptions);

        repository = new UserRepository(context);
    }

    // Inicio dos testes unitários:
    // Casos de teste:               
    // TESTES DE CONSULTAS
    //===================================================================================================== 

    /* Testar o método GetAll (na coleção de objetos) do Controlador de UserMockController:
          Testar se o valor retornado é igual a um OkObjectResult 
          é igual ao estatus code 200(Ok).*/
    [Fact]    
    public void GetUser_Return_OkResult_200_OK()
    {               
        var controller = new UserMockController(null, repository, mapper);

        var data = controller.GetAll();

        Assert.IsType<OkObjectResult>(data.Result);
    }

    /* Testar o método GetAll (na coleção de objetos) do Controlador de UserMockController:
           Testar se o valor retornado é igual a um BadRequestResult 
           é igual ao estatus code 400 (BadRequest).*/
    [Fact]  
    public void GetUser_Return_BadRequest_400_BadRequest()
    {           
        var controller = new UserMockController(null, repository, mapper);

        var data = controller.GetAllBadRequest();

        Assert.IsType<BadRequestResult>(data.Result);
    }

    /* Testar o método GetAll (na coleção de objetos)  do Controlador de UserMockController:
           Testar se o valor retornado é igual a um NotFoundResult 
           é igual ao estatus code 404 (NotFound).*/
    [Fact]  
    public void GetUser_Return_NotFound_404_NotFound()
    {
        var controller = new UserMockController(null, repository, mapper);

        var data = controller.GetAllNotFound();

        Assert.IsType<NotFoundResult>(data.Result);
    }

    //==========================================================================================

    /* Testar o método Get (um objeto) do Controlador de UserMockController:
           Testar se o valor retornado é igual a um OkObjectResult 
           é igual ao estatus code 200(Ok).*/
    [Fact] 
    public void GetUserId_Return_OkResult_200_OK()
    {
        var controller = new UserMockController(null, repository, mapper);

        var data = controller.GetById(Guid.NewGuid());

        Assert.IsType<OkObjectResult>(data.Result);
    }

    /* Testar o método Get (um objeto) do Controlador de UserMockController:
           Testar se o valor retornado é igual a um BadRequestResult 
           é igual ao estatus code 400 (BadRequest).*/
    [Fact] 
    public void GetUserId_Return_BadRequest_400_BadRequest()
    {
        var controller = new UserMockController(null, repository, mapper);

        var data = controller.GetBadRequestById(Guid.NewGuid());

        Assert.IsType<BadRequestResult>(data.Result);
    }

    /* Testar o método Get (um objeto)  do Controlador de UserMockController:
           Testar se o valor retornado é igual a um NotFoundResult 
           é igual ao estatus code 404 (NotFound).*/
    [Fact]  
    public void GetUserId_Return_NotFound_404_NotFound()
    { 
        var controller = new UserMockController(null, repository, mapper);

        var data = controller.GetNotFfoundById(Guid.Empty);

        Assert.IsType<NotFoundResult>(data.Result);
    }
}

// AINDA NÃO TERMINEI OS TESTES UNITÁRIOS => PROCURANDO TEMPO....