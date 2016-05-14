using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace App2
{

    public class PriorityComparer : IComparer<TaskObject>
    {
        public int Compare(TaskObject x, TaskObject y)
        {

            if (x.TruePriority > y.TruePriority)
                return -1;
            if (x == y)
                return 0;
            return 1;
        }
    }

    public class CalculatorClass
    {

        public static PriorityComparer TPC = new PriorityComparer();

        public static void ScheduleCalculate()
        {
            Globals.TaskList.Sort(TPC);
            DateTime StartMoment = new DateTime();
            StartMoment = DateTime.Now;
            DateTime WeekDayStart = DateTime.Now, WeekDayEnd = DateTime.Now;
            bool checker;
            int y, m, d, h, n, s;

            foreach(TaskObject element in Globals.TaskList)
            {
                backpoint:;
                switch (StartMoment.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        WeekDayStart = Globals.MondayStartTime;
                        WeekDayEnd = Globals.MondayEndTime;
                        break;
                    case DayOfWeek.Tuesday:
                        WeekDayStart = Globals.TuesdayStartTime;
                        WeekDayEnd = Globals.TuesdayEndTime;
                        break;
                    case DayOfWeek.Wednesday:
                        WeekDayStart = Globals.WednesdayStartTime;
                        WeekDayEnd = Globals.WednesdayEndTime;
                        break;
                    case DayOfWeek.Thursday:
                        WeekDayStart = Globals.ThursdayStartTime;
                        WeekDayEnd = Globals.ThursdayEndTime;
                        break;
                    case DayOfWeek.Friday:
                        WeekDayStart = Globals.FridayStartTime;
                        WeekDayEnd = Globals.FridayEndTime;
                        break;
                    case DayOfWeek.Saturday:
                        WeekDayStart = Globals.SaturdayStartTime;
                        WeekDayEnd = Globals.SaturdayEndTime;
                        break;
                    case DayOfWeek.Sunday:
                        WeekDayStart = Globals.SundayStartTime;
                        WeekDayEnd = Globals.SundayEndTime;
                        break;
                }

                checker = true;

                checker = StartMoment.TimeOfDay < Globals.WakeUpTime.TimeOfDay;

                if (checker)
                {
                    //StartMoment.AddHours(Globals.WakeUpTime.Hour - StartMoment.Hour);
                    y = StartMoment.Year;
                    m = StartMoment.Month;
                    d = StartMoment.Day;
                    h = Globals.WakeUpTime.Hour;
                    n = 0;
                    s = 0;
                    StartMoment = new DateTime(y,m,d,h,n,s);
                }

                checker = StartMoment.AddHours(element.EstimatedTime).TimeOfDay > WeekDayStart.TimeOfDay && StartMoment.TimeOfDay < WeekDayEnd.TimeOfDay;

                if (checker)
                {
                    //StartMoment.AddHours(-StartMoment.Hour + WeekDayEnd.Hour);
                    y = StartMoment.Year;
                    m = StartMoment.Month;
                    d = StartMoment.Day;
                    h = WeekDayEnd.Hour;
                    n = 0;
                    s = 0;
                    StartMoment = new DateTime(y, m, d, h, n, s);
                }

                checker = StartMoment.AddHours(element.EstimatedTime).TimeOfDay < Globals.BedTime.TimeOfDay;

                if (checker)
                {
                    element.StartDate = StartMoment;
                    element.EndDate = element.StartDate.AddHours(element.EstimatedTime);

                    y = element.EndDate.Year;
                    m = element.EndDate.Month;
                    d = element.EndDate.Day;
                    h = element.EndDate.Hour+1;
                    n = element.EndDate.Minute;
                    s = element.EndDate.Second;

                    StartMoment = new DateTime(y, m, d, h, n, s);
                }
                else
                {
                    //StartMoment.AddHours(Globals.WakeUpTime.Hour-StartMoment.Hour);
                    //StartMoment.AddMinutes(-StartMoment.Minute);
                    y = StartMoment.Year;
                    m = StartMoment.Month;
                    d = StartMoment.Day+1;
                    h = Globals.WakeUpTime.Hour;
                    n = 0;
                    s = 0;
                    StartMoment = new DateTime(y, m, d, h, n, s);
                    goto backpoint;
                }
            }
        }
    }
}
