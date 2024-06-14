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

        public static string ValidateTripDate(DateTime startDate)
        {
            bool validateDate = ValidateDates(startDate);
            if (validateDate)
            {
                return "Поездка не может быть назначена в прошлом!";
            }
            return string.Empty;
        }
    }
}
