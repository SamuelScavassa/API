using System.ComponentModel.DataAnnotations;

namespace API_ZAP.Model
{
    public abstract class User
    {
   
        public String EmailUser { get; set; }

        public String SenhaUser { get; set; }

        public User(String EmailUser, String SenhaUser) 
        {
            this.EmailUser = EmailUser;
            this.SenhaUser = SenhaUser;
        }

    }
}
