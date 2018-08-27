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

        public void Install(Package package) {
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
            //if (package.OnlyFiles?.Length > 0)
            //{
            //    LocateDirectory dirs = new LocateDirectory(), targetDir, found;

            //    foreach (string file in package.OnlyFiles.Replace(", ", ",").Split(','))
            //    {
            //        var parts = file.Split('/', '\\');
            //        targetDir = dirs;

            //        for (int i = 0; i < parts.Length - 1; i++)
            //        {
            //            string part = parts[i];
            //            found = targetDir.directories.SingleOrDefault(d => d.Name == part);
            //            if (found == null)
            //            {
            //                found = new LocateDirectory(part);
            //                targetDir.directories.Add(found);
            //            }
            //            targetDir = found;
            //        }
            //        targetDir.files.Add(parts[parts.Length - 1]);
            //    }

            //}

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
                    foreach (var file in package.OnlyFiles.Replace(", ", ",").Split(','))
                    {
                        string gitStart = package.Source.Substring(0, package.Source.Length - 4);
                        string location = $"{folder}/{file}";
                        Directory.CreateDirectory(Path.GetDirectoryName(location));
                        client.DownloadFile($"{gitStart}/blob/master/{file}", location);
                    }
                }
            }   

        }

    }
}
