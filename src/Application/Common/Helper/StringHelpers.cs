using System.Globalization;

namespace Entekhab.Salary.Application.Common.Helper;

public static class StringHelpers
{
    public static DateTime ConvertPersianToGeorgian(this string persianDate)
    {
        if (persianDate.Length != 8)
        {
            throw new ArgumentException("Invalid Persian date format.");
        }
        int year = int.Parse(persianDate.Substring(0, 4));
        int month = int.Parse(persianDate.Substring(4, 2));
        int day = int.Parse(persianDate.Substring(6, 2));

        PersianCalendar persianCalendar = new PersianCalendar();
        DateTime dateTime = persianCalendar.ToDateTime(year, month, day, 0, 0, 0, 0);

        return dateTime;
    }
}