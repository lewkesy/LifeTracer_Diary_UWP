using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.Threading.Tasks;  
using Windows.Storage;  

  
namespace LifeTracer
{
    static class DataUnit
    {
        public static bool IsSignUp = false;
        public static void SaveData(string key, object value)
        {
            ApplicationData.Current.LocalSettings.Values[key] = value;
        }

        public static object GetData(string key)
        {
            return ApplicationData.Current.LocalSettings.Values[key];
        }


        public static void RemoveData(string key)
        {
            ApplicationData.Current.LocalSettings.Values.Remove(key);
        }
    }
}