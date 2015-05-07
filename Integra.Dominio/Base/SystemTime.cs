using System;

namespace Integra.Dominio.Base
{
    public static class SystemTime
    {
        public static Func<DateTime> SetCurrentTime = () => DateTime.Now;

        public static DateTime Now
        {
            get
            {
                return SetCurrentTime();
            }
        }
    }
}