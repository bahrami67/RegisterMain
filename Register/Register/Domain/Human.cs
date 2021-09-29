using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Register.Models
{
    public class Human
    {
        public int Id { set; get; }

        //[Required(ErrorMessage="نام را وارد کنید")]
        [Display(Name = "نام")]
        public string Name { set; get; }

        //[Required(ErrorMessage = "فامیل را وارد کنید")]
        [Display(Name = "فامیل")]
        public string Family { set; get; }

        [Display(Name = "سن")]
        public int Age { set; get; }

        [Display(Name = "جنس")]
        public bool Gender { set; get; }

        //[MaxLength(11)]
        [Display(Name = "تلفن")]
        public string Phone { set; get; }

        //[MaxLength(10)]
        //[Required(ErrorMessage = "کدملی را وارد کنید")]
        [Display(Name = "کدملی")]
        public string NationalCode { set; get; }
    }
}
