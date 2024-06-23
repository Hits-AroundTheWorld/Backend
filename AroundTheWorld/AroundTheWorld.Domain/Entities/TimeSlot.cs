using System.ComponentModel.DataAnnotations;

namespace AroundTheWorld.Domain.Entities
{
    public class TimeInterval
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime SlotStart { get; set; }
        public DateTime SlotEnd { get; set; }
        public string Text { get; set; }
        public Guid TripId {  get; set; }
    }
}
