
namespace TestQuiz.GUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.ViewModels();
        }
    }
}
