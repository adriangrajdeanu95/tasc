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
        string TaskName, Description;
        DateTime Deadline, AdditionDate;
        DateTime StartDate, EndDate;
        double UserPriority, EstimatedTime, Sessions;
        double TruePriority;
        int Type;
        int[] CloneIndexes;
        //int Category;


        //constructor
        public TaskObject()
        {
            TaskName = "Unknown";
        }

        public void CalculateTruePriority(double ExtraParam)
        {
            double numerator, denominator;

            numerator = UserPriority * EstimatedTime;
            denominator = ((Deadline - DateTime.Now).TotalHours - ExtraParam) * Sessions;

            TruePriority = numerator / denominator;
        }

        public void ChangeName(string NewString)
        {
            TaskName = NewString;
        }

        public void ChangeDescription(string NewString)
        {
            Description = NewString;
        }

        public void ChangeDeadLine(DateTime NewDL, double ExtraParam)
        {
            Deadline = NewDL;
            CalculateTruePriority(ExtraParam);
        }

        public void ChangeUserPriority(double NewPrio, double ExtraParam)
        {
            UserPriority = NewPrio;
            CalculateTruePriority(ExtraParam);
        }

        public void ChangeEstimation(double NewETA, double ExtraParam)
        {
            EstimatedTime = NewETA;
            CalculateTruePriority(ExtraParam);
        }

        public void ChangeSessions(double NewSes, double ExtraParam)
        {
            Sessions = NewSes;
            CalculateTruePriority(ExtraParam);
        }

        public TaskObject CopyData()
        {
            TaskObject var = (TaskObject) this.MemberwiseClone();

            var.TaskName = TaskName;
            var.Description = Description;
            var.Deadline = Deadline;
            var.AdditionDate = AdditionDate;
            var.UserPriority = UserPriority;
            var.EstimatedTime = EstimatedTime;
            var.Sessions = Sessions;
            var.TruePriority = TruePriority;
            var.StartDate = StartDate;
            var.EndDate = EndDate;

            return var;
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