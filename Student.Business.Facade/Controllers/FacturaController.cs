using log4net.Core;
using Student.Business.Logic.Contrants;
using System.Collections.Generic;
using System.Web.Http;

namespace Student.Business.Facade.Controllers
{
    public class FacturaController : ApiController
    {
        private readonly ILogger Log;
        private readonly IBusinessGeneric<Factura> FacturaBl;

        public FacturaController(ILogger Log, IBusinessGeneric<Factura> facturaBl)
        {
            this.Log = Log;
            this.FacturaBl = facturaBl;
        }

        // GET: api/Factura/GetAll
        public int GetAll()
        {
            throw new System.NotSupportedException();
        }
        // GET: api/Factura
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Factura/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Factura
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Factura/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Factura/5
        public void Delete(int id)
        {
        }
    }
}
