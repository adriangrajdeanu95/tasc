using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
    public static class Globals
    {
        public static TaskObject[] TaskList;
        public static TaskObject CurrentTask { get; set; }

        public static DateTime WakeUpTime = new DateTime(1, 1, 1, 8, 0, 0);
        public static DateTime BedTime = new DateTime(1, 1, 1, 22, 0, 0);
        public static DateTime MondayStartTime = new DateTime(1, 1, 1, 9, 0, 0);
        public static DateTime MondayEndTime = new DateTime(1, 1, 1, 17, 0, 0);
        public static DateTime TuesdayStartTime = new DateTime(1, 1, 1, 9, 0, 0);
        public static DateTime TuesdayEndTime = new DateTime(1, 1, 1, 17, 0, 0);
        public static DateTime WednesdayStartTime = new DateTime(1, 1, 1, 9, 0, 0);
        public static DateTime WednesdayEndTime = new DateTime(1, 1, 1, 17, 0, 0);
        public static DateTime ThursdayStartTime = new DateTime(1, 1, 1, 9, 0, 0);
        public static DateTime ThursdayEndTime = new DateTime(1, 1, 1, 17, 0, 0);
        public static DateTime FridayStartTime = new DateTime(1, 1, 1, 9, 0, 0);
        public static DateTime FridayEndTime = new DateTime(1, 1, 1, 17, 0, 0);
        public static DateTime SaturdayStartTime = new DateTime(1, 1, 1, 9, 0, 0);
        public static DateTime SaturdayEndTime = new DateTime(1, 1, 1, 17, 0, 0);
        public static DateTime SundayStartTime = new DateTime(1, 1, 1, 9, 0, 0);
        public static DateTime SundayEndTime = new DateTime(1, 1, 1, 17, 0, 0);
    }
}


