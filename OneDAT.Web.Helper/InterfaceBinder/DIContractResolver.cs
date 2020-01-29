using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;


namespace OneDAT.Web.Helper.InterfaceBinder
{
    public class DIContractResolver : CamelCasePropertyNamesContractResolver
    {
        readonly IDIMeta diMeta;
        readonly IServiceProvider sp;
        public DIContractResolver(IDIMeta diMeta, IServiceProvider sp)
        {
            this.diMeta = diMeta;
            this.sp = sp;
        }
        protected override JsonObjectContract CreateObjectContract(Type objectType)
        {
            if (diMeta.IsRegistred(objectType))
            {
                JsonObjectContract contract = DIResolveContract(objectType);
                return contract;
            }

            return base.CreateObjectContract(objectType);
        }
        private JsonObjectContract DIResolveContract(Type objectType)
        {
            var fType = diMeta.RegistredTypeFor(objectType);
            if (fType != null) return base.CreateObjectContract(fType);
            else return CreateObjectContract(objectType);
        }
    }
}
