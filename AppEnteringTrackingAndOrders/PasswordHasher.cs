using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace AppEnteringTrackingAndOrders
{
    public static class PasswordHasher
    {
        // Метод для хеширования пароля
        public static string HashPassword(string password)
        {
            // Генерация хеша пароля с помощью BCrypt
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        // Метод для проверки пароля
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            // Проверка соответствия пароля и его хеша
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
