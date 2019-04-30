namespace ControleRotas.ViewModels
{
    public interface IViewModel
    {
        dynamic Model { get; set; }
        dynamic ListModel { get; }
        string Action { get; set; }
        string ControllerName { get; set; }
        string NameTableModels { get; set; }
        string TitleBox { get; set; }
    }
}
