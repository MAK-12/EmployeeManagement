﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementPortal.MVC.ViewModels
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Please enter Role Id.")]
        [Display(Name = "Role Id")]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Please enter Role Name.")]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }

        [Required(ErrorMessage = "Please enter Rate Per Hour.")]
        [Display(Name = "Rate Per Hour")]
        public decimal? RatePerhour { get; set; }
        public virtual ICollection<EmployeeViewModel> Employee { get; set; }
    }
}
