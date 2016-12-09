runAllForms();
			
// Model i agree button

			
// Validation
$(function() {
    // Validation
    $("#smart-form-register").validate({

        // Rules for form validation
        rules : {
            username : {
                required : true
            },
            email : {
                required : true,
                email : true
            },
            password : {
                required : true,
                minlength : 3,
                maxlength : 20
            },
            passwordConfirm : {
                required : true,
                minlength : 3,
                maxlength : 20,
                equalTo : '#password'
            },
            firstname : {
                required : true
            },
            lastname : {
                required : true
            }
        },

        // Messages for form validation
        messages : {
            login : {
                required : 'Porfavor , ingresa tu mail'
            },
            email : {
                required : 'Ingresa tu correo ',
                email : 'Por favor, ingresa un correo válido.'
            },
            password : {
                required : 'Por favor, ingresa tu contraseña'
            },
            passwordConfirm : {
                required : 'Por favor , ingresa tu contraseña de nuevo',
                equalTo : 'Tiene que ser exactamente igual a la que ingresaste arriba'
            },
            firstname : {
                required : 'Ingresa tu nombre'
            },
            lastname : {
                required : 'Ingresa tu apellido'
            }
        },

        // Ajax form submition
        submitHandler : function(form) {
            var nombre=$("[name=Nombre]").val()+" "+$("[name=Apellido]").val();
            var correo=$("[name=email]").val();
            var contrasena=$("[name=password]").val();
            var nickname=$("[name=username]").val();
            var empresa=$("[name=empresa]").val();
            var rutEmpresa = $("[name=Rutempresa]").val();
            var TipoUsuario = $("#TipoUsuario").val();
            $.post("Registro.aspx", {
                action:"registra",
                nickName: nickname,
                contrasena: contrasena,
                correo: correo,
                empresa: empresa,
                nombre: nombre,
                rutempresa: rutEmpresa,
                tipoUsuario:TipoUsuario
                },function(data){
                    data=data.split('//');
                    if(data[1]=="OK")
                    {
                        
                        alert("Ya estas registrado. Excelente!");

                    }
                    else
                    {
                        alert(data[2]);
                    }
                })
        },

        // Do not change code below
        errorPlacement : function(error, element) {
            error.insertAfter(element.parent());
        }
    });

});

