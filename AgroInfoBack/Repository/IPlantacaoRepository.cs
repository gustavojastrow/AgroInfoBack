using AgroInfoBack.DTOs;
using static AgroInfoBack.Models.PlantacaoModel;

namespace AgroInfoBack.Repository
{
    public interface IPlantacaoRepository
    {
        Task<List<PlantacaoDTO>> BuscarPlantacoes();
        Task<List<PlantacaoDTO>> BuscarPlantacoesPorStatus(int status); 
        Task<PlantacaoDTO> BuscarPlantacaoPorId(int id);
        Task<Plantacao> RegistrarPlantacao(Plantacao plantacao);
        Task<Plantacao> AtualizarPlantacao(int id, Plantacao plantacaoAtualizada);
        Task<bool> ExcluirPlantacao(int id);
    }
}
