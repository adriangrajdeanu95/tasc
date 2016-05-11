using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace App2
{
    public class TaskObject
    {
        int TaskIndex;
        string TaskName, Description;
        DateTime Deadline, AdditionDate;
        DateTime StartDate, EndDate;
        int UserPriority, EstimatedTimeHours, EstimatedTimeMinutes;
        int TruePriority;

        //int Category;


        //constructor
        public TaskObject()
        {
            TaskName = "Unknown";
        }

        /*
	^Associated Functions
	Creation
	Destruction
	List – Add
	Calls the rescheduling function adding this new variable
	Returns new list
	List – Remove
	Removes variable from list
	Calls rescheduling function
	List – Validate
	Adds variable to history/archive list
	Calls the remove function
	Change:
	Description
	Priority
•	Also recalculates real priority
•	Calls rescheduling function
	Deadline
•	Also recalculates real priority
•	Calls rescheduling function
	ETF
•	Also recalculates real priority
•	Calls rescheduling function
	Move to undone
	Move from undone
         */
    }

    
}