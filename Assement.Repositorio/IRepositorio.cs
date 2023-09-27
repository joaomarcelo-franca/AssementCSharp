using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assement.Pessoa;
using Assement;

namespace Assement.Repositorio
{
    public interface IRepositorio
    {
        void Adicionar(Aluno aluno);
        void VerificarFila();
        void VerificarMatricula(int matricula);
        void Atualizar(int matricula);
        void Excluir(int matricula);
    }
}
