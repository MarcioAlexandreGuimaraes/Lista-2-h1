using ListaH1.DTOs;
using System.Collections.Generic;

namespace ListaH1.Services
{
    public interface ICursoService
    {
        List<CursoDTO> GetAll();
        CursoDTO GetById(int id);
        CursoDTO Create(CreateCursoDTO dto);
        CursoDTO Update(int id, CreateCursoDTO dto);
        bool Delete(int id);
    }
}
