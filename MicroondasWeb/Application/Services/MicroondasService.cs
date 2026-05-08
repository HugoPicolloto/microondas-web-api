using MicroondasWeb.Application.DTOs.Response;

public class MicroondasService : IMicroondasService
{
    private readonly IMicroondasRepository _repositoryMicro;
    private readonly IProgramaRepository _programaRepository;


    public MicroondasService(IMicroondasRepository repository,  IProgramaRepository programaRepository)
    {
        _repositoryMicro = repository;
        _programaRepository = programaRepository;
    }

    public AquecimentoResp Iniciar(Aquecimento request)
    {
        var m = _repositoryMicro.Obter();

        // retomada
        if (m.Status == StatusMicroondas.Pausado)
        {
            m.Retomar();
            return Map(m);
        }

        // já executando → +30
        if (m.Status == StatusMicroondas.EmExecucao)
        {
            m.AdicionarTempo(30);
            return Map(m);
        }

        // início rápido
        if (!request.Tempo.HasValue && !request.Potencia.HasValue)
        {
            m.IniciarRapido();
            return Map(m);
        }

        var tempo = request.Tempo ?? 30;
        var potencia = request.Potencia ?? 10;

        m.Iniciar(tempo, potencia);
        return Map(m);
    }

    public AquecimentoResp IniciarPrograma(string nomePrograma)
    {
        var m = _repositoryMicro.Obter();

        var programa = _programaRepository.ObterTodos()
            .FirstOrDefault(x => x.Nome.Equals(nomePrograma, StringComparison.OrdinalIgnoreCase));

        m.IniciarPrograma(programa);

        _repositoryMicro.Salvar(m);

        return Map(m);
    }

    public AquecimentoResp Tick()
    {
        var m = _repositoryMicro.Obter();
        m.Tick();
        return Map(m);
    }

    public AquecimentoResp Pausar()
    {
        var m = _repositoryMicro.Obter();

        m.Pausar();
        return Map(m);
    }

    public void Cancelar()
    {
        var m = _repositoryMicro.Obter();

        m.Cancelar();
    }

    public AquecimentoResp ObterStatus()
    {
        var m = _repositoryMicro.Obter();

        return new AquecimentoResp
        {
            TempoRestante = m.TempoRestante,
            Status = m.Status.ToString(),
            StringAquecimento = m.StringAquecimento,
            Potencia = m.Potencia
        };
    }

    private AquecimentoResp Map(Microondas microondas)
    {
        return new AquecimentoResp
        {
            TempoRestante = microondas.TempoRestante,
            Status = microondas.Status.ToString(),
            StringAquecimento = microondas.StringAquecimento,
            Potencia = microondas.Potencia,
            ProgramaAtivo = microondas.ProgramaAtivo

        };
    }
}