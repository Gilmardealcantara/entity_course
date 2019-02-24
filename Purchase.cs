namespace entity_course
{
    internal class Purchase
    {
        public int Id { get; set; }
        public int Qnt { get; internal set; }
        public int ProductId { get; internal set; }
        public Product Product { get; internal set; }
        public double Price { get; internal set; }

        public override string ToString(){
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}