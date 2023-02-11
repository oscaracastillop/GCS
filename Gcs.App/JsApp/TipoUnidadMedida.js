function CrearTipoUnidadMedida() {
    let User = Cookies.get('IdUser');
    let NombreTipoUnidadMedida = $('#InputNombreTipoUnidadMedida').val()
    if (NombreTipoUnidadMedida == null || NombreTipoUnidadMedida == '' || NombreTipoUnidadMedida == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre del tipo unidad medida', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/TipoUnidadMedida/CrearTipoUnidadMedida',
            data: { IdUser: User, NombreTipoUnidadMedida: NombreTipoUnidadMedida },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/TipoUnidadMedida';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function GuardarCambiosTipoUnidadMedida() {
    let User = Cookies.get('IdUser');
    let IdTipoUnidadMedida = Cookies.get('IdEdit');
    let NombreTipoUnidadMedida = $('#InputENombreTipoUnidadMedida').val();
    let Activo = $('#SelectEstadoTipoUnidadMedida').val();
    if (NombreTipoUnidadMedida == '' || NombreTipoUnidadMedida == null || NombreTipoUnidadMedida == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre del tipo unidad medida', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/TipoUnidadMedida/GuardarCambiosTipoUnidadMedida',
            data: { IdTipoUnidadMedida: IdTipoUnidadMedida, IdUser: User, NombreTipoUnidadMedida: NombreTipoUnidadMedida, Activo: Activo },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/TipoUnidadMedida';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function EliminarTipoUnidadMedida() {
    let IdUser = Cookies.get('IdUser');
    let IdTipoUnidadMedida = $('#IdTipoUnidadMedida').text();
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/TipoUnidadMedida/EliminarTipoUnidadMedida',
        data: {
            IdUser: IdUser,
            IdTipoUnidadMedida: IdTipoUnidadMedida
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

function CargarDatosTipoUnidadMedida() {
    let IdTipoUnidadMedida = Cookies.get('IdEdit');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/TipoUnidadMedida/CargarDatosTipoUnidadMedida',
        data: { IdTipoUnidadMedida: IdTipoUnidadMedida },
        success: function (resultado) {
            $('#InputENombreTipoUnidadMedida').val(resultado[0].Nombre);
            $('#SelectEstadoTipoUnidadMedida').val(resultado[0].Activo);

        }
    });
}

function ListaTipoUnidadMedida(Tipo) {
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/TipoUnidadMedida/ListaTipoUnidadMedida',
        data: {},
        success: function (resultado) {
            var contador = 0;
            if (Tipo == "N") {
                if (resultado.length === 0) {
                    $("#SelectTipoUnidadMedida").append('<option value="">No hay Datos</option>');
                } else {
                    $("#SelectTipoUnidadMedida").empty().append('<option value="-1">Seleccione tipo unidad medida</option>');
                    $.each(resultado, function () {
                        $("#SelectTipoUnidadMedida").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                        contador++;
                    });
                }
            } else {
                $.each(resultado, function () {
                    $("#SelectETipoUnidadMedida").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                    contador++;
                });
            }
        },
    });
}

function GridTipoUnidadMedida() {
    let datatable = $('#gridTipoUnidadMedida').DataTable({
        "responsive": true,
        dom: 'B<"clear">frtip',
        buttons: [{
            extend: 'excelHtml5',
            footer: true,
            title: 'Lista de TipoUnidadMedidaes',
            filename: 'Lista de TipoUnidadMedidaes',
            text: 'Excel',
            exportOptions: {
                columns: [1, 2, 3, 4]
            }
        },
        {
            extend: 'pdfHtml5',
            download: 'open',
            footer: true,
            title: 'Lista de TipoUnidadMedidaes',
            filename: 'Lista de TipoUnidadMedidaes',
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
            "url": '/TipoUnidadMedida/GridTipoUnidadMedida',
            "type": "GET",
            "datatype": "json"
        },
        columns: [
            { "data": "Id", title: "Id", "visible": false },
            { "data": "Nombre", title: "Unidad Medida" },
            { "data": "Estado", title: "Estado" },
            { "data": "CreateBy", title: "Creado por" },
            { "data": "DateCreate", title: "Fecha Creación" },
            {
                title: "Editar",
                data: null,
                defaultContent: '<a href="#" class="EditarTipoUnidadMedida" title="Editar"><i class="bi-pencil-fill" style="Color:green"></i></a>',
                className: '',
                orderable: false,
                width: 50,
            },
            {
                title: "Eliminar",
                data: null,
                defaultContent: '<a href="#" class="EliminarTipoUnidadMedida" title="Eliminar"><i class="bi-trash-fill" style="Color:red"></i></a>',
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
    $('#gridTipoUnidadMedida').on('click', '.EditarTipoUnidadMedida', function () {
        let data = datatable.row($(this).parents()).data();
        Cookies.set('IdEdit', data.Id);
        window.location = "/TipoUnidadMedida/Editar_TipoUnidadMedida";
    });


    $('#gridTipoUnidadMedida').on('click', '.EliminarTipoUnidadMedida', function () {
        let data = datatable.row($(this).parents()).data();
        $('#ModalEliminarTipoUnidadMedida').modal('show');
        $('#IdTipoUnidadMedida').text(data.Id);
        $('#MensajeEliminarTipoUnidadMedida').text('Esta seguro de eliminar el tipo unidad medida ' + data.Nombre + ' ?');
    })
}



