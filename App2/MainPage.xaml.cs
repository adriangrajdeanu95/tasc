﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace App2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;


            // adding functionality
            //
            //
            //
            //
            //
            //
            //
            Globals.TaskList = new TaskObject[1];
            Globals.TaskList[0] = new TaskObject();
            Globals.TaskList[0].TaskName = "random task name";
            Globals.TaskList[0].Description = "much random description";
            Globals.TaskList[0].StartDate = new DateTime(2016, 5, 12, 18, 0, 0);
            Globals.TaskList[0].EndDate = new DateTime(2016, 5, 12, 19, 0, 0);

            List<TaskObject> MainList = new List<TaskObject>();
            MainList.Add(Globals.TaskList[0]);
            MainList.Add(Globals.TaskList[0]);
            TodayList.ItemsSource = MainList;


            //
            //
            //
            //
            //
                        
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void FilterAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FilterPage));
        }

        private void AddAppBarButton_Click(object sender, RoutedEventArgs e)
        {

            Frame.Navigate(typeof(AddNewTask));
            this.Frame.Navigate(typeof(AddNewTask));
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(TaskPage));
        }

        private void Preferences_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Preferences));
        }
    }
}
