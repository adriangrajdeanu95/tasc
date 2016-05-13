﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
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
    public sealed partial class Preferences : Page
    {
        public Preferences()
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

            TextBoxWake.Text = Globals.WakeUpTime.ToString("HH");
            TextBoxSleep.Text = Globals.BedTime.ToString("HH");
            TextBoxMondayS.Text = Globals.MondayStartTime.ToString("HH");
            TextBoxMondayE.Text = Globals.MondayEndTime.ToString("HH");
            TextBoxTuesdayS.Text = Globals.TuesdayStartTime.ToString("HH");
            TextBoxTuesdayE.Text = Globals.TuesdayEndTime.ToString("HH");
            TextBoxWednesdayS.Text = Globals.WednesdayStartTime.ToString("HH");
            TextBoxWednesdayE.Text = Globals.WednesdayEndTime.ToString("HH");
            TextBoxThursdayS.Text = Globals.ThursdayStartTime.ToString("HH");
            TextBoxThursdayE.Text = Globals.ThursdayEndTime.ToString("HH");
            TextBoxFridayS.Text = Globals.FridayStartTime.ToString("HH");
            TextBoxFridayE.Text = Globals.FridayEndTime.ToString("HH");
            TextBoxSaturdayS.Text = Globals.SaturdayStartTime.ToString("HH");
            TextBoxSaturdayE.Text = Globals.SaturdayEndTime.ToString("HH");
            TextBoxSundayS.Text = Globals.SundayStartTime.ToString("HH");
            TextBoxSundayE.Text = Globals.SundayEndTime.ToString("HH");
        }

        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                e.Handled = true;
                Frame.GoBack();
            }
        }

        private void SavePreferences_Click(object sender, RoutedEventArgs e)
        {
            //save preferences
        }

        private void cancelprefs_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void PrefInfoRoutine_Tapped(object sender, TappedRoutedEventArgs e)
        {

            MessageDialog msgbox = new MessageDialog("Here you can set the usual hours you wake up or go to sleep everyday.");
            msgbox.Commands.Add(new UICommand("Ok"));
            await msgbox.ShowAsync();
        }

        private async void PrefInfoSchedule_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MessageDialog msgbox = new MessageDialog("Here you can set the hours at which you begin and end your work, for each day of the week.");
            msgbox.Commands.Add(new UICommand("Ok"));
            await msgbox.ShowAsync();
        }
    }
}
