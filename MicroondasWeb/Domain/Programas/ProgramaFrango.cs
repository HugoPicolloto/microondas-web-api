
public class ProgramaFrango: ProgramaBase
{
    public override Guid Id => new Guid();
    public override string Nome => "Frango";
    public override string Alimento => "Frango (qualquer corte)";
    public override int Tempo => 480;
    public override int Potencia => 7;
    public override string StringAquecimento => "";
    public override string Instrucoes =>
        "Interrompa o processo na metade e vire o conteúdo " +
        "com a parte de baixo para cima para o descongelamento uniforme";
    public override char Simbolo => '$';
   
}
