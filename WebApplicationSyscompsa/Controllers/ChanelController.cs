using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationSyscompsa.Models;

namespace WebApplicationSyscompsa.Controllers
{
    [Route("api/Chanels")]
    [ApiController]
    public class ChanelController : ControllerBase
    {

        private readonly AppDbContext _context;
        public ChanelController(AppDbContext context)
        {
            this._context = context;
        }

        [HttpPost]
        [Route("saveChanels")]
        public async Task<IActionResult> savemensaje([FromBody] Chanels con)
        {
            if (ModelState.IsValid)
            {
                _context.chanels.Add(con);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return Ok(con);
                }

                else
                {
                    return BadRequest("Datos incorrectos");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}
