using System.ComponentModel.DataAnnotations;

namespace API_ZAP.Model
{
    public class Produto
    {
        [Key]
        public int idProduto { get; set; }
        [MaxLength(30)]
        public string nomeProduto { get; set; }
        public double preco { get; set; }
        [MaxLength(200)]
        public string descricao { get; set; }

        public Produto(int idProduto, String nomeProduto, double preco, String descricao) {
            this.idProduto = idProduto;
            this.nomeProduto = nomeProduto;
            this.preco = preco;
            this.descricao = descricao;
        }
    }
}
