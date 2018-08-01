using Student.Business.Logic.Contrants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Business.Logic.BusinessLogic
{
    public class FacturaBL<T> : IBusinessGeneric<T>
    {
        public T GetAll()
        {
            throw new NotSupportedException();
        }
    }
}
