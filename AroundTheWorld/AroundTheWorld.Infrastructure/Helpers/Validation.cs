using AroundTheWorld.Application.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AroundTheWorld.Infrastructure.Helpers
{
    public static class Validation
    {
        public static bool ValidateEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            var isValid = Regex.IsMatch(email, emailPattern);

            return isValid;
        }
        public static bool ValidatePassword(string passwrod)
        {
            string passwordPatter = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$";
            var isValid = Regex.IsMatch(passwrod, passwordPatter);

            return isValid;
        }
        public static bool ValidatePhoneNumber(string passwrod)
        {
            string passwordPatter = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";
            var isValid = Regex.IsMatch(passwrod, passwordPatter);

            return isValid;
        }
        public static bool ValidateBirthDate(DateTime birthDate)
        {
            var lessThanToday = birthDate < DateTime.Now;
            var notTooMany = birthDate > DateTime.Now.AddYears(-125);

            return (notTooMany && lessThanToday);
        }

        public static string validateUserData(
            string? password,
            string email, 
            DateTime birthDate, 
            string phoneNumber
            )
        {

            var validateBirthDate = Validation.ValidateBirthDate(birthDate);
            var validatePhoneNumber = Validation.ValidatePhoneNumber(phoneNumber);
            var validateEmail = Validation.ValidateEmail(email);

            if (password != null)
            {
                var validatePassword = Validation.ValidatePassword(password);

                if (!validatePassword)
                {
                    return ("Пароль должен содержать 1 заглавную букву, 1 строчную букву, " +
                        "1 цифру, 1 спец. символ и быть не меньше 6 символов");
                }
            }

            if (!validateEmail)
            {
                return ("Некорректный email");
            }
            

            if (!validateBirthDate)
            {
                return ("Некорректный возраст");
            }

            if (!validatePhoneNumber)
            {
                return ("Некорректный формат телефона");
            }

            return string.Empty;
        }

    }
}
