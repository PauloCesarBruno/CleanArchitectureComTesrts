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

    /* Testar o método GET do Controlador de UserMockController:
       Testar se o valor retornado é igual a um OkObjectResult 
       é igual ao estatus code 200(Ok).*/
    [Fact]  // Informa que é um código de teste unitário.  
    public void GetUser_Return_OkResult_200_OK()
    {
        //Arrange  
        var controller = new UserMockController(null, repository, mapper);


        //Act
        var data = controller.GetAll();

        //Assert         
        Assert.IsType<OkObjectResult>(data.Result);
    }
    /* Testar o método GET do Controlador de UserMockController:
           Testar se o valor retornado é igual a um OkObjectResult 
           é igual ao estatus code 400(BadRequest).*/
    [Fact]  // Informa que é um código de teste unitário.  
    public void GetUser_Return_BadRequest_400_BadRequest()
    {
        //Arrange  
        var controller = new UserMockController(null, repository, mapper);


        //Act
        var data = controller.GetAllBadRequest();

        //Assert        
        Assert.IsType<BadRequestResult>(data.Result);
    }

    // AINDA NÃO TERMINEI OS TESTES UNITÁRIOS => PROCURANDO TEMPO....
}