namespace MicroondasWeb.Application.DTOs.Response
{
    public class AquecimentoResp
    {
        public int TempoRestante { get; set; }
        public int Potencia { get; set; }
        public string Status { get; set; } = "";
        public string? StringAquecimento { get; set; }
        public string? Mensagem { get; set; }
        public bool ProgramaAtivo { get; set; }
    }
}