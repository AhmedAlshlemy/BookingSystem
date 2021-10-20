using System;
using System.Net.Mail;

namespace BAL.Helper
{
    public static class EmailHelper
    {
       
        public static bool SendEmail(string UserEmail, string Subject, string Message)
        {
            System.Console.WriteLine(Message);
            return true;
        }
    }
}
