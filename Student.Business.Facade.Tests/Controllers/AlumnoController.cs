using Student.Business.Logic.BusinessLogic;
using Student.Common.Logic.Log4net;
using Student.Common.Logic.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace Studen_Business.Facade.Controllers
{
    public class AlumnoController : ApiController
    {
        private readonly ILogger Log;
        private readonly IBusiness studentBl;

        public AlumnoController(ILogger Log, IBusiness business)
        {
            this.Log = Log;
            this.studentBl = business;
        }



        // GET: api/Alumno/GetAll
        [HttpGet()]
        public IHttpActionResult GetAll()
        {
            Log.Debug("" + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return Ok(studentBl.GetAll());
        }


        // GET: api/Alumno/5
        [HttpGet()]
        [Route("api/Alumno/GetById/{guid}")]
        public IHttpActionResult GetById(Guid guid)
        {
            Log.Debug("" + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return Ok(studentBl.GetById(guid));
        }

        // POST: api/Alumno
        [HttpPost()]
        [Route("api/Alumno/Post")]
        public IHttpActionResult Post(Alumno alumno)
        {
            Log.Debug("" + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return Ok(studentBl.AddAlumno(alumno));
        }

        // PUT: api/Alumno/5
        [HttpPut()]
        [Route("api/Alumno/Update/{guid}")]
        public IHttpActionResult Put(Guid guid, Alumno alumno)
        {
            Log.Debug("" + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return Ok(studentBl.Update(guid, alumno));
        }

        // DELETE: api/Alumno/5
        [HttpDelete()]
        [Route("api/Alumno/Remove/{guid}")]
        public IHttpActionResult Remove(Guid guid)
        {
            Log.Debug("" + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return Ok(studentBl.Remove(guid));
        }
    }
}