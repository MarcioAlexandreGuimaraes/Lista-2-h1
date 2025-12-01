using ListaH1.DTOs;
using ListaH1.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ListaH1.Services
{
    public class MatriculaService : IMatriculaService
    {
        private readonly List<Matricula> _matriculas = new();

        public List<MatriculaDTO> GetAll()
        {
            return _matriculas.Select(x => new MatriculaDTO
            {
                IdMatricula = x.IdMatricula,
                IdCurso = x.IdCurso,
                IdAluno = x.IdAluno,
                DataMatricula = x.DataMatricula,
                Ativa = x.Ativa
            }).ToList();
        }

        public MatriculaDTO GetById(int id)
        {
            var matricula = _matriculas.FirstOrDefault(x => x.IdMatricula == id);
            if (matricula == null) return null;

            return new MatriculaDTO
            {
                IdMatricula = matricula.IdMatricula,
                IdCurso = matricula.IdCurso,
                IdAluno = matricula.IdAluno,
                DataMatricula = matricula.DataMatricula,
                Ativa = matricula.Ativa
            };
        }

        public MatriculaDTO Create(CreateMatriculaDTO dto)
        {
            var matricula = new Matricula
            {
                IdMatricula = _matriculas.Count + 1,
                IdAluno = dto.IdAluno,
                IdCurso = dto.IdCurso,
                DataMatricula = DateTime.Now,
                Ativa = true
            };

            _matriculas.Add(matricula);

            return GetById(matricula.IdMatricula);
        }

        public MatriculaDTO Update(int id, CreateMatriculaDTO dto)
        {
            var matricula = _matriculas.FirstOrDefault(x => x.IdMatricula == id);
            if (matricula == null) return null;

            matricula.IdAluno = dto.IdAluno;
            matricula.IdCurso = dto.IdCurso;

            return GetById(id);
        }

        public bool Delete(int id)
        {
            var matricula = _matriculas.FirstOrDefault(x => x.IdMatricula == id);
            if (matricula == null) return false;

            _matriculas.Remove(matricula);
            return true;
        }
    }
}
