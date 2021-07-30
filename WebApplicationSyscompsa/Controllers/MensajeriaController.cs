using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationSyscompsa.Models;

namespace WebApplicationSyscompsa.Controllers
{
    [Route("api/mensajeria")]
    [ApiController]
    public class MensajeriaController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MensajeriaController(AppDbContext context)
        {
            this._context = context;
        }

        [HttpPost]
        [Route("savemensaje")]
        public async Task<IActionResult> savemensaje([FromBody] Mensajeria con)
        {
            if (ModelState.IsValid) {
                _context.mensajeria.Add(con);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return Ok(con);
                }
                else
                {
                    return BadRequest("Datos incorrectos");
                }
            }
            else {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Route("delmensaje/{us}/{id}")]
        public ActionResult<DataTable> delmensaje([FromRoute] string us, [FromRoute] int id)
        {

            string Sentencia = "delete from mensajeria where usuario = @user and id = @id";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {

                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.Add(new SqlParameter( "@user", us ));
                adapter.SelectCommand.Parameters.Add(new SqlParameter( "@id",   id ));
                adapter.Fill(dt);
            
            }

            if (dt == null)
            {
                return NotFound("");
            }

            return Ok(dt);

        }


        //ESTO ES PROVICIONAL HASTA PROGRAMAR LOS CANALES
        [HttpGet]
        [Route("getMensaje")]
        public ActionResult<DataTable> getMensaje()
        {

            string Sentencia = "select top(25) * from mensajeria ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {

                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                //adapter.SelectCommand.Parameters.Add(new SqlParameter("@user", us));
                //adapter.SelectCommand.Parameters.Add(new SqlParameter("@id", id));
                adapter.Fill(dt);

            }

            if (dt == null)
            {
                return NotFound("");
            }

            return Ok(dt);

        }

    }
}
