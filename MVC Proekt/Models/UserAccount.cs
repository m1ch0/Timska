using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_Proekt.Models
{
    public class UserAccount
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Мора да внесете корисничко име")]
        public String Username { get; set; }
        [Required(ErrorMessage ="Внесете лозинка.")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        [Compare("Password",ErrorMessage ="Внесетеја лозинката повторно")]
        [DataType(DataType.Password)]
        public String ConfirmPassword { get; set; }
        public String Name { get; set; }
        [Required(ErrorMessage = "Мора да внесете валидна емаил адреса")]
        [EmailAddress]
        public String Email { get; set; }
        public DateTime date { get; set; }
    }
}