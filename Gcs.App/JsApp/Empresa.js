function CrearEmpresa() {
    let User = Cookies.get('IdUser');
    let NombreEmpresa = $('#InputNombreEmpresa').val();
    let IdTipoDocumento = $('#SelectTipoDocumento').val();
    let Identificacion = $('#InputIdentificacionEmpresa').val();
    let Email = $('#InputEmailEmpresa').val();
    let Telefono = $('#InputTelefonoEmpresa').val();
    let Contacto = $('#InputContactoEmpresa').val();
    let IdCiudad = $('#SelectCiudad').val();
    let Direccion = $('#InputDireccionEmpresa').val();
    if (NombreEmpresa == null || NombreEmpresa == '' || NombreEmpresa == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre de la empresa', 'info');
    } else if (IdTipoDocumento == -1 || IdTipoDocumento == null || IdTipoDocumento == '') {
        Swal.fire('Mensaje del Sistema', 'Seleccione tipo documento', 'info');
    } else if (IdCiudad == -1 || IdCiudad == null || IdCiudad == '') {
        Swal.fire('Mensaje del Sistema', 'Seleccione la ciudad', 'info');
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
                        window.location.href = '/Empresa';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function GuardarCambiosEmpresa() {
    let User = Cookies.get('IdUser');
    let IdEmpresa = Cookies.get('IdEdit');
    let NombreEmpresa = $('#InputENombreEmpresa').val();
    let IdTipoDocumento = $('#SelectETipoDocumento').val();
    let Identificacion = $('#InputEIdentificacionEmpresa').val();
    let Email = $('#InputEEmailEmpresa').val();
    let Telefono = $('#InputETelefonoEmpresa').val();
    let Contacto = $('#InputEContactoEmpresa').val();
    let IdCiudad = $('#SelectECiudad').val();
    let Direccion = $('#InputEDireccionEmpresa').val();
    let Activo = $('#SelectEstadoEmpresa').val();
    if (NombreEmpresa == null || NombreEmpresa == '' || NombreEmpresa == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre de la empresa', 'info');
    } else if (IdTipoDocumento == -1 || IdTipoDocumento == null || IdTipoDocumento == '') {
        Swal.fire('Mensaje del Sistema', 'Seleccione tipo documento', 'info');
    } else if (IdCiudad == -1 || IdCiudad == null || IdCiudad == '') {
        Swal.fire('Mensaje del Sistema', 'Seleccione la ciudad', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/Empresa/GuardarCambiosEmpresa',
            data: {               
                IdUser: User,
                IdEmpresa: IdEmpresa,
                NombreEmpresa: NombreEmpresa,
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
                        window.location.href = '/Empresa';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}


function EliminarEmpresa() {
    let IdUser = Cookies.get('IdUser');
    let IdEmpresa = $('#IdEmpresa').text();
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Empresa/EliminarEmpresa',
        data: {
            IdUser: IdUser,
            IdEmpresa: IdEmpresa
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


function CargarDatosEmpresa() {
    let IdEmpresa = Cookies.get('IdEdit');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Empresa/CargarDatosEmpresa',
        data: { IdEmpresa: IdEmpresa },
        success: function (resultado) {
            $('#InputENombreEmpresa').val(resultado[0].Nombre);
            $('#SelectETipoDocumento').val(resultado[0].TipoDocumento);
            $('#InputEIdentificacionEmpresa').val(resultado[0].Identificacion);            
            $('#InputEEmailEmpresa').val(resultado[0].Email);
            $('#InputETelefonoEmpresa').val(resultado[0].Telefono);
            $('#InputEContactoEmpresa').val(resultado[0].Contacto);
            $('#SelectEPais').val(resultado[0].Pais);
            $('#SelectEDepartamento').val(resultado[0].Departamento);
            $('#SelectECiudad').val(resultado[0].Ciudad);
            $('#InputEDireccionEmpresa').val(resultado[0].Direccion);            
            $('#SelectEstadoEmpresa').val(resultado[0].Activo);
        }
    });
}


function ListaEmpresa(Tipo) {
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Empresa/ListaEmpresa',
        data: {},
        success: function (resultado) {
            var contador = 0;
            if (Tipo == "N") {
                if (resultado.length === 0) {
                    $("#SelectEmpresa").append('<option value="">No hay Datos</option>');
                } else {
                    $("#SelectEmpresa").empty().append('<option value="-1">Seleccione Empresa</option>');
                    $.each(resultado, function () {
                        $("#SelectEmpresa").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                        contador++;
                    });
                }
            } else {
                $.each(resultado, function () {
                    $("#SelectEEmpresa").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                    contador++;
                });
            }
        },
    });
}

function GridEmpresa() {
    let datatable = $('#gridEmpresa').DataTable({
        "responsive": true,
        dom: 'B<"clear">frtip',
        buttons: [{
            extend: 'excelHtml5',
            footer: true,
            title: 'Lista de Empresa',
            filename: 'Lista de Empresa',
            text: 'Excel',
            exportOptions: {
                columns: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10 , 11]
            }
        },
        {
            extend: 'pdfHtml5',
            download: 'open',
            footer: true,
            title: 'Lista de Empresa',
            filename: 'Lista de Empresa',
            text: 'Pdf',
            orientation: 'landscape',
            pageSize: 'LEGAL',
            exportOptions: {
                columns: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
            }
        },
        {
            extend: 'print',
            footer: true,
            filename: 'Export_File_print',
            text: 'Imprimir',
            exportOptions: {
                columns: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
            }
        },
        ],
        "order": [[1, "asc"]],
        destroy: true,
        "ajax": {
            "url": '/Empresa/GridEmpresa',
            "type": "GET",
            "datatype": "json"
        },
        columns: [
            { "data": "Id", title: "Id", "visible": false },
            { "data": "Nombre", title: "Empresa" },
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
                defaultContent: '<a href="#" class="EditarEmpresa" title="Editar"><i class="bi-pencil-fill" style="Color:green"></i></a>',
                className: '',
                orderable: false,
                width: 50,
            },
            {
                title: "Eliminar",
                data: null,
                defaultContent: '<a href="#" class="EliminarEmpresa" title="Eliminar"><i class="bi-trash-fill" style="Color:red"></i></a>',
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
    $('#gridEmpresa').on('click', '.EditarEmpresa', function () {
        let data = datatable.row($(this).parents()).data();
        Cookies.set('IdEdit', data.Id);
        window.location = "/Empresa/Editar_Empresa";
    });


    $('#gridEmpresa').on('click', '.EliminarEmpresa', function () {
        let data = datatable.row($(this).parents()).data();
        $('#ModalEliminarEmpresa').modal('show');
        $('#IdEmpresa').text(data.Id);
        $('#MensajeEliminarEmpresa').text('Esta seguro de eliminar la empresa ' + data.Nombre + ' ?');
    })
}
