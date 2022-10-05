using CadastroAlunos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAlunos.Contracts
{
    public interface IAlunoRepository
    {
        Task<List<Aluno>> GetAlunos();
        Task<Aluno> GetAlunoById(int? id);
        Task<Aluno> AddAluno(Aluno aluno);
        Task<int> UpdateAluno(int id, Aluno alunoAlterado);
        Task DeleteAluno(int? id);
    }
}
