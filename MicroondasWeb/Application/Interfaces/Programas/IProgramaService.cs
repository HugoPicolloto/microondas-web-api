using MicroondasWeb.Application.DTOs.Request;
using MicroondasWeb.Application.DTOs.Response;

public interface IProgramaService
{
    List<ProgramaResp> Listar();
    ProgramaResp Criar(Programa request);
    void Remover(Guid id);
}