
using IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   public class SetDicService:ServiceBase,ISetDicService
    {
        public SetDicService(IEFContext.IEFContext eFContext) : base(eFContext)
        {

        }
    }
}
