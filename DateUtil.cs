namespace LegacyCode_Kab
{
    public class DateUtil
    {

        public string conv(string d, int t)
        {
            string res = "";
            if (t == 1)
            {
                if (d.Length != 10) return "ERR";
                if (d[2] != '/' || d[5] != '/') return "ERR";
                string day = d.Substring(0, 2);
                string month = d.Substring(3, 2);
                string year = d.Substring(6, 4);
                if (!isVal(day, month, year)) return "ERR";
                res = month + "/" + day + "/" + year;
            }
            else if (t == 2)
            {
                if (d.Length != 10) return "ERR";
                if (d[2] != '/' || d[5] != '/') return "ERR";
                string month = d.Substring(0, 2);
                string day = d.Substring(3, 2);
                string year = d.Substring(6, 4);
                if (!isVal(day, month, year)) return "ERR";
                res = day + "/" + month + "/" + year;
            }
            else
            {
                res = "ERR";
            }
            return res;
        }

        private bool isVal(string x, string y, string z)
        {
            try
            {
                int dd = int.Parse(x);
                int mm = int.Parse(y);
                int yyyy = int.Parse(z);
                if (dd < 1 || dd > 31) return false;
                if (mm < 1 || mm > 12) return false;
                if (yyyy < 1900 || yyyy > 2100) return false;
                DateTime dt = new DateTime(yyyy, mm, dd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string getDay(string d)
        {
            if (d.Length != 10) return "ERR";
            if (d[2] != '/' || d[5] != '/') return "ERR";
            string day = d.Substring(0, 2);
            string month = d.Substring(3, 2);
            string year = d.Substring(6, 4);
            if (!isVal(day, month, year)) return "ERR";
            int dd = int.Parse(day);
            int mm = int.Parse(month);
            int yyyy = int.Parse(year);
            DateTime dt = new DateTime(yyyy, mm, dd);
            return dt.DayOfWeek.ToString();
        }

        public int calcDiff(string d1, string d2)
        {
            if (d1.Length != 10 || d2.Length != 10) return -1;
            if (d1[2] != '/' || d1[5] != '/' || d2[2] != '/' || d2[5] != '/') return -1;
            string day1 = d1.Substring(0, 2);
            string month1 = d1.Substring(3, 2);
            string year1 = d1.Substring(6, 4);
            string day2 = d2.Substring(0, 2);
            string month2 = d2.Substring(3, 2);
            string year2 = d2.Substring(6, 4);
            if (!isVal(day1, month1, year1) || !isVal(day2, month2, year2)) return -1;
            DateTime dt1 = new DateTime(int.Parse(year1), int.Parse(month1), int.Parse(day1));
            DateTime dt2 = new DateTime(int.Parse(year2), int.Parse(month2), int.Parse(day2));
            return Math.Abs((dt2 - dt1).Days);
        }

        public string addDays(string d, int n)
        {
            if (d.Length != 10) return "ERR";
            if (d[2] != '/' || d[5] != '/') return "ERR";
            string day = d.Substring(0, 2);
            string month = d.Substring(3, 2);
            string year = d.Substring(6, 4);
            if (!isVal(day, month, year)) return "ERR";
            DateTime dt = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
            dt = dt.AddDays(n);
            string dd = dt.Day.ToString().PadLeft(2, '0');
            string mm = dt.Month.ToString().PadLeft(2, '0');
            string yyyy = dt.Year.ToString();
            return dd + "/" + mm + "/" + yyyy;
        }

        public bool isLeap(string y)
        {
            int yyyy = int.Parse(y);
            if (yyyy % 4 == 0)
            {
                if (yyyy % 100 == 0)
                {
                    if (yyyy % 400 == 0) return true;
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
