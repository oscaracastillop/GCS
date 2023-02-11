function CrearEmpresa() {
    let User = Cookies.get('IdUser');
    let NombreEmpresa = $('#InputNombreEmpresa').val();
    let IdTipoDocumento = $('#SelectTipoDocumento').val();
    let Identificacion = $('#InputIdentificacionEmpresa').val();
    let Email = $('#InputEmailEmpresa').val();
    let Telefono = $('#InputTelefonoEmpresa').val();
    let Contacto = $('#InputContactoEmpresa').val();
    let IdCiudad = $('#SelectCiudad').val();
    if (NombreEmpresa == null || NombreEmpresa == '' || NombreEmpresa == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre de la empresa', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/Empresa/CrearEmpresa',
            data: {
                IdUser: User,
                NombreEmpresa: NombreEmpresa,
                IdTipoDocumento: IdTipoDocumento,
                Identificacion: Identificacion,
                Email: Email,
                Telefono: Telefono,
                Contacto: Contacto,
                IdCiudad: IdCiudad
            },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/Empresa';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}