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
            listViewTasks.ItemSelected += ListViewTasks_ItemSelected;
		}

        private void ListViewTasks_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Task task = (Task)e.SelectedItem;
            Debug.WriteLine(task.Name);

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
