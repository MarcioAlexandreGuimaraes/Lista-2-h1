using ListaH1.Domain;
using ListaH1.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace ListaH1.Services
{
    public class CursoService : ICursoService
    {
        private readonly List<Curso> _cursos = new();

        public List<CursoDTO> GetAll()
        {
            return _cursos.Select(x => new CursoDTO
            {
                IdCurso = x.IdCurso,
                Nome = x.Nome,
                NomeCoordenador = x.NomeCoordenador,
                Ativo = x.Ativo
            }).ToList();
        }

        public CursoDTO GetById(int id)
        {
            var curso = _cursos.FirstOrDefault(x => x.IdCurso == id);
            if (curso == null) return null;

            return new CursoDTO
            {
                IdCurso = curso.IdCurso,
                Nome = curso.Nome,
                NomeCoordenador = curso.NomeCoordenador,
                Ativo = curso.Ativo
            };
        }

        public CursoDTO Create(CreateCursoDTO dto)
        {
            var curso = new Curso
            {
                IdCurso = _cursos.Count + 1,
                Nome = dto.Nome,
                NomeCoordenador = dto.NomeCoordenador,
                Ativo = true
            };

            _cursos.Add(curso);

            return new CursoDTO
            {
                IdCurso = curso.IdCurso,
                Nome = curso.Nome,
                NomeCoordenador = curso.NomeCoordenador,
                Ativo = true
            };
        }

        public CursoDTO Update(int id, CreateCursoDTO dto)
        {
            var curso = _cursos.FirstOrDefault(x => x.IdCurso == id);
            if (curso == null) return null;

            curso.Nome = dto.Nome;
            curso.NomeCoordenador = dto.NomeCoordenador;

            return GetById(id);
        }

        public bool Delete(int id)
        {
            var curso = _cursos.FirstOrDefault(x => x.IdCurso == id);
            if (curso == null) return false;

            _cursos.Remove(curso);
            return true;
        }
    }
}
