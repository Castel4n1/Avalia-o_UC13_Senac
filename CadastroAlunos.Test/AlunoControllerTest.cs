using CadastroAlunos.Models;
using CadastroAlunos.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroAlunos.Test
{
    class AlunoControllerTest
    {
        Mock<AlunoRepository> _repository;
        Aluno alunoValido;

        public AlunoControllerTest()
        {
            _repository = new Mock<AlunoRepository>();
        }
    }
}
