using microservice2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace microservice2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly ClassDbContext _context;

        public ClassController(ClassDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Class>>> Get()
        {
            return Ok(await _context.Clases.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Class>> Get(int id)
        {
            var cl = await _context.Clases.FindAsync(id);
            //ClassProcessor.LoadClass();
            if (cl == null)
            {
                return BadRequest("Student not found.");
            }
            return Ok(cl);
        }

        [HttpPost]
        public async Task<ActionResult<List<Class>>> AddClass(Class cl)
        {
            _context.Add(cl);
            await _context.SaveChangesAsync();

            return Ok(await _context.Clases.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Class>>> UpdateStudent(Class request)
        {
            var cl = await _context.Clases.FindAsync(request.Id);
            if (cl == null)
            {
                return BadRequest("Student not found");
            }

            cl.Name = request.Name;
            cl.IdStudent = request.IdStudent;

            await _context.SaveChangesAsync();

            return Ok(await _context.Clases.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Class>>> Delete(int id)
        {
            var cl = await _context.Clases.FindAsync(id);
            if (cl == null)
            {
                return BadRequest("Student not found");
            }

            _context.Clases.Remove(cl);
            await _context.SaveChangesAsync();

            return Ok(await _context.Clases.ToListAsync());
        }
    }
}
