using System.ComponentModel.DataAnnotations;

namespace API_ZAP.Model
{
    public class Funcionario : User
    {
        [Key]
        public int IdFuncionario { get; set; }
         
        public String Nome { get; set; }

        public bool ADM = true;
        public Funcionario(string EmailUser, string SenhaUser, string nome) : base(EmailUser, SenhaUser)
        {
            Nome = nome;
        }
    }
}
