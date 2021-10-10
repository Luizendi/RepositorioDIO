using System;

namespace SeriesDIO
{
    class Program
    {
        static vRepositorio vnRepositorio = new vRepositorio();
        static void Main(string[] args)
        {
            Console.WriteLine("////////////\\\\\\\\\\\\\\\\\\\\\\\\");
            Console.WriteLine("   Seja bem-vindo ao");
            Console.WriteLine("     LuizendiFlix");
            Console.WriteLine("////////////\\\\\\\\\\\\\\\\\\\\\\\\");
            Console.WriteLine();

            string opcaoMenu = Menu();

            while (opcaoMenu.ToUpper() != "X")
            {
                switch (opcaoMenu)
                {
                    case "L":
                        ListarSeries();
                        break;
                    case "I":
                        InserirCadastro();
                        break;
                    case "U":
                        ModificarCadastro();
                        break;
                    case "D":
                        ExcluirCadastro();
                        break;
                    case "V":
                        VisualizarCadastro();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoMenu = Menu();
            }
            Console.WriteLine("Agradecemos por utilizar nossa plataforma");
            Console.WriteLine("A aplicação será finalizada!!");
            Console.ReadLine();
        }

        private static string Menu()
        {
            Console.WriteLine("----Menu----");
            Console.WriteLine("Escolha a opção desejada");
            Console.WriteLine();
            Console.WriteLine("L - Listar séries");
            Console.WriteLine("I - Inserir novo cadastro");
            Console.WriteLine("U - Modificar cadastro");
            Console.WriteLine("D - Excluir cadastro");
            Console.WriteLine("V - Visualizar cadastro");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine("------------");

            string opcaoMenu = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoMenu;
        }

        private static void ListarSeries()
        {
            Console.WriteLine("------------");

            var listagem = vnRepositorio.Lista();

            if (listagem.Count == 0)
            {
                Console.WriteLine("Infelizmente não existe nenhum registro!");
                Console.WriteLine("------------");
                Console.WriteLine();
                return;
            }

            foreach (var serieD in listagem)
            {
                var excluido = serieD.retornaExcluido();
                if (excluido == false)
                {
                    Console.WriteLine("Série disponível: ");
                    Console.WriteLine("#Série {0}: {1}", serieD.retornaID(), serieD.retornatitulo());
                    Console.WriteLine("------------");
                }
                else
                { 
                    Console.WriteLine("Série Cancelada: ");
                    Console.WriteLine("#Série {0}: {1}", serieD.retornaID(), serieD.retornatitulo());
                    Console.WriteLine("------------");
                }
                Console.WriteLine();
            }
        }
        private static void InserirCadastro()
        {
            Console.WriteLine("------------");
            Console.WriteLine("Insira a nova série:");

            foreach (int i in Enum.GetValues(typeof(GenEnum)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(GenEnum), i));
            }
            Console.WriteLine("------------");
            Console.WriteLine("Escolha o gênero a partir das opções acima: ");
            int rGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("------------");

            Console.WriteLine("Insira o título: ");
            string rTitulo = Console.ReadLine();
            Console.WriteLine("------------");

            Console.WriteLine("Insira o ano de início da série: ");
            int rAno = int.Parse(Console.ReadLine());
            Console.WriteLine("------------");

            Console.WriteLine("Insira a descrição: ");
            string rDescricao = Console.ReadLine();
            Console.WriteLine("------------");
            Console.WriteLine();

            Series novoCadastro = new Series(id: vnRepositorio.ProximoId(),
                                             genero: (GenEnum)rGenero,
                                             titulo: rTitulo,
                                             ano: rAno,
                                             descricao: rDescricao);
            vnRepositorio.Insere(novoCadastro);
        }

        private static void ModificarCadastro()
        {
            Console.WriteLine("Modificação de Cadastro");
            Console.WriteLine("Digite o ID da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(GenEnum)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(GenEnum), i));
            }
            Console.WriteLine("------------");
            Console.WriteLine("Escolha o gênero a partir das opções acima: ");
            int rGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("------------");

            Console.WriteLine("Insira o título: ");
            string rTitulo = Console.ReadLine();
            Console.WriteLine("------------");

            Console.WriteLine("Insira o ano de início da série: ");
            int rAno = int.Parse(Console.ReadLine());
            Console.WriteLine("------------");

            Console.WriteLine("Insira a descrição: ");
            string rDescricao = Console.ReadLine();
            Console.WriteLine("------------");
            Console.WriteLine();

            Series modificaCadastro = new Series(id: idSerie,
                                             genero: (GenEnum)rGenero,
                                             titulo: rTitulo,
                                             ano: rAno,
                                             descricao: rDescricao);
            vnRepositorio.Atualiza(idSerie, modificaCadastro);

            Console.WriteLine("Cadastro atualizado com sucesso!");
            Console.WriteLine();
        }

        private static void ExcluirCadastro()
        {
            Console.WriteLine("Exclusão de Cadastro");
            Console.WriteLine("Digite o ID para excluir: ");
            int idSerie = int.Parse(Console.ReadLine());
            
            vnRepositorio.Exclui(idSerie);
            Console.WriteLine("cadastro excluído com sucesso!");
            Console.WriteLine();
        }

        private static void VisualizarCadastro()
        {
            Console.WriteLine("Visualização de Cadastro");
            Console.WriteLine("Digite o ID para visualizar: ");
            int idSerie = int.Parse(Console.ReadLine());

            var serie = vnRepositorio.RetornaPorId(idSerie);

            Console.WriteLine("------------");
            Console.WriteLine("Informações da Série: ");
            Console.WriteLine(serie);
            Console.WriteLine("------------");
            Console.WriteLine();
        }
    }
}
