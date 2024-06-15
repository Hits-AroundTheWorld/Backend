using System;

namespace AroundTheWorld.Infrastructure.Helpers.TripValidation
{
    public static class ValidationTripInfo
    {
        public static bool ValidateDates(DateTime startDate)
        {
            bool lessThanToday = startDate.Date < DateTime.Now.Date;
            return lessThanToday;
        }

        public static bool ValidateStartAndEndDates(DateTime startDate, DateTime endTime) {
            bool lessThanStartDay = startDate.Date > endTime.Date;
            return lessThanStartDay;
        }
        public static string ValidateTripDate(DateTime startDate, DateTime endTime)
        {
            bool validateDate = ValidateDates(startDate);
            bool validateEndDate = ValidateStartAndEndDates(startDate, endTime);
            if(validateDate)
            {
                return "Вы не можете назначить конец поездки раньше чем начало поездки!";
            }
            if (validateDate)
            {
                return "Поездка не может быть назначена в прошлом!";
            }
            return string.Empty;
        }
    }
}
