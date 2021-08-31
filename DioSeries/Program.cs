using System;

namespace DioSeries
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {

            string OpcaoUser = ObterOpcaoUser();

            while (OpcaoUser.ToUpper() != "X")
            {
                switch(OpcaoUser)
                {
                case "1":
                    Listarserie();
                    break;
                case "2":
                    Inserirserie();
                    break;
                case "3":
                    Atualizarserie();
                    break;
                case "4":
                    Excluirserie();
                    break;
                case "5":
                    Vizualizarserie();
                    break;
                case "C":
                    Console.Clear();
                    break;
                default:
                    throw new Exception("Insira Alguma opção!");
                }
                OpcaoUser = ObterOpcaoUser();
            }
            
        }

        public static void Listarserie()
        {
            Console.WriteLine("Listar Séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Série Cadastrada");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                if (!excluido)
                {
                    Console.WriteLine("#ID: {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
                }
                
            }
        }

        public static void Inserirserie()
        {
            Console.WriteLine("Inserir nova série");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o Gênero conforme as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Series novaSerie = new Series(id: repositorio.ProximoId(),
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);
        repositorio.Insere(novaSerie);
        }

        public static void Atualizarserie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o Gênero conforme as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Series atualizaSerie = new Series(id: indiceSerie,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);
        repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        public static void Excluirserie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Excluir(indiceSerie);
        }

        public static void Vizualizarserie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }

        public static string ObterOpcaoUser()
        {
            Console.WriteLine();
             Console.WriteLine("Olá, Bem-vindos!!");
              Console.WriteLine("Informe a opção desejada: ");
               Console.WriteLine("1- Listar Series!");
                Console.WriteLine("2- Inserir novas Série!");
                 Console.WriteLine("3- Atualizar série!");
                  Console.WriteLine("4- Excluir série!");
                   Console.WriteLine("5- Vizulizar série!");
                    Console.WriteLine("C- Limpar a tela.");
                     Console.WriteLine("X- Sair.");
                      Console.WriteLine();

            string OpcaoUser = Console.ReadLine().ToUpper();
            Console.WriteLine();      
            return OpcaoUser;
        }
    }
}
