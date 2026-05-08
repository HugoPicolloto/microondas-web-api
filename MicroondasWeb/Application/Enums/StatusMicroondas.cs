using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum StatusMicroondas
{
    Parado,
    EmExecucao,
    Pausado,
    Concluido
}