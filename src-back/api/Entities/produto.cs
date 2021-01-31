using System;

namespace api.Entities
{
    public class produto
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public decimal valor { get; set; }
        public string unidade { get; set; }
        public DateTime data_criacao { get; set; }
    }
}
