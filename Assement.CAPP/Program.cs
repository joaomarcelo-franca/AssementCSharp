using Assement;
using Assement.Pessoa;
using Assement.Repositorio;
using Assement.CAPP;

class Program
{
    public static void Main(string[] args)
    {
        BancoDeAlunosFile banco5entidades = new BancoDeAlunosFile();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Entidades registrada no Arquivo .json");
        Console.WriteLine();
        Console.ResetColor();
        Console.ReadKey();
        banco5entidades.VerificarFila();
        IRepositorio repositorio;
        OperacoesCRUD opcrud;
        do
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Sistema de Cadastro para o Fies");
            Console.ResetColor();
            Console.WriteLine("Digite onde deseja que as informacoes sejam salvas!");
            Console.WriteLine("[1] - Em Lista");
            Console.WriteLine("[2] - Em Arquivo");
            int opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Repositorio em Lista escolhido");
                    repositorio = new BancoDeAlunosList();
                    break;
                case 2:
                    Console.WriteLine("Repositorio em Arquivo escolhido");
                    repositorio = new BancoDeAlunosFile();
                    break;
                default:
                    Console.WriteLine("Opcao invalida!");
                    Console.WriteLine("Repositorio em Lista escolhido");
                    repositorio = new BancoDeAlunosList();
                    break;
            }
            opcrud = new OperacoesCRUD(repositorio);
            Console.Clear();
            break;
        } while (true);
        bool verificar = true;
        do
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Sistema de Cadastro para o Fies");
            Console.ResetColor();
            Console.WriteLine("[1] - Cadastro de Aluno");
            Console.WriteLine("[2] - Verificar Fila de Alunos");
            Console.WriteLine("[3] - Verificar Aluno pela matricula");
            Console.WriteLine("[4] - Atualizar dados de Aluno");
            Console.WriteLine("[5] - Excluir Aluno");
            Console.WriteLine("[0] - Sair");
            Console.Write("Digite sua opcao: ");
            int opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    opcrud.AdicionarAlunoEmRepositorio();
                    break;
                case 2:
                    opcrud.VerificarFilaAlunos();
                    break;
                case 3:
                    opcrud.VerificarMatricula();
                    break;
                case 4:
                    opcrud.AlterarAluno();
                    break;
                case 5:
                    opcrud.ExcluirAluno();
                    break;
                case 0:
                    Console.Clear();
                    Console.WriteLine("Obrigado por utilizar nosso programa");
                    Console.ReadKey();
                    verificar = false;
                    break;
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Digite novamente");
                    break;
            }

        } while (verificar);

    }
}