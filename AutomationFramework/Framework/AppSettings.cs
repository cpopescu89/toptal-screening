using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace AutomationFramework.Framework
{
    public static class AppSettings
    {
        public static string GetSetting(string key)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("app.json", false, true)
                .Build();
            return config.GetSection("appSettings")[key];
        }

        public static TimeSpan WaitingTimeoutInSeconds =>
            new TimeSpan(0, 0, int.Parse(GetSetting("WaitingTimeoutInSeconds")));

        private static string GetSettingValue(string key) => GetSetting(key) ?? string.Empty;

        public static string GetPageUrl(string pageName)
        {

            var homepageUrl = GetHomepage();
            var pageFragment = GetSettingValue(pageName);

            return string.IsNullOrEmpty(pageFragment)
                ? homepageUrl
                : CombineUrLs(homepageUrl, pageFragment);
        }

        public static string GetHomepage() => GetSettingValue("StartingURL");
        public static string GetUsername() => GetSettingValue("Username");
        public static string GetPassword() => GetSettingValue("Password");

        public static string GetProfilePage() =>
            GetPageUrl("ProfilePage");


        private static string CombineUrLs(string url1, string url2)
        {
            if (!url1.Any())
                return url2;

            if (!url2.Any())
                return url1;

            url1 = url1.TrimEnd('/', '\\');
            url2 = url2.TrimStart('/', '\\');

            return $"{url1}/{url2}";
        }



    }

}
