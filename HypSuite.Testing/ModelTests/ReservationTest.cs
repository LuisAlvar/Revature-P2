using Xunit;
using HypSuite.Client.Controllers;
using Microsoft.AspNetCore.Mvc;
using HypSuite.Domain.Models;
using System.Collections.Generic;

namespace HypSuite.Testing.ModelTests
{
    public class ReservationTest
    {
      [Fact]
      public void TestRoomList()
      {
        var sut = new Room(){RoomID = 1,MaxCapacity=4,LocationID=1,DailyRate=65.5M,NumberOfBathrooms=2,NumberOfBeds=4};
        sut.Available= new List<Room>();
        sut.Available.Add(sut);
        var actual = sut.Available[0].DailyRate;
      //When
        var expected = 65.5M;
      //Then
        Assert.True(expected == actual);
        Assert.NotNull(actual);
        Assert.IsType<decimal>(actual);
      }
        
    }
}