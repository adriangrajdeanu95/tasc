using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
    public static class Globals
    {
        public static List<TaskObject> TaskList;
        public static TaskObject CurrentTask { get; set; }

        public static DateTime WakeUpTime { get; set; }
        public static DateTime BedTime { get; set; }
        public static DateTime MondayStartTime { get; set; }
        public static DateTime MondayEndTime { get; set; }
        public static DateTime TuesdayStartTime { get; set; }
        public static DateTime TuesdayEndTime { get; set; }
        public static DateTime WednesdayStartTime { get; set; }
        public static DateTime WednesdayEndTime { get; set; }
        public static DateTime ThursdayStartTime { get; set; }
        public static DateTime ThursdayEndTime { get; set; }
        public static DateTime FridayStartTime { get; set; }
        public static DateTime FridayEndTime { get; set; }
        public static DateTime SaturdayStartTime { get; set; }
        public static DateTime SaturdayEndTime { get; set; }
        public static DateTime SundayStartTime { get; set; }
        public static DateTime SundayEndTime { get; set; }
}
}


