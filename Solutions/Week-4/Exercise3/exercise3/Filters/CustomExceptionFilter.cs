using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace exercise3.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // Create a folder named "Logs" if it doesn't exist
            string logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            // Write exception to a log file
            string logPath = Path.Combine(logDirectory, "ErrorLog.txt");
            File.AppendAllText(logPath, $"{DateTime.Now}: {context.Exception.Message}{Environment.NewLine}");

            // Return 500 Internal Server Error
            context.Result = new ObjectResult("An error occurred.")
            {
                StatusCode = 500
            };
        }
    }
}
