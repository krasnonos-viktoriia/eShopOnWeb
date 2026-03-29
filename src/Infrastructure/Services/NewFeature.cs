using System;
using System.Threading.Tasks;

namespace SonarNet.Infrastructure.Services
{
    /// <summary>
    /// Приклад класу, що реалізує нову функціональність.
    /// </summary>
    public class NewFeature
    {
        /// <summary>
        /// Виконує основну логіку нової фічі.
        /// </summary>
        /// <param name="input">Вхідний параметр</param>
        /// <returns>Результат обробки</returns>
        public async Task<string> ExecuteAsync(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Input cannot be empty", nameof(input));

            // Імітація асинхронної роботи (наприклад, виклик API, робота з БД)
            await Task.Delay(100);

            var result = $"NewFeature executed with input: {input}";
            return result;
        }

        /// <summary>
        /// Синхронна версія методу.
        /// </summary>
        public string Execute(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Input cannot be empty", nameof(input));

            return $"NewFeature executed with input: {input}";
        }
    }
}