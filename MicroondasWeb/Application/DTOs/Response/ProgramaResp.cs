namespace MicroondasWeb.Application.DTOs.Response
{
    public class ProgramaResp
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Alimento { get; set; }
        public int Tempo { get; set; }
        public int Potencia { get; set; }
        public string StringAquecimento { get; set; }
        public string Instrucao { get; set; }
        public char Simbolo { get; set; }
        public bool Fixo { get; set; }
    }
}
