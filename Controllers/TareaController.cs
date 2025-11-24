using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using To_do_List.Interfaces;
using To_do_List.Model;

namespace To_do_List.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly Itarea servicio;

        public TareaController(Itarea servicio)
        {
            this.servicio = servicio; 
        }

        [HttpGet]
        [Route("Vertareas")]
        public List<TareaModel> GetTareas()
        {
            return servicio.GetTareaModels();
        }

        [HttpPost]
        [Route("Agregartarea")]
        public ActionResult<string> Settarea(TareaModel model)
        {
            if (ModelState.IsValid)
            {
                string result = servicio.Settarea(model);
                return Ok(result);  
            }
            else
            {
                return BadRequest("Datos inválidos");
            }
        }

        


        [HttpPut]
        [Route("Actualizartarea")]
        public ActionResult<string> Updatetarea([FromBody] TareaModel model)
        {
            return servicio.updatetarea(model);
        }


        [HttpDelete]
        [Route("EliminarTarea")]
        public string Deletetarea(int idtarea)
        {
            return servicio.Deletetarea(idtarea);
        }
    }
}
