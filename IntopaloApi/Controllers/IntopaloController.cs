using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using IntopaloApi.System_for_data_governance;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

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
                _context.Collections.Add(new Collection { Name = "IntopaloCollection1" });
                _context.SaveChanges();
            }
            if (_context.Schemas.Count() == 0)
            {
                _context.Schemas.Add(
                    new Schema {
                        Name = "private",
                        Tables = new List<Table> {
                            new Table { 
                                Name = "User",
                                Fields = new List<Field> {
                                    new Field {Name = "UserId", Type = "int" },
                                    new Field {Name = "UserName", Type = "nvarchar(max)" }
                                }

                            },

                            new Table {
                                Name = "Car",
                                Fields = new List<Field> {
                                    new Field {Name = "CarId", Type = "int" },
                                    new Field {Name = "OwnerId", Type = "int" },
                                    new Field {Name = "CarBrand", Type = "nvarchar(max)" }
                                }
                            }
                        }
                    }
                );
                _context.SaveChanges();
                _context.KeyRelationships.Add(new KeyRelationship{
                    FromId = _context.Fields.Single(f => f.Name == "UserId").Id,
                    ToId = _context.Fields.Single(f => f.Name == "OwnerId").Id,
                    Type = "exact"
                });
                _context.SaveChanges();
            }
   
            
        }
