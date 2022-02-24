using IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   public class PollutantService :ServiceBase, IPollutantService
    {
        public PollutantService(IEFContext.IEFContext eFContext) : base(eFContext)
        {

        }
    }
}
