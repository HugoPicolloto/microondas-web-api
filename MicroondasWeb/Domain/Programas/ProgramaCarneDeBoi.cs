
public class ProgramaCarneDeBoi: ProgramaBase
{
    public override Guid Id => new Guid();
    public override string Nome => "Carnes de boi";
    public override string Alimento => "Carne em pedaço ou tiras";
    public override int Tempo => 840;
    public override int Potencia => 4;
    public override string StringAquecimento => "";
    public override string Instrucoes =>
        "Interrompa o processo na metade e vire o conteúdo " +
        "com a parte de baixo para cima para o descongelamento uniforme";
    public override char Simbolo => '%';   
}


