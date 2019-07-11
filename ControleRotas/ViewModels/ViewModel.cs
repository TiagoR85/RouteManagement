namespace ControleRotas.ViewModels
{
    public class ViewModel : IViewModel
    {
        public dynamic Model { get; set; }
        public dynamic ListModel { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string TitleBox { get; set; }
        public string Error { get; set; }
    }
}