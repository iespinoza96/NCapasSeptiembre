using System.Web.Http;


namespace SL_WebAPI.Controllers
{
    
    public class MateriaController : ApiController
    {
        // GET: api/Materia
        [HttpGet]
        [Route("api/materia/getall")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Materia.GetAllLINQ();

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
            //return new string[] { "Luis", "Joel","Andrew" };
        }

        [HttpGet]
        [Route("api/materia/getbyid/{idMateria}")]
        public IHttpActionResult GetById(byte idMateria)
        {
            ML.Result result = BL.Materia.GetByIdEF(idMateria);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
            //return new string[] { "Luis", "Joel","Andrew" };
        }


        // POST: api/Materia
        [HttpPost]
        [Route("api/materia/add")]
        public IHttpActionResult Add([FromBody]ML.Materia materia)
        {
            ML.Result result = BL.Materia.AddLINQ(materia);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            { 
                return BadRequest(result.Message); 
            }
        }

        [HttpPut]
        [Route("api/materia/update/{idMateria}")]
        public IHttpActionResult Update(byte idMateria,[FromBody] ML.Materia materia)
        {
            materia.IdMateria = idMateria;
            ML.Result result = BL.Materia.UpdateLINQ(materia);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }


    }
}
