$("#Bienvenido").hide();
$("#Invalido").hide();

$(function () {

    // Validation
    $("#login-form").validate({
        // Rules for form validation
        rules: {
            usuario: {
                required: true
            },
            empresa: {
                required: true
            },
            password: {
                required: true,
                minlength: 3,
                maxlength: 20
            }
        },

        // Messages for form validation
        messages: {
            usuario: {
                required: 'Ingreso Usuario',
            },
            //empresa: {
              //  required: 'Seleccione Empresa',
            //},
            password: {
                required: 'Ingrese Contraseña'
            }
        },

        // Do not change code below
        errorPlacement: function (error, element) {
            error.insertAfter(element.parent());
        }
        ,
        submitHandler: function (form) {
            var usuario = $("[name=usuario]").val();
            var clave = $("[name=password]").val();
         
            var recordar = 0;

            if ($("#remember").is(":checked")) {
                recordar = 1;
            }
            $.post("login.aspx", { action: "login",clave: clave, usuario: usuario, recordar: recordar },
                function (data) {
                    $("#Bienvenido").hide();
                    $("#Invalido").hide();
                    data = data.split("//");
                    if (data[1] == "OK") {

                        $("#username").html(data[2]);
                        $("#Bienvenido").show();
                        location.href = "/Default.aspx";
                    }
                    else if (data[1] == "OKAdmin")
                    {
                        $("#username").html(data[2]);
                        $("#Bienvenido").show();
                        location.href = "/administracion.aspx";
                    }
                    else
                    {
                        $("#alerta").html(data[2]);
                        $("#Invalido").show();

                        return false;
                    }
                }
            );
            //Para que no se envie el formulario.

            return false;
        }
    });

    $(document).keypress(function (e) {
        if (e.which == 13) {
            var usuario = $("[name=usuario]").val();
            var clave = $("[name=password]").val();
            var empresa = $("[name=empresa]").val();
            var recordar = 0;

            if ($("#remember").is(":checked")) {
                recordar = 1;
            }
            $.post("login.aspx", { action: "login", empresa: empresa, clave: clave, usuario: usuario, recordar: recordar },
                function (data) {
                    $("#Bienvenido").hide();
                    $("#Invalido").hide();
                    data = data.split("//");
                    if (data[1] == "OK") {
                        $("#username").html(data[2]);
                        $("#Bienvenido").show();
                        location.href = "/Default.aspx";
                    } else {
                        $("#alerta").html(data[2]);
                        $("#Invalido").show();
                    }
                }
            );
        }
    });




});