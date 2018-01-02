using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace TaskSystem.Code
{
    public class CustomContractResolver : CamelCasePropertyNamesContractResolver
    {
        protected override JsonContract CreateContract(Type objectType)
        {
            var isdictionary = objectType.GetInterfaces().Any(i => i == typeof(IDictionary) ||
                                                                   (i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDictionary<,>)));
            return isdictionary ? base.CreateArrayContract(objectType) : base.CreateContract(objectType);
        }
    }
}
