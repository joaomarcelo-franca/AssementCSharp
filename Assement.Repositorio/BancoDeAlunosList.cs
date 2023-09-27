using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assement;
using Assement.Pessoa;

namespace Assement.Repositorio
{
    public class BancoDeAlunosList : IRepositorio
    {
        private List<Aluno> alunosCadastrados = new List<Aluno>();
        public void Adicionar(Aluno aluno)
        {
            alunosCadastrados.Add(aluno);
        }

        public void Atualizar(int matricula)
        {
            Aluno alunoMatricula = alunosCadastrados.Find(aluno => aluno.Matricula == matricula);
            int decisao = 0;
            if (alunoMatricula == null)
            {
                Console.WriteLine("Nenhum aluno encontrado com essa matricula");
            }
            else
            {
                Console.WriteLine("Aluno encontrado:");
                Console.WriteLine();
                Console.WriteLine($"Nome: {alunoMatricula.Nome}");
                Console.WriteLine($"Curso: {alunoMatricula.Curso}");
                Console.WriteLine($"Renda Familiar: {alunoMatricula.RendaFamiliar}");
                Console.WriteLine($"Data de Nascimento: {alunoMatricula.DataDeNascimento}");
                Console.WriteLine($"Matrícula: {alunoMatricula.Matricula}");
                Console.WriteLine($"Idade: {alunoMatricula.Idade}");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Deseja alterar dados do aluno {alunoMatricula.Nome}");
                Console.WriteLine("[1] - Alterar / [2] - Cancelar");
                Console.ResetColor();
                decisao = int.Parse(Console.ReadLine());
            }
            if (decisao == 1)
            {
                Console.WriteLine("Area de Alteracao de dados");
                Aluno aluno = new Aluno();
                aluno.Matricula = alunoMatricula.Matricula;
                Console.Write("Nome:");
                aluno.Nome = Console.ReadLine();
                Console.Write("Curso:");
                aluno.Curso = Console.ReadLine();
                Console.Write("Renda Familiar:");
                aluno.RendaFamiliar = double.Parse(Console.ReadLine());
                Console.Write("Data de Nascimento:");
                string data = Console.ReadLine();
                string[] nascimento = data.Split("/");
                aluno.DataDeNascimento = new DateTime(int.Parse(nascimento[2]), int.Parse(nascimento[1]), int.Parse(nascimento[0]));
                aluno.Idade = aluno.CalcularIdade(aluno.DataDeNascimento);
                alunosCadastrados.Remove(alunoMatricula);
                Adicionar(aluno);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Alteracao de dados de Aluno Concluida");
                Console.ResetColor();
            }
            else if (decisao == 2)
            {
                Console.WriteLine("Alteracao de dados de Aluno Cancelada");

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Operacao nao encontrada! Voltando ao menu");
            }
            Console.WriteLine("Aperte alguma tecla para prosseguir");
            Console.ReadKey();
            Console.Clear();
        }

        public void Excluir(int matricula)
        {
            Aluno alunoMatricula = alunosCadastrados.Find(aluno => aluno.Matricula == matricula);
            int decisao = 0;
            if (alunoMatricula == null)
            {
                Console.WriteLine("Nenhum aluno encontrado com essa matricula");
                Console.Clear();
            }
            else
            {
                Console.Write("Aluno encontrado: ");
                Console.WriteLine();
                Console.WriteLine($"Nome: {alunoMatricula.Nome}");
                Console.WriteLine($"Curso: {alunoMatricula.Curso}");
                Console.WriteLine($"Renda Familiar: {alunoMatricula.RendaFamiliar}");
                Console.WriteLine($"Data de Nascimento: {alunoMatricula.DataDeNascimento}");
                Console.WriteLine($"Matrícula: {alunoMatricula.Matricula}");
                Console.WriteLine($"Idade: {alunoMatricula.Idade}");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Deseja excluir o aluno {alunoMatricula.Nome}");
                Console.WriteLine("[1] - Excluir / [2] - Cancelar");
                decisao = int.Parse(Console.ReadLine());
            }
            if (decisao == 1)
            {
                alunosCadastrados.Remove(alunoMatricula);
                Console.WriteLine("Exclucao Realizada");
                Console.WriteLine($"O Aluno {alunoMatricula.Nome} com matricula {alunoMatricula.Matricula} foi excluido da Fila do Fies");
                Console.WriteLine("Aperte alguma tecla para prosseguir");
            }
            else if (decisao == 2)
            {
                Console.WriteLine("Exclucao de Aluno Cancelada");
                Console.WriteLine("Aperte alguma tecla para prosseguir");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Operacao nao encontrada! Voltando ao menu");
                Console.WriteLine("Aperte alguma tecla para prosseguir");
            }
            Console.ReadKey();
            Console.Clear();
        }

        public void VerificarFila()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Area de Fila");
            Console.ResetColor();
            if (alunosCadastrados.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nenhum Aluno Cadastrado");
                Console.ResetColor();

            }
            else
            {
                foreach (var aluno in alunosCadastrados)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Nome: {aluno.Nome}");
                    Console.WriteLine($"Curso: {aluno.Curso}");
                    Console.WriteLine($"Renda Familiar: {aluno.RendaFamiliar}");
                    Console.WriteLine($"Data de Nascimento: {aluno.DataDeNascimento}");
                    Console.WriteLine($"Matrícula: {aluno.Matricula}");
                    Console.WriteLine($"Idade: {aluno.Idade}");
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Aperte alguma tecla para voltar ao menu");
            Console.ReadKey();
            Console.Clear();
        }

        public void VerificarMatricula(int matricula)
        {
            Aluno alunoMatricula = alunosCadastrados.Find(aluno => aluno.Matricula == matricula);
            if (alunoMatricula == null)
            {
                Console.WriteLine("Nenhum aluno encontrado com essa matricula");
            }
            else
            {
                Console.WriteLine("Aluno encontrado:");
                Console.WriteLine();
                Console.WriteLine($"Nome: {alunoMatricula.Nome}");
                Console.WriteLine($"Curso: {alunoMatricula.Curso}");
                Console.WriteLine($"Renda Familiar: {alunoMatricula.RendaFamiliar}");
                Console.WriteLine($"Data de Nascimento: {alunoMatricula.DataDeNascimento}");
                Console.WriteLine($"Matrícula: {alunoMatricula.Matricula}");
                Console.WriteLine($"Idade: {alunoMatricula.Idade}");
                Console.WriteLine();
            }
            Console.WriteLine("Aperte alguma tecla para voltar ao menu");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
