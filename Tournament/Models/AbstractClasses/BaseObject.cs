﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tournament.Models
{
    /// <summary>
    /// Base Class for all objects
    /// </summary>
    public abstract class BaseObject
    {
        public string Name { get; set; }
        public int ID { get; set; }

    }
}
