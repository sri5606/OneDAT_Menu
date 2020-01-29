using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneDAT.Web.Helper.InterfaceBinder
{
    public class DIMetaDefault : IDIMeta
    {
        readonly IDictionary<Type, Type> register = new Dictionary<Type, Type>();
        public DIMetaDefault(IServiceCollection services)
        {
            foreach (var s in services)
            {
                register[s.ServiceType] = s.ImplementationType;
            }
        }
        public bool IsRegistred(Type t)
        {
            return register.ContainsKey(t);
        }

        public Type RegistredTypeFor(Type t)
        {
            return register[t];
        }
    }
}
