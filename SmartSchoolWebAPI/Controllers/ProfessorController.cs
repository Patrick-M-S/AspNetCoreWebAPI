using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchoolWebAPI.Data;
using SmartSchoolWebAPI.Models;

namespace SmartSchoolWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {

        private readonly IRepository _repo;
        public ProfessorController(IRepository repo) 
        {
            _repo = repo;

        }


        [HttpGet]
        public IActionResult GetProfessores()
        {
            var professores = _repo.GetAllProfessores(true);
            return Ok(professores);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProfessorId(int id) 
        {
            var professor = _repo.GetProfessorById(id, false);
            if (professor == null) return BadRequest("O Professor não foi encontrado");
            return Ok(professor);
        }

        //[HttpGet]
        //[Route("ByName")]
        //public IActionResult GetByName(string nome, string sobrenome)
        //{
        //    var professor = _datacontext.Professores.FirstOrDefault(a => a.Nome.Contains(nome));
        //    if (professor == null) return BadRequest("O Professor não foi encontrado");

        //    return Ok(professor);
        //}

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);

            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("Professor não cadastrado");
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _repo.GetProfessorById(id, false);
            if (prof == null) return BadRequest("Professor nao encontrado");

            _repo.Update(professor);

            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("Professor não atualizado");
        }
        
        [HttpPatch]
        [Route("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _repo.GetProfessorById(id);
            if (prof == null) return BadRequest("Professor nao encontrado");

            _repo.Update(professor);

            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _repo.GetProfessorById(id);
            if (professor == null) return BadRequest("Professor nao encontrado");

            _repo.Delete(professor);

            if (_repo.SaveChanges())
            {
                return Ok("Professor deletado");
            }

            return BadRequest("Professor não deletado");
        }
    }
}
