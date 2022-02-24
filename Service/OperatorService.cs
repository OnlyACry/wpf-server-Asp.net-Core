using IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   public  class OperatorService:ServiceBase,IOperatorService
    {
        public OperatorService(IEFContext.IEFContext eFContext) : base(eFContext)
        {

        }
    }
}
