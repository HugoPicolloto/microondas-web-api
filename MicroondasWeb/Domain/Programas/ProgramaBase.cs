public abstract class ProgramaBase
{
    public abstract Guid Id { get; }
    public abstract string Nome { get; }
    public abstract string Alimento { get; }
    public abstract int Tempo { get; }
    public abstract int Potencia { get; }
    public abstract string StringAquecimento { get; }
    public abstract string Instrucoes { get; }
    public abstract char Simbolo { get; }

}