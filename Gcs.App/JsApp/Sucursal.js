function CrearSucursal() {
    let User = Cookies.get('IdUser');
    let IdEmpresa = $('#SelectEmpresa').val();
    let NombreSucursal = $('#InputNombreSucursal').val();
    let IdTipoDocumento = $('#SelectTipoDocumento').val();
    let Identificacion = $('#InputIdentificacionSucursal').val();
    let Email = $('#InputEmailSucursal').val();
    let Telefono = $('#InputTelefonoSucursal').val();
    let Contacto = $('#InputContactoSucursal').val();
    let IdCiudad = $('#SelectCiudad').val();
    let Direccion = $('#InputDireccionSucursal').val();
    if (IdEmpresa == -1 || IdEmpresa == '' || IdEmpresa == null) {
        Swal.fire('Mensaje del Sistema', 'Seleccione la empresa', 'info');
    } else if (NombreSucursal == null || NombreSucursal == '' || NombreSucursal == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre de la sucursal', 'info');
    } else if (IdTipoDocumento == -1 || IdTipoDocumento == null || IdTipoDocumento == '') {
        Swal.fire('Mensaje del Sistema', 'Seleccione tipo documento', 'info');
    } else if (IdCiudad == -1 || IdCiudad == null || IdCiudad == '') {
        Swal.fire('Mensaje del Sistema', 'Seleccione la ciudad', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/Sucursal/CrearSucursal',
            data: {
                IdUser: User,
                IdEmpresa: IdEmpresa,
                NombreSucursal: NombreSucursal,
                IdTipoDocumento: IdTipoDocumento,
                Identificacion: Identificacion,
                Email: Email,
                Telefono: Telefono,
                Contacto: Contacto,
                IdCiudad: IdCiudad,
                Direccion: Direccion
            },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/Sucursal';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function GuardarCambiosSucursal() {
    let User = Cookies.get('IdUser');
    let IdEmpresa = $('#SelectEEmpresa').val();
    let IdSucursal = Cookies.get('IdEdit');
    let NombreSucursal = $('#InputENombreSucursal').val();
    let IdTipoDocumento = $('#SelectETipoDocumento').val();
    let Identificacion = $('#InputEIdentificacionSucursal').val();
    let Email = $('#InputEEmailSucursal').val();
    let Telefono = $('#InputETelefonoSucursal').val();
    let Contacto = $('#InputEContactoSucursal').val();
    let IdCiudad = $('#SelectECiudad').val();
    let Direccion = $('#InputEDireccionSucursal').val();
    let Activo = $('#SelectEstadoSucursal').val();
    if (IdEmpresa == -1 || IdEmpresa == '' || IdEmpresa == null) {
        Swal.fire('Mensaje del Sistema', 'Seleccione la empresa', 'info');
    } else if (NombreSucursal == null || NombreSucursal == '' || NombreSucursal == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre de la sucursal', 'info');
    } else if (IdTipoDocumento == -1 || IdTipoDocumento == null || IdTipoDocumento == '') {
        Swal.fire('Mensaje del Sistema', 'Seleccione tipo documento', 'info');
    } else if (IdCiudad == -1 || IdCiudad == null || IdCiudad == '') {
        Swal.fire('Mensaje del Sistema', 'Seleccione la ciudad', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/Sucursal/GuardarCambiosSucursal',
            data: {
                IdUser: User,
                IdSucursal: IdSucursal,
                IdEmpresa:  IdEmpresa,
                NombreSucursal: NombreSucursal,
                IdTipoDocumento: IdTipoDocumento,
                Identificacion: Identificacion,
                Email: Email,
                Telefono: Telefono,
                Contacto: Contacto,
                IdCiudad: IdCiudad,
                Direccion: Direccion,
                Activo: Activo
            },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/Sucursal';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}


function EliminarSucursal() {
    let IdUser = Cookies.get('IdUser');
    let IdSucursal = $('#IdSucursal').text();
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Sucursal/EliminarSucursal',
        data: {
            IdUser: IdUser,
            IdSucursal: IdSucursal
        },
        success: function (resultado) {
            valor = resultado.split('*');
            if (valor[0] == 'OK') {
                Swal.fire({
                    title: 'Mensaje del Sistema',
                    text: valor[1],
                    icon: 'success',
                }).then((result) => {
                    location.reload();
                })
            } else {
                Swal.fire('Mensaje del Sistema', valor[1], 'info');
            }
        }
    });
}


function CargarDatosSucursal() {
    let IdSucursal = Cookies.get('IdEdit');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Sucursal/CargarDatosSucursal',
        data: { IdSucursal: IdSucursal },
        success: function (resultado) {
            $('#IdEEmpresa').val(resultado[0].IdEmpresa);
            $('#InputENombreSucursal').val(resultado[0].Nombre);
            $('#SelectETipoDocumento').val(resultado[0].TipoDocumento);
            $('#InputEIdentificacionSucursal').val(resultado[0].Identificacion);
            $('#InputEEmailSucursal').val(resultado[0].Email);
            $('#InputETelefonoSucursal').val(resultado[0].Telefono);
            $('#InputEContactoSucursal').val(resultado[0].Contacto);
            $('#SelectEPais').val(resultado[0].Pais);
            $('#SelectEDepartamento').val(resultado[0].Departamento);
            $('#SelectECiudad').val(resultado[0].Ciudad);
            $('#InputEDireccionSucursal').val(resultado[0].Direccion);
            $('#SelectEstadoSucursal').val(resultado[0].Activo);
        }
    });
}


function ListaSucursal(Tipo) {
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Sucursal/ListaSucursal',
        data: {},
        success: function (resultado) {
            var contador = 0;
            if (Tipo == "N") {
                if (resultado.length === 0) {
                    $("#SelectSucursal").append('<option value="">No hay Datos</option>');
                } else {
                    $("#SelectSucursal").empty().append('<option value="-1">Seleccione Sucursal</option>');
                    $.each(resultado, function () {
                        $("#SelectSucursal").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                        contador++;
                    });
                }
            } else {
                $.each(resultado, function () {
                    $("#SelectESucursal").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                    contador++;
                });
            }
        },
    });
}

