using API_ZAP.Model;
using Microsoft.AspNetCore.Mvc;

namespace API_ZAP.Controllers
{
    [ApiController]
    [Route("produto")]
    public class ProdutoController : Controller
    {
        private DBZap db;
        public ProdutoController(DBZap db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult getProdutoById(int id)
        {
            Produto produto = db.Produtos.FirstOrDefault(x=> x.idProduto.Equals(id));
            if(produto == default) { 
                return NoContent();
            }
            return Ok(produto);
        }

        [HttpPost]
        [Route("create")]
        public ActionResult createProduto(Produto produto) {
            try
            {
                db.Produtos.Add(produto);
                db.SaveChanges();
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult deleteProdutoById(int id)
        {
            try
            {
                db.Produtos.Remove(db.Produtos.FirstOrDefault(x => x.idProduto.Equals(id)));
                db.SaveChanges();
                return Ok("Deleted");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("search")]
        public ActionResult searchProduto(String pesquisa)
        {
            var result = db.Produtos.Where(x => x.nomeProduto.Contains(pesquisa) || x.descricao.Contains(pesquisa));
            if (result.Count() > 0)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPut]
        [Route("update")]
        public ActionResult updateProduto(Produto produto)
        {
            try
            {
                var result = db.Produtos.FirstOrDefault(x => x.idProduto.Equals(produto.idProduto));
                if(result == default) return NotFound();

                result.preco = produto.preco;
                result.descricao = produto.descricao;
                result.nomeProduto = produto.nomeProduto;
                
                db.SaveChanges();
                return Ok(result);
            }
            catch (Exception ex) { return NotFound(ex); }
        }
    }
}
