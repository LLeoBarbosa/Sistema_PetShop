using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_PetShop.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "O nome é requerido!")]
        [Display(Name = "Nome")]
        [StringLength(50)]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O CPF é requerido!")]
        [Display(Name = "CPF")]
        [StringLength(11)]
        public int Cpf { get; set; }


        [Required(ErrorMessage = "O Endereço é requerido!")]
        [Display(Name = "Endereço")]
        [StringLength(100)]
        public string Endereco { get; set; }


        [Required(ErrorMessage = "O CEP é requerido!")]
        [Display(Name = "CEP")]
        [StringLength(10, MinimumLength = 8)]
        public string Cep { get; set; }


        [Required(ErrorMessage = "Informe a Cidade!")]
        [Display(Name = "Cidade")]
        [StringLength(25)]
        public string Cidade { get; set; }

               
        public char Uf { get; set; }


        [Required(ErrorMessage = "Informe o telefone Fixo")]
        [Display(Name = "Telefone")]
        [StringLength(11)]
        [DataType(DataType.PhoneNumber)]
        public string TelFixo { get; set; }


        [Required(ErrorMessage = "Informe o telefone movel")]
        [Display(Name = "Celular")]
        [StringLength(12)]
        [DataType(DataType.PhoneNumber)]
        public string TelMovel1 { get; set; }

        public string TelMovel2 { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Informe o email!")]
        [RegularExpression(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$", ErrorMessage = "Informe um email válido")]
        public string Email { get; set; }

        public List<NotaFiscal> NotasFicais { get; set; }

    }
}
