using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DotnetCsp.Models
{
    public class ServerPackageAdd
    {

        public const string InvalidPackage = "Package not found. You may not have access to add it";

        public const string DuplicateSource = "A package with this source already exists";

        [Required, MaxLength(200)]
        public string PackageName { get; set; }

        public int PackageId { get; set; }

    }
}
