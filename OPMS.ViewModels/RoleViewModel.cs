﻿using OPMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMS.ViewModels
{
    public class RoleViewModel
    {
        public RoleViewModel()
        {
            Users = new List<UserModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<UserModel> Users { get; set; }
    }
}