/*
        [HttpGet]
        public ActionResult<string> GetAll() {
            List<Table> tables = _context.Tables
                .Include(t => t.Fields)
                .ThenInclude(f => f.PrimaryKeyTo)
                .ToList();
            //tables[0].Fields[0].PrimaryKeyTo[0].To = null;
            //tables[1].Fields[1].ForeignKeyTo[0].From = null;
            return JsonConvert.SerializeObject(
                tables,
                new JsonSerializerSettings() {
                    // Allow loops since metadata is connected in a hierarchy.
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore,
                    // Identing for debug purposes only
                    Formatting = Formatting.Indented
                }
            );
        }

        [HttpGet]
        public ActionResult<List<StructuredBase>> GetAll()
        {
            return _context.StructuredBases.ToList();
        }
*/
        [HttpGet]
        //public ObjectResult GetAll()
        public ActionResult<string> GetAll() 
        {
            
            List<Table> tables = _context.Tables
                .Include(t => t.Fields)
                .ThenInclude(f => f.PrimaryKeyTo)
                .ToList();
            tables[0].Fields[0].PrimaryKeyTo[0].To = null;
            tables[1].Fields[1].ForeignKeyTo[0].From = null;
            //database.Add(tables);
            List<KeyValuePair<string,List<object>>> database = new List<KeyValuePair<string,List<object>>>(){
                new KeyValuePair<string,List<object>>("Collections",new List<object>(_context.Collections.ToList())),
                new KeyValuePair<string,List<object>>("Databases",new List<object>(_context.Databases.ToList())),
                new KeyValuePair<string,List<object>>("Fields",new List<object>(_context.Fields.ToList())),
                new KeyValuePair<string,List<object>>("KeyRelationships",new List<object>(_context.KeyRelationships.ToList())),
                new KeyValuePair<string,List<object>>("Schemas",new List<object>(_context.Schemas.ToList())),
                new KeyValuePair<string,List<object>>("StructuredFiles",new List<object>(_context.StructuredFiles.ToList())),
                new KeyValuePair<string,List<object>>("Tables",new List<object>(_context.Tables.ToList())),
                new KeyValuePair<string,List<object>>("Unstructuredfiles",new List<object>(_context.UnstructuredFiles.ToList())),
            };
            /*
            List<List<object>> database = new List<List<object>>();
            database.Add(new List<object>(_context.Collections.ToList()));
            database.Add(new List<object>(_context.Databases.ToList()));
            database.Add(new List<object>(_context.Fields.ToList()));
            database.Add(new List<object>(_context.KeyRelationships.ToList()));
            database.Add(new List<object>(_context.Schemas.ToList()));
            database.Add(new List<object>(_context.StructuredFiles.ToList()));
            database.Add(new List<object>(_context.Tables.ToList()));
            database.Add(new List<object>(_context.UnstructuredFiles.ToList()));
            */

            return JsonConvert.SerializeObject(
                database,
                new JsonSerializerSettings() {
                    // Allow loops since metadata is connected in a hierarchy.
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore,
                    // Identing for debug purposes only
                    Formatting = Formatting.Indented
                }
            );
        }

        // The function saves the new data to the database. The data can contain 
        // whole database, but also can be a single item. 
        // Correct Json syntax can be found in the guide.txt.
        [HttpPost]
        public ActionResult<string> Create(JsonData data)
        {
            if(data.jsonCollections != null){
                for(int i = 0; i<data.jsonCollections.Count;i++){
                    _context.Collections.Add(data.jsonCollections.ElementAt(i));
                    _context.SaveChanges();
                }
            }
            if(data.jsonDatabases != null){
                for(int i = 0; i<data.jsonDatabases.Count;i++){
                    _context.Databases.Add(data.jsonDatabases.ElementAt(i));
                    _context.SaveChanges();
                }
            }
            if(data.jsonFields != null){
                for(int i = 0; i<data.jsonFields.Count;i++){
                    _context.Fields.Add(data.jsonFields.ElementAt(i));
                    _context.SaveChanges();
                }
            }
            if(data.jsonKeyRelationships != null){
                for(int i = 0; i<data.jsonKeyRelationships.Count;i++){
                    _context.KeyRelationships.Add(data.jsonKeyRelationships.ElementAt(i));
                    _context.SaveChanges();
                }
            }
            if(data.jsonSchemas != null){
                for(int i = 0; i<data.jsonSchemas.Count;i++){
                    _context.Schemas.Add(data.jsonSchemas.ElementAt(i));
                    _context.SaveChanges();
                }
            }
            if(data.jsonStructuredFiles != null){
                for(int i = 0; i<data.jsonStructuredFiles.Count;i++){
                    _context.StructuredFiles.Add(data.jsonStructuredFiles.ElementAt(i));
                    _context.SaveChanges();
                }
            }
            if(data.jsonTables != null){
                for(int i = 0; i<data.jsonTables.Count;i++){
                    _context.Tables.Add(data.jsonTables.ElementAt(i));
                    _context.SaveChanges();
                }
            }
            if(data.jsonUnstructuredFiles != null){
                for(int i = 0; i<data.jsonUnstructuredFiles.Count;i++){
                    _context.UnstructuredFiles.Add(data.jsonUnstructuredFiles.ElementAt(i));
                    _context.SaveChanges();
                }
            }
       
            return GetAll();
        } 

        [HttpPut]
        public ActionResult<string> Update(JsonData data)
        {
            if(data.jsonCollections != null){
                for(int i = 0; i<data.jsonCollections.Count;i++){
                    var item = _context.Collections.Find(data.jsonCollections.ElementAt(i).Id);
                    if(item != null){
                        item.Name = data.jsonCollections.ElementAt(i).Name;
                        item.PrimaryKeyTo = data.jsonCollections.ElementAt(i).PrimaryKeyTo;
                        item.ForeignKeyTo = data.jsonCollections.ElementAt(i).ForeignKeyTo;
                        //item.Fields = data.jsonTables.ElementAt(i).Fields;
                        _context.Collections.Update(item);
                        _context.SaveChanges();
                    }
                }
            }
            if(data.jsonDatabases != null){
                for(int i = 0; i<data.jsonDatabases.Count;i++){
                    var item = _context.Databases.Find(data.jsonDatabases.ElementAt(i).Id);
                    if(item != null){
                        item.Name = data.jsonDatabases.ElementAt(i).Name;
                        item.Type = data.jsonDatabases.ElementAt(i).Type;
                        item.PrimaryKeyTo = data.jsonDatabases.ElementAt(i).PrimaryKeyTo;
                        item.ForeignKeyTo = data.jsonDatabases.ElementAt(i).ForeignKeyTo;
                        _context.Databases.Update(item);
                        _context.SaveChanges();
                    }
                }
            }
            if(data.jsonFields != null){
                for(int i = 0; i<data.jsonFields.Count;i++){
                    var item = _context.Fields.Find(data.jsonFields.ElementAt(i).Id);
                    if(item != null){
                        item.Name = data.jsonFields.ElementAt(i).Name;
                        item.Type = data.jsonFields.ElementAt(i).Type;
                        item.StructuredBase = data.jsonFields.ElementAt(i).StructuredBase;
                        item.PrimaryKeyTo = data.jsonFields.ElementAt(i).PrimaryKeyTo;
                        item.ForeignKeyTo = data.jsonFields.ElementAt(i).ForeignKeyTo;
                        _context.Fields.Update(item);
                        _context.SaveChanges();
                    }
                }
            }
            /*if(data.jsonKeyRelationships != null){
                for(int i = 0; i<data.jsonKeyRelationships.Count;i++){
                    var item = _context.KeyRelationships.Find(data.jsonKeyRelationships.ElementAt(i).Id);
                    if(item != null){
                        item.FromId = data.jsonKeyRelationships.ElementAt(i).FromId;
                        item.From = data.jsonKeyRelationships.ElementAt(i).From;
                        item.ToId = data.jsonKeyRelationships.ElementAt(i).ToId;
                        item.To = data.jsonKeyRelationships.ElementAt(i).To;
                        item.Type = data.jsonKeyRelationships.ElementAt(i).Type;
                        _context.KeyRelationships.Update(item);
                        _context.SaveChanges();
                    }
                }
            }*/
            if(data.jsonSchemas != null){
                for(int i = 0; i<data.jsonSchemas.Count;i++){
                    var item = _context.Schemas.Find(data.jsonSchemas.ElementAt(i).Id);
                    if(item != null){
                        item.SchemaName = data.jsonSchemas.ElementAt(i).SchemaName;
                        item.Tables = data.jsonSchemas.ElementAt(i).Tables;
                        item.PrimaryKeyTo = data.jsonSchemas.ElementAt(i).PrimaryKeyTo;
                        item.ForeignKeyTo = data.jsonSchemas.ElementAt(i).ForeignKeyTo;
                        _context.Schemas.Update(item);
                        _context.SaveChanges();
                    }
                }
            }
            if(data.jsonStructuredFiles != null){
                for(int i = 0; i<data.jsonStructuredFiles.Count;i++){
                    var item = _context.StructuredFiles.Find(data.jsonStructuredFiles.ElementAt(i).Id);
                    if(item != null){
                        item.FilePath = data.jsonStructuredFiles.ElementAt(i).FilePath;
                        item.PrimaryKeyTo = data.jsonStructuredFiles.ElementAt(i).PrimaryKeyTo;
                        item.ForeignKeyTo = data.jsonStructuredFiles.ElementAt(i).ForeignKeyTo;
                        //item.Fields = data.jsonTables.ElementAt(i).Fields;
                        _context.StructuredFiles.Update(item);
                        _context.SaveChanges();
                    }
                }
            }
            if(data.jsonTables != null){
                for(int i = 0; i<data.jsonTables.Count;i++){
                    var item = _context.Tables.Find(data.jsonTables.ElementAt(i).Id);
                    if(item != null){
                        item.TableName = data.jsonTables.ElementAt(i).TableName;
                        item.Schema = data.jsonTables.ElementAt(i).Schema;
                        item.PrimaryKeyTo = data.jsonTables.ElementAt(i).PrimaryKeyTo;
                        item.ForeignKeyTo = data.jsonTables.ElementAt(i).ForeignKeyTo;
                        //item.Fields = data.jsonTables.ElementAt(i).Fields;
                        _context.Tables.Update(item);
                        _context.SaveChanges();
                    }
                }
            }
            if(data.jsonUnstructuredFiles != null){
                for(int i = 0; i<data.jsonUnstructuredFiles.Count;i++){
                    var item = _context.UnstructuredFiles.Find(data.jsonUnstructuredFiles.ElementAt(i).Id);
                    if(item != null){
                        item.FilePath = data.jsonUnstructuredFiles.ElementAt(i).FilePath;
                        item.PrimaryKeyTo = data.jsonUnstructuredFiles.ElementAt(i).PrimaryKeyTo;
                        item.ForeignKeyTo = data.jsonUnstructuredFiles.ElementAt(i).ForeignKeyTo;
                        _context.UnstructuredFiles.Update(item);
                        _context.SaveChanges();
                    }
                }
            }
            return GetAll();
        }
        [HttpDelete]
        public ActionResult<string> Delete(JsonData data)
        {
            if(data.jsonCollections != null){
                for(int i = 0; i<data.jsonCollections.Count;i++){
                    var item = _context.Collections.Find(data.jsonCollections.ElementAt(i).Id);
                    if(item != null){
                        _context.Collections.Remove(item);
                        _context.SaveChanges();
                    }
                }
            }
            if(data.jsonDatabases != null){
                for(int i = 0; i<data.jsonDatabases.Count;i++){
                    var item = _context.Databases.Find(data.jsonDatabases.ElementAt(i).Id);
                    if(item != null){
                        _context.Databases.Remove(item);
                        _context.SaveChanges();
                    }
                }
            }
            if(data.jsonFields != null){
                for(int i = 0; i<data.jsonFields.Count;i++){
                    var item = _context.Fields.Find(data.jsonFields.ElementAt(i).Id);
                    if(item != null){
                        _context.Fields.Remove(item);
                        _context.SaveChanges();
                    }
                }
            }
            /*if(data.jsonKeyRelationships != null){
                for(int i = 0; i<data.jsonKeyRelationships.Count;i++){
                    var item = _context.KeyRelationships.Find(data.jsonKeyRelationships.ElementAt(i).Id);
                    if(item != null){
                        _context.KeyRelationships.Remove(item);
                        _context.SaveChanges();
                    }
                }
            }*/
            if(data.jsonSchemas != null){
                for(int i = 0; i<data.jsonSchemas.Count;i++){
                    var item = _context.Schemas.Find(data.jsonSchemas.ElementAt(i).Id);
                    if(item != null){
                        _context.Schemas.Remove(item);
                        _context.SaveChanges();
                    }
                }
            }
            if(data.jsonStructuredFiles != null){
                for(int i = 0; i<data.jsonStructuredFiles.Count;i++){
                    var item = _context.StructuredFiles.Find(data.jsonStructuredFiles.ElementAt(i).Id);
                    if(item != null){
                        _context.StructuredFiles.Remove(item);
                        _context.SaveChanges();
                    }
                }
            }
            if(data.jsonTables != null){
                for(int i = 0; i<data.jsonTables.Count;i++){
                    var item = _context.Tables.Find(data.jsonTables.ElementAt(i).Id);
                    if(item != null){
                        _context.Tables.Remove(item);
                        _context.SaveChanges();
                    }
                }
            }
            if(data.jsonUnstructuredFiles != null){
                for(int i = 0; i<data.jsonUnstructuredFiles.Count;i++){
                    var item = _context.UnstructuredFiles.Find(data.jsonUnstructuredFiles.ElementAt(i).Id);
                    if(item != null){
                        _context.UnstructuredFiles.Remove(item);
                        _context.SaveChanges();
                    }
                }
            }
            return GetAll();
        }
    }
}


