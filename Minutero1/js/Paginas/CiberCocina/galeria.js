$(document).ready(function () {


    pageSetUp();
    $('.superbox').SuperBox();




    var idUsuario = $("#idUsuario").val();

    $.get("Galeria.aspx", {
        action: "traeImagenes",
        idUsuario: idUsuario
    }, function (data) {


        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-XXXXXXXX-X']);
        _gaq.push(['_trackPageview']);

        (function () {
            var ga = document.createElement('script');
            ga.type = 'text/javascript';
            ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0];
            s.parentNode.insertBefore(ga, s);
        })();




        $("#elSuperBox").html(data);
        $('.superbox').SuperBox();


    })


});

function eliminaImagen(idImagen)
{
    if (parseInt(idImagen) > 0)
    {
        $.post("Galeria.aspx", {
            action:"eliminaImagen",
            idImagen:idImagen
        }, function (data) {
            data = data.split("//");
            if (data[1] == "OK")
            {
                alert(data[2]);
                location.href = "/Paginas/CiberCocina/Galeria.aspx";
            }
            else
            {
                aler(data[2]);
            }

        })
    }
}