namespace AroundTheWorld.Application.DTO.TimeIntervals
{
    public class CreateTimeIntervalDTO
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
        public Guid TripId { get; set; }
    }
}
