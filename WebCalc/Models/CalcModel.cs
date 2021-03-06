﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCalc.Models
{
    /// <summary>
    /// Модель для расчета значений
    /// </summary>
    public class CalcModel
    {
        /// <summary>
        /// X
        /// </summary>
        [Required]
        [Display(Name ="первая переменная")]
        public int X { get; set; }

        [Required]
        [Display(Name = "Результат")]
        public int Y { get; set; }

        public double Result { get; set; }
    }
}