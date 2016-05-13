using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Phone.UI.Input;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace App2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddNewTask : Page
    {
        public AddNewTask()
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
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        TaskObject VAR = new TaskObject();
        double aux1, aux2;

        private void AddNewTaskButton_Click(object sender, RoutedEventArgs e)
        {
            VAR.ChangeName(TextBoxTitle.Text);
            VAR.ChangeDescription(TextBoxDescription.Text);
            VAR.UserPriority = newpriorityslider.Value;
            //VAR.Deadline = Convert.ToDateTime(Deadline.Date);
            double.TryParse(TextBoxHours.Text, out aux1);
            double.TryParse(TextBoxMinutes.Text, out aux2);
            VAR.EstimatedTime = aux1+aux2/60;
            VAR.AdditionDate = DateTime.Now;
            VAR.Deadline = new DateTime(2016, 6, 1, 0, 0, 0);
            //TO CALCULATE THE EXTRA PARAM - HELDUP HOURS

            VAR.CalculateTruePriority(0);

           // Array.Resize(ref Globals.TaskList, Globals.TaskList.Length + 1);
          //  Globals.TaskList[Globals.TaskList.Length-1] = VAR;

          //  CalculatorClass.ScheduleCalculate();

            string parameter = "true";

            this.Frame.Navigate(typeof(MainPage), parameter);
        }

        private void canceltask_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                //e.Handled = true;
                Frame.GoBack();
            }
        }

        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                e.Handled = true;
                Frame.GoBack();
            }
        }

    }
}
