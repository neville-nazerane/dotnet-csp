using DotnetCsp.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetCsp.Web.Services;

namespace DotnetCsp.WebAPI.Controllers
{

    [ApiController, Route("api/[controller]")]
    public class PackagesController : Controller
    {
        private readonly IPackageRepository packageRepository;

        public PackagesController(IPackageRepository packageRepository)
        {
            this.packageRepository = packageRepository;
        }

        [HttpGet("{name}")]
        public ActionResult<Package> Get(string name)
        {
            var result = packageRepository.Get(name, true);
            if (result == null) return NotFound();
            return result;
        }
    }
}
