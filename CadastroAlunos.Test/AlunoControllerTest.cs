using CadastroAlunos.Contracts;
using CadastroAlunos.Controllers;
using CadastroAlunos.Models;
using CadastroAlunos.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CadastroAlunos.Test
{
    public class AlunoControllerTest
    {
        Mock<IAlunoRepository> _repository;


        public AlunoControllerTest()
        {
            _repository = new Mock<IAlunoRepository>();
        }

        [Fact]
        public void IndexDeveRetornar_Metodo_ViewResult()
        {
            //arrng
            AlunoController controller = new AlunoController(_repository.Object);
            //act
            var aluno = controller.Index();
            //Assert
            Assert.IsType<ViewResult>(aluno.Result);
        }
    }
}
