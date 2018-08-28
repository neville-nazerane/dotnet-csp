using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DotnetCsp.Core
{
    public class UserDisplay
    {

        public int Id { get; set; }

        [Required]
        public int? UserId { get; set; }
        public User User { get; set; }

        [Required, MaxLength(20)]
        public string DisplayName { get; set; }

    }
}
