using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DotnetCsp.Models
{
    public class PackageAdd
    {

        public const string DuplicateName = "A package with this name already exists";

        [Required, MaxLength(50)]
        public string Name { get; set; }

    }
}
