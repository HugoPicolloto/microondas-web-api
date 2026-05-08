namespace MicroondasWeb.Application.DTOs.Request
{
    public class Programa
    {
        public Guid Id { get; }
        public string Nome { get; set; }
        public string Alimento { get; set; }
        public int Tempo { get; set; }
        public int Potencia { get; set; }
        public string StringAquecimento { get; set; }
        public bool PreDefinido { get; internal set; }
        public string Instrucao { get; set; }
        public char Simbolo { get; set; }
    }
}

