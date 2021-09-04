using System;
using System.Runtime.InteropServices;

namespace Finances.Business.Shared.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTime UtcBrazil(this DateTime dateTime)
        {
            bool isLinux = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

            var tzi = TimeZoneInfo.FindSystemTimeZoneById(isLinux ? "America/Sao_Paulo" : "E. South America Standard Time");
            return TimeZoneInfo.ConvertTime(dateTime, tzi);
        }
    }
}
