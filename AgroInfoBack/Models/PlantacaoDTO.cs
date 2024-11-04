namespace AgroInfoBack.DTOs
{
    public class PlantacaoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Status { get; set; }
        public string? ImagemInicio { get; set; }
        public string? ImagemMeio { get; set; }
        public string? ImagemFim { get; set; }
        public DateTime? DataConclusao { get; set; }
        public int? QuantidadeObtida { get; set; }

        public List<AgrotoxicoDTO> Agrotoxicos { get; set; }
        public List<FertilizanteDTO> Fertilizantes { get; set; }
    }

    public class AgrotoxicoDTO
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public DateTime DataAplicacao { get; set; }
        public string Objetivo { get; set; }
        public string Dosagem { get; set; }
        public string Descricao { get; set; }
        public int NotaResultado { get; set; }
    }

    public class FertilizanteDTO
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public DateTime DataAplicacao { get; set; }
        public string Objetivo { get; set; }
        public string Quantidade { get; set; }
        public string Descricao { get; set; }
        public int NotaResultado { get; set; }
    }
}
