using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            DateTime StartMoment = DateTime.Now;
            DateTime WeekDayStart = DateTime.Now, WeekDayEnd = DateTime.Now;
            bool checker;

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

                checker = StartMoment.AddHours(element.EstimatedTime).TimeOfDay > WeekDayStart.TimeOfDay;

                if (checker)
                {
                    StartMoment.AddHours(-StartMoment.Hour + WeekDayEnd.Hour);
                }

                checker = StartMoment.AddHours(element.EstimatedTime).TimeOfDay < Globals.BedTime.TimeOfDay;

                if (checker)
                {
                    element.StartDate = StartMoment;
                    element.EndDate = element.StartDate.AddHours(element.EstimatedTime);

                    StartMoment = element.EndDate.AddHours(1);
                }
                else
                {
                    StartMoment.AddHours(Globals.WakeUpTime.Hour-StartMoment.Hour);
                    StartMoment.AddMinutes(-StartMoment.Minute);
                    goto backpoint;
                }
            }
        }
    }
}
