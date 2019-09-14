using System.Collections.Generic;
using HypSuite.Client.Controllers;
using HypSuite.Domain.Models;
using Xunit;

namespace HypSuite.Testing.ModelTests
{
    public class RoomTest
    {
      [Fact]
      public void TestRoomDefaults()
      {
        var sut = new Room(){RoomID = 1, IsSmoking= false, LocationID =1, NumberOfBathrooms=2, NumberOfBeds = 2,MaxCapacity=4,SizeSqFt=450,DailyRate=100};
        var actual = sut.IsSmoking;
        var actual2 = sut.IsOccupied;
      //When
        var expected = false;
      //Then
        Assert.True(expected == actual);
        Assert.True(expected == actual2);
        Assert.NotNull(actual);
        Assert.IsType<bool>(actual);
      }

      [Fact]
      public void TestRoomRemoval()
      {
      //Given
      var sut = new GuestController();
      GuestController.Current = new Reservation();
      GuestController.Current.Rooms = new List<Room>();
      GuestController.Current.Rooms.Add(new Room(){RoomID=2, IsOccupied=false,MaxCapacity=4,NumberOfBathrooms=2,NumberOfBeds=4,DailyRate=100M,LocationID=1,SizeSqFt=450});
      //When
      sut.RemoveRoom();
      var actual = GuestController.Current.Rooms;
      var expected = 0;
      //Then
      //Assert.Null(actual);
      foreach (var item in GuestController.Current.Rooms)
      {
          System.Console.WriteLine("\n\n"+item+"\n\n");
      }

      System.Console.WriteLine("\n\n\n\n" + actual.Capacity + " " + expected+ "\n\n\n\n");
      Assert.True(actual.Capacity == expected);
      }
    }
}