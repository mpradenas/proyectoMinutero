$(document).ready(function () {
    $("#Cancelar").hide();



    $("#GuardaTipoComida").click(function () {


        var idTipoComida = parseInt($("#idTipoComida").val());
        var descripcionTipoComida = $("#DescripcionTipoComida").val();
        $.post("tipoComida.aspx", {
            action: "GuardarTipoComida",
            idTipoComida: idTipoComida,
            descripcionTipoComida: descripcionTipoComida
        }, function (data) {
            data = data.split("//");
            if (data[1] == "OK") {
                alert(data[2]);
                location.href = "/Paginas/nevera/TipoComida.aspx";
            } else {
                alert(data[2]);
            }

        })


    })

    $("#Cancelar").click(function () {

        $("#idTipoComida").val("");
        $("#DescripcionTipoComida").val("");
        $("#GuardaTipoComida").html("Guardar");
        $("#Cancelar").hide();
    })

    $("#BuscadorPlatos").click(function () {

        var descripcionPlato = $("#DescripcionTipoComida").val();
        $.get("TipoComida.aspx", {
            action: "BuscaTipoComida",
            descripcionTipoComida: descripcionTipoComida

        }, function (data) {
            data = data.split("//");
            if (data[1] == "OK") {
                $("#idTipoComida").val(data[2]);
                $("#DescripcionTipoComida").val(data[4]);
            }
            else {
                alert(data[2]);
            }
        })

    })
})

function editar(idTipoComida, descripcionTipoComida) {
    $("#Cancelar").show();
    $("#idTipoComida").val(idTipoComida);
    $("#DescripcionTipoComida").val(descripcionTipoComida);
    $("#GuardaPlato").html("Modificar");
}

function Elimina(idTipoComida) {
    $.post("TipoComida.aspx", {
        action: "EliminaTipoComida",
        idTipoComida: idTipoComida
    }, function (data) {

        data = data.split("//");
        if (data[1] == "OK") {
            alert(data[2]);
            location.href = "/Paginas/nevera/TipoComida.aspx";
        }
        else {

            alert(data[2]);
        }
    })
}