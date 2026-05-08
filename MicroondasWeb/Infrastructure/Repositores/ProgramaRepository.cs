using System.Text.Json;

public class ProgramaRepository : IProgramaRepository
{
    private readonly string _path;

    public ProgramaRepository(IWebHostEnvironment env)
    {
        var pasta = Path.Combine(env.ContentRootPath, "Data");

        // cria a pasta automaticamente
        if (!Directory.Exists(pasta))
            Directory.CreateDirectory(pasta);

        _path = Path.Combine(pasta, "programas.json");
    }

    public List<ProgramaAquecimento> ObterTodos()
    {
        var seed = ProgramaSeed.Criar();
        var custom = Carregar();

        return seed.Concat(custom).ToList();
    }

    public void SalvarTodos(List<ProgramaAquecimento> programas)
    {
        var custom = programas
            .Where(p => !p.Fixo)
            .ToList();

        var json = JsonSerializer.Serialize(custom, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(_path, json);
    }

    private List<ProgramaAquecimento> Carregar()
    {
        if (!File.Exists(_path))
            return new();

        var json = File.ReadAllText(_path);

        return JsonSerializer.Deserialize<List<ProgramaAquecimento>>(json)
               ?? new();
    }
}