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

        private readonly IRepository _repo;

        public AlunoController(IRepository repo) 
        {
            _repo = repo;

        }

        [HttpGet]
        [Route("pegaResposta")]
        public IActionResult pegaResposta()
        {
            return Ok(_repo.pegaResposta());
        }


        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllAlunos(true);
            return Ok(result);
        }        

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado");

            return Ok(aluno);
        }
        
        //[HttpGet("ByName")]
        //public IActionResult GetByName(string nome, string sobrenome)
        //{
        //    var aluno = _dataContext.Alunos.FirstOrDefault(a => 
        //    a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome)
        //    );
        //    if (aluno == null) return BadRequest("O Aluno não foi encontrado");

        //    return Ok(aluno);
        //}
        
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);

            if (_repo.SaveChanges()) 
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno não cadastrado");            
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id);
            if (alu == null) return BadRequest("Aluno nao encontrado");

            _repo.Update(aluno);

            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno não atualizado!");
        }
        
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id);
            if (alu == null) return BadRequest("Aluno nao encontrado");

            _repo.Update(aluno);

            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno não atualizado!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var alu = _repo.GetAlunoById(id);
            if (alu == null) return BadRequest("Aluno nao encontrado");

            _repo.Delete(alu);

            if (_repo.SaveChanges())
            {
                return Ok("Aluno deletado");
            }

            return BadRequest("Aluno não deletado!");
        }
    }
}
