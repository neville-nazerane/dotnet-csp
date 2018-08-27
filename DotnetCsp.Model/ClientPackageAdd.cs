using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DotnetCsp.Models
{
    public class ClientPackageAdd
    {

        public const string InvalidPackage = "Package not found. You may not have access to add it";

        public const string DuplicateSource = "A package with this source already exists";

        [Required, MaxLength(300)]
        public string Source { get; set; }

        [MaxLength(800)]
        public string OnlyFiles { get; set; }

        public int PackageId { get; set; }

    }
}
