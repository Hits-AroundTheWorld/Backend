﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Domain.Entities.Enums
{
    public enum UserRequestStatus
    {
        InQueue,
        Approved,
        Rejected,
        DeletedRequest,
        LeftFromTrip
    }
}