function GridSucursal() {
    let datatable = $('#gridSucursal').DataTable({
        "responsive": true,
        dom: 'B<"clear">frtip',
        buttons: [{
            extend: 'excelHtml5',
            footer: true,
            title: 'Lista de Sucursal',
            filename: 'Lista de Sucursal',
            text: 'Excel',
            exportOptions: {
                columns: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
            }
        },
        {
            extend: 'pdfHtml5',
            download: 'open',
            footer: true,
            title: 'Lista de Sucursal',
            filename: 'Lista de Sucursal',
            text: 'Pdf',
            orientation: 'landscape',
            pageSize: 'LEGAL',
            exportOptions: {
                columns: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
            }
        },
        {
            extend: 'print',
            footer: true,
            filename: 'Export_File_print',
            text: 'Imprimir',
            exportOptions: {
                columns: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
            }
        },
        ],
        "order": [[1, "asc"]],
        destroy: true,
        "ajax": {
            "url": '/Sucursal/GridSucursal',
            "type": "GET",
            "datatype": "json"
        },
        columns: [
            { "data": "Id", title: "Id", "visible": false },
            { "data": "Empresa", title: "Empresa" },
            { "data": "Nombre", title: "Sucursal" },
            { "data": "TipoDocumento", title: "Documento" },
            { "data": "Identificacion", title: "Identificación" },
            { "data": "Email", title: "Email" },
            { "data": "Telefono", title: "Teléfono" },
            { "data": "Contacto", title: "Contacto" },
            { "data": "Direccion", title: "Dirección" },
            { "data": "Ciudad", title: "Ciudad" },
            { "data": "Estado", title: "Estado" },
            { "data": "CreateBy", title: "Creado por" },
            { "data": "DateCreate", title: "Fecha Creación" },
            {
                title: "Editar",
                data: null,
                defaultContent: '<a href="#" class="EditarSucursal" title="Editar"><i class="bi-pencil-fill" style="Color:green"></i></a>',
                className: '',
                orderable: false,
                width: 50,
            },
            {
                title: "Eliminar",
                data: null,
                defaultContent: '<a href="#" class="EliminarSucursal" title="Eliminar"><i class="bi-trash-fill" style="Color:red"></i></a>',
                className: '',
                orderable: false,
                width: 50,
            },
        ],
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.11.2/i18n/es_es.json"
        },
        lengthMenu: [
            [10, 25, 50, -1],
            ['10 Filas', '25 Filas', '50 Filas', 'Ver Todo']
        ],
    });
    $('#gridSucursal').on('click', '.EditarSucursal', function () {
        let data = datatable.row($(this).parents()).data();
        Cookies.set('IdEdit', data.Id);
        window.location = "/Sucursal/Editar_Sucursal";
    });


    $('#gridSucursal').on('click', '.EliminarSucursal', function () {
        let data = datatable.row($(this).parents()).data();
        $('#ModalEliminarSucursal').modal('show');
        $('#IdSucursal').text(data.Id);
        $('#MensajeEliminarSucursal').text('Esta seguro de eliminar la sucursal ' + data.Nombre + ' ?');
    })
}
