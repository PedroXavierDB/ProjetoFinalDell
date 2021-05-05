//alert("Ola Mundo!");
//console.log("Ola Mundo!");
//console.log(document);
//console.log(document.querySelector("h1"));
//console.log(title);
//console.log(title.textContent);
var title = document.querySelector(".title");
title.textContent = "Nutrition Table";

var pacientes = document.querySelectorAll(".paciente");
for(var i = 0; i < pacientes.length; i++){
  var peso = pacientes[i].querySelector(".info-peso").textContent;
  var altura = pacientes[i].querySelector(".info-altura").textContent;
  var tdImc = pacientes[i].querySelector(".info-imc");


  var pesoEhValido = validaPeso(peso);
  var alturaEhValido = true;

  if(!pesoEhValido){
    console.log("peso invalido");
    pesoEhValido = false;
    tdImc.textContent = "Peso inválido!"
    pacientes[i].classList.add("paciente-invalido");
  }

  if(altura <= 0 || altura >= 3.0){
    console.log("altura invalido");
    alturaEhValido = false;
    tdImc.textContent = "Altura inválida!";
    pacientes[i].classList.add("paciente-invalido");
  }

  if(alturaEhValido && pesoEhValido){
      var imc = calculaImc(peso,altura);
      tdImc.textContent = imc;
  }
}

function validaPeso(peso){
  if(peso <= 0 || peso >= 1000){
    return false;
  }else{
    return true;
  }
}

function calculaImc(peso,altura){
  var imc = 0;
  imc = peso / (altura * altura);
  return imc.toFixed(2);
}
