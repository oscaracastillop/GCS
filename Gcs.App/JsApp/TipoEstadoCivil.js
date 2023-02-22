function CrearTipoEstadoCivil() {
    let User = Cookies.get('IdUser');
    let NombreTipoEstadoCivil = $('#InputNombreTipoEstadoCivil').val()
    if (NombreTipoEstadoCivil == null || NombreTipoEstadoCivil == '' || NombreTipoEstadoCivil == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre del tipo estado civil', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/TipoEstadoCivil/CrearTipoEstadoCivil',
            data: { IdUser: User, NombreTipoEstadoCivil: NombreTipoEstadoCivil },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/TipoEstadoCivil';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function GuardarCambiosTipoEstadoCivil() {
    let User = Cookies.get('IdUser');
    let IdTipoEstadoCivil = Cookies.get('IdEdit');
    let NombreTipoEstadoCivil = $('#InputENombreTipoEstadoCivil').val();
    let Activo = $('#SelectEstadoTipoEstadoCivil').val();
    if (NombreTipoEstadoCivil == '' || NombreTipoEstadoCivil == null || NombreTipoEstadoCivil == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre del tipo estado civil', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/TipoEstadoCivil/GuardarCambiosTipoEstadoCivil',
            data: { IdTipoEstadoCivil: IdTipoEstadoCivil, IdUser: User, NombreTipoEstadoCivil: NombreTipoEstadoCivil, Activo: Activo },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/TipoEstadoCivil';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function EliminarTipoEstadoCivil() {
    let IdUser = Cookies.get('IdUser');
    let IdTipoEstadoCivil = $('#IdTipoEstadoCivil').text();
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/TipoEstadoCivil/EliminarTipoEstadoCivil',
        data: {
            IdUser: IdUser,
            IdTipoEstadoCivil: IdTipoEstadoCivil
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

function CargarDatosTipoEstadoCivil() {
    let IdTipoEstadoCivil = Cookies.get('IdEdit');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/TipoEstadoCivil/CargarDatosTipoEstadoCivil',
        data: { IdTipoEstadoCivil: IdTipoEstadoCivil },
        success: function (resultado) {
            $('#InputENombreTipoEstadoCivil').val(resultado[0].Nombre);
            $('#SelectEstadoTipoEstadoCivil').val(resultado[0].Activo);

        }
    });
}

function ListaTipoEstadoCivil(Tipo) {
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/TipoEstadoCivil/ListaTipoEstadoCivil',
        data: {},
        success: function (resultado) {
            var contador = 0;
            if (Tipo == "N") {
                if (resultado.length === 0) {
                    $("#SelectTipoEstadoCivil").append('<option value="">No hay Datos</option>');
                } else {
                    $("#SelectTipoEstadoCivil").empty().append('<option value="-1">Seleccione Estado Civil</option>');
                    $.each(resultado, function () {
                        $("#SelectTipoEstadoCivil").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                        contador++;
                    });
                }
            } else {
                $.each(resultado, function () {
                    $("#SelectETipoEstadoCivil").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                    contador++;
                });
            }
        },
    });
}

function GridTipoEstadoCivil() {
    let datatable = $('#gridTipoEstadoCivil').DataTable({
        "responsive": true,
        dom: 'B<"clear">frtip',
        buttons: [{
            extend: 'excelHtml5',
            footer: true,
            title: 'Lista de tipo estado civil',
            filename: 'Listado tipo estado civil',
            text: 'Excel',
            exportOptions: {
                columns: [1, 2, 3, 4]
            }
        },
        {
            extend: 'pdfHtml5',
            download: 'open',
            footer: true,
            title: 'Lista de tipo estado civil',
            filename: 'Lista de tipo estado civil',
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
            "url": '/TipoEstadoCivil/GridTipoEstadoCivil',
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
                defaultContent: '<a href="#" class="EditarTipoEstadoCivil" title="Editar"><i class="bi-pencil-fill" style="Color:green"></i></a>',
                className: '',
                orderable: false,
                width: 50,
            },
            {
                title: "Eliminar",
                data: null,
                defaultContent: '<a href="#" class="EliminarTipoEstadoCivil" title="Eliminar"><i class="bi-trash-fill" style="Color:red"></i></a>',
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
    $('#gridTipoEstadoCivil').on('click', '.EditarTipoEstadoCivil', function () {
        let data = datatable.row($(this).parents()).data();
        Cookies.set('IdEdit', data.Id);
        window.location = "/TipoEstadoCivil/Editar_TipoEstadoCivil";
    });


    $('#gridTipoEstadoCivil').on('click', '.EliminarTipoEstadoCivil', function () {
        let data = datatable.row($(this).parents()).data();
        $('#ModalEliminarTipoEstadoCivil').modal('show');
        $('#IdTipoEstadoCivil').text(data.Id);
        $('#MensajeEliminarTipoEstadoCivil').text('Esta seguro de eliminar el tipo estado civil ' + data.Nombre + ' ?');
    })
}



