using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace SolutionExplorer.KMS.SharedUI.Utilities
{
    public class ApplicationHelper
    {
        /// <summary>
        /// نام نمایشی پراپرتی خواسته شده رو برمی‌گرداند
        /// </summary>
        /// <typeparam name="TModel">نوع موجودیت مورد نظر</typeparam>
        /// <param name="propertyName">نام پراپرتی موردنظر که نام نمایشی آن باید در موجودیت مشخص شده بررسی شود</param>
        /// <returns>نام نمایشی پراپرتی مورد نظر را برمی‌گرداند</returns>
        public static string GetDisplayName<TModel>(string propertyName)
        {
            var propertyInfo = typeof(TModel).GetProperty(propertyName);
            if (propertyInfo == null)
            {
                return string.Empty;
            }

            var displayAttribute = propertyInfo.GetCustomAttribute<DisplayAttribute>();
            if (displayAttribute != null && !string.IsNullOrEmpty(displayAttribute.Name))
            {
                return displayAttribute.Name;
            }

            var displayNameAttribute = propertyInfo.GetCustomAttribute<DisplayNameAttribute>();
            if (displayNameAttribute != null && !string.IsNullOrEmpty(displayNameAttribute.DisplayName))
            {
                return displayNameAttribute.DisplayName;
            }

            return propertyInfo.Name;
        }
    }
}
