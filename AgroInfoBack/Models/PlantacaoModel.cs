using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AgroInfoBack.Models
{
    public class PlantacaoModel
    {
        public class Plantacao
        {
            public int Id { get; set; }

            [Required]
            public string Nome { get; set; }
            public int Status { get; set; }
            [Required]
            public string Descricao { get; set; }
            public string? ImagemInicio { get; set; }
            public string? ImagemMeio { get; set; }
            public string? ImagemFim { get; set; }
            public DateTime? DataConclusao { get; set; } 
            public int? QuantidadeObtida { get; set; }

            [JsonIgnore]
            public ICollection<Agrotoxico> Agrotoxicos { get; set; } = new List<Agrotoxico>();
            [JsonIgnore]
            public ICollection<Fertilizante> Fertilizantes { get; set; } = new List<Fertilizante>();
        }


        public class Agrotoxico
        {
            public int Id { get; set; }

            [Required]
            public string Nome { get; set; }

            [Required]
            public string Tipo { get; set; }

            public DateTime DataAplicacao { get; set; }
            public string Objetivo { get; set; }
            public string Dosagem { get; set; } 
            public string Descricao { get; set; }
            public int NotaResultado { get; set; }
            public int PlantacaoId { get; set; }

            [JsonIgnore]
            public Plantacao Plantacao { get; set; }
        }

        public class Fertilizante
        {
            public int Id { get; set; }

            [Required]
            public string Nome { get; set; }

            public string Objetivo { get; set; }
            public DateTime DataAplicacao { get; set; }
            public string Quantidade { get; set; }
            public string Descricao { get; set; }
            public int NotaResultado { get; set; }
            [Required]
            public string Tipo { get; set; }
            public int PlantacaoId { get; set; }
            [JsonIgnore] 
            public Plantacao Plantacao { get; set; }
        }
    }
}

