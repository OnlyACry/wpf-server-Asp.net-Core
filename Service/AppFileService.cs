using IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
     public class AppFileService : ServiceBase, InAppFileSaver
    {
        public AppFileService(IEFContext.IEFContext eFContext) : base(eFContext)
        {

        }
    }
}
