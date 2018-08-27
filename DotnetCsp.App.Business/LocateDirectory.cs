using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCsp.App.Business
{
    class LocateDirectory
    {

        public string Name { get; set; }

        internal readonly List<LocateDirectory> directories;

        internal readonly List<string> files;

        public LocateDirectory(string Name) : this()
        {
            this.Name = Name;
        }

        public LocateDirectory()
        {
            directories = new List<LocateDirectory>();
            files = new List<string>();
        }

    }
}
