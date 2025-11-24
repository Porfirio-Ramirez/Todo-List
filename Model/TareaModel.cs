using System.ComponentModel.DataAnnotations;

namespace To_do_List.Model
{
    public class TareaModel
    {
        [Key]
        public int idtarea { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }
    }
}
