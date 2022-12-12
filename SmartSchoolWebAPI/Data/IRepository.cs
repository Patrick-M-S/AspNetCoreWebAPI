using SmartSchoolWebAPI.Models;

namespace SmartSchoolWebAPI.Data
{
    public interface IRepository
    {
        string pegaResposta();
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        // Alunos
        Aluno[] GetAllAlunos(bool includeProfessor = false);
        Aluno[] GetAllAlunosByDisciplinaId(int discplinaId, bool includeProfessor = false);
        public Aluno GetAlunoById(int alunoId, bool includeProfessor = false);    
        
        // Professores
        Professor[] GetAllProfessores(bool includeAlunos = false);
        Professor[] GetAllProfessoresByDisciplinaId(int discplinaId, bool includeAlunos = false);
        Professor GetProfessorById(int profId, bool includeAlunos = false);
    }
}
