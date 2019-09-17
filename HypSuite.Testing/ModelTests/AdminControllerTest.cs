using HypSuite.Client.Controllers;
using HypSuite.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace HypSuite.Testing.ModelTests
{
    public class AdminControllerTest
    {
        [Fact]
      public void TestAdminLogin()
      {
        var sut = new AdminController();
        Employee a = new Employee{Username ="op",Password="password"};
        var view = sut.AdminLogin(a);
        Assert.NotNull(view);
        Assert.IsType<RedirectToActionResult>(view);
      }
    }
}