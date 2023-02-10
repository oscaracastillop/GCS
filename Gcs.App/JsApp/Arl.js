function CrearArl() {
    let User = Cookies.get('IdUser');
    let NombreArl = $('#InputNombreArl').val();
    let Email = $('#InputEmailArl').val();
    let Telefono = $('#InputTelefonoArl').val();
    if (NombreArl == null || NombreArl == '' || NombreArl == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre de la arl', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/Arl/CrearArl',
            data: { IdUser: User, NombreArl: NombreArl, Email: Email, Telefono: Telefono },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/Arl';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function GuardarCambiosArl() {
    let User = Cookies.get('IdUser');
    let IdArl = Cookies.get('IdEdit');
    let NombreArl = $('#InputENombreArl').val();
    let Email = $('#InputEEmailArl').val();
    let Telefono = $('#InputETelefonoArl').val();
    let Activo = $('#SelectEstadoArl').val();
    if (NombreArl == '' || NombreArl == null || NombreArl == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre de la arl', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/Arl/GuardarCambiosArl',
            data: { IdArl: IdArl, IdUser: User, NombreArl: NombreArl, Email: Email, Telefono: Telefono, Activo: Activo },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/Arl';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function EliminarArl() {
    let IdUser = Cookies.get('IdUser');
    let IdArl = $('#IdArl').text();
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Arl/EliminarArl',
        data: {
            IdUser: IdUser,
            IdArl: IdArl
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

function CargarDatosArl() {
    let IdArl = Cookies.get('IdEdit');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Arl/CargarDatosArl',
        data: { IdArl: IdArl },
        success: function (resultado) {
            $('#InputENombreArl').val(resultado[0].Nombre);
            $('#InputEEmailArl').val(resultado[0].Email);
            $('#InputETelefonoArl').val(resultado[0].Telefono);
            $('#SelectEstadoArl').val(resultado[0].Activo);            
        }
    });
}

function ListaArl(Tipo) {
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Arl/ListaArl',
        data: {},
        success: function (resultado) {
            var contador = 0;
            if (Tipo == "N") {
                if (resultado.length === 0) {
                    $("#SelectArl").append('<option value="">No hay Datos</option>');
                } else {
                    $("#SelectArl").empty().append('<option value="-1">Seleccione arl</option>');
                    $.each(resultado, function () {
                        $("#SelectArl").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                        contador++;
                    });
                }
            } else {
                $.each(resultado, function () {
                    $("#SelectEArl").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                    contador++;
                });
            }
        },
    });
}

function GridArl() {
    let datatable = $('#gridArl').DataTable({
        "responsive": true,
        dom: 'B<"clear">frtip',
        buttons: [{
            extend: 'excelHtml5',
            footer: true,
            title: 'Lista de Arl',
            filename: 'Lista de Arl',
            text: 'Excel',
            exportOptions: {
                columns: [1, 2, 3, 4, 5, 6]
            }
        },
        {
            extend: 'pdfHtml5',
            download: 'open',
            footer: true,
            title: 'Lista de Arl',
            filename: 'Lista de Arl',
            text: 'Pdf',
            exportOptions: {
                columns: [1, 2, 3, 4, 5, 6]
            }
        },
        {
            extend: 'print',
            footer: true,
            filename: 'Export_File_print',
            text: 'Imprimir',
            exportOptions: {
                columns: [1, 2, 3, 4, 5, 6]
            }
        },
        ],
        "order": [[1, "asc"]],
        destroy: true,
        "ajax": {
            "url": '/Arl/GridArl',
            "type": "GET",
            "datatype": "json"
        },
        columns: [
            { "data": "Id", title: "Id", "visible": false },
            { "data": "Nombre", title: "Arl" },            
            { "data": "Email", title: "Email" },
            { "data": "Telefono", title: "Teléfono" },
            { "data": "Estado", title: "Estado" },
            { "data": "CreateBy", title: "Creado por" },
            { "data": "DateCreate", title: "Fecha Creación" },
            {
                title: "Editar",
                data: null,
                defaultContent: '<a href="#" class="EditarArl" title="Editar"><i class="bi-pencil-fill" style="Color:green"></i></a>',
                className: '',
                orderable: false,
                width: 50,
            },
            {
                title: "Eliminar",
                data: null,
                defaultContent: '<a href="#" class="EliminarArl" title="Eliminar"><i class="bi-trash-fill" style="Color:red"></i></a>',
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
    $('#gridArl').on('click', '.EditarArl', function () {
        let data = datatable.row($(this).parents()).data();
        Cookies.set('IdEdit', data.Id);
        window.location = "/Arl/Editar_Arl";
    });


    $('#gridArl').on('click', '.EliminarArl', function () {
        let data = datatable.row($(this).parents()).data();
        $('#ModalEliminarArl').modal('show');
        $('#IdArl').text(data.Id);
        $('#MensajeEliminarArl').text('Esta seguro de eliminar la arl ' + data.Nombre + ' ?');
    })
}



