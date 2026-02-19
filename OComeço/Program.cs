using OComeço;

ChamadoRepository repo = new();

while (true)
{


    Console.WriteLine("\nMenu\t");

    Console.WriteLine("Escolha qual opção voce deseja:\n 1 = Criar Chamado\n 2 = Listar Chamados\n 3 = Fechar Chamado\n Digite 0 para sair do programa\n");
    int resposta = Convert.ToInt32(Console.ReadLine());

    if (resposta == 0)
    {
        break;
    }

    if (resposta == 1)
    {
        Console.WriteLine("Digite o título");
        string? titulo = Console.ReadLine();

        Console.WriteLine("Digite a descrição");
        string? descricao = Console.ReadLine();

        repo.Criar(titulo!, descricao!);
        Console.WriteLine("Chamado criado no banco com sucesso");
    }
    else if (resposta == 2)
    {
        repo.Listar();
    }
    else if (resposta == 3)
    {
        Console.WriteLine("Digite o ID do chamado que deseja fechar:");
        int id = Convert.ToInt32(Console.ReadLine());
        repo.Fechar(id);

        System.Console.WriteLine("Chamado fechado");

    }
    else
    {
        Console.WriteLine("Opção invalida");
    }


}

    Console.ReadKey();
