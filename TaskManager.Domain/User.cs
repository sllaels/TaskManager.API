using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain
{
    public class User
    {

        public int Id { get; set; }

        [Required(ErrorMessage ="Пожалуйста, введите свое имя")]
        [MaxLength(50,ErrorMessage ="Максимальна длина имени 50 символов")]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите пароль")]
        public string Password { get; set; }
    }
}
