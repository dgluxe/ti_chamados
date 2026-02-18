using OComeço;

GerenciadorChamados gerenciador = new();
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

        gerenciador.Criar(titulo, descricao);
    }
    else if (resposta == 2)
    {
        gerenciador.Listar();
    }
    else if (resposta == 3)
    {
        gerenciador.Fechar();
    }
    else
    {
        Console.WriteLine("Opção invalida");
    }


}

    Console.ReadKey();
