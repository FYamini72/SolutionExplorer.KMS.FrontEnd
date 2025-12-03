namespace SolutionExplorer.KMS.SharedUI.Services.Interfaces
{
    public interface IHttpService
    {
        /// <summary>
        /// به روش آسنکرون، یک درخواست اچ تی تی پی با متد گت را ارسال می‌کند.
        /// </summary>
        /// <typeparam name="TResponse">نوع بازگشتی سرویس</typeparam>
        /// <param name="endpoint">آدرس سرویس</param>
        /// <param name="addAuthToken">آیا توکن احراز هویت به درخواست اضافه شود؟ (پیش‌فرض: true)</param>
        /// <returns>اطلاعات بازگشتی که به مدل مشخص شده تبدیل شده است.</returns>
        Task<TResponse?> GetAsync<TResponse>(string endpoint, bool addAuthToken = true);

        /// <summary>
        /// به روش آسنکرون، یک درخواست اچ تی تی پی با متد پست را ارسال می‌کند.
        /// این متد براساس ساختار پروژه بک‌اند پیاده سازی شده است.
        /// </summary>
        /// <typeparam name="TRequest">نوع اطلاعات ارسالی</typeparam>
        /// <typeparam name="TResponse">نوع بازگشتی سرویس</typeparam>
        /// <param name="endpoint">آدرس سرویس</param>
        /// <param name="model">اطلاعات مورد نیاز جهت جستجو و صفحه بندی</param>
        /// <param name="addAuthToken">آیا توکن احراز هویت به درخواست اضافه شود؟ (پیش‌فرض: true)</param>
        /// <returns>اطلاعات بازگشتی که به مدل مشخص شده تبدیل شده است.</returns>
        Task<TResponse?> GetByFilterAsync<TRequest, TResponse>(string endpoint, TRequest model, bool addAuthToken = true);

        /// <summary>
        /// به روش آسنکرون، یک درخواست اچ تی تی پی با متد پست را ارسال می‌کند
        /// </summary>
        /// <typeparam name="TRequest">نوع اطلاعات ارسالی</typeparam>
        /// <typeparam name="TResponse">نوع بازگشتی سرویس</typeparam>
        /// <param name="endpoint">آدرس سرویس</param>
        /// <param name="model">اطلاعات مورد نیاز جهت ارسال به سرویس</param>
        /// <param name="addAuthToken">آیا توکن احراز هویت به درخواست اضافه شود؟ (پیش‌فرض: true)</param>
        /// <returns>اطلاعات بازگشتی که به مدل مشخص شده تبدیل شده است.</returns>
        Task<TResponse?> PostAsync<TRequest, TResponse>(string endPoint, TRequest model, bool addAuthToken = true);

        /// <summary>
        /// به روش آسنکرون، یک درخواست اچ تی تی پی با متد پوت را ارسال می‌کند
        /// </summary>
        /// <typeparam name="TRequest">نوع اطلاعات ارسالی</typeparam>
        /// <typeparam name="TResponse">نوع بازگشتی سرویس</typeparam>
        /// <param name="endpoint">آدرس سرویس</param>
        /// <param name="model">اطلاعات مورد نیاز جهت ارسال به سرویس</param>
        /// <param name="addAuthToken">آیا توکن احراز هویت به درخواست اضافه شود؟ (پیش‌فرض: true)</param>
        /// <returns>اطلاعات بازگشتی که به مدل مشخص شده تبدیل شده است.</returns>
        Task<TResponse?> PutAsync<TRequest, TResponse>(string endPoint, TRequest model, bool addAuthToken = true);

        /// <summary>
        /// به روش آسنکرون، یک درخواست اچ تی تی پی با متد دلت را ارسال می‌کند
        /// </summary>
        /// <typeparam name="TRequest">نوع اطلاعات ارسالی</typeparam>
        /// <typeparam name="TResponse">نوع بازگشتی سرویس</typeparam>
        /// <param name="endpoint">آدرس سرویس</param>
        /// <param name="addAuthToken">آیا توکن احراز هویت به درخواست اضافه شود؟ (پیش‌فرض: true)</param>
        /// <returns>اطلاعات بازگشتی که به مدل مشخص شده تبدیل شده است.</returns>
        Task<TResponse?> DeleteAsync<TResponse>(string endPoint, bool addAuthToken = true);

        /// <summary>
        /// به روش آسنکرون، یک درخواست اچ تی تی پی با متد پست را بصورت مالتی پارت ارسال می‌کند
        /// </summary>
        /// <typeparam name="TRequest">نوع اطلاعات ارسالی</typeparam>
        /// <typeparam name="TResponse">نوع بازگشتی سرویس</typeparam>
        /// <param name="endpoint">آدرس سرویس</param>
        /// <param name="model">اطلاعات مورد نیاز جهت ارسال به سرویس</param>
        /// <param name="maxSize"></param>
        /// <param name="addAuthToken">آیا توکن احراز هویت به درخواست اضافه شود؟ (پیش‌فرض: true)</param>
        /// <returns>اطلاعات بازگشتی که به مدل مشخص شده تبدیل شده است.</returns>
        Task<TResponse?> PostMultipartAsync<TRequest, TResponse>(string endpoint, TRequest model, int maxSize = 20, bool addAuthToken = true);
        Task<byte[]?> DownloadFileAsync(string endpoint, bool addAuthToken = true);
        Task<TResponse?> PutMultipartAsync<TRequest, TResponse>(string endpoint, TRequest model, int maxSize = 20, bool addAuthToken = true);
    }
}