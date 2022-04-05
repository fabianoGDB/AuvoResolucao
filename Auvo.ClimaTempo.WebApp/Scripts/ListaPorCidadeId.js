
$(document).ready(function () {

    $('#cidadeId').select2({});
    $('#cidadeId').on('select2:select', function () {
        var value = $("#cidadeId").val();
        ListarCidades(value);
        $("#divPainel").show(500);
    })
    $('#cidadeId').on('select2:open', function () {
        $("#divPainel").hide(500);
    })
});

function ListarCidades(value) {

    var url = "/Home/ListarCidade";
    var data = { 'nome': value };

    $.ajax({

        url: url,
        type: "GET",
        datatype: "json",
        data: data,
    }).done(function (response) {
        montarpainel(response, data.nome);
    });
}

function montarpainel(previsaoClima, data) {
    var indice = 0;
    var divPainel = document.getElementById("divPainel");
    var painel = `<div class="container">`;
    painel += `<div class="text-center" style="font-size: 30px;">Clima para os próximos 7 dias na cidade de ${data} </div>`;
    painel += `<div class="row" style="display: flex; flex-wrap: wrap; width: 110rem; justify-content: space-between;">`
    for (indice = 0; indice < previsaoClima.length && indice < 7; indice++) {


        painel += `<div style="width: 14%; padding: 5px;">`;
        painel += ` <div class="panel panel-primary ">`;
        painel += `<div class="panel-heading text-center">Quarta Feira</div>`;
        painel += ` <div class="panel-body">`;
        painel += `<p class="glyphicon-cloud"> ${previsaoClima[indice].Clima}</p>`;
        painel += `<p> Minima: ${previsaoClima[indice].TemperaturaMinima}&ordm;C</p>`;
        painel += `<p> Maxima: ${previsaoClima[indice].TemperaturaMaxima}&ordm;C</p >`;
        painel += `</div>`;
        painel += `</div>`;
        painel += `</div>`;
    }
    painel += `</div>`;
    painel += `</div>`;
    divPainel.innerHTML = painel;

}
