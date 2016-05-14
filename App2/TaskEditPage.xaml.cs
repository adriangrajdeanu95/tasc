using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace App2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TaskEditPage : Page
    {
        public TaskEditPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            TextBoxTitle.Text = Globals.CurrentTask.TaskName;
            TextBoxDescription.Text = Globals.CurrentTask.Description;
            newpriorityslider.Value = Globals.CurrentTask.UserPriority;
            DeadlinePicker.Date = Globals.CurrentTask.Deadline;
        }

        public async void ErrorMessage(string text)
        {
            MessageDialog msgbox = new MessageDialog(text);
            msgbox.Commands.Add(new UICommand("Ok"));
            await msgbox.ShowAsync();
        }

        public bool EditTask()
        {
            double aux1, aux2;
            if (string.IsNullOrWhiteSpace(TextBoxTitle.Text))
            {
                ErrorMessage("Error. Title empty.");
                return false;
            }
            Globals.CurrentTask.ChangeName(TextBoxTitle.Text);
            Globals.CurrentTask.ChangeDescription(TextBoxDescription.Text);
            Globals.CurrentTask.UserPriority = newpriorityslider.Value;
            double.TryParse(TextBoxHours.Text, out aux1);
            double.TryParse(TextBoxMinutes.Text, out aux2);
            if ((string.IsNullOrWhiteSpace(TextBoxHours.Text) || string.IsNullOrWhiteSpace(TextBoxMinutes.Text)) && aux2 > 59)
            {
                ErrorMessage("Error. Estimated time incorrectly set.");
                return false;
            }
            Globals.CurrentTask.EstimatedTime = aux1 + aux2 / 60;
            Globals.CurrentTask.AdditionDate = DateTime.Now;
            if (DeadlinePicker.Date.LocalDateTime < Globals.CurrentTask.AdditionDate)
            {
                ErrorMessage("Error. Deadline impossible.");
                return false;
            }
            Globals.CurrentTask.Deadline = new DateTime();
            Globals.CurrentTask.Deadline = DeadlinePicker.Date.LocalDateTime;
            //TO CALCULATE THE EXTRA PARAM - HELDUP HOURS

            Globals.CurrentTask.CalculateTruePriority(0);

            CalculatorClass.ScheduleCalculate();

            return true;
        }

        private void AddNewTaskButton_Click(object sender, RoutedEventArgs e)
        {

            if (Frame.CanGoBack && EditTask())
            {
                Frame.GoBack();
            }
        }

        private void canceltask_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                //e.Handled = true;
                Frame.GoBack();
            }
        }
    }
}
