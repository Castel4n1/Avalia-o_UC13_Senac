using CadastroAlunos.Contracts;
using CadastroAlunos.Data;
using CadastroAlunos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAlunos.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly CadastroAlunosContext _context;

        public AlunoRepository(CadastroAlunosContext context)
        {
            _context = context;
        }

        public async Task<List<Aluno>> GetAlunos()
        {
            return await _context.Aluno.ToListAsync();
        }

        public async Task<Aluno> GetAlunoById(int id)
        {
            return await _context.Aluno.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Aluno> AddAluno(Aluno aluno)
        {

            _context.Aluno.Add(aluno);
            await _context.SaveChangesAsync();

            return aluno;
        }

        public async Task<int> UpdateAluno(int id, Aluno alunoAlterado)
        {
            var aluno = await _context.Aluno.FirstOrDefaultAsync(c => c.Id == id);

            if (aluno == null)
                return 0;

            //cliente.AtualizaDados(clienteAlterado.Nome, clienteAlterado.Nascimeto, clienteAlterado.Email);

            _context.Entry(aluno).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task DeleteAluno(int id)
        {
            var aluno = await _context.Aluno.FirstOrDefaultAsync(c => c.Id == id);

            _context.Aluno.Remove(aluno);
            await _context.SaveChangesAsync();
        }
    }
}
