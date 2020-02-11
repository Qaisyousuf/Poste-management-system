﻿using OPMS.Data.Context;
using OPMS.Data.Interfaces;
using OPMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPMS.Data.Concrete
{
    public class MainPostSystemRepository:Repository<MainPostSystem>,IMainPostSystemRepository
    {
        public MainPostSystemRepository(ContextDb context):base(context)
        {

        }
    }
}
