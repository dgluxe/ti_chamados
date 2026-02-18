using System;
using System.Collections.Generic;
using System.Text;

namespace OComeço
{
    public class Chamado
    {
        public int Id;
        public string? Titulo;
        public string? Descricao;
        public bool EstaAberto;

    }

    public class GerenciadorChamados
    {
        
        public int Proximoid = 1;

        private List<Chamado> chamados = new List<Chamado>();


        public void Criar(string? titulo, string? descricao)
        {
           Chamado chamado = new Chamado();
            chamado.Titulo = titulo;
            chamado.Descricao = descricao;
            chamado.EstaAberto = true;
            chamado.Id = Proximoid;
            Proximoid++;

            chamados.Add(chamado);

            Console.WriteLine("\nChamado criado com sucesso\n");
        }
        public void Listar()
        {
            if (chamados.Count == 0)
            {
                Console.WriteLine("Não há chamados existentes");
                return;
            }

            foreach (Chamado chamadoItem in chamados)
            {
                Console.WriteLine($"ID: {chamadoItem.Id}");
                Console.WriteLine($"Titulo: {chamadoItem.Titulo}");
                Console.WriteLine($"Descrição: {chamadoItem.Descricao}");
                string status = chamadoItem.EstaAberto ? "Aberto" : "Fechado";
                Console.WriteLine($"Status do chamado: {status}\n");
            }
        }
        public void Fechar()
        {

            if (chamados.Count == 0)
            {
                Console.WriteLine("Não há chamados existentes");
                return;
            }
            foreach (Chamado chamadoItem in chamados)
            {
                Console.WriteLine($"ID: {chamadoItem.Id}");
                Console.WriteLine($"Titulo: {chamadoItem.Titulo}");
                Console.WriteLine($"Descrição: {chamadoItem.Descricao}");
                string status = chamadoItem.EstaAberto ? "Aberto" : "Fechado";
                Console.WriteLine($"Status do chamado: {status}\n \n");
            }
            Console.WriteLine("Digite o Número do ID que você pretende fechar!\n");
            int resposta1 = Convert.ToInt32(Console.ReadLine());

            bool encontrado = false;


            foreach (Chamado chamadoItem in chamados)
            {
                if (resposta1 == chamadoItem.Id)
                {
                    Console.WriteLine($"ID: {chamadoItem.Id}");
                    Console.WriteLine($"Titulo: {chamadoItem.Titulo}");
                    Console.WriteLine($"Descrição: {chamadoItem.Descricao}");
                    Console.WriteLine($"Status do chamado: {chamadoItem.EstaAberto}\n \n");

                    Console.WriteLine("Você gostaria de fechar esse chamado?");
                    Console.WriteLine("1 = Sim | 2 = Não\n");
                    int opcao = Convert.ToInt32(Console.ReadLine());

                    if (opcao == 1)
                    {
                        chamadoItem.EstaAberto = false;
                        Console.WriteLine("Chamado fechado com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("Operação cancelada.");
                    }

                    encontrado = true;
                    break;

                }
            }
            if (!encontrado)
            {
                Console.WriteLine("Chamado não encontrado.");
            }
        }
    } 
}

