    using AgroInfoBack.Repository;
    using Microsoft.AspNetCore.Mvc;
    using static AgroInfoBack.Models.PlantacaoModel;

namespace AgroInfoBack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlantacaoController : ControllerBase
    {
        private readonly IPlantacaoRepository _plantacaoRepository;

        public PlantacaoController(IPlantacaoRepository plantacaoRepository)
        {
            _plantacaoRepository = plantacaoRepository;
        }

        [HttpGet]
        [Route("BuscarPlantacoesAtivas")]

        public async Task<IActionResult> BuscarPlantacoes()
        {
            var plantacoes = await _plantacaoRepository.BuscarPlantacoesPorStatus(0);
            return Ok(plantacoes);
        }
        [HttpGet]
        [Route("BuscarPlantacoesFinalizadas")]
        public async Task<IActionResult> BuscarPlantacoesFinalizadas()
        {
            var plantacoesFinalizadas = await _plantacaoRepository.BuscarPlantacoesPorStatus(1);
            return Ok(plantacoesFinalizadas);
        }


        [HttpPost]
        [Route("registrarPlantacao")]
        public async Task<IActionResult> RegisterPlantacao()
        {
            var formCollection = await Request.ReadFormAsync();

            var imagemInicio = formCollection.Files.Any(f => f.Name == "imagemInicio")
                ? await SalvarImagem(formCollection.Files, "imagemInicio")
                : null;

            var imagemMeio = formCollection.Files.Any(f => f.Name == "imagemMeio")
                ? await SalvarImagem(formCollection.Files, "imagemMeio")
                : null;

            var imagemFim = formCollection.Files.Any(f => f.Name == "imagemFim")
                ? await SalvarImagem(formCollection.Files, "imagemFim")
                : null;

            var plantacao = new Plantacao
            {
                Nome = formCollection["nome"],
                Descricao = formCollection["descricao"],
                ImagemInicio = imagemInicio,
                ImagemMeio = imagemMeio,
                ImagemFim = imagemFim,
                Status = 0,
                DataConclusao = formCollection.ContainsKey("dataConclusao") && DateTime.TryParse(formCollection["dataConclusao"], out var dataConclusao) ? dataConclusao : (DateTime?)null,
                QuantidadeObtida = formCollection.ContainsKey("quantidadeObtida") && int.TryParse(formCollection["quantidadeObtida"], out var quantidade) ? quantidade : (int?)null
            };

            if (formCollection.ContainsKey("agrotoxicos"))
            {
                foreach (var agrotoxico in formCollection["agrotoxicos"])
                {
                    var agrotoxicoData = Newtonsoft.Json.JsonConvert.DeserializeObject<Agrotoxico>(agrotoxico);
                    plantacao.Agrotoxicos.Add(agrotoxicoData);
                }
            }

            if (formCollection.ContainsKey("fertilizantes"))
            {
                foreach (var fertilizante in formCollection["fertilizantes"])
                {
                    var fertilizanteData = Newtonsoft.Json.JsonConvert.DeserializeObject<Fertilizante>(fertilizante);
                    plantacao.Fertilizantes.Add(fertilizanteData);
                }
            }

            await _plantacaoRepository.RegistrarPlantacao(plantacao);

            return CreatedAtAction(nameof(RegisterPlantacao), new { id = plantacao.Id }, plantacao);
        }



        [HttpGet]
        [Route("buscarPlantacao/{id}")]
        public async Task<IActionResult> BuscarPlantacaoPorId(int id)
        {
            var plantacao = await _plantacaoRepository.BuscarPlantacaoPorId(id);
            if (plantacao == null)
            {
                return NotFound($"Plantação com ID {id} não encontrada.");
            }
            return Ok(plantacao);
        }
            [HttpPut]
            [Route("atualizarPlantacao/{id}")]
            public async Task<IActionResult> AtualizarPlantacao(int id)
            {
                var formCollection = await Request.ReadFormAsync();
                var plantacaoExistente = await _plantacaoRepository.BuscarPlantacaoPorId(id);

                var imagemInicio = formCollection.Files["imagemInicio"] != null
                    ? await SalvarImagem(formCollection.Files, "imagemInicio")
                    : formCollection["imagemInicio"].ToString() ?? plantacaoExistente.ImagemInicio;

                var imagemMeio = formCollection.Files["imagemMeio"] != null
                    ? await SalvarImagem(formCollection.Files, "imagemMeio")
                    : formCollection["imagemMeio"].ToString() ?? plantacaoExistente.ImagemMeio;

                var imagemFim = formCollection.Files["imagemFim"] != null
                    ? await SalvarImagem(formCollection.Files, "imagemFim")
                    : formCollection["imagemFim"].ToString() ?? plantacaoExistente.ImagemFim;

                int status = formCollection.ContainsKey("status") && int.TryParse(formCollection["status"], out int parsedStatus)
                    ? parsedStatus
                    : plantacaoExistente.Status;

                DateTime? dataConclusao = formCollection.ContainsKey("dataConclusao") && DateTime.TryParse(formCollection["dataConclusao"], out var parsedDate)
                    ? parsedDate
                    : plantacaoExistente.DataConclusao;

                int? quantidadeObtida = formCollection.ContainsKey("quantidadeObtida") && int.TryParse(formCollection["quantidadeObtida"], out var parsedQuantity)
                    ? parsedQuantity
                    : plantacaoExistente.QuantidadeObtida;

                var plantacaoAtualizada = new Plantacao
                {
                    Nome = formCollection["nome"],
                    Descricao = formCollection["descricao"],
                    ImagemInicio = imagemInicio,
                    ImagemMeio = imagemMeio,
                    ImagemFim = imagemFim,
                    Status = status,
                    DataConclusao = dataConclusao,
                    QuantidadeObtida = quantidadeObtida,
                    Agrotoxicos = formCollection["agrotoxicos"]
                        .Select(agrotoxico => Newtonsoft.Json.JsonConvert.DeserializeObject<Agrotoxico>(agrotoxico))
                        .ToList(),
                    Fertilizantes = formCollection["fertilizantes"]
                        .Select(fertilizante => Newtonsoft.Json.JsonConvert.DeserializeObject<Fertilizante>(fertilizante))
                        .ToList()
                };

                var result = await _plantacaoRepository.AtualizarPlantacao(id, plantacaoAtualizada);

                if (result == null)
                    return NotFound($"Plantação com ID {id} não encontrada.");

                return Ok(result);
            }


        [HttpDelete]
        [Route("excluirPlantacao/{id}")]
        public async Task<IActionResult> ExcluirPlantacao(int id)
        {
            var sucesso = await _plantacaoRepository.ExcluirPlantacao(id);

            if (!sucesso)
                return NotFound($"Plantação com ID {id} não encontrada.");

            return NoContent();
        }

        private async Task<string> SalvarImagem(IFormFileCollection files, string fieldName)
        {
            var file = files.FirstOrDefault(f => f.Name == fieldName);
            if (file != null && file.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var filePath = Path.Combine(uploadsFolder, file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return $"/uploads/{file.FileName}";
            }
            return null;
        }
    }
}