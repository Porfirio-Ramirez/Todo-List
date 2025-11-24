using To_do_List.Contexto;
using To_do_List.Interfaces;
using To_do_List.Model;
using Microsoft.EntityFrameworkCore;
namespace To_do_List.services
{
    public class TareaServicio : Itarea
    {
        private readonly TareaContexto context;

        public TareaServicio(TareaContexto context)
        {
            this.context = context;
        }

        public string Deletetarea(int idtarea)
        {
            try
            {
                var eliminar = context.tarea.Find(idtarea);
                context.tarea.Remove(eliminar);
                context.SaveChanges();
                return $"Tarea eliminada";
            }catch (Exception e)
            {
                return $"No se elimino {e.Message}";
            }
           
        }

        public List<TareaModel> GetTareaModels()
        {
            return context.tarea.ToList();
        }

        public string Settarea(TareaModel model)
        {
            try
            {
                context.tarea.Add(model);
                context.SaveChanges();
                return $"Tarea agregada correctamente";
            }catch (Exception e)
            {
                return $"Error al agregar tarea {e.Message}";
            }
           

        }

        public string updatetarea(TareaModel model)
        {
            try
            {
                context.Entry(model).State = EntityState.Modified;
                context.SaveChanges();
                return $"Tarea modificada";
            }catch (Exception e)
            {
                return $"No se pudo modificar datos {e.Message}";

            }
        }
    }
}
