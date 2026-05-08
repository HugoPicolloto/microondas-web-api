using MicroondasWeb.Application.DTOs.Response;

public interface IMicroondasService
{
    AquecimentoResp Iniciar(Aquecimento request);
    AquecimentoResp Tick();
    AquecimentoResp Pausar();
    AquecimentoResp ObterStatus();
    AquecimentoResp IniciarPrograma(string nomePrograma);

    void Cancelar();
}