using API_ZAP.Model;
using Microsoft.AspNetCore.Mvc;

namespace API_ZAP.Controllers
{
    [ApiController]
    [Route("pedidos")]
    public class PedidosController : Controller
    {
        private DBZap db;
        public PedidosController(DBZap db)
        {
            this.db = db;
        }

        [HttpPost]
        [Route("create")]
        public ActionResult createPedido(Pedidos pedido)
        {
           try
            {
                db.Pedidos.Add(pedido);
                db.SaveChanges();
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpGet]
        [Route("pendentes")]
        public ActionResult getPendentes()
        {
            try
            {
                var result = db.Pedidos.Where(x => x.aprovado == false);
                if(result.Count() > 0)
                {
                    return Ok(result);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("pendentes")]
        public ActionResult setPendentes(int id)
        {
            try
            {
                var result = db.Pedidos.Find(id);
                if (result == null) return BadRequest();
                result.aprovado = true;
                db.SaveChanges();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }
}
