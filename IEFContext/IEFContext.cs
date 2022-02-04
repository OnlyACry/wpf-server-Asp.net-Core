using EFCore;
using System;

namespace IEFContext
{
    public interface IEFContext
    {
        EFCoreContext CreateDBContext();
    }
}
