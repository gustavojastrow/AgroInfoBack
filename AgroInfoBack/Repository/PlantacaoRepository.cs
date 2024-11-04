using AgroInfoBack.Context;
using AgroInfoBack.DTOs;
using Microsoft.EntityFrameworkCore;

using static AgroInfoBack.Models.PlantacaoModel;

namespace AgroInfoBack.Repository
{
    public class PlantacaoRepository : IPlantacaoRepository
    {
        private readonly AgroContext _context;

        public PlantacaoRepository(AgroContext context)
        {
            _context = context;
        }
        public async Task<List<PlantacaoDTO>> BuscarPlantacoesPorStatus(int status)
        {
            return await MapearParaDTO(_context.Plantacoes.Where(p => p.Status == status)).ToListAsync();
        }

        public async Task<Plantacao> RegistrarPlantacao(Plantacao plantacao)
        {
            await _context.Plantacoes.AddAsync(plantacao);
            await _context.SaveChangesAsync();
            return plantacao;
        }

        public async Task<List<PlantacaoDTO>> BuscarPlantacoes()
        {
            return await MapearParaDTO(_context.Plantacoes).ToListAsync();
        }

        public async Task<PlantacaoDTO> BuscarPlantacaoPorId(int id)
        {
            return await MapearParaDTO(_context.Plantacoes.Where(p => p.Id == id)).FirstOrDefaultAsync();
        }

        public async Task<Plantacao> AtualizarPlantacao(int id, Plantacao plantacaoAtualizada)
        {
            var plantacaoExistente = await _context.Plantacoes
                .Include(p => p.Agrotoxicos)
                .Include(p => p.Fertilizantes)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (plantacaoExistente == null) return null;

            AtualizarCamposBasicos(plantacaoExistente, plantacaoAtualizada);
            AtualizarColecao(plantacaoExistente.Agrotoxicos, plantacaoAtualizada.Agrotoxicos);
            AtualizarColecao(plantacaoExistente.Fertilizantes, plantacaoAtualizada.Fertilizantes);

            plantacaoExistente.DataConclusao = plantacaoAtualizada.DataConclusao;
            plantacaoExistente.QuantidadeObtida = plantacaoAtualizada.QuantidadeObtida;

            await _context.SaveChangesAsync();
            return plantacaoExistente;
        }


        public async Task<bool> ExcluirPlantacao(int id)
        {
            var plantacao = await _context.Plantacoes.FindAsync(id);
            if (plantacao == null) return false;

            _context.Plantacoes.Remove(plantacao);
            await _context.SaveChangesAsync();
            return true;
        }

        private IQueryable<PlantacaoDTO> MapearParaDTO(IQueryable<Plantacao> query)
        {
            return query.Select(p => new PlantacaoDTO
            {
                Id = p.Id,
                Nome = p.Nome,
                Descricao = p.Descricao,
                ImagemInicio = p.ImagemInicio,
                ImagemMeio = p.ImagemMeio,
                ImagemFim = p.ImagemFim,
                DataConclusao = p.DataConclusao,
                QuantidadeObtida = p.QuantidadeObtida,
                Agrotoxicos = p.Agrotoxicos.Select(a => new AgrotoxicoDTO
                {
                    Nome = a.Nome,
                    Tipo = a.Tipo,
                    DataAplicacao = a.DataAplicacao,
                    Objetivo = a.Objetivo,
                    Dosagem = a.Dosagem,
                    Descricao = a.Descricao,
                    NotaResultado = a.NotaResultado
                }).ToList(),
                Fertilizantes = p.Fertilizantes.Select(f => new FertilizanteDTO
                {
                    Nome = f.Nome,
                    Tipo = f.Tipo,
                    DataAplicacao = f.DataAplicacao,
                    Objetivo = f.Objetivo,
                    Quantidade = f.Quantidade,
                    Descricao = f.Descricao,
                    NotaResultado = f.NotaResultado
                }).ToList()
            });
        }

        private void AtualizarCamposBasicos(Plantacao destino, Plantacao origem)
        {
            destino.Nome = origem.Nome;
            destino.Descricao = origem.Descricao;
            destino.Status = origem.Status;
            destino.ImagemInicio = origem.ImagemInicio;
            destino.ImagemMeio = origem.ImagemMeio;
            destino.ImagemFim = origem.ImagemFim;
            destino.DataConclusao = origem.DataConclusao;
            destino.QuantidadeObtida = origem.QuantidadeObtida;
        }

        private void AtualizarColecao<T>(ICollection<T> destino, ICollection<T> origem) where T : class
        {
            destino.Clear();
            foreach (var item in origem)
            {
                destino.Add(item);
            }
        }
    }
}
