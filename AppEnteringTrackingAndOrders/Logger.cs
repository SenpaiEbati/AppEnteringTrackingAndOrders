using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEnteringTrackingAndOrders
{
    public static class Logger
    {
        private static readonly string LogDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "RestaurantApp",
            "Logs");

        private static readonly string LogFilePath = Path.Combine(
            LogDirectory,
            $"log_{DateTime.Now:yyyyMMdd}.txt");

        static Logger()
        {
            // Создаем директорию для логов, если её нет
            if (!Directory.Exists(LogDirectory))
            {
                Directory.CreateDirectory(LogDirectory);
            }
        }

        public static async Task LogAsync(string message)
        {
            try
            {
                await File.AppendAllTextAsync(
                    LogFilePath,
                    $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                // Если не удалось записать лог, выводим в отладочную консоль
                Debug.WriteLine($"Ошибка записи лога: {ex.Message}");
            }
        }
    }
}
