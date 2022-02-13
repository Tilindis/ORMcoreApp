using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ORMcoreApp.DataAcces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OfficersWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficerControllerRoute : ControllerBase
    {

        private PoliceManContent policeManContent;

        readonly JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
            ContractResolver = new CamelCasePropertyNamesContractResolver()

        };
        //System.Text.Json.JsonSerializerOptions
        public OfficerControllerRoute(PoliceManContent content)
        {
            policeManContent = content;
        }

        // GET: api/<OfficerController>
        [HttpGet]
        public IActionResult Get()
        {
            //return new JsonResult(policeManContent.ginklai.ToList(), jsonSerializerSettings);

            var guns = policeManContent.ginklai.ToList();
            if (guns == null)
                return NoContent();
            return Ok( new JsonResult(new { data = guns }, jsonSerializerSettings));
        }

        // GET api/<OfficerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var gun = policeManContent.ginklai.FirstOrDefault(p => p.Id == id);
            if (gun == null)
                return NoContent();
            return Accepted(new JsonResult(new { data = gun }, jsonSerializerSettings));
        }

        // POST api/<OfficerController>
        [HttpPost]
        public IActionResult Post(string gunname, string gunmodel, int gunid)
        {
            try
            {
                policeManContent.ginklai.Add(new ORMcoreApp.Models.Ginklas()
                {
                    GunName = gunname,
                    GunModel = gunmodel,
                    GunID = gunid
                });
                policeManContent.SaveChanges();
                return Accepted();
            }
            catch(Exception)
            {
                return BadRequest();
            }

        }

        // PUT api/<OfficerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, string gunname, string gunmodel, int gunid)
        {

            var gun = policeManContent.ginklai.FirstOrDefault(p => p.Id == id);

            if (gun == null)
                return NoContent();

            gun.GunName = gunname;
            gun.GunModel = gunmodel;
            gun.GunID = gunid;
            
            try
            {
                policeManContent.SaveChanges();
                return Accepted();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }

        // DELETE api/<OfficerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            
            try
            {
                policeManContent.ginklai.Remove(policeManContent.ginklai.FirstOrDefault(a => a.Id == id));
                policeManContent.SaveChanges();
                return Accepted();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        // PATCH /api/<OfficerController>/{id}/{key}
        [HttpPatch("{id}/{key}")]
        public IActionResult PATCH(int id, string key, string value)
        {
            var gun = policeManContent.ginklai.FirstOrDefault(x => x.Id == id);

            if (gun == null)
            {
                return NoContent();
            }

            if (key == nameof(gun.GunName))
                gun.GunName = value;
            else if (key == nameof(gun.GunModel))
                gun.GunModel = value;
            else if (key == nameof(gun.GunID))
                gun.GunID = Convert.ToInt32(value);
            else
                return BadRequest();

            try
            {
                policeManContent.SaveChanges();
                return Accepted();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
