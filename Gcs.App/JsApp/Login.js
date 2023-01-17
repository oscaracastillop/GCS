function Ingresar() {
    let Usuario = $('#InputUsuario').val()
    let Password = $('#InputPassword').val()
    if (Usuario == '' || Usuario == null || Usuario == undefined) {
        Swal.fire('Mensaje del Sistema', 'Por favor ingrese el nombre de Usuario', 'info');
    }
    else if (Password == '' || Password == null || Password == undefined) {
        Swal.fire('Mensaje del Sistema', 'Por favor ingrese la Contraseña', 'info');
    }
    else {
        $.ajax({
            type: 'POST',
            dataType: 'Json',
            url: '/Login/IniciarSesion',
            data: { Usuario: Usuario, Password: Password },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Cookies.set('IdUser', valor[1]);
                    window.location.href = '/Home';
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            },
        });
    }
}
