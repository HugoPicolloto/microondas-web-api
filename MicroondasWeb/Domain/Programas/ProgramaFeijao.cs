
public class ProgramaFeijao : ProgramaBase
{
    public override Guid Id => new Guid();
    public override string Nome => "Feijao";
    public override string Alimento => "Feijão congelado";
    public override int Tempo => 480;
    public override int Potencia => 9;
    public override string StringAquecimento => "";
    public override string Instrucoes =>
        "Deixe o recipiente destampado e em casos de plástico," +
        "cuidado ao retirar o recipiente pois o mesmo pode perder resistência em altas temperaturas";
    public override char Simbolo => '&';
}

