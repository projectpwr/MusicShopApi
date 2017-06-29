using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public abstract class DomainControllerBase : ControllerBase
    {
        public string SerializeObject(Object target)
        {
            return JsonConvert.SerializeObject(target, Formatting.Indented);
        }

    }
}
