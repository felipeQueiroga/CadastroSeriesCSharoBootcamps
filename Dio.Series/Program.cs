using Dio.Series.Enums;
using System;

namespace Dio.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = "";
            while (opcaoUsuario != "X")
            {
                opcaoUsuario = ObterOpcaoUsuario();
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    case "X":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opção invalida");
                        break;

                }
            }
        }

        private static void VisualizarSerie()
        {
            ListarSeries();

            Console.Write("Digite o Nº da sereie que deseja Visualizar:");
            int indiceSelecao = int.Parse(Console.ReadLine());
            Serie serieSelecionada = repositorio.RetornaPorId(indiceSelecao);

            Console.WriteLine(serieSelecionada);
            Console.WriteLine(); //quebra linha
        }

        private static void ExcluirSerie()
        {
            ListarSeries();

            Console.Write("Digite o Nº da sereie que deseja excluir:");
            int indiceExclusao = int.Parse(Console.ReadLine());
            Serie serieExcluida = repositorio.RetornaPorId(indiceExclusao);

            repositorio.Exclui(indiceExclusao);

            Console.WriteLine("Serie Excluida:");
            Console.WriteLine(serieExcluida);
            Console.WriteLine(); //quebra linha
        }

        private static void AtualizarSerie()
        {
            ListarSeries();

            Console.Write("Digite o Nº da sereie que deseja alterar:");
            int indiceAlteracao = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o Nº do genero acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o novo titulo da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o novo ano de inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a nova descricao da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie serieAtualiza = new Serie(id: indiceAlteracao,
                                  genero: (Genero)entradaGenero,
                                  titulo: entradaTitulo,
                                  ano: entradaAno,
                                  descricao: entradaDescricao);

            repositorio.Atualiza(indiceAlteracao, serieAtualiza);
            Console.WriteLine("Serie Atualizada:");
            Console.WriteLine(serieAtualiza);
            Console.WriteLine(); //quebra linha
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova serie");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o Nº do genero acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descricao da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                  genero: (Genero)entradaGenero,
                                  titulo: entradaTitulo,
                                  ano: entradaAno,
                                  descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
            Console.WriteLine("Serie cadastrada:");
            Console.WriteLine(novaSerie);
            Console.WriteLine(); //quebra linha
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Series ao seu dispor!!!");
            Console.WriteLine("Escolha a opção desejada:");
            Console.WriteLine("1 - Listar Series");
            Console.WriteLine("2 - Inserir Serie");
            Console.WriteLine("3 - Atualizar");
            Console.WriteLine("4 - Excluir");
            Console.WriteLine("5 - Visualizar");
            Console.WriteLine("C - Limpar a tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string OpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return OpcaoUsuario;
        }

        public static void ListarSeries()
        {
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma serie cadastrada!");
            }

            foreach (var serie in lista)
            {
                bool situacao = serie.RetonaExcluido();
                Console.WriteLine("#ID {0}: - {1} - {2}", serie.RetonaID(), serie.RetonaTitulo(), (situacao ? "*Excluido*" : ""));
            }
            Console.WriteLine(); //quebra linha
        }
    }
}
