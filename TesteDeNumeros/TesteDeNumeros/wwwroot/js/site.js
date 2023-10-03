// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var form1 = document.getElementById('form1');
var boxJogos = document.getElementById('boxJogos');
var btn_add = document.getElementById('add');
var inputField = document.getElementById('inputField');
const inputs = document.querySelectorAll('input[type="number"]');

var count = 0;

var qtdJogos = 60;
var i = 0;

while (i < qtdJogos) {
	i++
	createNumber();
}

function createViewNumber(valor) {
	// this.valor = valor;
	var element = document.createElement('input');
	element.setAttribute('type', 'number');
	element.setAttribute('maxlenght', '1');
	element.setAttribute('id', valor);
	element.setAttribute('value', valor);
	
	inputField.appendChild(element);
}


function createNumber() {
	var element = document.createElement('input');
	element.setAttribute('type', 'checkbox');
	element.setAttribute('class', 'btn-check rounded-5');
	element.setAttribute('id', 'btn-check-' + i);
	element.setAttribute('value', '' + i);
	element.setAttribute('autocomplete', 'off');
	element.setAttribute('onclick', 'gravarCheck(this)')

	boxJogos.appendChild(element);

	// Label do checkbox

	var element1 = document.createElement('label');
	element1.setAttribute('class', 'btn rounded-5');
	element1.setAttribute('for', 'btn-check-' + i);
	if (i < 10) {
		element1.textContent = "0" + i;
	}
	else {
		element1.textContent = i;
	}


	boxJogos.appendChild(element1);
}

function gravarCheck(input) {
	var result = input.checked;
	var valor = document.getElementById("escolhidos").value;

	if (count <= 5) {
		if (result) {
			count++;
			input.checked = true;

			if (valor == "") {
				valor = input.value;
				createViewNumber(input.value);
			}
			else {
				createViewNumber(input.value);
				valor = valor + ";" + input.value;
			}
			document.getElementById("escolhidos").value = valor;
		}
	}
	else if (result) {
		console.log("não pode escolher mais números seu fela");
		input.checked = false;
	}

	if (!result) {
		count--;
		input.checked = false;
		var teste = document.getElementById("escolhidos").value;

		if (teste.includes(input.value)) {
			if (teste.includes(input.value + ";")) {
				teste = teste.replace(input.value + ";", '');
			}
			else if (teste.includes(";" + input.value)) {
				teste = teste.replace(";" + input.value, '');
			}
			else {
				teste = teste.replace(input.value, '');
			}
			document.getElementById("escolhidos").value = teste;


			var element = document.getElementById("inputField");
			var child = document.getElementById(input.value);
			element.removeChild(child);

			


		}
	}
}

//function gravarCheck(input) {
//	var result = input.checked;
//	var valor = document.getElementById("escolhidos").value;

//	// Verificação para ver a quantidade de números já selecionados.
	

//	if (count <= 5) {

//		// Caso seja true ele adiciona +1 no count e marca o botãoo como checked.

//		if (result) {
//			count++;
//			input.checked = true;

//			if (valor == "") {
//				valor = input.value;
//			}
//			// Caso o número seja marcado ele adiciona o valor a variavel escolhidos
//			else {
//				valor = valor + ";" + input.value;
//			}
//			document.getElementById("escolhidos").value = valor;
//		}
//	}

//	// Caso o result seja true porém o limite de número já foi atigindo ele não deixa marca mais nenhum número.

//	else if (result) {
//		console.log("não pode escolher mais números seu fela");
//		input.checked = false;
//	}

//		// Caso o result seja (false= Não selecionado) ele retira da count e marca este checkbox como desmarcado.

//	if (!result) {
//		count--;
//		input.checked = false;
//		var teste = document.getElementById("escolhidos").value;

//		// Verificação caso o usuário remova um número selecionado ele retire do input

//		if (teste.includes(input.value)) {
//			if (teste.includes(input.value + ";")) {
//				teste = teste.replace(input.value + ";", '');
//				document.getElementById("escolhidos").value = teste;
//			}
//			else if (teste.includes(";" + input.value)) {
//				teste = teste.replace(";" + input.value, '');
//				document.getElementById("escolhidos").value = teste;
//			}
//			else {
//				teste = teste.replace(input.value, '');
//				document.getElementById("escolhidos").value = teste;
//			}
//		}
//	}

//	console.log(count);
//}
