using CadastroAlunos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CadastroAlunos.Test
{
    public class AlunoTest
    {
        [Theory]
        [InlineData("Kaue","T91")]
        [InlineData("Jose", "T92")]
        [InlineData("", "T91")]
        [InlineData("Marcio", "")]
        [InlineData("", "")]
        public void AtualizaDados_Verdadeiros_IndenpendenteDosDadosPassados(string nome, string turma)
        {
            //arrange
            Aluno aluno = new Aluno();
            aluno.Nome = "Josias";
            aluno.Turma = "T10";
            //act
            aluno.AtualizarDados(nome, turma);
            //assert
            Assert.Equal(aluno.Nome, nome);
            Assert.Equal(aluno.Turma, turma);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(7)]
        public void VerificaAprovacao_SeMaiorOuIgual_A_Cinco(double nota)
        {
            //arrange
            Aluno aluno = new Aluno();

            //act
            aluno.Media = nota;
            //assert
            Assert.True(aluno.VerificaAprovação());
        }

        [Fact]
        public void AtualizaMedia_ComNovoValor_Recebido()
        {
            //Arr
            Aluno aluno = new Aluno();
            aluno.Media = 10;
            //Act
            double result = 5;
            aluno.AtualizaMedia(result);
            //Assert
            Assert.Equal(aluno.Media, result);
        }
    }
}