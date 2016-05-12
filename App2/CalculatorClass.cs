using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
    public class TruePriorityComparer : IComparer<TaskObject>
    {
        public int Compare(TaskObject x, TaskObject y)
        {
            return x.TruePriority.CompareTo(y.TruePriority);
        }
    }

    class CalculatorClass
    {
        TruePriorityComparer TPC = new TruePriorityComparer();

        public void ScheduleCalculate()
        {
            Array.Sort(Globals.TaskList, TPC);
            DateTime StartMoment = DateTime.Now;
            DateTime WeekDayStart = DateTime.Now, WeekDayEnd = DateTime.Now;
            int i;
            bool checker;

            for (i=0; i<Globals.TaskList.Length; i++)
            {
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

                checker = StartMoment.AddHours(Globals.TaskList[i].EstimatedTime).TimeOfDay > WeekDayStart.TimeOfDay;

                if (checker)
                {
                    StartMoment.AddHours(-StartMoment.Hour + WeekDayEnd.Hour);
                }

                checker = StartMoment.AddHours(Globals.TaskList[i].EstimatedTime).TimeOfDay < Globals.BedTime.TimeOfDay;

                if (checker)
                {
                    Globals.TaskList[i].StartDate = StartMoment;
                    Globals.TaskList[i].EndDate = Globals.TaskList[i].StartDate.AddHours(Globals.TaskList[i].EstimatedTime);

                    StartMoment = Globals.TaskList[i].EndDate.AddHours(1);
                }
                else
                {
                    StartMoment.AddHours(Globals.WakeUpTime.Hour-StartMoment.Hour);
                    StartMoment.AddMinutes(-StartMoment.Minute);
                    i--;
                }
            }
        }
    }
}
