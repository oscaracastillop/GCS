function CrearTipoGenero() {
    let User = Cookies.get('IdUser');
    let NombreTipoGenero = $('#InputNombreTipoGenero').val()
    if (NombreTipoGenero == null || NombreTipoGenero == '' || NombreTipoGenero == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre del tipo género', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/TipoGenero/CrearTipoGenero',
            data: { IdUser: User, NombreTipoGenero: NombreTipoGenero },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/TipoGenero';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function GuardarCambiosTipoGenero() {
    let User = Cookies.get('IdUser');
    let IdTipoGenero = Cookies.get('IdEdit');
    let NombreTipoGenero = $('#InputENombreTipoGenero').val();
    let Activo = $('#SelectEstadoTipoGenero').val();
    if (NombreTipoGenero == '' || NombreTipoGenero == null || NombreTipoGenero == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre del tipo género', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/TipoGenero/GuardarCambiosTipoGenero',
            data: { IdTipoGenero: IdTipoGenero, IdUser: User, NombreTipoGenero: NombreTipoGenero, Activo: Activo },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/TipoGenero';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function EliminarTipoGenero() {
    let IdUser = Cookies.get('IdUser');
    let IdTipoGenero = $('#IdTipoGenero').text();
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/TipoGenero/EliminarTipoGenero',
        data: {
            IdUser: IdUser,
            IdTipoGenero: IdTipoGenero
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

function CargarDatosTipoGenero() {
    let IdTipoGenero = Cookies.get('IdEdit');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/TipoGenero/CargarDatosTipoGenero',
        data: { IdTipoGenero: IdTipoGenero },
        success: function (resultado) {
            $('#InputENombreTipoGenero').val(resultado[0].Nombre);
            $('#SelectEstadoTipoGenero').val(resultado[0].Activo);

        }
    });
}

function ListaTipoGenero(Tipo) {
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/TipoGenero/ListaTipoGenero',
        data: {},
        success: function (resultado) {
            var contador = 0;
            if (Tipo == "N") {
                if (resultado.length === 0) {
                    $("#SelectTipoGenero").append('<option value="">No hay Datos</option>');
                } else {
                    $("#SelectTipoGenero").empty().append('<option value="-1">Seleccione Sexo</option>');
                    $.each(resultado, function () {
                        $("#SelectTipoGenero").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                        contador++;
                    });
                }
            } else {
                $.each(resultado, function () {
                    $("#SelectETipoGenero").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                    contador++;
                });
            }
        },
    });
}

function GridTipoGenero() {
    let datatable = $('#gridTipoGenero').DataTable({
        "responsive": true,
        dom: 'B<"clear">frtip',
        buttons: [{
            extend: 'excelHtml5',
            footer: true,
            title: 'Lista de Tipo Genero',
            filename: 'Lista de Tipo Genero',
            text: 'Excel',
            exportOptions: {
                columns: [1, 2, 3, 4]
            }
        },
        {
            extend: 'pdfHtml5',
            download: 'open',
            footer: true,
            title: 'Lista de Tipo Genero',
            filename: 'Lista de Tipo Genero',
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
            "url": '/TipoGenero/GridTipoGenero',
            "type": "GET",
            "datatype": "json"
        },
        columns: [
            { "data": "Id", title: "Id", "visible": false },
            { "data": "Nombre", title: "Género" },
            { "data": "Estado", title: "Estado" },
            { "data": "CreateBy", title: "Creado por" },
            { "data": "DateCreate", title: "Fecha Creación" },
            {
                title: "Editar",
                data: null,
                defaultContent: '<a href="#" class="EditarTipoGenero" title="Editar"><i class="bi-pencil-fill" style="Color:green"></i></a>',
                className: '',
                orderable: false,
                width: 50,
            },
            {
                title: "Eliminar",
                data: null,
                defaultContent: '<a href="#" class="EliminarTipoGenero" title="Eliminar"><i class="bi-trash-fill" style="Color:red"></i></a>',
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
    $('#gridTipoGenero').on('click', '.EditarTipoGenero', function () {
        let data = datatable.row($(this).parents()).data();
        Cookies.set('IdEdit', data.Id);
        window.location = "/TipoGenero/Editar_TipoGenero";
    });


    $('#gridTipoGenero').on('click', '.EliminarTipoGenero', function () {
        let data = datatable.row($(this).parents()).data();
        $('#ModalEliminarTipoGenero').modal('show');
        $('#IdTipoGenero').text(data.Id);
        $('#MensajeEliminarTipoGenero').text('Esta seguro de eliminar el tipo genero ' + data.Nombre + ' ?');
    })
}



