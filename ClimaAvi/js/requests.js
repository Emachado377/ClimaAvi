var resp;

async function criarPlanta(planta) {

    await $.ajax({
        url: '/Testes/CriarPlanta',
        type: 'POST',
        data: planta,
        success: function (result) {
            resp = $.extend(true, {}, result);
            //resp = result;
        },
        fail: function () {
            alert("error");
            resp = {}
        }
    });

    return resp;
}