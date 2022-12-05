using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchoolWebAPI.Data;
using SmartSchoolWebAPI.Models;

namespace SmartSchoolWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public AlunoController(DataContext context) 
        {
            _dataContext = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dataContext.Alunos);
        }        

        [HttpGet("ById/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _dataContext.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado");

            return Ok(aluno);
        }
        
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = _dataContext.Alunos.FirstOrDefault(a => 
            a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome)
            );
            if (aluno == null) return BadRequest("O Aluno não foi encontrado");

            return Ok(aluno);
        }
        
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _dataContext.Add(aluno);
            _dataContext.SaveChanges();
            return Ok(aluno);
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _dataContext.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alu == null) return BadRequest("Aluno nao encontrado");

            _dataContext.Update(aluno);
            _dataContext.SaveChanges();
            return Ok(aluno);
        }
        
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _dataContext.Alunos.FirstOrDefault(a => a.Id == id);
            if (alu == null) return BadRequest("Aluno nao encontrado");

            _dataContext.Update(aluno);
            _dataContext.SaveChanges();
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _dataContext.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno nao encontrado");

            _dataContext.Remove(aluno);
            _dataContext.SaveChanges();
            return Ok();
        }
    }
}
