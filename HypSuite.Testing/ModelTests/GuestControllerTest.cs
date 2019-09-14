using HypSuite.Client.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace HypSuite.Testing.ModelTests
{
    public class GuestControllerTest
    {
      [Fact]
      public void TestRoomList()
      {
        var sut = new GuestController();
        var view = sut.ChooseRegion();
      //When
      
      //Then
        Assert.NotNull(view);
        Assert.IsType<ViewResult>(view);
      }
    }
}