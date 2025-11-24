using To_do_List.Model;

namespace To_do_List.Interfaces
{
    public interface Itarea
    {
        public List<TareaModel> GetTareaModels();
        string Settarea(TareaModel model);
        string updatetarea(TareaModel model);
        string Deletetarea(int idtarea);
    }
}
