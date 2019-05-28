using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace WebApplication1.Controllers
{
    [Route("/api")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/hello
        [HttpGet]
        [Route("hello")]
        public ActionResult Hello()
        {
            return Ok("Hello world");
        }

        [HttpGet]
        [Route("paises")]
        public ActionResult ObtenerPaises()
        {
            var lstPaises = BL.Logica.ObtenerPaises();
            return Ok(lstPaises);
        }

        [HttpPost]
        [Route("nuevoPais")]
        public ActionResult ObtenerPaises(Pais pais)
        {
            var seRegistro = BL.Logica.CrearPais(pais);
            return Ok(seRegistro);
        }

        // GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
