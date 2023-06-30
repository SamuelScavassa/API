using API_ZAP.Model;
using Microsoft.AspNetCore.Mvc;

namespace API_ZAP.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : Controller
    {
        private DBZap db;
        public ClienteController(DBZap db)
        {
            this.db = db;
        }

        [HttpPost]
        [Route("cadastro")]
        public ActionResult Create(Cliente cliente)
        {
            Cliente? usr = db.Clientes.FirstOrDefault(x => x.EmailUser == cliente.EmailUser);
            if (usr == default)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return Ok(cliente);
            }
            return NotFound("Email já cadastrado");
        }

        public class Log
        {
            public String email { get; set; }
            public String senha { get; set; }
        }

        [HttpPost]
        [Route("login")]
        public  ActionResult Login(Log log)
        {
            Cliente? usr =  db.Clientes.FirstOrDefault(x => x.EmailUser == log.email);
            Funcionario? funcionario =  db.Funcionarios.FirstOrDefault(x => x.EmailUser == log.email);
            if (usr != default)
            {
                if (usr.SenhaUser == log.senha)
                {
                   
                    return Ok(usr);
                }
            }
            if(funcionario != default)
            {
                if (funcionario.SenhaUser == log.senha)
                {
                   
                    return Ok(funcionario);
                }
            }
            return NotFound("User não cadastrado");
        }

        [HttpPut]
        [Route("update")]
        public ActionResult Update(Cliente alter)
        {
            Cliente? cliente = db.Clientes.FirstOrDefault(x => x.IdCliente == alter.IdCliente);
            if(cliente == default)
            {
                return BadRequest();
            }
            cliente.Nome = alter.Nome;
            cliente.EmailUser = alter.EmailUser;
            
            db.SaveChanges();
            return Ok(cliente);
        }

    }
}
