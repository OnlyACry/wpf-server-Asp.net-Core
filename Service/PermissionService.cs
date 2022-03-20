using IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   public class PermissionService:ServiceBase,IPermissionService
    {
        public PermissionService(IEFContext.IEFContext eFContext) : base(eFContext)
        {

        }
    }
}
