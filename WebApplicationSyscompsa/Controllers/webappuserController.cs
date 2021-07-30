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
    [Route("api/Webappuser")]
    [ApiController]
    public class Webappuser : ControllerBase
    {
        private readonly AppDbContext _context;
        public Webappuser(AppDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("getwebappuser/{us}/{id}")]
        public ActionResult<DataTable> gettransprod( [FromRoute] string us, [FromRoute] int id )
        {

            string Sentencia = "select * from webappuser where usuario = @us and id = @id ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@us", us));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@id", id));
                adapter.Fill(dt);
            }

            if (dt == null) {
                return NotFound("");
            }

            return Ok(dt);

        }

        [HttpPost]
        [Route("savewebappuser")]
        public async Task<IActionResult> savewebappuser([FromBody] Webappusers con)
        {

            var result = await _context.webappuser.FirstOrDefaultAsync(x => x.usuario == con.usuario );

            if (result != null) {                
                return BadRequest("Datos repetidos");
            }

            else {

                if (ModelState.IsValid) {

                    _context.webappuser.Add(con);

                    if (await _context.SaveChangesAsync() > 0) {                        
                        return Ok(con);                        
                    }

                    else {
                        return BadRequest("Datos incorrectos");
                    }

                }

                else {
                    return BadRequest(ModelState);
                }

            }



        }

    }

}
