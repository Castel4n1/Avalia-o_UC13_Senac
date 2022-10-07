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
        Aluno alunoValido;

        public AlunoControllerTest()
        {
            _repository = new Mock<IAlunoRepository>();
        }

        [Fact]
        public async void IndexDeveRetornar_Metodo_ViewResult()
        {
            //arrng
            AlunoController controller = new AlunoController(_repository.Object);
            //act
            var aluno = await controller.Index();
            //Assert
            Assert.IsType<ViewResult>(aluno);
        }

        [Fact]
        public async void MetodoIndex_ChamaRepositorioApenas_UmaVez()
        {
            //arrange
            AlunoController controller = new AlunoController(_repository.Object);
                _repository.Setup(r => r.AddAluno(alunoValido))
                    .ReturnsAsync(alunoValido);
            //act
            await controller.Create(alunoValido);
            //assert
            _repository.Verify(repo => repo.AddAluno(alunoValido), Times.Once);
        }

        [Fact]
        public async void MetodoDetais_RetornaBadRequestComIdNulo()
        {
            //arrange
            AlunoController controller = new AlunoController(_repository.Object);
            //act
            var result = await controller.Details(-1);
            //assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async void NotFound_ParaIdValido_ViewResultAlunoEncontrado()
        {
            //arrang
            AlunoController controller = new AlunoController(_repository.Object);
            //act
            var result = await controller.Details(30);
            //assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void MetodoDetails_RetornaViewResultParaAlunoEncontrado()
        {
            //arrange
            AlunoController controller = new AlunoController(_repository.Object);

            Aluno aluno = new Aluno();
            aluno.Id = 1;

            _repository.Setup(a => a.GetAlunoById(1))
               .ReturnsAsync(aluno);

            //act
            var result = await controller.Details(1);

            //assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void MetodoDetails_ChamaRepositorioApenas_UmaVez()
        {
            //arrange
            AlunoController controller = new AlunoController(_repository.Object);

            Aluno aluno = new Aluno();
            aluno.Id = 1;

            _repository.Setup(a => a.GetAlunoById(1))
                .ReturnsAsync(aluno);
            //act
            await controller.Details(2);
            //assert
            _repository.Verify(ar => ar.GetAlunoById(2), Times.Once);


        }
        [Fact]
        public async void MetodoCreate_VerificaChamaUnicaVezCasoInvalidaRetornarUmaView()
        {
            //arrange
            AlunoController controller = new AlunoController(_repository.Object);

            Aluno aluno = new Aluno();

            aluno.Id = -55;
            aluno.Nome = null;
            aluno.Turma = null;
            aluno.Media = -105;

            //act
            var result = await controller.Create(aluno);

            //assert
            //assert
            _repository.Verify(ar => ar.AddAluno(aluno), Times.Once);

            Assert.IsType<RedirectToActionResult>(result);
        }
    }
}
