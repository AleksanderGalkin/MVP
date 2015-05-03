﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoDB.Model.Interface
{
    public interface IViewModel
    {
        string lastUserID { get; set; }
        DateTime? lastDT { get; set; }
    }
}
