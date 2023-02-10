function CrearEps() {
    let User = Cookies.get('IdUser');
    let NombreEps = $('#InputNombreEps').val()
    if (NombreEps == null || NombreEps == '' || NombreEps == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre de la eps', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/Eps/CrearEps',
            data: { IdUser: User, NombreEps: NombreEps },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/Eps';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function GuardarCambiosEps() {
    let User = Cookies.get('IdUser');
    let IdEps = Cookies.get('IdEdit');
    let NombreEps = $('#InputENombreEps').val();
    let Activo = $('#SelectEstadoEps').val();
    if (NombreEps == '' || NombreEps == null || NombreEps == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre de la eps', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/Eps/GuardarCambiosEps',
            data: { IdEps: IdEps, IdUser: User, NombreEps: NombreEps, Activo: Activo },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/Eps';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function EliminarEps() {
    let IdUser = Cookies.get('IdUser');
    let IdEps = $('#IdEps').text();
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Eps/EliminarEps',
        data: {
            IdUser: IdUser,
            IdEps: IdEps
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

function CargarDatosEps() {
    let IdEps = Cookies.get('IdEdit');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Eps/CargarDatosEps',
        data: { IdEps: IdEps },
        success: function (resultado) {
            $('#InputENombreEps').val(resultado[0].Nombre);
            $('#SelectEstadoEps').val(resultado[0].Activo);

        }
    });
}

function ListaEps(Tipo) {
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Eps/ListaEps',
        data: {},
        success: function (resultado) {
            var contador = 0;
            if (Tipo == "N") {
                if (resultado.length === 0) {
                    $("#SelectEps").append('<option value="">No hay Datos</option>');
                } else {
                    $("#SelectEps").empty().append('<option value="-1">Seleccione Eps</option>');
                    $.each(resultado, function () {
                        $("#SelectEps").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                        contador++;
                    });
                }
            } else {
                $.each(resultado, function () {
                    $("#SelectEEps").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                    contador++;
                });
            }
        },
    });
}

function GridEps() {
    let datatable = $('#gridEps').DataTable({
        "responsive": true,
        dom: 'B<"clear">frtip',
        buttons: [{
            extend: 'excelHtml5',
            footer: true,
            title: 'Lista de Eps',
            filename: 'Lista de Eps',
            text: 'Excel',
            exportOptions: {
                columns: [1, 2, 3, 4]
            }
        },
        {
            extend: 'pdfHtml5',
            download: 'open',
            footer: true,
            title: 'Lista de Eps',
            filename: 'Lista de Eps',
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
            "url": '/Eps/GridEps',
            "type": "GET",
            "datatype": "json"
        },
        columns: [
            { "data": "Id", title: "Id", "visible": false },
            { "data": "Nombre", title: "Eps" },
            { "data": "Estado", title: "Estado" },
            { "data": "CreateBy", title: "Creado por" },
            { "data": "DateCreate", title: "Fecha Creación" },
            {
                title: "Editar",
                data: null,
                defaultContent: '<a href="#" class="EditarEps" title="Editar"><i class="bi-pencil-fill" style="Color:green"></i></a>',
                className: '',
                orderable: false,
                width: 50,
            },
            {
                title: "Eliminar",
                data: null,
                defaultContent: '<a href="#" class="EliminarEps" title="Eliminar"><i class="bi-trash-fill" style="Color:red"></i></a>',
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
    $('#gridEps').on('click', '.EditarEps', function () {
        let data = datatable.row($(this).parents()).data();
        Cookies.set('IdEdit', data.Id);
        window.location = "/Eps/Editar_Eps";
    });


    $('#gridEps').on('click', '.EliminarEps', function () {
        let data = datatable.row($(this).parents()).data();
        $('#ModalEliminarEps').modal('show');
        $('#IdEps').text(data.Id);
        $('#MensajeEliminarEps').text('Esta seguro de eliminar la eps ' + data.Nombre + ' ?');
    })
}



