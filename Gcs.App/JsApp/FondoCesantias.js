function CrearFondoCesantias() {
    let User = Cookies.get('IdUser');
    let NombreFondoCesantias = $('#InputNombreFondoCesantias').val();
    let Email = $('#InputEmailFondoCesantias').val();
    let Telefono = $('#InputTelefonoFondoCesantias').val();
    if (NombreFondoCesantias == null || NombreFondoCesantias == '' || NombreFondoCesantias == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre de el fondo de cesantías', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/FondoCesantias/CrearFondoCesantias',
            data: { IdUser: User, NombreFondoCesantias: NombreFondoCesantias, Email: Email, Telefono: Telefono },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/FondoCesantias';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function GuardarCambiosFondoCesantias() {
    let User = Cookies.get('IdUser');
    let IdFondoCesantias = Cookies.get('IdEdit');
    let NombreFondoCesantias = $('#InputENombreFondoCesantias').val();
    let Email = $('#InputEEmailFondoCesantias').val();
    let Telefono = $('#InputETelefonoFondoCesantias').val();
    let Activo = $('#SelectEstadoFondoCesantias').val();
    if (NombreFondoCesantias == '' || NombreFondoCesantias == null || NombreFondoCesantias == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre de el fondo de cesantías', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/FondoCesantias/GuardarCambiosFondoCesantias',
            data: { IdFondoCesantias: IdFondoCesantias, IdUser: User, NombreFondoCesantias: NombreFondoCesantias, Email: Email, Telefono: Telefono, Activo: Activo },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/FondoCesantias';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function EliminarFondoCesantias() {
    let IdUser = Cookies.get('IdUser');
    let IdFondoCesantias = $('#IdFondoCesantias').text();
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/FondoCesantias/EliminarFondoCesantias',
        data: {
            IdUser: IdUser,
            IdFondoCesantias: IdFondoCesantias
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

function CargarDatosFondoCesantias() {
    let IdFondoCesantias = Cookies.get('IdEdit');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/FondoCesantias/CargarDatosFondoCesantias',
        data: { IdFondoCesantias: IdFondoCesantias },
        success: function (resultado) {
            $('#InputENombreFondoCesantias').val(resultado[0].Nombre);
            $('#InputEEmailFondoCesantias').val(resultado[0].Email);
            $('#InputETelefonoFondoCesantias').val(resultado[0].Telefono);
            $('#SelectEstadoFondoCesantias').val(resultado[0].Activo);
        }
    });
}

function ListaFondoCesantias(Tipo) {
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/FondoCesantias/ListaFondoCesantias',
        data: {},
        success: function (resultado) {
            var contador = 0;
            if (Tipo == "N") {
                if (resultado.length === 0) {
                    $("#SelectFondoCesantias").append('<option value="">No hay Datos</option>');
                } else {
                    $("#SelectFondoCesantias").empty().append('<option value="-1">Seleccione FondoCesantias</option>');
                    $.each(resultado, function () {
                        $("#SelectFondoCesantias").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                        contador++;
                    });
                }
            } else {
                $.each(resultado, function () {
                    $("#SelectEFondoCesantias").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                    contador++;
                });
            }
        },
    });
}

function GridFondoCesantias() {
    let datatable = $('#gridFondoCesantias').DataTable({
        "responsive": true,
        dom: 'B<"clear">frtip',
        buttons: [{
            extend: 'excelHtml5',
            footer: true,
            title: 'Lista de Fondo Cesantías',
            filename: 'Lista de Fondo Cesantías',
            text: 'Excel',
            exportOptions: {
                columns: [1, 2, 3, 4, 5, 6]
            }
        },
        {
            extend: 'pdfHtml5',
            download: 'open',
            footer: true,
            title: 'Lista de Fondo Cesantías',
            filename: 'Lista de Fondo Cesantías',
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
            "url": '/FondoCesantias/GridFondoCesantias',
            "type": "GET",
            "datatype": "json"
        },
        columns: [
            { "data": "Id", title: "Id", "visible": false },
            { "data": "Nombre", title: "Fondo Cesantías" },
            { "data": "Estado", title: "Estado" },
            { "data": "Email", title: "Email" },
            { "data": "Telefono", title: "Teléfono" },
            { "data": "CreateBy", title: "Creado por" },
            { "data": "DateCreate", title: "Fecha Creación" },
            {
                title: "Editar",
                data: null,
                defaultContent: '<a href="#" class="EditarFondoCesantias" title="Editar"><i class="bi-pencil-fill" style="Color:green"></i></a>',
                className: '',
                orderable: false,
                width: 50,
            },
            {
                title: "Eliminar",
                data: null,
                defaultContent: '<a href="#" class="EliminarFondoCesantias" title="Eliminar"><i class="bi-trash-fill" style="Color:red"></i></a>',
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
    $('#gridFondoCesantias').on('click', '.EditarFondoCesantias', function () {
        let data = datatable.row($(this).parents()).data();
        Cookies.set('IdEdit', data.Id);
        window.location = "/FondoCesantias/Editar_FondoCesantias";
    });


    $('#gridFondoCesantias').on('click', '.EliminarFondoCesantias', function () {
        let data = datatable.row($(this).parents()).data();
        $('#ModalEliminarFondoCesantias').modal('show');
        $('#IdFondoCesantias').text(data.Id);
        $('#MensajeEliminarFondoCesantias').text('Esta seguro de eliminar el fondo de cesantías ' + data.Nombre + ' ?');
    })
}



