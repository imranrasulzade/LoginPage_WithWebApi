using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WebApi : ControllerBase
    {
        private readonly MyDatabase myDatabase;
        public WebApi(MyDatabase database)
        {
            myDatabase = database;
        }
        [HttpPost]
        public IActionResult CheckLogin(Mushteri mushteri)
        {
            var item = myDatabase.mushteris.Where(x=>x.Username == mushteri.Username && x.Password == mushteri.Password).FirstOrDefault();
            if (item != null)
            {
                return Ok("OK ugurlu emeliyyat)");
            }
            else
            {
                return NotFound("Ugursuz emeliyyat(");
            }
            
        }
    }
}
