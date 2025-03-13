
using Microsoft.VisualBasic;
using System.Data;

class Task3
{
    static public class DataServis
    {
        static public string GetDay(string date)
        {
            string ans;

            DateTime parse = DateTime.Parse(date);

            ans = parse.ToString("dddd");

            return ans; 
        }

        static public int GetDaysSpan(int day, int month, int year)
        {

            DateTime usr = new DateTime(year, month, day);

            return (usr.Date - DateTime.Today).Days;
        }
    }
}