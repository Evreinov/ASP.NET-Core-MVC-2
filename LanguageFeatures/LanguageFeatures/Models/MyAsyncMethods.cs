namespace LanguageFeatures.Models
{
    public class MyAsyncMethods
    {
        // Использование асинхронных методов - работа с задачами напрямую
        //public static Task<long?> GetPageLenght()
        //{
        //    HttpClient client = new HttpClient();
        //    var httpTask = client.GetAsync("http://apress.com");
        //    return httpTask.ContinueWith((Task<HttpResponseMessage> antecedent) =>
        //    {
        //        return antecedent.Result.Content.Headers.ContentLength;
        //    });
        //}

        // Использование асинхронных методов - применение ключевых свойств async и await
        public async static Task<long?> GetPageLenght()
        {
            HttpClient client = new HttpClient();
            var httpMessage = await client.GetAsync("http://apress.com");
            return httpMessage.Content.Headers.ContentLength;
        }
    }
}
