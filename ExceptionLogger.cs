using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Reflection;

namespace Helpers
{
    public static class ExceptionLogger
    {
        public static void LogExceptionsToFile<T>(this T content) where T : Exception
        {
            const string path = @"C:\LogForPasswordManagement";
            const string logPrefix = "Log.txt";
            var fileValues = Assembly.GetCallingAssembly().ToString().Split();
            //dynamically names the file based on the application.
            string fileName = (fileValues[0].Contains(".")) ? fileValues[0].Substring(0, fileValues[0].IndexOf(".")) + logPrefix : 
                fileValues[0].Substring(0, fileValues[0].IndexOf(",")) + logPrefix;

            string fullPath = Path.Combine(path, fileName);
            string contentWithTimeStamp = DateTime.Now + ": " + content;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                if (!File.Exists(fullPath))
                {
                    File.WriteAllText(fullPath, contentWithTimeStamp.ToString());
                }
            }
            using (StreamWriter sw = File.AppendText(fullPath))
            {
                sw.WriteLine(contentWithTimeStamp);
            }
        }

        //private static string LogText<T>(this T content, Action<T> logType)
        //{
        //    string path = @"C:\LogForPasswordManagement";
        //    string fileName = (logType.Method.Name.Equals("LogExceptionsToFile")) ? "LogFile.txt" : "LogRegularText.txt";
        //    string fullPath = Path.Combine(path, fileName);
        //    string contentWithTimeStamp = DateTime.Now + ": " + content;
            
        //    if (!Directory.Exists(path))
        //    {
        //        Directory.CreateDirectory(path);
        //        if (!File.Exists(fullPath))
        //        {
        //            File.WriteAllText(fullPath, contentWithTimeStamp.ToString());
        //            return contentWithTimeStamp;
        //        }
        //    }
        //    using (StreamWriter sw = File.AppendText(fullPath))
        //    {
        //        sw.WriteLine(contentWithTimeStamp);
        //    }
        //    return contentWithTimeStamp;
        //}
    }
}
