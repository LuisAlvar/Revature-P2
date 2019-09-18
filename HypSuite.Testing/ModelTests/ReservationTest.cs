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
        var sut = new Room(){RoomID = 1,MaxCapacity=4,LocationRefID=1,DailyRate=65.5M,NumberOfBathrooms=2,NumberOfBeds=4};
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

      [Fact]
      public void TestCalculate()
      {
      //Given
        var sut = new Reservation();
        sut.CheckInDate="2019-09-17";
        sut.CheckOutDate="2019-09-19";
        sut.Rooms = new List<Room>(){new Room{DailyRate=50M}, new Room{DailyRate=60M}, new Room{DailyRate=70M}};
      //When
        var actual = sut.CalculateReservationCost();
      //Then
        var expected = 360M;
        Assert.True(expected==actual);
      }

      [Fact]
      public void TestCheckDates()
      {
      //Given
        var sut = new Reservation();
        sut.CheckInDate="2019-09-20";
        sut.CheckOutDate="2019-09-19";
      //When
        var actual = sut.CheckDates();
      //Then
        var expected = false;
        Assert.True(expected==actual);
      }
        
    }
}