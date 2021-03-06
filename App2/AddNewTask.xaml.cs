﻿using System;
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
using Windows.UI.Popups;

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

        public async void ErrorMessage(string text)
        {
            MessageDialog msgbox = new MessageDialog(text);
            msgbox.Commands.Add(new UICommand("Ok"));
            await msgbox.ShowAsync();
        }

        public bool AddANewTask()
        {
            TaskObject VAR = new TaskObject();
            double aux1, aux2;
            if (string.IsNullOrWhiteSpace(TextBoxTitle.Text))
            {
                ErrorMessage("Error. Title empty.");
                return false;
            }
            VAR.ChangeName(TextBoxTitle.Text);
            VAR.ChangeDescription(TextBoxDescription.Text);
            VAR.UserPriority = newpriorityslider.Value;
            double.TryParse(TextBoxHours.Text, out aux1);
            double.TryParse(TextBoxMinutes.Text, out aux2);
            if ((string.IsNullOrWhiteSpace(TextBoxHours.Text) || string.IsNullOrWhiteSpace(TextBoxMinutes.Text)) && aux2>59)
            {
                ErrorMessage("Error. Estimated time incorrectly set.");
                return false;
            }
            VAR.EstimatedTime = aux1 + aux2 / 60;
            VAR.AdditionDate = DateTime.Now;
            if (DeadlinePicker.Date.LocalDateTime < VAR.AdditionDate)
            {
                ErrorMessage("Error. Deadline impossible.");
                return false;
            }
            VAR.Deadline = new DateTime();
            VAR.Deadline = DeadlinePicker.Date.LocalDateTime;
            //TO CALCULATE THE EXTRA PARAM - HELDUP HOURS

            VAR.CalculateTruePriority(0);

            Globals.TaskList.Add(VAR);
            //UtilityClass.DataToText();

            CalculatorClass.ScheduleCalculate();

            return true;
        }



        private void AddNewTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack && AddANewTask())
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
