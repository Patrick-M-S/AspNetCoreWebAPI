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
        private readonly DataContext _datacontext;
        public ProfessorController(DataContext context) 
        {
            _datacontext = context;
        }


        [HttpGet]
        public IActionResult GetProfessores()
        {
            return Ok(_datacontext.Professores);
        }

        [HttpGet]
        [Route("ById/{id}")]
        public IActionResult GetProfessorId(int id) 
        {
            var professor = _datacontext.Professores.FirstOrDefault(a => a.Id == id);
            if (professor == null) return BadRequest("O Professor não foi encontrado");
            return Ok(professor);
        }

        [HttpGet]
        [Route("ByName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var professor = _datacontext.Professores.FirstOrDefault(a => a.Nome.Contains(nome));
            if (professor == null) return BadRequest("O Professor não foi encontrado");

            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _datacontext.Add(professor);
            _datacontext.SaveChanges();
            return Ok(professor);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _datacontext.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (prof == null) return BadRequest("Professor nao encontrado");

            _datacontext.Update(professor);
            _datacontext.SaveChanges();
            return Ok(professor);
        }
        
        [HttpPatch]
        [Route("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _datacontext.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (prof == null) return BadRequest("Professor nao encontrado");

            _datacontext.Update(professor);
            _datacontext.SaveChanges();
            return Ok(professor);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _datacontext.Professores.FirstOrDefault(a => a.Id == id);
            if (professor == null) return BadRequest("Professor nao encontrado");

            _datacontext.Remove(professor);
            _datacontext.SaveChanges();
            return Ok();
        }
    }
}
