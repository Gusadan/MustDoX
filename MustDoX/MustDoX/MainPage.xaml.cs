using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MustDoX
{
	public partial class MainPage : ContentPage
	{
        Task taskSelected;

		public MainPage()
		{
			InitializeComponent();
            listViewTasks.ItemSelected += ListViewTasks_ItemSelected;
            taskSelected = null;
		}

        private void ListViewTasks_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            taskSelected = (Task)e.SelectedItem;
            Debug.WriteLine(taskSelected.Name);
        }

        private async void ButtonTest_Clicked(object sender, EventArgs e)
        {
            Debug.Write("Text", "Test");
            await listViewTasks.FadeTo(1, 3000);
            Debug.Write("Visible", listViewTasks.IsVisible.ToString());
        }

        private void ListViewTasks_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            reloadListViewTasks();
        }

        private void FloatingActionButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddTaskPage());
        }

        private void buttonDelete_Clicked(object sender, EventArgs e)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Task>();
                var numberOfRows = conn.Delete(taskSelected);
            }
            reloadListViewTasks();
        }

        private void reloadListViewTasks()
        {
            using (SQLite.SQLiteConnection sQLiteConnection = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                sQLiteConnection.CreateTable<Task>();

                var tasks = sQLiteConnection.Table<Task>().ToList();
                listViewTasks.ItemsSource = tasks;
            }
        }
    }
}
