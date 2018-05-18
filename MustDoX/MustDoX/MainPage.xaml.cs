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

        private void Add_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddTaskPage());
        }

        private void FloatingActionButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Whew", "Ayos", "wen");
        }

    }
}
