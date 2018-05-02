using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MustDoX
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddTaskPage : ContentPage
	{
		public AddTaskPage ()
		{
			InitializeComponent ();
		}

        private void AddTask_Button_Clicked(object sender, EventArgs e)
        {
            Task task = new Task
            {
                Name = entryName.Text
            };
            
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Task>();
                var numberOfRows = conn.Insert(task);

                if(numberOfRows > 0)
                {
                    DisplayAlert("Success", "Task inserted!", "Great");
                }
                else
                {
                    DisplayAlert("Failure", "Task failed to be inserted!", "Dang It");
                }
            }
        }
	}
}