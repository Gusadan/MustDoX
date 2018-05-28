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
		public MainPage()
		{
			InitializeComponent();
		}

        private void ListViewTasks_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Task task = (Task)e.Item;
            Debug.WriteLine(task.Name);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using(SQLite.SQLiteConnection sQLiteConnection = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                sQLiteConnection.CreateTable<Task>();

                var tasks = sQLiteConnection.Table<Task>().ToList();
                listViewTasks.ItemsSource = tasks;
            }
        }

        private void FloatingActionButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddTaskPage());
        }

    }
}
