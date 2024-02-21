namespace AirlinesApp.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public int Airline {  get; set; }
        public string Code { get; set; }
        public int Source { get; set; }
        public int Destination { get; set; }
        public TimeSpan Departure { get; set; }
        public TimeSpan Arrival { get; set; }
    }
}
