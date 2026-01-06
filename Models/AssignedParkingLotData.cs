namespace ParkingLotSystem.Models
{
    public class AssignedParkingLotData
    {
        public int ParkingLotID { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Assigned { get; set; }
    }
}