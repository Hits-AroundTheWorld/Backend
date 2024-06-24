namespace AroundTheWorld.Application.DTO.TimeIntervals
{
    public class EditTimeIntervalDTO
    {
        public Guid TimeIntervalId { get; set; }
        public string Title { get; set; }
        public string? Text { get; set; }
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
    }
}
