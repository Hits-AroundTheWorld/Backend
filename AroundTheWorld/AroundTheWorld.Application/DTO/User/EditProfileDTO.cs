using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.DTO.User
{
    public class EditProfileDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? AboutMe { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
