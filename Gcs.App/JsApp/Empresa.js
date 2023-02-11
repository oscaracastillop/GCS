function CrearEmpresa() {
    let User = Cookies.get('IdUser');
    let NombreEmpresa = $('#InputNombreEmpresa').val();
    let IdTipoDocumento = $('#SelectTipoDocumento').val();
    let Identificacion = $('#InputIdentificacionEmpresa').val();
    let Email = $('#InputEmailEmpresa').val();
    let Telefono = $('#InputTelefonoEmpresa').val();
    let NombreEmpresa = $('#InputNombreEmpresa').val();



    let Email = $('#InputEmailArl').val();
    let Telefono = $('#InputTelefonoArl').val();
    if (NombreArl == null || NombreArl == '' || NombreArl == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre de la arl', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/Arl/CrearArl',
            data: { IdUser: User, NombreArl: NombreArl, Email: Email, Telefono: Telefono },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/Arl';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}