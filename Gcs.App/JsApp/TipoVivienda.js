function CrearTipoVivienda() {
    let User = Cookies.get('IdUser');
    let NombreTipoVivienda = $('#InputNombreTipoVivienda').val()
    if (NombreTipoVivienda == null || NombreTipoVivienda == '' || NombreTipoVivienda == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre del Tipo Vivienda', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/TipoVivienda/CrearTipoVivienda',
            data: { IdUser: User, NombreTipoVivienda: NombreTipoVivienda },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/TipoVivienda';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function GuardarCambiosTipoVivienda() {
    let User = Cookies.get('IdUser');
    let IdTipoVivienda = Cookies.get('IdEdit');
    let NombreTipoVivienda = $('#InputENombreTipoVivienda').val();
    let Activo = $('#SelectEstadoTipoVivienda').val();
    if (NombreTipoVivienda == '' || NombreTipoVivienda == null || NombreTipoVivienda == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre del Tipo Vivienda', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/TipoVivienda/GuardarCambiosTipoVivienda',
            data: { IdTipoVivienda: IdTipoVivienda, IdUser: User, NombreTipoVivienda: NombreTipoVivienda, Activo: Activo },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/TipoVivienda';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function EliminarTipoVivienda() {
    let IdUser = Cookies.get('IdUser');
    let IdTipoVivienda = $('#IdTipoVivienda').text();
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/TipoVivienda/EliminarTipoVivienda',
        data: {
            IdUser: IdUser,
            IdTipoVivienda: IdTipoVivienda
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

function CargarDatosTipoVivienda() {
    let IdTipoVivienda = Cookies.get('IdEdit');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/TipoVivienda/CargarDatosTipoVivienda',
        data: { IdTipoVivienda: IdTipoVivienda },
        success: function (resultado) {
            $('#InputENombreTipoVivienda').val(resultado[0].Nombre);
            $('#SelectEstadoTipoVivienda').val(resultado[0].Activo);

        }
    });
}

function ListaTipoVivienda(Tipo) {
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/TipoVivienda/ListaTipoVivienda',
        data: {},
        success: function (resultado) {
            var contador = 0;
            if (Tipo == "N") {
                if (resultado.length === 0) {
                    $("#SelectTipoVivienda").append('<option value="">No hay Datos</option>');
                } else {
                    $("#SelectTipoVivienda").empty().append('<option value="-1">Seleccione Vivienda</option>');
                    $.each(resultado, function () {
                        $("#SelectTipoVivienda").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                        contador++;
                    });
                }
            } else {
                $.each(resultado, function () {
                    $("#SelectETipoVivienda").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                    contador++;
                });
            }
        },
    });
}

function GridTipoVivienda() {
    let datatable = $('#gridTipoVivienda').DataTable({
        "responsive": true,
        dom: 'B<"clear">frtip',
        buttons: [{
            extend: 'excelHtml5',
            footer: true,
            title: 'Lista de Tipo Vivienda',
            filename: 'Listado Tipo Vivienda',
            text: 'Excel',
            exportOptions: {
                columns: [1, 2, 3, 4]
            }
        },
        {
            extend: 'pdfHtml5',
            download: 'open',
            footer: true,
            title: 'Listado Tipo Vivienda',
            filename: 'Listado Tipo Vivienda',
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
            "url": '/TipoVivienda/GridTipoVivienda',
            "type": "GET",
            "datatype": "json"
        },
        columns: [
            { "data": "Id", title: "Id", "visible": false },
            { "data": "Nombre", title: "Tipo Vivienda" },
            { "data": "Estado", title: "Estado" },
            { "data": "CreateBy", title: "Creado por" },
            { "data": "DateCreate", title: "Fecha Creación" },
            {
                title: "Editar",
                data: null,
                defaultContent: '<a href="#" class="EditarTipoVivienda" title="Editar"><i class="bi-pencil-fill" style="Color:green"></i></a>',
                className: '',
                orderable: false,
                width: 50,
            },
            {
                title: "Eliminar",
                data: null,
                defaultContent: '<a href="#" class="EliminarTipoVivienda" title="Eliminar"><i class="bi-trash-fill" style="Color:red"></i></a>',
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
    $('#gridTipoVivienda').on('click', '.EditarTipoVivienda', function () {
        let data = datatable.row($(this).parents()).data();
        Cookies.set('IdEdit', data.Id);
        window.location = "/TipoVivienda/Editar_TipoVivienda";
    });


    $('#gridTipoVivienda').on('click', '.EliminarTipoVivienda', function () {
        let data = datatable.row($(this).parents()).data();
        $('#ModalEliminarTipoVivienda').modal('show');
        $('#IdTipoVivienda').text(data.Id);
        $('#MensajeEliminarTipoVivienda').text('Esta seguro de eliminar el Tipo Vivienda ' + data.Nombre + ' ?');
    })
}



