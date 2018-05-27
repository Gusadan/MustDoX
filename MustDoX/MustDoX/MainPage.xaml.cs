using System;
using System.Collections.Generic;
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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using(SQLite.SQLiteConnection sQLiteConnection = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                sQLiteConnection.CreateTable<Task>();

                var tasks = sQLiteConnection.Table<Task>().ToList();
                listViewTaks.ItemsSource = tasks;
            }
        }

        private void Add_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddTaskPage());
        }

        private void FloatingActionButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddTaskPage());
        }

    }
}
