using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogHandler
{   
    public class LogsHandler
    {
        [JsonInclude]
        public DateTime Date { get; set; }
        [JsonInclude]
        public string ErrorMessage { get; set; }
        [JsonInclude]
        public string ErrorType { get; set; }
        [JsonInclude]
        public string ErrorFromClass { get; set; }
        [JsonInclude]
        public string ErrorFromMethod { get; set; }
        

        public LogsHandler()
        {
            ErrorType = string.Empty;
            ErrorMessage = string.Empty;
            Date = DateTime.Now;
            ErrorFromClass = string.Empty;
            ErrorFromMethod = string.Empty;
        }

        public LogsHandler(DateTime Date, string ErrorMessage, string ErrorType, string ErrorFromClass, string ErrorFromMethod)
        {
            this.Date = Date;
            this.ErrorMessage = ErrorMessage;
            this.ErrorType = ErrorType;
            this.ErrorFromClass = ErrorFromClass;
            this.ErrorFromMethod = ErrorFromMethod;
        }

        /// <summary>
        /// Log errors useful infos to get what's breaking everything
        /// </summary>
        /// <param name="ErrorMessage"></param>
        /// <param name="ErrorType"></param>
        /// <param name="ErrorFromClass"></param>
        /// <param name="ErrorFromMethod"></param>
        public static void ErrorLog(string ErrorMessage, string ErrorType, string ErrorFromClass, string ErrorFromMethod)
        {
            List <string> error= new List<string>();
            error.Add((DateTime.Now).ToString());
            error.Add ("Error Message: "+ErrorMessage);
            error.Add("Error Type: " + ErrorType);
            error.Add("Error Class: " + ErrorFromClass);
            error.Add("Error Method: " + ErrorFromMethod);
            error.Add("\n");
            LogsHandler errorJson = new LogsHandler(DateTime.Now, ErrorMessage, ErrorType, ErrorFromClass, ErrorFromMethod);
            WriteJSON(errorJson);
            if (WriteTXT(error))
                Console.WriteLine("You can check logs about your error in Logs.txt in your project.");
            else 
                Console.WriteLine("There was an error i couldn't write logs about the error.");
        }

        private static bool WriteTXT(List <string> error)
        {
            Console.Clear();
            try
            {
                string workingDirectory = Environment.CurrentDirectory;
                File.AppendAllLines(Directory.GetParent(workingDirectory).Parent.Parent.FullName + @"\Logs.txt",error);
                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex); }
            Console.ReadLine();
            return false;
        }
        private static bool WriteJSON(LogsHandler log)
        {
            Console.Clear();
            try
            {
                string workingDirectory = Environment.CurrentDirectory;
                File.AppendAllText(
                    Directory.GetParent(workingDirectory).Parent.Parent.FullName + @"\Logs.json",
                    JsonSerializer.Serialize(log, new JsonSerializerOptions {WriteIndented = true}));
                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex); }
            Console.ReadLine();
            return false;
        }
    }
}
