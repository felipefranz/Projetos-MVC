using App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApp.Models;

namespace WebApp.Controllers
{
    [EnableCors("*", "*", "*")]
    //Adicionando caminho genérico para as chamadas da API
    [RoutePrefix("api/Aluno")]
    public class AlunoController : ApiController
    {
        // GET: api/Aluno/Recuperar
        [HttpGet]
        //Rota para requisição direto pela chamada recuperar
        [Route("Recuperar")] 
        [Authorize(Roles = Funcao.Professor)]
        //public IEnumerable<Aluno> Get()
        public IHttpActionResult Recuperar()
        {
            //Aluno aluno = new Aluno();
            //return aluno.ListarAluno();
            
            try
            { 
                AlunoModel aluno = new AlunoModel();
                return Ok(aluno.ListarAluno());
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
            //return new string[] { "value1", "value2" };
        }

        // GET: api/Aluno/5
        [HttpGet]
        //[Route("Recuperar/{id}")] //Explicitando o parâmetro de chamada
        [Route("Recuperar/{id:int}/{nome?}/{sobrenome?}")] //Explicitando tipo de variavel e parâmetro opcional sobrenome
        //public Aluno Get(int id)
        public IHttpActionResult Get(int id, string nome = null, string sobrenome = null)
        {
            try
            {
                AlunoModel aluno = new AlunoModel();

                return Ok(aluno.ListarAluno(id).FirstOrDefault());
                //return aluno.ListarAluno().Where(x => x.id == id).FirstOrDefault(); //Where estraga a performance da aplicação

                //return "";
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        // GET: api/Aluno/RecuperarPorDataNome/1998-06/vinicius
        [HttpGet]
        [Route(@"RecuperarPorDataNome/{data:regex([0-9]{4}\-[0-9]{2})}/{nome:minlength(5)}")] //Explicitando tipo de variavel e parâmetro opcional sobrenome
        public IHttpActionResult Recuperar(string data, string nome)
        {
            try
            {
                AlunoModel aluno = new AlunoModel();

                IEnumerable<AlunoDTO> alunos = aluno.ListarAluno().Where(x => x.data == data || x.nome == nome);

                if (!alunos.Any())
                    return NotFound();

                return Ok(alunos);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

 
        }

        // POST: api/Aluno
        /*
        public void Post([FromBody]string value)
        {
        
        }
        */

        [HttpPost]
        // POST: api/Aluno
        public IHttpActionResult Post(AlunoDTO aluno)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                //List<Aluno> alunos = new List<Aluno>();
                AlunoModel _aluno = new AlunoModel();
                _aluno.Inserir(aluno);
                return Ok(_aluno.ListarAluno());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        // PUT: api/Aluno/5
        public IHttpActionResult Put(int id, [FromBody]AlunoDTO aluno)
        {
            try
            {
                AlunoModel _aluno = new AlunoModel();
                aluno.id = id;
                _aluno.Atualizar(aluno);

                return Ok(_aluno.ListarAluno(id).FirstOrDefault());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        // DELETE: api/Aluno/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                AlunoModel _aluno = new AlunoModel();
                _aluno.Deletar(id);

                return Ok("Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}

/* Exemplo Json
// PUT: api/Aluno/5
public Aluno Put(int id, [FromBody]Aluno aluno)
{
    Aluno _aluno = new Aluno();

    return _aluno.Atualizar(id, aluno);
}
*/
