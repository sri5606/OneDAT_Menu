using System;
using System.Collections.Generic;
using System.Text;

namespace OneDAT.Web.Helper.InterfaceBinder
{
    public interface IDIMeta
    {
        bool IsRegistred(Type t);
        Type RegistredTypeFor(Type t);
    }
}
