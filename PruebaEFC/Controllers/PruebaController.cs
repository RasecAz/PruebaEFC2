using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaEFC.Entidades;

namespace PruebaEFC.Controllers
{
    [ApiController]
    [Route("api/AddPrueba")]
    public class PruebaController : ControllerBase
    {
        private readonly ApplicationDbContex _dbContex;

        public PruebaController(ApplicationDbContex dbContex)
        {
            _dbContex = dbContex;
        }
        [HttpPost]
        public async Task<ActionResult> Post(Prueba prueba)
        {
            _dbContex.Add(prueba);
            await _dbContex.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prueba>>> Get()
        {
            return await _dbContex.Pruebas.ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Prueba prueba)
        {
            if(id != prueba.Id)
            {
                return BadRequest();
            }
            _dbContex.Entry(prueba).State = EntityState.Modified;
            await _dbContex.SaveChangesAsync();
            return Ok();
           

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _dbContex.Pruebas.Where(d => d.Id == id).ExecuteDeleteAsync();

            if(result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

    }
}
