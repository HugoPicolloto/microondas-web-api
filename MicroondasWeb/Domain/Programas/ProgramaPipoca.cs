public class ProgramaPipoca : ProgramaBase
{
    public override Guid Id => new Guid();
    public override string Nome => "Pipoca";
    public override string Alimento => "Pipoca (de micro-ondas)";
    public override int Tempo => 180;
    public override int Potencia => 7;
    public override string StringAquecimento => "";
    public override string Instrucoes =>
        "Se ficar mais de 10s sem estouro, interromper.";
    public override char Simbolo => '#';
    
}