using System;
using System.Collections.Generic;

class Program
{
    static List<string> aFazer = new List<string>();
    static List<string> emProgresso = new List<string>();
    static List<string> concluido = new List<string>();

    static void Main()
    {
        int opcao = 0;
        do
        {
            Console.WriteLine("Menu de Opções:");
            Console.WriteLine("1 - Adicionar nova tarefa");
            Console.WriteLine("2 - Exibir tarefas");
            Console.WriteLine("3 - Mover tarefa");
            Console.WriteLine("4 - Sair");
            Console.Write("Escolha uma opção: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    AdicionarTarefa();
                    break;
                case 2:
                    ExibirTarefas();
                    break;
                case 3:
                    MoverTarefa();
                    break;
                case 4:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }
        } while (opcao != 4);
    }

    static void AdicionarTarefa()
    {
        Console.Write("Digite o nome da nova tarefa: ");
        string tarefa = Console.ReadLine();
        aFazer.Add(tarefa);
        Console.WriteLine("Tarefa adicionada à lista 'A Fazer'.");
    }

    static void ExibirTarefas()
    {
        Console.WriteLine("\nTarefas 'A Fazer':");
        if (aFazer.Count == 0)
            Console.WriteLine("Nenhuma tarefa na lista.");
        else
            aFazer.ForEach(tarefa => Console.WriteLine(tarefa));

        Console.WriteLine("\nTarefas 'Em Progresso':");
        if (emProgresso.Count == 0)
            Console.WriteLine("Nenhuma tarefa na lista.");
        else
            emProgresso.ForEach(tarefa => Console.WriteLine(tarefa));

        Console.WriteLine("\nTarefas 'Concluído':");
        if (concluido.Count == 0)
            Console.WriteLine("Nenhuma tarefa na lista.");
        else
            concluido.ForEach(tarefa => Console.WriteLine(tarefa));
    }

    static void MoverTarefa()
    {
        Console.WriteLine("Escolha a lista de origem:");
        Console.WriteLine("1 - A Fazer");
        Console.WriteLine("2 - Em Progresso");
        Console.Write("Digite o número da lista: ");
        int origem = int.Parse(Console.ReadLine());

        List<string> listaOrigem = null;
        List<string> listaDestino = null;
        string nomeOrigem = "", nomeDestino = "";

        if (origem == 1)
        {
            listaOrigem = aFazer;
            listaDestino = emProgresso;
            nomeOrigem = "A Fazer";
            nomeDestino = "Em Progresso";
        }
        else if (origem == 2)
        {
            listaOrigem = emProgresso;
            listaDestino = concluido;
            nomeOrigem = "Em Progresso";
            nomeDestino = "Concluído";
        }
        else
        {
            Console.WriteLine("Lista de origem inválida.");
            return;
        }

        if (listaOrigem.Count == 0)
        {
            Console.WriteLine($"Nenhuma tarefa na lista '{nomeOrigem}'.");
            return;
        }

        Console.WriteLine($"Tarefas na lista '{nomeOrigem}':");
        for (int i = 0; i < listaOrigem.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {listaOrigem[i]}");
        }

        Console.Write("Escolha o número da tarefa para mover: ");
        int tarefaIndex = int.Parse(Console.ReadLine()) - 1;

        if (tarefaIndex < 0 || tarefaIndex >= listaOrigem.Count)
        {
            Console.WriteLine("Tarefa inválida.");
            return;
        }

        string tarefa = listaOrigem[tarefaIndex];
        listaOrigem.RemoveAt(tarefaIndex);
        listaDestino.Add(tarefa);
        Console.WriteLine($"Tarefa movida para '{nomeDestino}'.");
    }
}
