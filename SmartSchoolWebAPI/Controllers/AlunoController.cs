using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartSchoolWebAPI.Models;

namespace SmartSchoolWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>() 
        {
            new Aluno() 
            {
                Id = 1,
                Nome = "Marcos",
                Sobrenome = "Mendes",
                Telefone = "66544555"
            },
                        
            new Aluno()
            {
                Id = 2,
                Nome = "Marta",
                Sobrenome = "Mendes",
                Telefone = "42554443"
            },
                                    
            new Aluno()
            {
                Id = 3,
                Nome = "Laura",
                Sobrenome = "Mendes",
                Telefone = "4424233"
            },
        };

        public AlunoController() { }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }        

        [HttpGet("ById/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado");

            return Ok(aluno);
        }
        
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(a => 
            a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome)
            );
            if (aluno == null) return BadRequest("O Aluno não foi encontrado");

            return Ok(aluno);
        }
        
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {

            return Ok(aluno);
        }
        
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {

            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            return Ok();
        }
    }
}
