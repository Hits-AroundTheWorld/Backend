namespace AroundTheWorld.Application.DTO.Days
{
    public class CreateTimeSlotDTO
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
    }
}
