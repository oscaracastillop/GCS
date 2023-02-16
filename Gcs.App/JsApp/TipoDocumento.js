function CrearTipoDocumento() {
    let User = Cookies.get('IdUser');
    let NombreTipoDocumento = $('#InputNombreTipoDocumento').val()
    if (NombreTipoDocumento == null || NombreTipoDocumento == '' || NombreTipoDocumento == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre del tipo documento', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/TipoDocumento/CrearTipoDocumento',
            data: { IdUser: User, NombreTipoDocumento: NombreTipoDocumento },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/TipoDocumento';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function GuardarCambiosTipoDocumento() {
    let User = Cookies.get('IdUser');
    let IdTipoDocumento = Cookies.get('IdEdit');
    let NombreTipoDocumento = $('#InputENombreTipoDocumento').val();
    let Activo = $('#SelectEstadoTipoDocumento').val();
    if (NombreTipoDocumento == '' || NombreTipoDocumento == null || NombreTipoDocumento == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre del tipo documento', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/TipoDocumento/GuardarCambiosTipoDocumento',
            data: { IdTipoDocumento: IdTipoDocumento, IdUser: User, NombreTipoDocumento: NombreTipoDocumento, Activo: Activo },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/TipoDocumento';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function EliminarTipoDocumento() {
    let IdUser = Cookies.get('IdUser');
    let IdTipoDocumento = $('#IdTipoDocumento').text();
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/TipoDocumento/EliminarTipoDocumento',
        data: {
            IdUser: IdUser,
            IdTipoDocumento: IdTipoDocumento
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

function CargarDatosTipoDocumento() {
    let IdTipoDocumento = Cookies.get('IdEdit');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/TipoDocumento/CargarDatosTipoDocumento',
        data: { IdTipoDocumento: IdTipoDocumento },
        success: function (resultado) {
            $('#InputENombreTipoDocumento').val(resultado[0].Nombre);
            $('#SelectEstadoTipoDocumento').val(resultado[0].Activo);

        }
    });
}

function ListaTipoDocumento(Tipo) {
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/TipoDocumento/ListaTipoDocumento',
        data: {},
        success: function (resultado) {
            var contador = 0;
            if (Tipo == "N") {
                if (resultado.length === 0) {
                    $("#SelectTipoDocumento").append('<option value="">No hay Datos</option>');
                } else {
                    $("#SelectTipoDocumento").empty().append('<option value="-1">Seleccione documento</option>');
                    $.each(resultado, function () {
                        $("#SelectTipoDocumento").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                        contador++;
                    });
                }
            } else {
                $.each(resultado, function () {
                    $("#SelectETipoDocumento").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                    contador++;
                });
            }
        },
    });
}

function GridTipoDocumento() {
    let datatable = $('#gridTipoDocumento').DataTable({
        "responsive": true,
        dom: 'B<"clear">frtip',
        buttons: [{
            extend: 'excelHtml5',
            footer: true,
            title: 'Lista de Tipo Documento',
            filename: 'Listado Tipo Documento',
            text: 'Excel',
            exportOptions: {
                columns: [1, 2, 3, 4]
            }
        },
        {
            extend: 'pdfHtml5',
            download: 'open',
            footer: true,
            title: 'Listado Tipo Documento',
            filename: 'Listado Tipo Documento',
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
            "url": '/TipoDocumento/GridTipoDocumento',
            "type": "GET",
            "datatype": "json"
        },
        columns: [
            { "data": "Id", title: "Id", "visible": false },
            { "data": "Nombre", title: "Tipo Documento" },
            { "data": "Estado", title: "Estado" },
            { "data": "CreateBy", title: "Creado por" },
            { "data": "DateCreate", title: "Fecha Creación" },
            {
                title: "Editar",
                data: null,
                defaultContent: '<a href="#" class="EditarTipoDocumento" title="Editar"><i class="bi-pencil-fill" style="Color:green"></i></a>',
                className: '',
                orderable: false,
                width: 50,
            },
            {
                title: "Eliminar",
                data: null,
                defaultContent: '<a href="#" class="EliminarTipoDocumento" title="Eliminar"><i class="bi-trash-fill" style="Color:red"></i></a>',
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
    $('#gridTipoDocumento').on('click', '.EditarTipoDocumento', function () {
        let data = datatable.row($(this).parents()).data();
        Cookies.set('IdEdit', data.Id);
        window.location = "/TipoDocumento/Editar_TipoDocumento";
    });


    $('#gridTipoDocumento').on('click', '.EliminarTipoDocumento', function () {
        let data = datatable.row($(this).parents()).data();
        $('#ModalEliminarTipoDocumento').modal('show');
        $('#IdTipoDocumento').text(data.Id);
        $('#MensajeEliminarTipoDocumento').text('Esta seguro de eliminar el tipo documento ' + data.Nombre + ' ?');
    })
}



