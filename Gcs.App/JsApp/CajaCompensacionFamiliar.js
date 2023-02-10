function CrearCajaCompensacionFamiliar() {
    let User = Cookies.get('IdUser');
    let NombreCajaCompensacionFamiliar = $('#InputNombreCajaCompensacionFamiliar').val();
    let Email = $('#InputEmailCajaCompensacionFamiliar').val();
    let Telefono = $('#InputTelefonoCajaCompensacionFamiliar').val();
    if (NombreCajaCompensacionFamiliar == null || NombreCajaCompensacionFamiliar == '' || NombreCajaCompensacionFamiliar == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre de la caja compensación familiar', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/CajaCompensacionFamiliar/CrearCajaCompensacionFamiliar',
            data: { IdUser: User, NombreCajaCompensacionFamiliar: NombreCajaCompensacionFamiliar, Email: Email, Telefono: Telefono },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/CajaCompensacionFamiliar';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function GuardarCambiosCajaCompensacionFamiliar() {
    let User = Cookies.get('IdUser');
    let IdCajaCompensacionFamiliar = Cookies.get('IdEdit');
    let NombreCajaCompensacionFamiliar = $('#InputENombreCajaCompensacionFamiliar').val();
    let Email = $('#InputEEmailCajaCompensacionFamiliar').val();
    let Telefono = $('#InputETelefonoCajaCompensacionFamiliar').val();
    let Activo = $('#SelectEstadoCajaCompensacionFamiliar').val();
    if (NombreCajaCompensacionFamiliar == '' || NombreCajaCompensacionFamiliar == null || NombreCajaCompensacionFamiliar == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre de la caja compensación familiar', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/CajaCompensacionFamiliar/GuardarCambiosCajaCompensacionFamiliar',
            data: { IdCajaCompensacionFamiliar: IdCajaCompensacionFamiliar, IdUser: User, NombreCajaCompensacionFamiliar: NombreCajaCompensacionFamiliar, Email: Email, Telefono: Telefono, Activo: Activo },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/CajaCompensacionFamiliar';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function EliminarCajaCompensacionFamiliar() {
    let IdUser = Cookies.get('IdUser');
    let IdCajaCompensacionFamiliar = $('#IdCajaCompensacionFamiliar').text();
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/CajaCompensacionFamiliar/EliminarCajaCompensacionFamiliar',
        data: {
            IdUser: IdUser,
            IdCajaCompensacionFamiliar: IdCajaCompensacionFamiliar
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

function CargarDatosCajaCompensacionFamiliar() {
    let IdCajaCompensacionFamiliar = Cookies.get('IdEdit');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/CajaCompensacionFamiliar/CargarDatosCajaCompensacionFamiliar',
        data: { IdCajaCompensacionFamiliar: IdCajaCompensacionFamiliar },
        success: function (resultado) {
            $('#InputENombreCajaCompensacionFamiliar').val(resultado[0].Nombre);
            $('#InputEEmailCajaCompensacionFamiliar').val(resultado[0].Email);
            $('#InputETelefonoCajaCompensacionFamiliar').val(resultado[0].Telefono);
            $('#SelectEstadoCajaCompensacionFamiliar').val(resultado[0].Activo);
        }
    });
}

function ListaCajaCompensacionFamiliar(Tipo) {
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/CajaCompensacionFamiliar/ListaCajaCompensacionFamiliar',
        data: {},
        success: function (resultado) {
            var contador = 0;
            if (Tipo == "N") {
                if (resultado.length === 0) {
                    $("#SelectCajaCompensacionFamiliar").append('<option value="">No hay Datos</option>');
                } else {
                    $("#SelectCajaCompensacionFamiliar").empty().append('<option value="-1">Seleccione CajaCompensacionFamiliar</option>');
                    $.each(resultado, function () {
                        $("#SelectCajaCompensacionFamiliar").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                        contador++;
                    });
                }
            } else {
                $.each(resultado, function () {
                    $("#SelectECajaCompensacionFamiliar").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                    contador++;
                });
            }
        },
    });
}

function GridCajaCompensacionFamiliar() {
    let datatable = $('#gridCajaCompensacionFamiliar').DataTable({
        "responsive": true,
        dom: 'B<"clear">frtip',
        buttons: [{
            extend: 'excelHtml5',
            footer: true,
            title: 'Lista de Caja Compensación Familiar',
            filename: 'Lista de Caja Compensación Familiar',
            text: 'Excel',
            exportOptions: {
                columns: [1, 2, 3, 4, 5, 6]
            }
        },
        {
            extend: 'pdfHtml5',
            download: 'open',
            footer: true,
            title: 'Lista de Caja Compensación Familiar',
            filename: 'Lista de Caja Compensación Familiar',
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
            "url": '/CajaCompensacionFamiliar/GridCajaCompensacionFamiliar',
            "type": "GET",
            "datatype": "json"
        },
        columns: [
            { "data": "Id", title: "Id", "visible": false },
            { "data": "Nombre", title: "CajaCompensacionFamiliar" },
            { "data": "Estado", title: "Estado" },
            { "data": "Email", title: "Email" },
            { "data": "Telefono", title: "Teléfono" },
            { "data": "CreateBy", title: "Creado por" },
            { "data": "DateCreate", title: "Fecha Creación" },
            {
                title: "Editar",
                data: null,
                defaultContent: '<a href="#" class="EditarCajaCompensacionFamiliar" title="Editar"><i class="bi-pencil-fill" style="Color:green"></i></a>',
                className: '',
                orderable: false,
                width: 50,
            },
            {
                title: "Eliminar",
                data: null,
                defaultContent: '<a href="#" class="EliminarCajaCompensacionFamiliar" title="Eliminar"><i class="bi-trash-fill" style="Color:red"></i></a>',
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
    $('#gridCajaCompensacionFamiliar').on('click', '.EditarCajaCompensacionFamiliar', function () {
        let data = datatable.row($(this).parents()).data();
        Cookies.set('IdEdit', data.Id);
        window.location = "/CajaCompensacionFamiliar/Editar_CajaCompensacionFamiliar";
    });


    $('#gridCajaCompensacionFamiliar').on('click', '.EliminarCajaCompensacionFamiliar', function () {
        let data = datatable.row($(this).parents()).data();
        $('#ModalEliminarCajaCompensacionFamiliar').modal('show');
        $('#IdCajaCompensacionFamiliar').text(data.Id);
        $('#MensajeEliminarCajaCompensacionFamiliar').text('Esta seguro de eliminar la caja compensación familiar ' + data.Nombre + ' ?');
    })
}



