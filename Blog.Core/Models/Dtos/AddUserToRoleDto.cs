﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Models.Dtos
{
    public class AddUserToRoleDto
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}
