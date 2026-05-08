
public class MicroondasRepository : IMicroondasRepository
{
    private Microondas _m = new();

    public Microondas Obter() => _m;

    public void Salvar(Microondas m)
        => _m = m;
}