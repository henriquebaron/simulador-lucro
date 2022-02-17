using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimuladorLucroAPI.Models
{
    public class UserForRegistrationDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required(ErrorMessage = "Endereço de e-mail é obrigatório.")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "As senhas digitadas não conferem.")]
        public string ConfirmPassword { get; set; }
    }
}
