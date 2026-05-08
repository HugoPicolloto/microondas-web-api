public class ProgramaAquecimento
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Alimento { get; private set; }
    public int TempoSegundos { get; private set; }
    public int Potencia { get; private set; }
    public string StringAquecimento { get; private set; }
    public string Instrucao { get; private set; }
    public char Simbolo { get; private set; }
    public bool Fixo { get; private set; }

    public ProgramaAquecimento(
        Guid id,
        string nome,
        string alimento,
        int tempoSegundos,
        int potencia,
        string stringAquecimento,
        string instrucao,
        char simbolo,
        bool fixo)
    {
        Id = id;
        Nome = nome;
        Alimento = alimento;
        TempoSegundos = tempoSegundos;
        Potencia = potencia;
        StringAquecimento = stringAquecimento;
        Instrucao = instrucao;
        Simbolo = simbolo;
        Fixo = fixo;
    }
}