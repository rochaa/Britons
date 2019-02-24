// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function(){
    $("#Telefone").inputmask("(99) 9999[9]-9999");
});

$(document).ready(function(){
    $("#Cep").inputmask("99999-999");
});

function AdicionarTelefone() {
    var listaDeTelefones = document.getElementById('TelefonesLista');
    var telefone = document.getElementById('Telefone').value;
    var telefoneItem = document.createElement('li');
    var telefoneId = telefone.replace(/\D/g,'');

    if($('#' + telefoneId).length == 0 && (telefoneId.length == 10 || telefoneId.length == 11))
    {
        var label = document.createElement('label');
        label.setAttribute('class','telefone-itens');
        label.setAttribute('id', telefoneId);
        label.appendChild(document.createTextNode(telefone));

        var input = document.createElement('input');
        input.type = 'hidden';
        input.setAttribute('class', 'form-control');
        input.setAttribute('id', 'telefones_' + listaDeTelefones.childElementCount + '_');
        input.setAttribute('name', 'telefones[' + listaDeTelefones.childElementCount + ']');
        input.setAttribute('value', telefone);

        var link = document.createElement('a');
        link.href = '#';
        link.setAttribute('onclick', '$(this).parent().remove();');
        link.setAttribute('class', 'btn btn-danger telefone-botao');
        link.appendChild(document.createTextNode('x'));

        telefoneItem.appendChild(label);
        telefoneItem.appendChild(input);
        telefoneItem.appendChild(link);

        document.getElementById('Telefone').value = '';

        listaDeTelefones.appendChild(telefoneItem);
    }
}
