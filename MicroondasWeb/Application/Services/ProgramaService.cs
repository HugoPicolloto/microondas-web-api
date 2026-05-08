using MicroondasWeb.Application.DTOs.Request;
using MicroondasWeb.Application.DTOs.Response;

public class ProgramaService : IProgramaService
{
    private readonly IProgramaRepository _repo;

    public ProgramaService(IProgramaRepository repo)
    {
        _repo = repo;
    }

    public List<ProgramaResp> Listar()
        => _repo.ObterTodos().Select(Map).ToList();

    public ProgramaResp Criar(Programa req)
    {
        var lista = _repo.ObterTodos();

        if (lista.Any(x => x.Simbolo == req.Simbolo))
            throw new DomainException($"Já existe um programa com a string de aquecimento ' {req.Simbolo} '");

        var programa = new ProgramaAquecimento(

            Guid.NewGuid(),
            req.Nome,
            req.Alimento,
            req.Tempo,
            req.Potencia,
            req.StringAquecimento ?? "",
            req.Instrucao,
            req.Simbolo,
            false
        );

        lista.Add(programa);
        _repo.SalvarTodos(lista);

        return Map(programa);
    }

    public void Remover(Guid id)
    {
        var lista = _repo.ObterTodos()
            .Where(x => x.Id != id)
            .ToList();

        _repo.SalvarTodos(lista);
    }

    private ProgramaResp Map(ProgramaAquecimento p)
    {
        return new ProgramaResp
        {
            Id = p.Id,
            Nome = p.Nome,
            Alimento = p.Alimento,
            Tempo = p.TempoSegundos,
            Potencia = p.Potencia,
            Instrucao = p.Instrucao,
            Simbolo = p.Simbolo,
            Fixo = p.Fixo
        };
    }
}