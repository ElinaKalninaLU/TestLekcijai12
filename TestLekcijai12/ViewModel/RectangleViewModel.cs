using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DBClasses;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLekcijai12.ViewModel
{
    [ObservableObject]
    public partial class RectangleViewModel
    {
        private IConfiguration _configuration { get; set; }
        private DBManager _dBManager { get; set; }
        public RectangleViewModel(IConfiguration configuration):base()
        {
            _configuration = configuration;
            _dBManager = new DBManager(_configuration["ConnectionStrings:MyDB"]);
            refresh();
        }

        [ObservableProperty]
        private int height = 4;

        [ObservableProperty]
        private int width = 3;

        [ObservableProperty]
        private string info = "";

        [ObservableProperty]
        private string submitButtonText = "Add Rectangle";

        [ObservableProperty]
        private ObservableCollection<Rectangle> rectangleList= new ObservableCollection<DBClasses.Rectangle>() { new DBClasses.Rectangle() { Height=1, Width=1} };

        [ObservableProperty]
        private DBClasses.Rectangle _selectedRectangle;

        private Rectangle UpdateRectangle = null;

        [RelayCommand]
        private void addRectangle()
        {
            if (UpdateRectangle is null)
            {
                Debug.WriteLine($"Rectangle {width}, {height}");
                _dBManager.AddRectangle(height, width);
                Info = "Rectangle Added";
            }
            else
            {
                UpdateRectangle.Height = Height;
                UpdateRectangle.Width = Width;
                _dBManager.Update();
                UpdateRectangle = null;
                _selectedRectangle = null;
                Info = "Rectangle updated!";
                SubmitButtonText = "Add Rectangle";
            }
            refresh();
        }

        [RelayCommand]
        private void refresh()
        {
         rectangleList.Clear();
            foreach (var r in _dBManager.GetRectangles())
            {
                rectangleList.Add(r);
            }
        }

        [RelayCommand]
        private void delete()
        {
            if (_selectedRectangle != null)
            {
                _dBManager.RemoveRectangle( _selectedRectangle );
                Info = "Rectangle deleted!";
                refresh();
            }
        }

        [RelayCommand]
        private void edit()
        {
            if (_selectedRectangle != null)
            {
                Width = _selectedRectangle.Width;
                Height = _selectedRectangle.Height;
                SubmitButtonText = "Update Rectangle";
                UpdateRectangle = _selectedRectangle;
            }
        }
    }
}
