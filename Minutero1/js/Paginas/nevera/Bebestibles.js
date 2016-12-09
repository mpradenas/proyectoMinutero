$(document).ready(function () {
    $("#Cancelar").hide();

    setTimeout("ComprobarTipoBebida()",500);


    $("#GuardaBebida").click(function () {

        var NombreBebestible = $("#NombreBebestible").val();
        var idBebestible = parseInt($("#idBebestible").val());
        var descripcion = $("#descripcionBebestible").val();
        var tipoBebida = parseInt($("#tipoBebestible").val());

        $.post("Bebestibles.aspx", {
            action: "GuardarBebestible",
            idBebestible: idBebestible,
            nombreBebestible: NombreBebestible,
            descripcion: descripcion,
            tipoBebida: tipoBebida

        }, function (data) {
            data = data.split("//");
            if (data[1] == "OK") {
                alert(data[2]);
                location.href = "/Paginas/nevera/Bebestibles.aspx";
            } else {
                alert(data[2]);
            }

        })


    })

    $("#Cancelar").click(function () {

        $("#NombrePlato").val("");
        $("#idPlatoAcompanamiento").val("");
        $("#descripcionPlato").val("");
        $("#tipoPlato").val("");
        $("#GuardaPlato").html("Guardar");
        $("#Cancelar").hide();
    })

    $("#BuscadorPlatos").click(function () {

        var nombrePlato = $("#NombrePlato").val();
        var descripcionPlato = $("#descripcionPlato").val();
        $.get("PlatoAcompanamiento.aspx", {
            action: "BuscaPlatoAcompanamiento",
            nombrePlato: nombrePlato,
            descripcion: descripcionPlato

        }, function (data) {
            data = data.split("//");
            if (data[1] == "OK") {
                $("#idPlatoAcompanamiento").val(data[2]);
                $("#NombrePlato").val(data[3]);
                $("#descripcionPlato").val(data[4]);
                $("#tipoPlato").val(data[5]);
            }
            else {
                alert(data[2]);
            }
        })

    })
})

function editar(idplatoAcompanamiento, NombrePlato, descripcion, TipoPlato) {
    $("#Cancelar").show();
    $("#NombrePlato").val(NombrePlato);
    $("#idPlatoAcompanamiento").val(idplatoAcompanamiento);
    $("#descripcionPlato").val(descripcion);
    $("#tipoPlato").val(TipoPlato);
    $("#GuardaPlato").html("Modificar");
}

function Elimina(idBebestible) {
    $.post("Bebestibles.aspx", {
        action: "EliminaBebestibles",
        idBebestible: idBebestible
    }, function (data) {

        data = data.split("//");
        if (data[1] == "OK") {
            alert(data[2]);
            location.href = "/Paginas/nevera/Bebestibles.aspx";
        }
        else {

            alert(data[2]);
        }
    })
}

function ComprobarTipoBebida()
{
    $.post("Bebestibles.aspx", {
        action: "ConsultaTipoBebestible"

    }, function (data) {
        data = data.split("//");
        if (data[1] != "OK" && data[1]=="NOK") {
            
            $("NombreBebestible").attr("disabled", true);
            $("descripcionBebestible").attr("disabled", true);
            $("tipoBebestible").attr("disabled", true);
            confirm(data[2]);
            if (confirm) {
                location.href = "../../Paginas/nevera/tipobebida.aspx";
            }
        }
        else
        {
            $("NombreBebestible").attr("disabled", false);
            $("descripcionBebestible").attr("disabled", false);
            $("tipoBebestible").attr("disabled", false);

        }
    })
}