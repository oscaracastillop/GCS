function CrearCiudad() {
    let User = Cookies.get('IdUser');
    let IdDepartamento = $('#SelectDepartamento').val();
    let NombreCiudad = $('#InputNombreCiudad').val()
    if (IdDepartamento == -1) {
        Swal.fire('Mensaje del Sistema', 'Seleccione el Departamento', 'info');
    } else if (NombreCiudad == null || NombreCiudad == '' || NombreCiudad == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre del Ciudad', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/Ciudad/CrearCiudad',
            data: { IdUser: User, IdDepartamento: IdDepartamento, NombreCiudad: NombreCiudad },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/Ciudad';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function GuardarCambiosCiudad() {
    let User = Cookies.get('IdUser');
    let IdDepartamento = $('#SelectEDepartamento').val();
    let IdCiudad = Cookies.get('IdEdit');
    let NombreCiudad = $('#InputENombreCiudad').val();
    let Activo = $('#SelectEstadoCiudad').val();
    if (NombreCiudad == '' || NombreCiudad == null || NombreCiudad == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre del Ciudad', 'info');
    } else if (IdDepartamento == -1) {
        Swal.fire('Mensaje del Sistema', 'Seleccione el Departamento', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/Ciudad/GuardarCambiosCiudad',
            data: {
                IdDepartamento: IdDepartamento,
                IdCiudad: IdCiudad,
                IdUser: User,
                NombreCiudad: NombreCiudad,
                Activo: Activo
            },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/Ciudad';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function EliminarCiudad() {
    let IdUser = Cookies.get('IdUser');
    let IdCiudad = $('#IdCiudad').text();
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Ciudad/EliminarCiudad',
        data: {
            IdUser: IdUser,
            IdCiudad: IdCiudad
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

function CargarDatosCiudad() {
    let IdCiudad = Cookies.get('IdEdit');
    ListaDepartamento("E");
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Ciudad/CargarDatosCiudad',
        data: { IdCiudad: IdCiudad },
        success: function (resultado) {
            $('#SelectEDepartamento').val(resultado[0].IdDepartamento);
            $('#InputENombreCiudad').val(resultado[0].Nombre);
            $('#SelectEstadoCiudad').val(resultado[0].Activo);

        }
    });
}

function ListaCiudad(Tipo) {
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Ciudad/ListaCiudad',
        data: {},
        success: function (resultado) {
            var contador = 0;
            if (Tipo == "N") {
                if (resultado.length === 0) {
                    $("#SelectCiudad").append('<option value="">No hay Datos</option>');
                } else {
                    $("#SelectCiudad").empty().append('<option value="-1">Seleccione Ciudad</option>');
                    $.each(resultado, function () {
                        $("#SelectCiudad").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                        contador++;
                    });
                }
            } else {
                $.each(resultado, function () {
                    $("#SelectECiudad").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                    contador++;
                });
            }
        },
    });
}

function BuscarCiudadIdDepartamento(Tipo, IdDepartamento) {
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Ciudad/BuscarCiudadIdDepto',
        data: { IdDepartamento: IdDepartamento },
        success: function (resultado) {   
            $("#SelectCiudad").empty().append();
            var contador = 0;
            if (Tipo == "N") {
                if (IdDepartamento == -1) {
                    $("#SelectCiudad").empty().append();
                } else {
                    if (resultado.length === 0) {
                        $("#SelectCiudad").append('<option value="0">No hay Datos</option>');
                    } else {
                        $("#SelectCiudad").empty().append('<option value="-1">Seleccione Ciudad</option>');
                        $.each(resultado, function () {
                            $("#SelectCiudad").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                            contador++;
                        });
                    }
                }            
            } else {
                $.each(resultado, function () {
                    $("#SelectECiudad").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                    contador++;
                });
            }
        },
    });
}

function GridCiudad() {
    let datatable = $('#gridCiudad').DataTable({
        "responsive": true,
        dom: 'B<"clear">frtip',
        buttons: [{
            extend: 'excelHtml5',
            footer: true,
            title: 'Lista de Ciudades',
            filename: 'Lista de Ciudades',
            text: 'Excel',
            exportOptions: {
                columns: [1, 2, 3, 4, 5]
            }
        },
        {
            extend: 'pdfHtml5',
            download: 'open',
            footer: true,
            title: 'Lista de Ciudades',
            filename: 'Lista de Ciudades',
            text: 'Pdf',
            exportOptions: {
                columns: [1, 2, 3, 4, 5]
            }
        },
        {
            extend: 'print',
            footer: true,
            filename: 'Export_File_print',
            text: 'Imprimir',
            exportOptions: {
                columns: [1, 2, 3, 4, 5]
            }
        },
        ],
        "order": [[1, "asc"]],
        destroy: true,
        "ajax": {
            "url": '/Ciudad/GridCiudad',
            "type": "GET",
            "datatype": "json"
        },
        columns: [
            { "data": "Id", title: "Id", "visible": false },
            { "data": "Nombre", title: "Ciudad" },
            { "data": "NombreDepartamento", title: "Departamento" },
            { "data": "Estado", title: "Estado" },
            { "data": "CreateBy", title: "Creado por" },
            { "data": "DateCreate", title: "Fecha Creación" },
            {
                title: "Editar",
                data: null,
                defaultContent: '<a href="#" class="EditarCiudad" title="Editar"><i class="bi-pencil-fill" style="Color:green"></i></a>',
                className: '',
                orderable: false,
            },
            {
                title: "Eliminar",
                data: null,
                defaultContent: '<a href="#" class="EliminarCiudad" title="Eliminar"><i class="bi-trash-fill" style="Color:red"></i></a>',
                className: '',
                orderable: false,
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
    $('#gridCiudad').on('click', '.EditarCiudad', function () {
        let data = datatable.row($(this).parents()).data();
        Cookies.set('IdEdit', data.Id);
        window.location = "/Ciudad/Editar_Ciudad";
    });


    $('#gridCiudad').on('click', '.EliminarCiudad', function () {
        let data = datatable.row($(this).parents()).data();
        $('#ModalEliminarCiudad').modal('show');
        $('#IdCiudad').text(data.Id);
        $('#MensajeEliminarCiudad').text('Esta seguro de eliminar la ciudad ' + data.Nombre + ' ?');
    })
}




