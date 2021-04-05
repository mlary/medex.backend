namespace Medex.Site.Infrastructure
{
    public class ResponseWrapper<T>
    {
        /// <summary>
        /// Данные
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Статус запроса
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Текст ошибки
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public ResponseWrapper()
        {
        }

        /// <summary>
        /// Конструктор с заполнение даты и флага success
        /// </summary>
        /// <param name="success"></param>
        /// <param name="data"></param>
        public ResponseWrapper(bool success, T data)
        {
            Success = success;
            Data = data;
        }

        public ResponseWrapper(bool success, string errorMessage)
        {
            Success = success;
            Error = errorMessage;
        }
    }
}
