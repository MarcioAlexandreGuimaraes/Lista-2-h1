namespace ListaH1.DTOs
{
    public class MatriculaDTO
    {
        public int IdMatricula { get; set; }
        public int IdAluno { get; set; }
        public int IdCurso { get; set; }
        public DateTime DataMatricula { get; set; }
        public bool Ativa { get; set; }
    }
}
