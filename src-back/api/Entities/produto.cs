using System;

namespace api.Entities
{
    public class produto
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public decimal? valor { get; set; }
        public string unidade { get; set; }
        public DateTime? datahora_cadastro { get; set; }

        public int? categoriaid { get; set; }
        public categoria categoria { get; set; }
    }
}
