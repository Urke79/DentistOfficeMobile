using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MobileApp
{
    public static class Consts
    {
        public static readonly string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Medic.db"); 
    }
}
