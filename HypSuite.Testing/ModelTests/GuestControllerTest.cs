using System.Collections.Generic;
using HypSuite.Client.Controllers;
using HypSuite.Domain.Models;
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

      [Fact]
      public void TestViewLocations()
      {
        var sut = new GuestController();
        GuestController.Current = new Reservation();
        GuestController.Current.HotelsLocation=new Location{Street="1000 Mesquite St"};
        var view = sut.ViewLocations(GuestController.Current.HotelsLocation);
        var actual = GuestController.Current.HotelsLocation.State;
      //When
        var expected = "Texas";
      //Then
        Assert.NotNull(view);
        Assert.IsType<RedirectToActionResult>(view);
        Assert.True(expected.CompareTo(actual)==0);
      }

      [Fact]
      public void TestChooseRegion()
      {
        var sut = new GuestController();
        GuestController.Current = new Reservation();
        GuestController.Current.HotelsLocation=new Location();
        Location l = new Location{State = "Texas"};
        var view = sut.ChooseRegion(l);
        var actual = GuestController.Current.HotelsLocation.State;
      //When
        var expected = "Texas";
      //Then
        Assert.NotNull(view);
        Assert.IsType<RedirectToActionResult>(view);
        Assert.True(expected.CompareTo(actual)==0);
      }
      [Fact]
      public void TestViewRooms()
      {
        var sut = new GuestController();
        GuestController.Current = new Reservation();
        GuestController.CurrentGuest = new Guest{PartySize=2}; 
        GuestController.Current.Rooms=new List<Room>();
        Room r = new Room{RoomID = 13};
        var view = sut.ViewRooms(r);
        var actual = GuestController.Current.Rooms[0].RoomID;
      //When
        var expected = 13;
      //Then
        Assert.NotNull(view);
        Assert.IsType<RedirectToActionResult>(view);
        Assert.True(expected ==actual);
      }
      [Fact]
      public void TestGuestInformation()
      {
        var sut = new GuestController();
        GuestController.Current = new Reservation();
        GuestController.Current.HotelsLocation = new Location{ClientID=1};
        GuestController.CurrentGuest = new Guest();
        Guest g =new Guest{FirstName="o", LastName="p",PartySize=2};
        var view = sut.GuestInformation(g);
        var actual = GuestController.CurrentGuest.ClientID;
      //When
        var expected = 1;
      //Then
        Assert.NotNull(view);
        Assert.IsType<RedirectToActionResult>(view);
        Assert.True(expected==actual);
      }

      [Fact]
      public void TestReservationDates()
      {
        var sut = new GuestController();
        GuestController.Current = new Reservation();
        Reservation r = new Reservation{CheckInDate="2019-09-17",CheckOutDate="2019-09-18"};
        var view = sut.ReservationDates(r);
        var actual = GuestController.Current.CheckInDate;
        //When
        var expected = "2019-09-17";
        //Then
        Assert.NotNull(view);
        Assert.IsType<RedirectToActionResult>(view);
        Assert.True(expected==actual);
      }
      
    }
}