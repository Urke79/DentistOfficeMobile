using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;

namespace MobileApp
{
    public static class Consts
    {
        // TODO - remove this line for this branch - SQL Lite DB
        // public static readonly string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Medic.db");
       // public static readonly string baseApiUrl = "path to URL here";
        public static string IPAddress = DeviceInfo.Platform == DevicePlatform.Android ? "10.0.2.2" : "localhost";
        public static string baseApiUrl = $"https://uroswebapi.azurewebsites.net";
    }
}
