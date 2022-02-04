using IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class fdecaypoolService : ServiceBase, IfdecaypoolService
    {
        //实例化LoginService时，把实例对象eFContext传到它的基类Service中去了
        public fdecaypoolService(IEFContext.IEFContext eFContext) : base(eFContext)
        {

        }
    }
}
