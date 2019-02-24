using System.Collections.Generic;
using Newtonsoft.Json.Linq;
namespace entity_course
{
    internal class Produto
    {
        public int Id { get; internal set; }
        public string Nome { get; internal set; }
        public string Categoria { get; internal set; }
        public double Preco { get; internal set; }
    }

    public class Product
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public string Category { get; internal set; }
        public double UnityPrice { get; internal set; }
        public string Unity { get; internal set; }

        public IList<PromotionProduct> Promotions { get; internal set; }

        public override string ToString(){
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}