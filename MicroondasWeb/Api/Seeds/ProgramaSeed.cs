public static class ProgramaSeed
{
    public static List<ProgramaAquecimento> Criar()
    {
        return new List<ProgramaAquecimento>
        {
            Map(new ProgramaPipoca()),
            Map(new ProgramaLeite()),
            Map(new ProgramaCarneDeBoi()),
            Map(new ProgramaFrango()),
            Map(new ProgramaFeijao())
        };
    }

    private static ProgramaAquecimento Map(ProgramaBase p)
    {
        return new ProgramaAquecimento(
            p.Id,
            p.Nome,
            p.Alimento,
            p.Tempo,
            p.Potencia,
            p.StringAquecimento,
            p.Instrucoes,
            p.Simbolo,
            true // FIXO
        );
    }
}