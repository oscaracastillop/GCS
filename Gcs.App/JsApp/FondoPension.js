function CrearFondoPension() {
    let User = Cookies.get('IdUser');
    let NombreFondoPension = $('#InputNombreFondoPension').val();
    let Email = $('#InputEmailFondoPension').val();
    let Telefono = $('#InputTelefonoFondoPension').val();
    if (NombreFondoPension == null || NombreFondoPension == '' || NombreFondoPension == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre de el fondo pensión', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/FondoPension/CrearFondoPension',
            data: { IdUser: User, NombreFondoPension: NombreFondoPension, Email: Email, Telefono: Telefono },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/FondoPension';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function GuardarCambiosFondoPension() {
    let User = Cookies.get('IdUser');
    let IdFondoPension = Cookies.get('IdEdit');
    let NombreFondoPension = $('#InputENombreFondoPension').val();
    let Email = $('#InputEEmailFondoPension').val();
    let Telefono = $('#InputETelefonoFondoPension').val();
    let Activo = $('#SelectEstadoFondoPension').val();
    if (NombreFondoPension == '' || NombreFondoPension == null || NombreFondoPension == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre de el fondo pensión', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/FondoPension/GuardarCambiosFondoPension',
            data: { IdFondoPension: IdFondoPension, IdUser: User, NombreFondoPension: NombreFondoPension, Email: Email, Telefono: Telefono, Activo: Activo },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/FondoPension';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function EliminarFondoPension() {
    let IdUser = Cookies.get('IdUser');
    let IdFondoPension = $('#IdFondoPension').text();
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/FondoPension/EliminarFondoPension',
        data: {
            IdUser: IdUser,
            IdFondoPension: IdFondoPension
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

function CargarDatosFondoPension() {
    let IdFondoPension = Cookies.get('IdEdit');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/FondoPension/CargarDatosFondoPension',
        data: { IdFondoPension: IdFondoPension },
        success: function (resultado) {
            $('#InputENombreFondoPension').val(resultado[0].Nombre);
            $('#InputEEmailFondoPension').val(resultado[0].Email);
            $('#InputETelefonoFondoPension').val(resultado[0].Telefono);
            $('#SelectEstadoFondoPension').val(resultado[0].Activo);
        }
    });
}

function ListaFondoPension(Tipo) {
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/FondoPension/ListaFondoPension',
        data: {},
        success: function (resultado) {
            var contador = 0;
            if (Tipo == "N") {
                if (resultado.length === 0) {
                    $("#SelectFondoPension").append('<option value="">No hay Datos</option>');
                } else {
                    $("#SelectFondoPension").empty().append('<option value="-1">Seleccione FondoPension</option>');
                    $.each(resultado, function () {
                        $("#SelectFondoPension").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                        contador++;
                    });
                }
            } else {
                $.each(resultado, function () {
                    $("#SelectEFondoPension").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                    contador++;
                });
            }
        },
    });
}

function GridFondoPension() {
    let datatable = $('#gridFondoPension').DataTable({
        "responsive": true,
        dom: 'B<"clear">frtip',
        buttons: [{
            extend: 'excelHtml5',
            footer: true,
            title: 'Lista de Fondo Pensión',
            filename: 'Lista de Fondo Pensión',
            text: 'Excel',
            exportOptions: {
                columns: [1, 2, 3, 4, 5, 6]
            }
        },
        {
            extend: 'pdfHtml5',
            download: 'open',
            footer: true,
            title: 'Lista de Fondo Pensión',
            filename: 'Lista de Fondo Pensión',
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
            "url": '/FondoPension/GridFondoPension',
            "type": "GET",
            "datatype": "json"
        },
        columns: [
            { "data": "Id", title: "Id", "visible": false },
            { "data": "Nombre", title: "Fondo Pensión" },
            { "data": "Estado", title: "Estado" },
            { "data": "Email", title: "Email" },
            { "data": "Telefono", title: "Teléfono" },
            { "data": "CreateBy", title: "Creado por" },
            { "data": "DateCreate", title: "Fecha Creación" },
            {
                title: "Editar",
                data: null,
                defaultContent: '<a href="#" class="EditarFondoPension" title="Editar"><i class="bi-pencil-fill" style="Color:green"></i></a>',
                className: '',
                orderable: false,
                width: 50,
            },
            {
                title: "Eliminar",
                data: null,
                defaultContent: '<a href="#" class="EliminarFondoPension" title="Eliminar"><i class="bi-trash-fill" style="Color:red"></i></a>',
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
    $('#gridFondoPension').on('click', '.EditarFondoPension', function () {
        let data = datatable.row($(this).parents()).data();
        Cookies.set('IdEdit', data.Id);
        window.location = "/FondoPension/Editar_FondoPension";
    });


    $('#gridFondoPension').on('click', '.EliminarFondoPension', function () {
        let data = datatable.row($(this).parents()).data();
        $('#ModalEliminarFondoPension').modal('show');
        $('#IdFondoPension').text(data.Id);
        $('#MensajeEliminarFondoPension').text('Esta seguro de eliminar el fondo pensión ' + data.Nombre + ' ?');
    })
}



