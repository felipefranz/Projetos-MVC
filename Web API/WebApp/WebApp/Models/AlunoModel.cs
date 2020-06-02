using App.Domain;
using App.Repository;
using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class AlunoModel
    {

        //Retorna a lista de alunos armazenados no Database.mdf 
        public List<AlunoDTO> ListarAluno(int? id = null)
        {
            try
            {
                var alunoDB = new AlunoDAO();
                return alunoDB.ListarAlunoDB(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar Alunos: Erro => {ex.Message}");
            }

        }

        //Busca o maior Id da lista e salva novo aluno
        public void Inserir (AlunoDTO aluno)
        {
            try
            {
                var alunoDB = new AlunoDAO();
                alunoDB.InserirAlunoDB(aluno);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar Alunos: Erro => {ex.Message}");
            }
        }

        //Procura id aluno na lista Json e se encontrar atualizar as informações do mesmo
        public void Atualizar(AlunoDTO aluno)
        {
            try
            {
                var alunoDB = new AlunoDAO();
                alunoDB.AtualizarAlunoDB(aluno);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar Aluno: Erro => {ex.Message}");
            }
        }
        
        //Encontra aluno pelo e id, remove da lista e alimenta o json novamente
        public void Deletar(int id)
        {
            try
            {
                var alunoDB = new AlunoDAO();
                alunoDB.DeletarAlunoDB(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar o Aluno: Erro => {ex.Message}");
            }
        }

        //Exemplo 1 JSON
        /*public List<Aluno> ListarAluno()
        {

            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Base.json");
            var json = File.ReadAllText(caminhoArquivo);
            var listaAlunos = JsonConvert.DeserializeObject<List<Aluno>>(json);
            return listaAlunos;

        }
               
        //Rescreve a lista de alunos na base JSON
        public bool RescreverArquivo(List<AlunoModel> listaAlunos)
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Base.json");

            var json = JsonConvert.SerializeObject(listaAlunos, Formatting.Indented);
            File.WriteAllText(caminhoArquivo, json);

            return true;
        }
        


        //Busca o maior Id da lista e salva novo aluno
        public Aluno Inserir (Aluno Aluno)
        {
            var listaAlunos = this.ListarAluno();

            var maxId = listaAlunos.Max(aluno => aluno.id);
            Aluno.id = maxId + 1;
            listaAlunos.Add(Aluno);

            RescreverArquivo(listaAlunos);
            return Aluno;
        }

        //Procura id aluno na lista Json e se encontrar atualizar as informações do mesmo
        public Aluno Atualizar(int id, Aluno Aluno)
        {
            var listaAlunos = this.ListarAluno();

            var itemIndex = listaAlunos.FindIndex(p => p.id == Aluno.id);
            if (itemIndex >= 0)
            {
                Aluno.id = id;
                listaAlunos[itemIndex] = Aluno;
            }
            else
            {
                return null;
            }

            RescreverArquivo(listaAlunos);
            return Aluno;
        }

        //Encontra aluno pelo e id, remove da lista e alimenta o json novamente
        public bool Deletar(int id)
        {
            var listaAlunos = this.ListarAluno();

            var itemIndex = listaAlunos.FindIndex(p => p.id == id);
            if (itemIndex >= 0)
            {
                listaAlunos.RemoveAt(itemIndex);
            }
            else
            {
                return false;
            }

            RescreverArquivo(listaAlunos);
            return true;
        }
        */

        /*exemplo 3
        public List<Alunos> listaAlunos()
        {
            Alunos aluno = new Alunos();
            aluno.id = 1;
            aluno.nome = "Marta";
            aluno.sobrenome = "will";
            aluno.telefone = "123456";
            aluno.ra = 00001;

            Alunos aluno1 = new Alunos();
            aluno1.id = 2;
            aluno1.nome = "Laura";
            aluno1.sobrenome = "will";
            aluno1.telefone = "123456";
            aluno1.ra = 00002;

            Alunos aluno3 = new Alunos();
            aluno3.id = 3;
            aluno3.nome = "Joao";
            aluno3.sobrenome = "will";
            aluno3.telefone = "123456";
            aluno3.ra = 00003;

            List<Alunos> listaAlunos = new List<Alunos>();

            //Adiciona alunos a lista
            listaAlunos.Add(aluno);
            listaAlunos.Add(aluno1);
            listaAlunos.Add(aluno3);

            return listaAlunos;

        }
        */

        /*exemplo 2
        public List<string> listaAlunos()
        {
            List<string> listaAlunos = new List<string>();

            listaAlunos.Add("Marta");
            listaAlunos.Add("Julia");
            listaAlunos.Add("Paula");
            listaAlunos.Add("Rafa");
            listaAlunos.Add("Paulo");

            return listaAlunos;

            //Exemplo 1
            //return "Marta, Julia, Paula, Rafa, Paulo";
        }
        */
    }
}