using TestLekcijai12.ViewModel;

namespace TestLekcijai12;

public partial class RectanglePage : ContentPage
{

    private IRectangleViewModel _vm;
    public RectanglePage(RectangleViewModel vm)
    // public RectanglePage(RectangleSQLiteViewModel vm)
    {
        _vm = vm;
        this.BindingContext = _vm;
        InitializeComponent();
    }
}