// Post function attemps
/* 
     var json = Request.Body;

            using (StreamReader reader 
                  = new StreamReader(json))
        {
            string json2 = @"{""user"":{""name"":""asdf"",""teamname"":""b"",""email"":""c"",""players"":[""1"",""2""]}}";
            var bodyStr = reader.ReadToEnd();
            var objData = (JArray)JsonConvert.DeserializeObject(bodyStr); // Deserialize json data
            JObject tieto = JObject.Parse(json2);
            JToken jUser = tieto["user"];
            string name = (string) jUser["name"];
            //JToken user = objData["Collections"];
            dynamic jObject = new JObject();
            if(objData.GetType() == typeof(Collection)){
                var i = 5;
            //jObject.Name = objData.Value<string>("Name");
            //jObject.Address = objData.Value<string>("Address");
            //jObject.TABLE2 = objData.Value<JArray>("TABLE2");
            }
        }
            
        
                        foreach (JArray list in data) {
                
                var test = list.Children();
                var wot = test.ElementAt(0);
                var wot2 = test.ElementAt(1);
                var woot = wot.Children();
                var wuf = woot[0]["Name"];
                if(wot.First().GetType() == typeof(Collection)){
                    var test1 = 5;
                /* if(list.First().GetType() == typeof(Collection)){
                    //List<Collection> col_list = (List<Collection>)list;
                    foreach(Collection collection in list){
                        _context.Collections.Add(collection);
                        _context.SaveChanges();
                    }
                }
                }
            }
             */
