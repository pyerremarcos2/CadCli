using CadCli.API.Controllers;
using CadCli.API.Models;
using Microsoft.AspNetCore.Mvc;
namespace CadCli.Tests;

public class ClientesControllerTest
{
    private readonly ClientesController _controller;
    public ClientesControllerTest()
    {
        _controller = new ClientesController();
    }
    [Fact]
    public void Get_WhenCalled_ReturnsOkResult()
    {
        // Act
        var okResult = _controller.GetAll();
        // Assert
        Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
    }
    [Fact]
    public void Get_WhenCalled_ReturnsAllItems()
    {
        // Act
        var okResult = _controller.GetAll() as OkObjectResult;
        // Assert
        var items = Assert.IsType<List<Cliente>>(okResult.Value);
        Assert.Equal(4, items.Count);
    }

    [Fact]
    public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
    {
        // Act
        var notFoundResult = _controller.GetById(100);

        // Assert
        Assert.IsType<NotFoundResult>(notFoundResult);
    }

    [Fact]
    public void GetById_ExistingIdPassed_ReturnsOkResult()
    {
        // Arrange
        var id = 1;

        // Act
        var okResult = _controller.GetById(1);

        // Assert
        Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
    }

    [Fact]
    public void GetById_ExistingGuidPassed_ReturnsRightItem()
    {
        // Arrange
        var testId = 1;

        // Act
        var okResult = _controller.GetById(testId) as OkObjectResult;

        // Assert
        Assert.IsType<Cliente>(okResult.Value);
        Assert.Equal(testId, (okResult.Value as Cliente).Id);
    }


}