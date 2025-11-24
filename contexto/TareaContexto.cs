using Microsoft.EntityFrameworkCore;
using To_do_List.Interfaces;
using To_do_List.Model;

namespace To_do_List.Contexto
{
    public class TareaContexto : DbContext
    {
        public TareaContexto(DbContextOptions<TareaContexto> db): base(db)
        {
        }

       public DbSet<TareaModel> tarea { get; set; }
    }
}
