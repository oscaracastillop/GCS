function BuscarCookie() {
    let IdUser = Cookies.get('IdUser');
    if (IdUser == '' || IdUser == undefined || IdUser == null) {
        Swal.fire({
            title: 'Mensaje del Sistema',
            text: "Su Sesión ya expiro, por favor vuelva a Ingresar",
            icon: 'info',
        }).then((result) => {
            window.location.href = '/Login';
        })
    }
}

function CerrarSesion() {
    Cookies.remove('IdUser');
    window.location.href = '/Login';
}