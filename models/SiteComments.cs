using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TouristiqueDbContext.models
{
    public class SiteComment
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public Site Site { get; set; }
        [Required]
        public IdentityUser User { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}