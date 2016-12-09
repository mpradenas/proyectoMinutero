$(document).ready(function () {
    $("#Cancelar").hide();



    $("#GuardaPostre").click(function () {

        var NombrePostre = $("#Nombrepostre").val();
        var idPostre = parseInt($("#idPostre").val());
        var descripcion = $("#descripcionPostre").val();
        
        $.post("postres.aspx", {
            action: "GuardaPostre",
            idpostre: idPostre,
            nombrePostre:NombrePostre ,
            descripcion: descripcion,

        }, function (data) {
            data = data.split("//");
            if (data[1] == "OK") {
                alert(data[2]);
                location.href = "/Paginas/nevera/postres.aspx";
            } else {
                alert(data[2]);
            }

        })


    })

    $("#Cancelar").click(function () {

        $("#Nombrepostre").val("");
        $("#idPostre").val("");
        $("#descripcionPostre").val("");
       
        $("#Guardapostre").html("Guardar");
        $("#Cancelar").hide();
    })

    $("#Buscadorpostres").click(function () {

        var nombrepostre = $("#Nombrepostre").val();
        var descripcionpostre = $("#descripcionPostre").val();
        $.get("postre.aspx", {
            action: "BuscapostrePrincipal",
            nombrepostre: nombrepostre,
            descripcion: descripcionpostre

        }, function (data) {
            data = data.split("//");
            if (data[1] == "OK") {
                $("#idpostrePrincipal").val(data[2]);
                $("#Nombrepostre").val(data[3]);
                $("#descripcionpostre").val(data[4]);
                $("#tipopostre").val(data[5]);
            }
            else {
                alert(data[2]);
            }
        })

    })
})

function editar(idpostre, Nombrepostre, descripcion) {
    $("#Cancelar").show();
    $("#Nombrepostre").val(Nombrepostre);
    $("#idPostre").val(idpostre);
    $("#descripcionPostre").val(descripcion);
    
    $("#Guardapostre").html("Modificar");
}

function Elimina(idPostre) {
    $.post("Postres.aspx", {
        action: "Eliminapostre",
        idPostre: idpostre
    }, function (data) {

        data = data.split("//");
        if (data[1] == "OK") {
            alert(data[2]);
            location.href = "/Paginas/nevera/postre.aspx";
        }
        else {
            alert(data[2]);
        }
    })
}
