using DotnetCsp.Core;
using DotnetCsp.App.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using NetCore.Apis.Consumer;
using System.Net.Http;

namespace DotnetCsp.App.Business
{
    public class PackageControl
    {
        private readonly PackageAccess packageAccess;

        public PackageControl(PackageAccess packageAccess)
        {
            this.packageAccess = packageAccess;
        }

        public async Task InstallAsync(string packageName)
        {
            Console.WriteLine("adding package : " + packageName);
            var res = await packageAccess.Get(packageName);
            Console.WriteLine("response recieved with code: " + res.StatusCode);
            if (res.IsSuccessful) Install(res);
        }

        public void Install(Package package)
        {
            foreach (var p in package.ServerPackages)
                InstallServerPackage(p);
            foreach (var p in package.ClientPackages)
                InstallClientPackage(p);
        }

        public void InstallServerPackage(ServerPackage package)
        {
            Console.WriteLine("installing: " + package.PackageName);
            var process = Process.Start("dotnet.exe", $"add package {package.PackageName}");
            process.WaitForExit();
        }

        public void InstallClientPackage(ClientPackage package)
        {

            string folder = "wwwroot/lib/" + package.Package.Name;

            if (string.IsNullOrWhiteSpace(package.OnlyFiles))
            {
                Process.Start("git.exe", $"clone {package.Source} {folder}");
                var process = new Process();
                process.StartInfo.FileName = "git.exe";
                process.StartInfo.Arguments = $"clone {package.Source} {folder}";
                process.Start();
                process.WaitForExit();
                Directory.Delete(folder + "/.git");
            }
            else
            {
                using (var client = new WebClient())
                {
                    string baseAddr = package.Source;
                    if (baseAddr.EndsWith(".git"))
                        baseAddr = baseAddr.Substring(0, baseAddr.Length - 4);
                    baseAddr = baseAddr
                                    .Replace("https://github.com", "https://raw.githubusercontent.com");
                    if (!baseAddr.EndsWith("/")) baseAddr += "/";
                        client.BaseAddress = baseAddr;

                    foreach (var file in package.OnlyFiles.Replace(", ", ",").Split(','))
                    {
                        string location =  $"{folder}/{file}";
                        Directory.CreateDirectory(Path.GetDirectoryName(location));
                        client.DownloadFile($"master/{file}", location);
                    }
                }
            }   

        }

    }
}
