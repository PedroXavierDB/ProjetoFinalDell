var btnAdicionar = document.querySelector("#adicionar-paciente");
btnAdicionar.addEventListener("click", function(){
  event.preventDefault();

  var form = document.querySelector("#form-adiciona");

  var paciente = obtemPacienteDoFormulario(form);

  var pacienteTr = montaTr(paciente);

  var erros = validaPaciente(paciente);

  if(erros.length > 0){
    exibeMensagensErro(erros);
    return;
  }

  var tabela = document.querySelector("#tabela-pacientes");
  tabela.appendChild(pacienteTr);

  });

  function obtemPacienteDoFormulario(form){
    var paciente = {
      nome: form.nome.value,
      peso: form.peso.value,
      altura: form.altura.value,
      gordura: form.gordura.value,
      imc:calculaImc(form.peso.value, form.altura.value)
    }
    return paciente;
  }

  function  montaTr(paciente){
    var pacienteTr = document.createElement("tr");
    pacienteTr.classList.add("paciente");

    var nomeTd = montaTd(paciente.nome,"info-nome");
    var pesoTd = montaTd(paciente.peso,"info-peso");
    var alturaTd = montaTd(paciente.altura,"info-altura");
    var gorduraTd = montaTd(paciente.gordura,"info-gordura");
    var imcTd = montaTd(paciente.imc,"info-imc");

    pacienteTr.appendChild(nomeTd);
    pacienteTr.appendChild(pesoTd);
    pacienteTr.appendChild(alturaTd);
    pacienteTr.appendChild(gorduraTd);
    pacienteTr.appendChild(imcTd);

    return pacienteTr;
  }

  function montaTd(dado,classe){
    var td = document.createElement("td");
    td.textContent = dado;
    td.classList.add(classe);

    return td;
  }

  function validaPaciente(paciente){

    var erros = [];

    if(!validaPeso(paciente.peso)){
      erros.push("Peso invalido! ");
    }

    return erros;
  }

  function exibeMensagensErro(erros){
    var ul = document.querySelector("#mensagem-erro");
    erros.forEach(function(erro){
      var li = document.createElement("li");
      li.textContent = erro;
      ul.appendChild(li);
    });

  }
