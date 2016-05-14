using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace App2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public ObservableCollection<TaskObject> ItemListsDay { get; set; }
        public ObservableCollection<TaskObject> ItemListsWeek { get; set; }
        public ObservableCollection<TaskObject> ItemListsAll { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            Globals.TaskList = new List<TaskObject>();
            Globals.CurrentTask = new TaskObject();
            Globals.WakeUpTime = new DateTime(1, 1, 1, 8, 0, 0);
            Globals.BedTime = new DateTime(1, 1, 1, 22, 0, 0);
            Globals.MondayStartTime = new DateTime(1, 1, 1, 9, 0, 0);
            Globals.MondayEndTime = new DateTime(1, 1, 1, 17, 0, 0);
            Globals.TuesdayStartTime = new DateTime(1, 1, 1, 9, 0, 0);
            Globals.TuesdayEndTime = new DateTime(1, 1, 1, 17, 0, 0);
            Globals.WednesdayStartTime = new DateTime(1, 1, 1, 9, 0, 0);
            Globals.WednesdayEndTime = new DateTime(1, 1, 1, 17, 0, 0);
            Globals.ThursdayStartTime = new DateTime(1, 1, 1, 9, 0, 0);
            Globals.ThursdayEndTime = new DateTime(1, 1, 1, 17, 0, 0);
            Globals.FridayStartTime = new DateTime(1, 1, 1, 9, 0, 0);
            Globals.FridayEndTime = new DateTime(1, 1, 1, 17, 0, 0);
            Globals.SaturdayStartTime = new DateTime(1, 1, 1, 9, 0, 0);
            Globals.SaturdayEndTime = new DateTime(1, 1, 1, 17, 0, 0);
            Globals.SundayStartTime = new DateTime(1, 1, 1, 9, 0, 0);
            Globals.SundayEndTime = new DateTime(1, 1, 1, 17, 0, 0);
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

            ItemListsDay = new ObservableCollection<TaskObject>();
            ItemListsWeek = new ObservableCollection<TaskObject>();
            ItemListsAll = new ObservableCollection<TaskObject>();
            foreach (TaskObject element in Globals.TaskList)
            {
                if (element.StartDate.DayOfWeek == DateTime.Now.DayOfWeek)
                    ItemListsDay.Add(element);
            }

            foreach (TaskObject element in Globals.TaskList)
            {
                if ((element.StartDate - DateTime.Now).TotalDays < 7)
                    ItemListsWeek.Add(element);
            }
            foreach (TaskObject element in Globals.TaskList)
            {
                    ItemListsAll.Add(element);
            }

            TodayList.ItemsSource = ItemListsDay;
            WeekList.ItemsSource = ItemListsWeek;
            ALLList.ItemsSource = ItemListsAll;
        }

        private void FilterAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FilterPage));
        }

        private void AddAppBarButton_Click(object sender, RoutedEventArgs e)
        {

            this.Frame.Navigate(typeof(AddNewTask));
        }

        public void ChangeCurrentTask(TaskObject parameter)
        {
            Globals.CurrentTask = parameter;
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            TaskObject current = new TaskObject();
            current = (TaskObject)e.ClickedItem;
            ChangeCurrentTask(current);
            Frame.Navigate(typeof(TaskPage));
        }

        private void Preferences_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Preferences));
        }
    }
}
