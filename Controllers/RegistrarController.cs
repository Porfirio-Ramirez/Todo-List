using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using To_do_List.Model;

namespace To_do_List.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrarController : ControllerBase
    {
        private readonly IConfiguration confi;

        public RegistrarController(IConfiguration confi)
        {
            this.confi = confi;
        }

        [HttpPost]
        [Route("Registrar")]
        public IActionResult Registrar(RegistrarModel registro)
        {
            try
            {
                if (string.IsNullOrEmpty(registro.nombre) || string.IsNullOrEmpty(registro.usuario) || string.IsNullOrEmpty(registro.clave))
                {
                    return BadRequest(new { message = "Todos los campos son requeridos" });
                }

                using (SqlConnection con = new SqlConnection(this.confi.GetConnectionString("Appconnection").ToString()))
                {
                    con.Open();

                    
                    string query = "INSERT INTO registrar (nombre, usuario, clave) VALUES (@nombre, @usuario, @clave)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@nombre", registro.nombre);
                    cmd.Parameters.AddWithValue("@usuario", registro.usuario);
                    cmd.Parameters.AddWithValue("@clave", registro.clave);

                    int result = cmd.ExecuteNonQuery(); 

                    
                    if (result > 0)
                    {
                        return Ok(new { message = "Usuario registrado" });
                    }
                    else
                    {
                        return BadRequest(new { message = "No se pudo registrar el usuario" });
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = $"Datos no ingresados: {e.Message}" });
            }
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] RegistrarModel registro)
        {
            try
            {
               
                if (string.IsNullOrEmpty(registro.usuario) || string.IsNullOrEmpty(registro.clave))
                {
                    return BadRequest(new { message = "Usuario y clave son requeridos" });
                }

                using (SqlConnection con = new SqlConnection(this.confi.GetConnectionString("Appconnection").ToString()))
                {
                    con.Open();

                  
                    string query = "SELECT COUNT(1) FROM registrar WHERE usuario = @usuario AND clave = @clave";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@usuario", registro.usuario);
                    cmd.Parameters.AddWithValue("@clave", registro.clave);

                    int userExists = (int)cmd.ExecuteScalar(); 

                    if (userExists > 0) 
                    {
                        return Ok(new { message = "Login exitoso" });
                    }
                    else
                    {
                        return Unauthorized(new { message = "Usuario o clave incorrectos" });
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = $"Error al intentar iniciar sesión: {e.Message}" });
            }
        }
    }
}
