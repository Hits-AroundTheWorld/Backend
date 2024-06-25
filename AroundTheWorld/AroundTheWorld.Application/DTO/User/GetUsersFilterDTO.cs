using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.DTO.User
{
    public class GetUsersFilterDTO
    {
        public string? FullName { get; set;}
        public string? Email { get; set;}
        public string? Country { get; set;}
        public MinMaxAgeDTO? Age { get; set;}
        public int currentPage { get; set;}
        public int PageSize { get; set;}
    }
}
