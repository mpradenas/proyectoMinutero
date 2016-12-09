$(document).ready(function ()
{
    $("#Cancelar").hide();

    

    $("#GuardaPlato").click(function () {
        
        var NombrePlato = $("#NombrePlato").val();
        var idPlato = parseInt($("#idPlatoPrincipal").val());
        var descripcion = $("#descripcionPlato").val();
        var tipoPlato = parseInt($("#tipoPlato").val());

        $.post("PlatoPrincipal.aspx", {
            action: "GuardarPlato",
            idPlato: idPlato,
            nombrePlato: NombrePlato,
            descripcion: descripcion,
            tipoPlato:tipoPlato

        }, function (data) {
            data = data.split("//");
            if (data[1] == "OK") {
                alert(data[2]);
                location.href = "/Paginas/nevera/PlatoPrincipal.aspx";
            } else
            {
                alert(data[2]);
            }

        })


    })

    $("#Cancelar").click(function () {

        $("#NombrePlato").val("");
        $("#idPlatoPrincipal").val("");
        $("#descripcionPlato").val("");
        $("#tipoPlato").val("");
        $("#GuardaPlato").html("Guardar");
        $("#Cancelar").hide();
    })

    $("#BuscadorPlatos").click(function () {

        var nombrePlato = $("#NombrePlato").val();
        var descripcionPlato = $("#descripcionPlato").val();
        $.get("PlatoPrincipal.aspx", {
            action: "BuscaPlatoPrincipal",
            nombrePlato: nombrePlato,
            descripcion:descripcionPlato

        }, function (data)
        {
            data = data.split("//");
            if (data[1] == "OK") {
               $("#idPlatoPrincipal").val(data[2]);
               $("#NombrePlato").val(data[3]);
               $("#descripcionPlato").val(data[4]);
               $("#tipoPlato").val(data[5]);
            }
            else
            {
                alert(data[2]);
            }
        })

    })
})

function editar(idplatoPrincipal,NombrePlato,descripcion,TipoPlato)
{
   $("#Cancelar").show();
   $("#NombrePlato").val(NombrePlato);
   $("#idPlatoPrincipal").val(idplatoPrincipal);
   $("#descripcionPlato").val(descripcion);
   $("#tipoPlato").val(TipoPlato);
   $("#GuardaPlato").html("Modificar");
}

function Elimina(idPlatoPrincipal)
{
    $.post("PlatoPrincipal.aspx", {
        action: "EliminaPlato",
        idPlatoPrincipal:idPlatoPrincipal
    }, function (data) {

        data = data.split("//");
        if (data[1] == "OK")
        {
            alert(data[2]);
            location.href = "/Paginas/nevera/PlatoPrincipal.aspx";
        }
        else
        {
            alert(data[2]);
        }
    })
}

function ComprobarTipoComida() {
    $.post("PlatoPrincipal.aspx", {
        action: "ConsultaTipoComida"

    }, function (data) {
        data = data.split("//");
        if (data[1] != "OK" && data[1] == "NOK") {

            $("NombrePlato").attr("disabled", true);
            $("descripcionPlato").attr("disabled", true);
            $("tipoPlato").attr("disabled", true);
            confirm(data[2]);
            if (confirm) {
                location.href = "../../Paginas/nevera/TipoComida.aspx";
            }
        }
        else {
            $("NombrePlato").attr("disabled", false);
            $("descripcionPlato").attr("disabled", false);
            $("tipoPlato").attr("disabled", false);

        }
    })
}