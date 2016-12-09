$(document).ready(function () {
    $("#Cancelar").hide();



    $("#GuardaTipoBebida").click(function () {

      
        var idTipoBebida = parseInt($("#idTipoBebida").val());
        var descripcionTipoBebida = $("#DescripcionTipoBebida").val();
        $.post("TipoBebida.aspx", {
            action: "GuardarTipoBebida",
            idTipoBebida: idTipoBebida,
            descripcionTipoBebida: descripcionTipoBebida
        }, function (data) {
            data = data.split("//");
            if (data[1] == "OK") {
                alert(data[2]);
                location.href = "/Paginas/nevera/TipoBebida.aspx";
            } else {
                alert(data[2]);
            }

        })


    })

    $("#Cancelar").click(function () {

        $("#idTipoBebida").val("");
        $("#DescripcionTipoBebida").val("");
        $("#GuardaPlato").html("Guardar");
        $("#Cancelar").hide();
    })

    $("#BuscadorPlatos").click(function () {

        var descripcionPlato = $("#DescripcionTipoBebida").val();
        $.get("TipoBebida.aspx", {
            action: "BuscaTipoBebida",
            nombrePlato: nombrePlato,
            descripcionTipoBebida: descripcionPlato

        }, function (data) {
            data = data.split("//");
            if (data[1] == "OK") {
                $("#idTipoBebida").val(data[2]);
                $("#DescripcionTipoBebida").val(data[4]);
            }
            else {
                alert(data[2]);
            }
        })

    })
})

function editar(idTipoBebida, descripcionTipobebida) {
    $("#Cancelar").show();
    $("#idTipoBebida").val(idTipoBebida);
    $("#DescripcionTipoBebida").val(descripcionTipobebida);
    $("#GuardaPlato").html("Modificar");
}

function Elimina(idTipoBebida) {
    $.post("TipoBebida.aspx", {
        action: "EliminaTipoBebida",
        idTipoBebida: idTipoBebida
    }, function (data) {

        data = data.split("//");
        if (data[1] == "OK") {
            alert(data[2]);
            location.href = "/Paginas/nevera/TipoBebida.aspx";
        }
        else {

            alert(data[2]);
        }
    })
}