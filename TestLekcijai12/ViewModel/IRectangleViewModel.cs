using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommonClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TestLekcijai12.ViewModel
{
    public interface IRectangleViewModel
    {
        int Width { get; set; }
        int Height { get; set; }
        string Info { get; set; }
        string SubmitButtonText { get; set; }
        ObservableCollection<IRectangle> RectangleList { get; set; }
        IRectangle SelectedRectangle { get; set; }
        bool IsDeleteVisible {  get; set; }

        IRelayCommand addRectangleCommand { get; }

        IRelayCommand deleteCommand { get; }

        IRelayCommand itemSelectedCommand { get; }

    }
}
