using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;



namespace Domain.Models
{
    public class History
    {
        public virtual Guid Id { get; set; }

        [Required]
        [Display(Name = "первая переменная")]
        public virtual int X { get; set; }

        [Required]
        [Display(Name = "вторая переменная")]
        public virtual int Y { get; set; }

        [Display(Name = "Результат")]
        public virtual double Result { get; set; }

        [Display(Name = "Операция")]
        public virtual string Operation { get; set; }

        [Required]
        [Display(Name = "Дата создания")]
        public virtual DateTime CreationDate { get; set; }
    }
}