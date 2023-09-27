using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assement.Pessoa;
using Assement.Repositorio;


namespace Assement.CAPP
{
    internal class OperacoesCRUD
    {

        private IRepositorio _repositorio;
        private static int matricula = 0;
        public OperacoesCRUD(IRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public void AdicionarAlunoEmRepositorio()
        {
            //Pegando dados do Aluno
            Aluno aluno = new Aluno();
            string data;
            string[] nascimento;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Area de Cadastro de Aluno");
            Console.ResetColor();
            Console.Write("Informe seu nome: ");
            aluno.Nome = Console.ReadLine();
            Console.Write("Informe seu curso: ");
            aluno.Curso = Console.ReadLine();
            Console.Write("Informe sua renda familiar: ");
            aluno.RendaFamiliar = double.Parse(Console.ReadLine());
            Console.Write("Informe sua Data de Nascimento dd/mm/yyyy: ");
            data = Console.ReadLine();
            nascimento = data.Split("/");
            aluno.DataDeNascimento = new DateTime(int.Parse(nascimento[2]), int.Parse(nascimento[1]), int.Parse(nascimento[0]));
            aluno.Idade = aluno.CalcularIdade(aluno.DataDeNascimento);
            aluno.Matricula = matricula;
            aluno.Matriculado = true;
            matricula++;

            _repositorio.Adicionar(aluno);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{aluno.Nome} cadrastado com sucesso com matricula {aluno.Matricula}");
            Console.WriteLine("Aperte alguma tecla para prosseguir");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }
        public void VerificarFilaAlunos()
        {
            _repositorio.VerificarFila();
        }
        public void VerificarMatricula()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Area de verificar inscricao por matricula");
            Console.ResetColor();
            Console.Write("Digite a matricula do aluno: ");
            int matriculaEntrada = int.Parse(Console.ReadLine());
            _repositorio.VerificarMatricula(matriculaEntrada);
        }
        public void AlterarAluno()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Area de Alteraçao de inscricao por matricula");
            Console.ResetColor();
            Console.Write("Digite a matricula do aluno: ");
            int matriculaEntrada = int.Parse(Console.ReadLine());
            _repositorio.Atualizar(matriculaEntrada);
        }
        public void ExcluirAluno()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Area de Exclucao de inscricao por matricula");
            Console.ResetColor();
            Console.Write("Digite a matricula do aluno: ");
            int matriculaEntrada = int.Parse(Console.ReadLine());
            _repositorio.Excluir(matriculaEntrada);
        }
    }
}
