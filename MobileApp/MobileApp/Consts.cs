using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;

namespace MobileApp
{
    public static class Consts
    {
        public static string IPAddress = DeviceInfo.Platform == DevicePlatform.Android ? "10.0.2.2" : "localhost";
        public static string baseApiUrl = $"https://uroswebapi.azurewebsites.net";
    }
}
