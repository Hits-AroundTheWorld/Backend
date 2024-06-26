using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Domain.Entities
{
    public class Checkpoint
    {
        public Guid Id { get; set; }
        public Guid ChecklistId { get; set; }
        public string Text { get; set; }
        public int NumberOfItems { get; set; } = 1;
        public bool IsChecked { get; set; }
    }
}
