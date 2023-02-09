function CrearPais() {
    let User = Cookies.get('IdUser');
    let NombrePais = $('#InputNombrePais').val()
    if (NombrePais == null || NombrePais == '' || NombrePais == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre del país', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/Pais/CrearPais',
            data: { IdUser: User, NombrePais: NombrePais },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/Pais';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function GuardarCambiosPais() {
    let User = Cookies.get('IdUser');
    let IdPais = Cookies.get('IdEdit');
    let NombrePais = $('#InputENombrePais').val();
    let Activo = $('#SelectEstadoPais').val();
    if (NombrePais == '' || NombrePais == null || NombrePais == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre del País', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/Pais/GuardarCambiosPais',
            data: { IdPais: IdPais, IdUser: User, NombrePais: NombrePais, Activo: Activo },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/Pais';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function EliminarPais() {
    let IdUser = Cookies.get('IdUser');
    let IdPais = $('#IdPais').text();
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Pais/EliminarPais',
        data: {
            IdUser: IdUser,
            IdPais: IdPais
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

function CargarDatosPais() {
    let IdPais = Cookies.get('IdEdit');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Pais/CargarDatosPais',
        data: { IdPais: IdPais },
        success: function (resultado) {
            $('#InputEditarNombrePais').val(resultado[0].Nombre);
            $('#SelectEstadoPais').val(resultado[0].Activo);

        }
    });
}

function ListaPais(Tipo) {
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Pais/ListaPais',
        data: {},
        success: function (resultado) {
            var contador = 0;
            if (Tipo == "N") {
                if (resultado.length === 0) {
                    $("#SelectPais").append('<option value="">No hay Datos</option>');
                } else {
                    $("#SelectPais").empty().append('<option value="-1">Seleccione País</option>');
                    $.each(resultado, function () {
                        $("#SelectPais").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                        contador++;
                    });
                }
            } else {
                $.each(resultado, function () {
                    $("#SelectEPais").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                    contador++;
                });
            }
        },
    });
}

function GridPais() {
    let datatable = $('#gridPais').DataTable({
         "responsive": true,
        dom: 'B<"clear">frtip',
        buttons: [{
            extend: 'excelHtml5',
            footer: true,
            title: 'Lista de Paises',
            filename: 'Lista de Paises',
            text: 'Excel',
            exportOptions: {
                columns: [1, 2, 3, 4]
            }
        },
        {
            extend: 'pdfHtml5',
            download: 'open',
            footer: true,
            title: 'Lista de Paises',
            filename: 'Lista de Paises',
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
            "url": '/Pais/GridPais',
            "type": "GET",
            "datatype": "json"
        },
        columns: [
            { "data": "Id", title: "Id", "visible": false },
            { "data": "Nombre", title: "Pais" },
            { "data": "Estado", title: "Estado" },
            { "data": "CreateBy", title: "Creado por" },
            { "data": "DateCreate", title: "Fecha Creación" },
            {
                title: "Editar",
                data: null,
                defaultContent: '<a href="#" class="EditarPais" title="Editar"><i class="bi-pencil-fill" style="Color:green"></i></a>',
                className: '',
                orderable: false,
                width: 50,
            },
            {
                title: "Eliminar",
                data: null,
                defaultContent: '<a href="#" class="EliminarPais" title="Eliminar"><i class="bi-trash-fill" style="Color:red"></i></a>',
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
    $('#gridPais').on('click', '.EditarPais', function () {
        let data = datatable.row($(this).parents()).data();
        Cookies.set('IdEdit', data.Id);
        window.location = "/Pais/Editar_Pais";
    });


    $('#gridPais').on('click', '.EliminarPais', function () {
        let data = datatable.row($(this).parents()).data();
        $('#ModalEliminarPais').modal('show');
        $('#IdPais').text(data.Id);
        $('#MensajeEliminarPais').text('Esta seguro de eliminar el país ' + data.Nombre + ' ?');
    })
}



