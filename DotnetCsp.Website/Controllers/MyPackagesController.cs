using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetCsp.Core;
using DotnetCsp.Models;
using DotnetCsp.Web.Services;
using Microsoft.AspNetCore.Authorization;

namespace DotnetCsp.Website.Controllers
{

    [Authorize]
    public class MyPackagesController : Controller
    {
        private readonly IPackageRepository packageRepository;

        public MyPackagesController(IPackageRepository packageRepository)
        {
            this.packageRepository = packageRepository;
        }

        public IActionResult Index() => View(packageRepository.ListForCurrentUser());

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(PackageAdd package)
        {
            if (ModelState.IsValid)
            {
                var res = packageRepository.Add(package);
                if (res == null) return this.ValidateAndView(package);
                else return RedirectToAction(nameof(Index));
            }
            else return View(package);
        }

        [HttpGet, Route("[controller]/[action]/{name}")]
        public IActionResult Details(string name) => View(packageRepository.Get(name, true));

        public IActionResult ToPackage(int id) 
            => RedirectToAction(nameof(Details), new { packageRepository.Get(id).Name });

        [HttpGet]
        public IActionResult AddClient(int id) => View(new ClientPackageAdd { PackageId = id });

        [HttpPost]
        public IActionResult AddClient(ClientPackageAdd package)
        {
            if (ModelState.IsValid)
            {
                var res = packageRepository.AddClient(package);
                if (res == null) return this.ValidateAndView(package);
                else return RedirectToAction(nameof(ToPackage), new { id = package.PackageId });
            }
            else return View(package);
        }

        [HttpGet]
        public IActionResult AddServer(int id) => View(new ServerPackageAdd { PackageId = id });

        [HttpPost]
        public IActionResult AddServer(ServerPackageAdd package)
        {
            
            if (ModelState.IsValid)
            {
                var res = packageRepository.AddServer(package);
                if (res == null) return this.ValidateAndView(package);
                else return RedirectToAction(nameof(ToPackage), new { id = package.PackageId });
            }
            else return View(package);
        }

    }
}
