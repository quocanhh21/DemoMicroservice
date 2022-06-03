using Confluent.Kafka;
using microservice2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace microservice2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly ClassDbContext _context;
        private ProducerConfig _config;

        public ClassController(ClassDbContext context, ProducerConfig config)
        {
            _context = context;
            _config = config;
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

        [HttpPost("send")]
        public async Task<ActionResult> Get(string topic,Class cl)
        {
            string serializedCl = JsonConvert.SerializeObject(cl);
            try
            {
                using (var producer = new ProducerBuilder<Null, string>(_config).Build())
                {
                    await producer.ProduceAsync(topic, new Message<Null, string> { Value = serializedCl });
                    producer.Flush(TimeSpan.FromSeconds(10));
                    return Ok(true);
                }
            }
            catch (ProduceException<string,Class> ex)
            {
                return BadRequest($"Fail: {ex.Error.Reason}");
            }
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
