using System.ComponentModel.DataAnnotations;

namespace API_ZAP.Model
{
    public class Pedidos
    {
        [Key]
        public int idPedido { get; set; }
        public Cliente cliente { get; set; }
        public List<Produto> produtos { get; set; }
        public bool aprovado { get; set; } = false;
        public double valor { get; set; }
    }
}
