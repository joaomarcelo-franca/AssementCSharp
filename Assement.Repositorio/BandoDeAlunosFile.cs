using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Assement.Pessoa;


namespace Assement.Repositorio
{
    public class BancoDeAlunosFile : IRepositorio
    {
        String caminhoRepositorio = @"RepositorioFile.json";

        public void Adicionar(Aluno aluno)
        {

            string json = JsonConvert.SerializeObject(aluno);
            using (StreamWriter writer = new StreamWriter(caminhoRepositorio, true))
            {
                writer.WriteLine(json);
            }


        }

        public void Atualizar(int matricula)
        {
            bool encontrado = false;
            int decisao = 0;
            List<String> linhas = new List<String>(File.ReadAllLines(caminhoRepositorio));
            foreach (String linha in linhas)
            {
                Aluno aluno = JsonConvert.DeserializeObject<Aluno>(linha);
                if (aluno.Matricula == matricula)
                {
                    Console.Write("Aluno encontrado: ");
                    Console.WriteLine();
                    Console.WriteLine($"Nome: {aluno.Nome}");
                    Console.WriteLine($"Curso: {aluno.Curso}");
                    Console.WriteLine($"Renda Familiar: {aluno.RendaFamiliar}");
                    Console.WriteLine($"Data de Nascimento: {aluno.DataDeNascimento}");
                    Console.WriteLine($"Matrícula: {aluno.Matricula}");
                    Console.WriteLine($"Idade: {aluno.Idade}");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Deseja excluir o aluno {aluno.Nome}");
                    Console.WriteLine("[1] - Alterar / [2] - Cancelar");
                    decisao = int.Parse(Console.ReadLine());
                    if (decisao == 1)
                    {
                        Console.WriteLine("Area de Alteracao de dados");
                        Aluno alunoNovo = new Aluno();
                        alunoNovo.Matricula = aluno.Matricula;
                        Console.Write("Nome:");
                        alunoNovo.Nome = Console.ReadLine();
                        Console.Write("Curso:");
                        alunoNovo.Curso = Console.ReadLine();
                        Console.Write("Renda Familiar:");
                        alunoNovo.RendaFamiliar = double.Parse(Console.ReadLine());
                        Console.Write("Data de Nascimento:");
                        string data = Console.ReadLine();
                        string[] nascimento = data.Split("/");
                        alunoNovo.DataDeNascimento = new DateTime(int.Parse(nascimento[2]), int.Parse(nascimento[1]), int.Parse(nascimento[0]));
                        alunoNovo.Idade = aluno.CalcularIdade(alunoNovo.DataDeNascimento);
                        linhas.Remove(linha);
                        string json = JsonConvert.SerializeObject(alunoNovo);
                        linhas.Add(json);
                        File.WriteAllLines(caminhoRepositorio, linhas);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Alteracao de dados de Aluno Concluida");
                        Console.ResetColor();

                    }
                    else if (decisao == 2)
                    {
                        Console.WriteLine("Exclucao de Aluno Cancelada");
                    }
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("Nenhum aluno encontrado com essa matricula");
            }
            Console.WriteLine("Aperte alguma tecla para voltar ao menu");
            Console.ReadKey();
            Console.Clear();
        }

        public void Excluir(int matricula)
        {
            bool encontrado = false;
            List<String> linhas = new List<String>(File.ReadAllLines(caminhoRepositorio));
            int decisao = 0;
            foreach (string linha in linhas)
            {
                Aluno aluno = JsonConvert.DeserializeObject<Aluno>(linha);
                if (aluno.Matricula == matricula)
                {
                    Console.Write("Aluno encontrado: ");
                    Console.WriteLine();
                    Console.WriteLine($"Nome: {aluno.Nome}");
                    Console.WriteLine($"Curso: {aluno.Curso}");
                    Console.WriteLine($"Renda Familiar: {aluno.RendaFamiliar}");
                    Console.WriteLine($"Data de Nascimento: {aluno.DataDeNascimento}");
                    Console.WriteLine($"Matrícula: {aluno.Matricula}");
                    Console.WriteLine($"Idade: {aluno.Idade}");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Deseja excluir o aluno {aluno.Nome}");
                    Console.WriteLine("[1] - Excluir / [2] - Cancelar");
                    decisao = int.Parse(Console.ReadLine());
                    if (decisao == 1)
                    {
                        linhas.Remove(linha);
                        File.WriteAllLines(caminhoRepositorio, linhas);
                        Console.WriteLine("Exclucao Realizada");
                        Console.WriteLine($"O Aluno {aluno.Nome} com matricula {aluno.Matricula} foi excluido da Fila do Fies");

                    }
                    else if (decisao == 2)
                    {
                        Console.WriteLine("Exclucao de Aluno Cancelada");
                    }
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("Nenhum aluno encontrado com essa matricula");
            }
            Console.WriteLine("Aperte alguma tecla para voltar ao menu");
            Console.ReadKey();
            Console.Clear();
        }

        public void VerificarFila()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Area de Fila");
            Console.ResetColor();
            if (!File.Exists(caminhoRepositorio))
            {
                File.Create(caminhoRepositorio);
            }

            string[] linhas = File.ReadAllLines(caminhoRepositorio);

            foreach (string linha in linhas)
            {
                Aluno aluno = JsonConvert.DeserializeObject<Aluno>(linha);
                if (aluno != null)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Nome: {aluno.Nome}");
                    Console.WriteLine($"Curso: {aluno.Curso}");
                    Console.WriteLine($"Renda Familiar: {aluno.RendaFamiliar}");
                    Console.WriteLine($"Data de Nascimento: {aluno.DataDeNascimento}");
                    Console.WriteLine($"Matrícula: {aluno.Matricula}");
                    Console.WriteLine($"Idade: {aluno.Idade}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nenhum Aluno Cadastrado");
                    Console.ResetColor();
                }
            }
            Console.WriteLine();
            Console.WriteLine("Aperte alguma tecla para voltar ao menu");
            Console.ReadKey();
            Console.Clear();
            //Por algum motivo que eu desconheco esse console Clear nao esta limpando o Console Writeline de Area de Fila
        }

        public void VerificarMatricula(int matricula)
        {

            bool encontrado = false;

            string[] linhas = File.ReadAllLines(caminhoRepositorio);
            foreach (string linha in linhas)
            {
                Aluno aluno = JsonConvert.DeserializeObject<Aluno>(linha);
                if (aluno.Matricula == matricula)
                {
                    Console.WriteLine("Aluno encontrado");
                    Console.WriteLine();
                    Console.WriteLine($"Nome: {aluno.Nome}");
                    Console.WriteLine($"Curso: {aluno.Curso}");
                    Console.WriteLine($"Renda Familiar: {aluno.RendaFamiliar}");
                    Console.WriteLine($"Data de Nascimento: {aluno.DataDeNascimento}");
                    Console.WriteLine($"Matrícula: {aluno.Matricula}");
                    Console.WriteLine($"Idade: {aluno.Idade}");
                    Console.WriteLine();
                    encontrado = true;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("Nenhum aluno encontrado com essa matricula");
            }
            Console.WriteLine("Aperte alguma tecla para voltar ao menu");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
