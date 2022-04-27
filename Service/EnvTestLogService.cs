using IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class EnvTestLogService: ServiceBase, IEnvTestLogService
    {
        public EnvTestLogService(IEFContext.IEFContext eFContext) : base(eFContext)
        {

        }
    }
}
