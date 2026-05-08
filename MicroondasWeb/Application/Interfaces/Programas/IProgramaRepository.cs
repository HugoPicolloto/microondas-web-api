public interface IProgramaRepository
{
    List<ProgramaAquecimento> ObterTodos();
    void SalvarTodos(List<ProgramaAquecimento> programas);
}