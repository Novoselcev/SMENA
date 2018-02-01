using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SSZ.Models
{
    public class Logout
    {

       
        [Required(ErrorMessage = "Логин не определен"), AllowHtml]
        public string Username { get; set; }
        [Display(Name ="Табельный номер")]
        public string TabNomer { get; set; }
        [Required]
        [Display(Name = "Язык")]
        public string Lang { get; set; }


        [Required]
        [AllowHtml]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [Display(Name = "Завод")]
        public string Plant { get; set; }
        [Display(Name = "Система")]
        public string SystemSap { get; set; }
    }

    public class systemsap
    {
       
        public string Name { get; set; }
        public string Text { get; set; }
    }


    public class ListPlant
    {

        public string Name { get; set; }
        public string Text { get; set; }

    }
}