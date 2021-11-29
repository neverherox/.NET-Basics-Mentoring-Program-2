using System;

namespace ClassLibrary1
{
    public static class Class1
    {
        public static string GetHello(string userName)
        {
            return $"{DateTime.Now} Hello {userName}!";
        }
    }
}
