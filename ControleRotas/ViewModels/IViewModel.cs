namespace ControleRotas.ViewModels
{
    public interface IViewModel
    {
        dynamic Model { get; set; }
        dynamic ListModel { get; }
        string ActionName { get; set; }
        string ControllerName { get; set; }
        string TitleBox { get; set; }
    }
}
