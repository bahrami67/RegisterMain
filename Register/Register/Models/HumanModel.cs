using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;



namespace Register.Models
{
    public class HumanModel
    {
        public int Id { set; get; }

        [Required(ErrorMessage="نام را وارد کنید")]
        [DisplayName("نام")]
        public string Name { set; get; }

        [Required(ErrorMessage = "فامیل را وارد کنید")]
        [DisplayName("فامیل")]
        public string Family { set; get; }

        [DisplayName("سن")]
        public int Age { set; get; }

        [DisplayName( "جنس")]
        public bool Gender { set; get; }

        [DisplayName("تلفن")]
        [MaxLength(11)]
        public string Phone { set; get; }

        [Required(ErrorMessage = "کدملی را وارد کنید")]
        [DisplayName("کدملی")]
        [StringLength(10 , ErrorMessage = "کد ملی 10 رقم است"), MinLength(10, ErrorMessage = "کد ملی 10 رقم است")]
        public string NationalCode { set; get; }

    }

}
