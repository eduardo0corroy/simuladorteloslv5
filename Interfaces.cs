namespace TelosKanban.Interfaces
{
    public interface IKanbanService
    {
        void AdicionarTarefa(string titulo, string descricao);
        void AlterarStatusTarefa(int id, StatusTarefa novoStatus);
        void ListarTarefas();
    }
}
