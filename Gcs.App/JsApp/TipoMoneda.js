function CrearTipoMoneda() {
    let User = Cookies.get('IdUser');
    let NombreTipoMoneda = $('#InputNombreTipoMoneda').val()
    if (NombreTipoMoneda == null || NombreTipoMoneda == '' || NombreTipoMoneda == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre del tipo moneda', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/TipoMoneda/CrearTipoMoneda',
            data: { IdUser: User, NombreTipoMoneda: NombreTipoMoneda },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/TipoMoneda';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function GuardarCambiosTipoMoneda() {
    let User = Cookies.get('IdUser');
    let IdTipoMoneda = Cookies.get('IdEdit');
    let NombreTipoMoneda = $('#InputENombreTipoMoneda').val();
    let Activo = $('#SelectEstadoTipoMoneda').val();
    if (NombreTipoMoneda == '' || NombreTipoMoneda == null || NombreTipoMoneda == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre del tipo moneda', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/TipoMoneda/GuardarCambiosTipoMoneda',
            data: { IdTipoMoneda: IdTipoMoneda, IdUser: User, NombreTipoMoneda: NombreTipoMoneda, Activo: Activo },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/TipoMoneda';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function EliminarTipoMoneda() {
    let IdUser = Cookies.get('IdUser');
    let IdTipoMoneda = $('#IdTipoMoneda').text();
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/TipoMoneda/EliminarTipoMoneda',
        data: {
            IdUser: IdUser,
            IdTipoMoneda: IdTipoMoneda
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

function CargarDatosTipoMoneda() {
    let IdTipoMoneda = Cookies.get('IdEdit');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/TipoMoneda/CargarDatosTipoMoneda',
        data: { IdTipoMoneda: IdTipoMoneda },
        success: function (resultado) {
            $('#InputENombreTipoMoneda').val(resultado[0].Nombre);
            $('#SelectEstadoTipoMoneda').val(resultado[0].Activo);

        }
    });
}

function ListaTipoMoneda(Tipo) {
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/TipoMoneda/ListaTipoMoneda',
        data: {},
        success: function (resultado) {
            var contador = 0;
            if (Tipo == "N") {
                if (resultado.length === 0) {
                    $("#SelectTipoMoneda").append('<option value="">No hay Datos</option>');
                } else {
                    $("#SelectTipoMoneda").empty().append('<option value="-1">Seleccione TipoMoneda</option>');
                    $.each(resultado, function () {
                        $("#SelectTipoMoneda").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                        contador++;
                    });
                }
            } else {
                $.each(resultado, function () {
                    $("#SelectETipoMoneda").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                    contador++;
                });
            }
        },
    });
}

function GridTipoMoneda() {
    let datatable = $('#gridTipoMoneda').DataTable({
        "responsive": true,
        dom: 'B<"clear">frtip',
        buttons: [{
            extend: 'excelHtml5',
            footer: true,
            title: 'Lista de Tipo Moneda',
            filename: 'Lista de Tipo Moneda',
            text: 'Excel',
            exportOptions: {
                columns: [1, 2, 3, 4]
            }
        },
        {
            extend: 'pdfHtml5',
            download: 'open',
            footer: true,
            title: 'Lista de Tipo Moneda',
            filename: 'Lista de Tipo Moneda',
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
            "url": '/TipoMoneda/GridTipoMoneda',
            "type": "GET",
            "datatype": "json"
        },
        columns: [
            { "data": "Id", title: "Id", "visible": false },
            { "data": "Nombre", title: "TipoMoneda" },
            { "data": "Estado", title: "Estado" },
            { "data": "CreateBy", title: "Creado por" },
            { "data": "DateCreate", title: "Fecha Creación" },
            {
                title: "Editar",
                data: null,
                defaultContent: '<a href="#" class="EditarTipoMoneda" title="Editar"><i class="bi-pencil-fill" style="Color:green"></i></a>',
                className: '',
                orderable: false,
                width: 50,
            },
            {
                title: "Eliminar",
                data: null,
                defaultContent: '<a href="#" class="EliminarTipoMoneda" title="Eliminar"><i class="bi-trash-fill" style="Color:red"></i></a>',
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
    $('#gridTipoMoneda').on('click', '.EditarTipoMoneda', function () {
        let data = datatable.row($(this).parents()).data();
        Cookies.set('IdEdit', data.Id);
        window.location = "/TipoMoneda/Editar_TipoMoneda";
    });


    $('#gridTipoMoneda').on('click', '.EliminarTipoMoneda', function () {
        let data = datatable.row($(this).parents()).data();
        $('#ModalEliminarTipoMoneda').modal('show');
        $('#IdTipoMoneda').text(data.Id);
        $('#MensajeEliminarTipoMoneda').text('Esta seguro de eliminar el tipo moneda ' + data.Nombre + ' ?');
    })
}
