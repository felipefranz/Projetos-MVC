var tbody = document.querySelector('table tbody');
var aluno = {};

function Cadastrar() {
    aluno.nome = document.querySelector("#nome").value;
    aluno.sobrenome = document.querySelector("#sobrenome").value;
    aluno.telefone = document.querySelector("#telefone").value;
    aluno.data = document.querySelector("#data").value;
    aluno.ra = document.querySelector("#ra").value;
   
    if (aluno.id === undefined || aluno.id === 0)
     {   //Cadastrar novo
         salvarEstudante('POST', 0, aluno);
     }
     else 
     {   //Alterar 
         salvarEstudante('PUT', aluno.id, aluno);     
     }

     carregaEstudantes();
     Cancelar();
}

function deletarEstudante(estudante){

    bootbox.confirm({
        message: `Tem certeza que deseja excluir o ${estudante.nome}?`,
        buttons: {
            confirm: {
                label: 'SIM',
                className: 'btn-success'
            },
            cancel: {
                label: 'NÃO',
                className: 'btn-danger'
            }
        },
        callback: function (result) {
            if (result){
                excluirEstudante(estudante.id);
                carregaEstudantes();
            }
            //console.log(result);
        }
    });
}

function NovoAluno() { //Função para limpar modal quando clicado em cadastrar
    var btnSalvar = document.querySelector('#btnSalvar');
    var titulo = document.querySelector('#tituloModal');
    document.querySelector("#nome").value = '';
    document.querySelector("#sobrenome").value = '';
    document.querySelector("#telefone").value = '';
    document.querySelector("#data").value = '';
    document.querySelector("#ra").value = '';

    aluno = {};

    btnSalvar.textContent = 'Cadastrar';
    titulo.textContent = 'Cadastrar Aluno';

    $('#myModal').modal('show')
}

function Cancelar(){
    var btnSalvar = document.querySelector('#btnSalvar');
    var titulo = document.querySelector('#tituloModal');
    document.querySelector("#nome").value = '';
    document.querySelector("#sobrenome").value = '';
    document.querySelector("#telefone").value = '';
    document.querySelector("#data").value = '';
    document.querySelector("#ra").value = '';

    aluno = {};

    btnSalvar.textContent = 'Cadastrar';
    titulo.textContent = 'Cadastrar Aluno';

    $('#myModal').modal('hide')
}

function carregaEstudantes(metodo, id, corpo) {

    tbody.innerHTML = '';

    var xhr = new XMLHttpRequest();

    //False = Síncrono
    //True = Assíncrono
    xhr.open(`GET`, `http://localhost:6343/api/Aluno/Recuperar`, true);
    xhr.setRequestHeader('Authorization', sessionStorage.getItem('token'));

	xhr.onerror = function () {
		console.error('ERRO', xhr.readyState);
	}


	xhr.onreadystatechange = function() {
		if (this.readyState == 4){
			if(this.status == 200) {
				var estudantes = JSON.parse(this.responseText);
				for(var indice in estudantes){
					adicionaLinha(estudantes[indice]);
				}
			}
			else if(this.status == 500){
				var erro = JSON.parse(this.responseText);
				console.log(erro.message);
				console.log(erro.exceptionMessage);
			}
		}
		
	}
         
    xhr.send(); 
}

function salvarEstudante(metodo, id, corpo) {
    var xhr = new XMLHttpRequest();

    if (id === undefined || id === 0)
        id = '';

    //False = Síncrono
    //True = Assíncrono
    xhr.open(metodo, `http://localhost:6343/api/Aluno/${id}`, false);

    xhr.setRequestHeader('content-type', 'application/json');
    xhr.send(JSON.stringify(corpo));       
}

function excluirEstudante(id) {
    var xhr = new XMLHttpRequest();

    //False = Síncrono
    //True = Assíncrono
    xhr.open(`DELETE`, `http://localhost:6343/api/Aluno/${id}`, false);

    xhr.send();

}

carregaEstudantes();

function editarEstudante(estudante){
    var btnSalvar = document.querySelector('#btnSalvar');
    var titulo = document.querySelector('#tituloModal');
    document.querySelector("#nome").value = estudante.nome;
    document.querySelector("#sobrenome").value = estudante.sobrenome;
    document.querySelector("#telefone").value = estudante.telefone;
    document.querySelector("#data").value = estudante.data;
    document.querySelector("#ra").value = estudante.ra;

    btnSalvar.textContent = 'Salvar';
    titulo.textContent = `Editar Aluno: ${estudante.nome}`;

    aluno = estudante;
}

function adicionaLinha(estudante) {
    
    var trow = `<tr>
                <td>${estudante.nome}</td>
                <td>${estudante.sobrenome}</td>
                <td>${estudante.telefone}</td>
                <td>${estudante.data}</td>
                <td>${estudante.ra}</td>
                <td>
                    <button class="btn btn-info" data-toggle="modal" data-target="#myModal" onClick='editarEstudante(${JSON.stringify(estudante)})'>Editar</button>
                    <button class="btn btn-danger" onClick='deletarEstudante(${JSON.stringify(estudante)})'>Deletar</button>
               </td>                         
               </tr>`;

    tbody.innerHTML += trow; 
}