﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureFactory.Interfaces
{
    public interface IModel
    {
        [Key]
        public int Id { get; set; }
    }
}
