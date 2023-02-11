function CrearTipoFormaPago() {
    let User = Cookies.get('IdUser');
    let NombreTipoFormaPago = $('#InputNombreTipoFormaPago').val()
    if (NombreTipoFormaPago == null || NombreTipoFormaPago == '' || NombreTipoFormaPago == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre del tipo forma pago', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/TipoFormaPago/CrearTipoFormaPago',
            data: { IdUser: User, NombreTipoFormaPago: NombreTipoFormaPago },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/TipoFormaPago';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function GuardarCambiosTipoFormaPago() {
    let User = Cookies.get('IdUser');
    let IdTipoFormaPago = Cookies.get('IdEdit');
    let NombreTipoFormaPago = $('#InputENombreTipoFormaPago').val();
    let Activo = $('#SelectEstadoTipoFormaPago').val();
    if (NombreTipoFormaPago == '' || NombreTipoFormaPago == null || NombreTipoFormaPago == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre del tipo forma pago', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/TipoFormaPago/GuardarCambiosTipoFormaPago',
            data: { IdTipoFormaPago: IdTipoFormaPago, IdUser: User, NombreTipoFormaPago: NombreTipoFormaPago, Activo: Activo },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/TipoFormaPago';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function EliminarTipoFormaPago() {
    let IdUser = Cookies.get('IdUser');
    let IdTipoFormaPago = $('#IdTipoFormaPago').text();
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/TipoFormaPago/EliminarTipoFormaPago',
        data: {
            IdUser: IdUser,
            IdTipoFormaPago: IdTipoFormaPago
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

function CargarDatosTipoFormaPago() {
    let IdTipoFormaPago = Cookies.get('IdEdit');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/TipoFormaPago/CargarDatosTipoFormaPago',
        data: { IdTipoFormaPago: IdTipoFormaPago },
        success: function (resultado) {
            $('#InputENombreTipoFormaPago').val(resultado[0].Nombre);
            $('#SelectEstadoTipoFormaPago').val(resultado[0].Activo);

        }
    });
}

function ListaTipoFormaPago(Tipo) {
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/TipoFormaPago/ListaTipoFormaPago',
        data: {},
        success: function (resultado) {
            var contador = 0;
            if (Tipo == "N") {
                if (resultado.length === 0) {
                    $("#SelectTipoFormaPago").append('<option value="">No hay Datos</option>');
                } else {
                    $("#SelectTipoFormaPago").empty().append('<option value="-1">Seleccione TipoFormaPago</option>');
                    $.each(resultado, function () {
                        $("#SelectTipoFormaPago").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                        contador++;
                    });
                }
            } else {
                $.each(resultado, function () {
                    $("#SelectETipoFormaPago").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                    contador++;
                });
            }
        },
    });
}

function GridTipoFormaPago() {
    let datatable = $('#gridTipoFormaPago').DataTable({
        "responsive": true,
        dom: 'B<"clear">frtip',
        buttons: [{
            extend: 'excelHtml5',
            footer: true,
            title: 'Lista de Tipo Forma Pago',
            filename: 'Lista de Tipo Forma Pago',
            text: 'Excel',
            exportOptions: {
                columns: [1, 2, 3, 4]
            }
        },
        {
            extend: 'pdfHtml5',
            download: 'open',
            footer: true,
            title: 'Lista de Tipo Forma Pago',
            filename: 'Lista de Tipo Forma Pago',
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
            "url": '/TipoFormaPago/GridTipoFormaPago',
            "type": "GET",
            "datatype": "json"
        },
        columns: [
            { "data": "Id", title: "Id", "visible": false },
            { "data": "Nombre", title: "Forma Pago" },
            { "data": "Estado", title: "Estado" },
            { "data": "CreateBy", title: "Creado por" },
            { "data": "DateCreate", title: "Fecha Creación" },
            {
                title: "Editar",
                data: null,
                defaultContent: '<a href="#" class="EditarTipoFormaPago" title="Editar"><i class="bi-pencil-fill" style="Color:green"></i></a>',
                className: '',
                orderable: false,
                width: 50,
            },
            {
                title: "Eliminar",
                data: null,
                defaultContent: '<a href="#" class="EliminarTipoFormaPago" title="Eliminar"><i class="bi-trash-fill" style="Color:red"></i></a>',
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
    $('#gridTipoFormaPago').on('click', '.EditarTipoFormaPago', function () {
        let data = datatable.row($(this).parents()).data();
        Cookies.set('IdEdit', data.Id);
        window.location = "/TipoFormaPago/Editar_TipoFormaPago";
    });


    $('#gridTipoFormaPago').on('click', '.EliminarTipoFormaPago', function () {
        let data = datatable.row($(this).parents()).data();
        $('#ModalEliminarTipoFormaPago').modal('show');
        $('#IdTipoFormaPago').text(data.Id);
        $('#MensajeEliminarTipoFormaPago').text('Esta seguro de eliminar la forma pago ' + data.Nombre + ' ?');
    })
}



