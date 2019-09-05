using System.Collections.Generic;

namespace HypSuite.Domain.Models
{
    public class Room
    {
        public int RoomID {get;set;}
        public int MaxCapacity { get; set; }
        public List<Bed> Beds { get; set; }
        public int NumberOfBathrooms {get;set;}
        public bool IsSmoking { get; set; }
        public int SizeSqFt {get;set;}
        public decimal DailyRate{get;set;}
    }
}