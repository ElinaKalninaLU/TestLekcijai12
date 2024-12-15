using DBClasses;
using Microsoft.Extensions.Configuration;

namespace Lekcija14
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public IConfiguration configuration { get; set; }

            public MainPage(IConfiguration _configuration)
        {
            configuration = _configuration;
            InitializeComponent();

        }




        private void OnCounterClicked(object sender, EventArgs e)
        {
          //  CounterBtn.Text = configuration["ConnectionStrings:MyDB"];
        var context = new GeometryContext(configuration["ConnectionStrings:MyDB"]);
     CounterBtn.Text = "Rectangles: " + context.Rectangles.Count().ToString();
    //count++;

            //if (count == 1)
            //    CounterBtn.Text = $"Clicked {count} time";
            //else
            //    CounterBtn.Text = $"Clicked {count} times";

            //SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
        {

        }
    }

}
