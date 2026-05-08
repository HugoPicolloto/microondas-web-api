public class Microondas
{
    public int TempoRestante { get; private set; }
    public int Potencia { get; private set; }
    public StatusMicroondas Status { get; private set; } = StatusMicroondas.Parado;
    public string StringAquecimento { get; private set; } = "";

    public bool ProgramaAtivo => _programa != null;

    private const int TempoMaximoSegundos = 120;
    private ProgramaAquecimento? _programa;

    public void Iniciar(int tempo, int potencia)
    {

        _programa = null;

        ValidarTempo(tempo);
        potencia = ValidarPotencia(potencia);

        TempoRestante = tempo;
        Potencia = potencia;
        Status = StatusMicroondas.EmExecucao;
        StringAquecimento = StringAquecimento;
        LimitarTempoMaximo();

    }

    public void IniciarPrograma(ProgramaAquecimento programa)
    {
        _programa = programa;

        TempoRestante = programa.TempoSegundos;
        Potencia = programa.Potencia;
        Status = StatusMicroondas.EmExecucao;
        StringAquecimento = programa.StringAquecimento;

    }

    public void IniciarRapido()
    {
        Iniciar(30, 10);
    }

    public void AdicionarTempo(int segundos)
    {
        if (Status != StatusMicroondas.EmExecucao)
            throw new DomainException("Só é possível adicionar tempo durante o aquecimento");

        if (_programa == null)
        {
            TempoRestante += segundos;
            LimitarTempoMaximo();

        }
    }

    public void Tick()
    {
        if (Status != StatusMicroondas.EmExecucao) return;

        if (TempoRestante > 0)
        {
            TempoRestante--;

            char simbolo = _programa?.Simbolo ?? '.';
            var bloco = new string(simbolo, Potencia);


            if (!string.IsNullOrEmpty(StringAquecimento))
                StringAquecimento += " ";

            StringAquecimento += bloco;

            if (TempoRestante == 0)
            {
                Status = StatusMicroondas.Concluido;
                StringAquecimento += " Aquecimento concluído";
            }
        }
    }

    public void Pausar()
    {
        if (Status == StatusMicroondas.EmExecucao)
            Status = StatusMicroondas.Pausado;
    }

    public void Cancelar()
    {
        _programa = null;

        Status = StatusMicroondas.Parado;
        TempoRestante = 0;
        StringAquecimento = "";
    }
    private void ValidarTempo(int tempo)
    {
        if (tempo < 1 || tempo > 120)
            throw new DomainException("Tempo deve ser entre 1 e 120");
    }

    private int ValidarPotencia(int potencia)
    {
        if (potencia == 0)
            potencia = 10;

        if (potencia < 1 || potencia > 10)
            throw new DomainException("Potência deve ser entre 1 e 10");

        return potencia;
    }

    public void Retomar()
    {
        if (Status == StatusMicroondas.Pausado)
            Status = StatusMicroondas.EmExecucao;

        if (_programa == null)
            LimitarTempoMaximo();

    }

    private void LimitarTempoMaximo()
    {
        if (TempoRestante > TempoMaximoSegundos)
            TempoRestante = TempoMaximoSegundos;
    }


}