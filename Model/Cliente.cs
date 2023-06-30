using System.ComponentModel.DataAnnotations;

namespace API_ZAP.Model
{
    public class Cliente : User
    {
        [Key]
        public int IdCliente { get; set; }
        public String Nome { get; set; }

        public Cliente(string EmailUser, string SenhaUser, string nome) : base(EmailUser, SenhaUser)
        {
            Nome = nome;
        }
    }
}
