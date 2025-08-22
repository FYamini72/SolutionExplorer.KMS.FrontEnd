namespace SolutionExplorer.KMS.SharedUI.Services.Interfaces
{
    public interface IHttpService
    {
        /// <summary>
        /// به روش آسنکرون، یک درخواست اچ تی تی پی با متد گت را ارسال می‌کند.
        /// </summary>
        /// <typeparam name="TResponse">نوع بازگشتی سرویس</typeparam>
        /// <param name="endpoint">آدرس سرویس</param>
        /// <returns>اطلاعات بازگشتی که به مدل مشخص شده تبدیل شده است.</returns>
        Task<TResponse?> GetAsync<TResponse>(string endpoint);

        /// <summary>
        /// به روش آسنکرون، یک درخواست اچ تی تی پی با متد پست را ارسال می‌کند.
        /// این متد براساس ساختار پروژه بک‌اند پیاده سازی شده است.
        /// </summary>
        /// <typeparam name="TRequest">نوع اطلاعات ارسالی</typeparam>
        /// <typeparam name="TResponse">نوع بازگشتی سرویس</typeparam>
        /// <param name="endpoint">آدرس سرویس</param>
        /// <param name="model">اطلاعات مورد نیاز جهت جستجو و صفحه بندی</param>
        /// <returns>اطلاعات بازگشتی که به مدل مشخص شده تبدیل شده است.</returns>
        Task<TResponse?> GetByFilterAsync<TRequest, TResponse>(string endpoint, TRequest model);

        /// <summary>
        /// به روش آسنکرون، یک درخواست اچ تی تی پی با متد پست را ارسال می‌کند
        /// </summary>
        /// <typeparam name="TRequest">نوع اطلاعات ارسالی</typeparam>
        /// <typeparam name="TResponse">نوع بازگشتی سرویس</typeparam>
        /// <param name="endpoint">آدرس سرویس</param>
        /// <param name="model">اطلاعات مورد نیاز جهت ارسال به سرویس</param>
        /// <returns>اطلاعات بازگشتی که به مدل مشخص شده تبدیل شده است.</returns>
        Task<TResponse?> PostAsync<TRequest, TResponse>(string endPoint, TRequest model);

        /// <summary>
        /// به روش آسنکرون، یک درخواست اچ تی تی پی با متد پوت را ارسال می‌کند
        /// </summary>
        /// <typeparam name="TRequest">نوع اطلاعات ارسالی</typeparam>
        /// <typeparam name="TResponse">نوع بازگشتی سرویس</typeparam>
        /// <param name="endpoint">آدرس سرویس</param>
        /// <param name="model">اطلاعات مورد نیاز جهت ارسال به سرویس</param>
        /// <returns>اطلاعات بازگشتی که به مدل مشخص شده تبدیل شده است.</returns>
        Task<TResponse?> PutAsync<TRequest, TResponse>(string endPoint, TRequest model);
    }

    public interface ISpinnerService
    {
        event Action OnHide;
        event Action OnShow;

        void Hide();
        void Show();
    }
}
