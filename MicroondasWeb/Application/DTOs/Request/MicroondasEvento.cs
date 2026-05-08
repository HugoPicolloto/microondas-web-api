
public class MicroondasEvento
{
    public MicroondasEventosTipo Tipos { get; set; }
    public DateTime OcorridoEm { get; set; } = DateTime.UtcNow;

    public int? TempoRestante { get; set; }
    public string? Bloco { get; set; }
    public string? Mensagem { get; set; }
}

