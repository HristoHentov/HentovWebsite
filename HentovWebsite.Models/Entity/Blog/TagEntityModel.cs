﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HentovWebsite.Models.Configuration;
using Microsoft.AspNet.Identity;

namespace HentovWebsite.Models.Entity.Blog
{
    [Table("Tags")]
    public class TagEntityModel
    { 
        public int Id { get; set; }
        [Required]
        [StringLength(Constraints.TagNameMaxLen, MinimumLength = Constraints.TagNameMinLen)]
        public string Name { get; set; }
    }
}
