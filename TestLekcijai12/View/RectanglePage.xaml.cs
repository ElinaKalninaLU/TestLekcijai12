using TestLekcijai12.ViewModel;

namespace TestLekcijai12;

public partial class RectanglePage : ContentPage
{
	private RectangleViewModel _vm;

    public RectanglePage(RectangleViewModel vm)
	{
		_vm = vm;
		this.BindingContext = _vm;
		InitializeComponent();
	}
}