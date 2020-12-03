using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_PetShop.Models
{
    public class Usuario
    {

        private int userId;
        private string role;
        private string status;
        private string email;
        private string password;
        private string username;

        //*********************************************************************************************************
        //*********************************************************************************************************
        [Key]
        [Required]
        public int UserId { get => userId; set => userId = value; }
        

        [Required(ErrorMessage = "Informe o login! (8 a 15 caracteres) ")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "O username deve conter de 8 a 15 caracteres.")]
        public string Username { get => username; set => username = value; }


        [Required(ErrorMessage = "Informe a senha (6 a 8 caracteres)")]
        [StringLength(8, MinimumLength = 6, ErrorMessage = "A senha deve conter entre 6 e 8 caracteres.")]
        public string Password { get => password; set => password = value; }


        [Required(ErrorMessage = "O Email é requerido!")]
        [RegularExpression(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$", ErrorMessage = "Informe um email válido")]
        public string Email { get => email; set => email = value; }

        public string Role { get => role; set => role = value; }

        public string Status { get => status; set => status = value; }

    }
}
