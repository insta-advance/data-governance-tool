using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using IntopaloApi.System_for_data_governance;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


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
                _context.Collections.Add(new Collection { CollectionName = "IntopaloCollection1" });
                _context.SaveChanges();
            }
            if (_context.Schemas.Count() == 0)
            {
                _context.Schemas.Add(
                    new Schema {
                        SchemaName = "private",
                        Tables = new List<Table> {
                            new Table { 
                                TableName = "User",
                                Fields = new List<Field> {
                                    new Field {FieldName = "UserId", FieldType = "int" },
                                    new Field {FieldName = "UserName", FieldType = "nvarchar(max)" }
                                }

                            },

                            new Table {
                                TableName = "Car",
                                Fields = new List<Field> {
                                    new Field {FieldName = "CarId", FieldType = "int" },
                                    new Field {FieldName = "CarBrand", FieldType = "nvarchar(max)" }
                                }
                            }
                        }
                    }
                );
                _context.SaveChanges();
            }
   
            
        }
        [HttpGet]
        public ActionResult<string> GetAll() {
            List<Table> tables = _context.Tables
                .Include(t => t.Fields)
                .ToList();
            string jasonTables = JsonConvert.SerializeObject(
                tables,
                Formatting.Indented,
                /* Identing for debug purposes only */
                new JsonSerializerSettings() {
                    /* Allow loops since metadata is connected in a hierarchy. */
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }
            );
            return jasonTables;
        }
    }
}
