
public class ProgramaLeite : ProgramaBase
{
    public override Guid Id => new Guid();
    public override string Nome => "Leite";
    public override string Alimento => "Leite";
    public override int Tempo => 300;
    public override int Potencia => 5;
    public override string StringAquecimento => "";
    public override string Instrucoes =>
        "Cuidado com aquecimento de líquidos, o choque térmico " +
        "aliado ao movimento do recipiente pode causar fervura imediata causando risco de queimaduras";
    public override char Simbolo => '*';   
}

