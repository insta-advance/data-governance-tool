using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using IntopaloApi.System_for_data_governance;

namespace IntopaloApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntopaloController : ControllerBase
    {
        private readonly DataGovernanceDBContext _context;

        public IntopaloController(DataGovernanceDBContext context)
        {
            _context = context;

            if (_context.Collections.Count() == 0)
            {
                // Create a new IntopaloItem if collection is empty,
                // which means you can't delete all IntopaloItems.
                _context.Collections.Add(new Collection { TableType = "IntopaloCollection1" });
                _context.SaveChanges();
            }
            if (_context.Tables.Count() == 0)
            {
                _context.Tables.Add(new Table { TableName = "IntopaloTable1" });
                _context.SaveChanges();
            }
   
            
        }
        [HttpGet]
        public ActionResult<List<Table>> GetAll()
        {
            return _context.Tables.ToList();
        }
/*
        [HttpGet("{id}", Name = "GetIntopalo")]
        public ActionResult<IntopaloItem> GetById(long id)
        {
            var item = _context.IntopaloItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(IntopaloItem item)
        {
            _context.IntopaloItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetIntopalo", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, IntopaloItem item)
        {
            var Intopalo = _context.IntopaloItems.Find(id);
            if (Intopalo == null)
            {
                return NotFound();
            }

            Intopalo.IsComplete = item.IsComplete;
            Intopalo.Name = item.Name;

            _context.IntopaloItems.Update(Intopalo);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var Intopalo = _context.IntopaloItems.Find(id);
            if (Intopalo == null)
            {
                return NotFound();
            }

            _context.IntopaloItems.Remove(Intopalo);
            _context.SaveChanges();
            return NoContent();
        }
        */
    }
}
