using DBClasses;
using Microsoft.Extensions.Configuration;

namespace TestLekcijai12
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
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void DBBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                var dbM = new DBManager(configuration["ConnectionStrings:MyDB"]);
                dbM.AddRectangle(6, 5);
                DBBtn.Text = dbM.GetRectangles().Count.ToString();
            }
            catch (Exception ex)
            {
                DBBtn.Text = $"Error: {ex.Message}";
            }
        }
    }

}
