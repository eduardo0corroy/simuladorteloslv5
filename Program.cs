
using System;
using TelosKanban.Models;
using TelosKanban.Services;

namespace TelosKanban
{
    class Program
    {
        static void Main(string[] args)
        {
            var kanbanService = new KanbanService();
            string comando;

            Console.WriteLine("Bem-vindo ao sistema Kanban!");

            do
            {
                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("1 - Adicionar Tarefa");
                Console.WriteLine("2 - Alterar Status da Tarefa");
                Console.WriteLine("3 - Listar Tarefas");
                Console.WriteLine("0 - Sair");
                comando = Console.ReadLine();

                switch (comando)
                {
                    case "1":
                        Console.Write("Digite o título da tarefa: ");
                        string titulo = Console.ReadLine();
                        Console.Write("Digite a descrição da tarefa: ");
                        string descricao = Console.ReadLine();
                        kanbanService.AdicionarTarefa(titulo, descricao);
                        Console.WriteLine("Tarefa adicionada com sucesso!");
                        break;
                    case "2":
                        Console.Write("Digite o ID da tarefa para alterar: ");
                        if (int.TryParse(Console.ReadLine(), out int id))
                        {
                            Console.Write("Digite o novo status (0-A Fazer, 1-Em Progresso, 2-Concluido): ");
                            if (int.TryParse(Console.ReadLine(), out int statusId) && Enum.IsDefined(typeof(StatusTarefa), statusId))
                            {
                                kanbanService.AlterarStatusTarefa(id, (StatusTarefa)statusId);
                                Console.WriteLine("Status atualizado com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Status inválido.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("ID inválido.");
                        }
                        break;
                    case "3":
                        kanbanService.ListarTarefas();
                        break;
                    case "0":
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Comando inválido.");
                        break;
                }
            } while (comando != "0");
        }
    }
}
