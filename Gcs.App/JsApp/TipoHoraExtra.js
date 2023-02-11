function CrearTipoHoraExtra() {
    let User = Cookies.get('IdUser');
    let NombreTipoHoraExtra = $('#InputNombreTipoHoraExtra').val()
    if (NombreTipoHoraExtra == null || NombreTipoHoraExtra == '' || NombreTipoHoraExtra == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre del tipo hora extra', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/TipoHoraExtra/CrearTipoHoraExtra',
            data: { IdUser: User, NombreTipoHoraExtra: NombreTipoHoraExtra },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/TipoHoraExtra';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function GuardarCambiosTipoHoraExtra() {
    let User = Cookies.get('IdUser');
    let IdTipoHoraExtra = Cookies.get('IdEdit');
    let NombreTipoHoraExtra = $('#InputENombreTipoHoraExtra').val();
    let Activo = $('#SelectEstadoTipoHoraExtra').val();
    if (NombreTipoHoraExtra == '' || NombreTipoHoraExtra == null || NombreTipoHoraExtra == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre del tipo hora extra', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/TipoHoraExtra/GuardarCambiosTipoHoraExtra',
            data: { IdTipoHoraExtra: IdTipoHoraExtra, IdUser: User, NombreTipoHoraExtra: NombreTipoHoraExtra, Activo: Activo },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/TipoHoraExtra';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function EliminarTipoHoraExtra() {
    let IdUser = Cookies.get('IdUser');
    let IdTipoHoraExtra = $('#IdTipoHoraExtra').text();
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/TipoHoraExtra/EliminarTipoHoraExtra',
        data: {
            IdUser: IdUser,
            IdTipoHoraExtra: IdTipoHoraExtra
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

function CargarDatosTipoHoraExtra() {
    let IdTipoHoraExtra = Cookies.get('IdEdit');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/TipoHoraExtra/CargarDatosTipoHoraExtra',
        data: { IdTipoHoraExtra: IdTipoHoraExtra },
        success: function (resultado) {
            $('#InputENombreTipoHoraExtra').val(resultado[0].Nombre);
            $('#SelectEstadoTipoHoraExtra').val(resultado[0].Activo);

        }
    });
}

function ListaTipoHoraExtra(Tipo) {
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/TipoHoraExtra/ListaTipoHoraExtra',
        data: {},
        success: function (resultado) {
            var contador = 0;
            if (Tipo == "N") {
                if (resultado.length === 0) {
                    $("#SelectTipoHoraExtra").append('<option value="">No hay Datos</option>');
                } else {
                    $("#SelectTipoHoraExtra").empty().append('<option value="-1">Seleccione tipo hora extra</option>');
                    $.each(resultado, function () {
                        $("#SelectTipoHoraExtra").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                        contador++;
                    });
                }
            } else {
                $.each(resultado, function () {
                    $("#SelectETipoHoraExtra").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                    contador++;
                });
            }
        },
    });
}

function GridTipoHoraExtra() {
    let datatable = $('#gridTipoHoraExtra').DataTable({
        "responsive": true,
        dom: 'B<"clear">frtip',
        buttons: [{
            extend: 'excelHtml5',
            footer: true,
            title: 'Lista de Tipo Hora Extra',
            filename: 'Listado Tipo Hora Extra',
            text: 'Excel',
            exportOptions: {
                columns: [1, 2, 3, 4]
            }
        },
        {
            extend: 'pdfHtml5',
            download: 'open',
            footer: true,
            title: 'Lista de Tipo Hora Extra',
            filename: 'Lista de Tipo Hora Extra',
            text: 'Pdf',
            exportOptions: {
                columns: [1, 2, 3, 4]
            }
        },
        {
            extend: 'print',
            footer: true,
            filename: 'Export_File_print',
            text: 'Imprimir',
            exportOptions: {
                columns: [1, 2, 3, 4]
            }
        },
        ],
        "order": [[1, "asc"]],
        destroy: true,
        "ajax": {
            "url": '/TipoHoraExtra/GridTipoHoraExtra',
            "type": "GET",
            "datatype": "json"
        },
        columns: [
            { "data": "Id", title: "Id", "visible": false },
            { "data": "Nombre", title: "Hora Extra" },
            { "data": "Estado", title: "Estado" },
            { "data": "CreateBy", title: "Creado por" },
            { "data": "DateCreate", title: "Fecha Creación" },
            {
                title: "Editar",
                data: null,
                defaultContent: '<a href="#" class="EditarTipoHoraExtra" title="Editar"><i class="bi-pencil-fill" style="Color:green"></i></a>',
                className: '',
                orderable: false,
                width: 50,
            },
            {
                title: "Eliminar",
                data: null,
                defaultContent: '<a href="#" class="EliminarTipoHoraExtra" title="Eliminar"><i class="bi-trash-fill" style="Color:red"></i></a>',
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
    $('#gridTipoHoraExtra').on('click', '.EditarTipoHoraExtra', function () {
        let data = datatable.row($(this).parents()).data();
        Cookies.set('IdEdit', data.Id);
        window.location = "/TipoHoraExtra/Editar_TipoHoraExtra";
    });


    $('#gridTipoHoraExtra').on('click', '.EliminarTipoHoraExtra', function () {
        let data = datatable.row($(this).parents()).data();
        $('#ModalEliminarTipoHoraExtra').modal('show');
        $('#IdTipoHoraExtra').text(data.Id);
        $('#MensajeEliminarTipoHoraExtra').text('Esta seguro de eliminar el tipo hora extra ' + data.Nombre + ' ?');
    })
}



