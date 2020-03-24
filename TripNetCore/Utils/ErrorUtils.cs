using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripNetCore.Utils
{
    public class ErrorUtils
    {
        public static string dbErrorMessage(string text, Exception e)
        {
            bool showErrors = true;
            string errMessage = text;
            if (showErrors)
            {
                errMessage += "\n-->  " + e.Message;
                if (e.InnerException != null)
                {
                    errMessage += " and " + e.InnerException.Message;
                    if (e.InnerException.InnerException != null)
                    {
                        errMessage += " and " + e.InnerException.InnerException;
                    }
                }

            }
            return errMessage;
        }
    }
}
