function CrearDepartamento() {
    let User = Cookies.get('IdUser');
    let IdPais = $('#SelectPais').val();
    let NombreDepartamento = $('#InputNombreDepartamento').val()
    if (IdPais == -1) {
        Swal.fire('Mensaje del Sistema', 'Seleccione el país', 'info');
    } else if (NombreDepartamento == null || NombreDepartamento == '' || NombreDepartamento == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre del Departamento / Estado', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/Departamento/CrearDepartamento',
            data: { IdUser: User, IdPais: IdPais, NombreDepartamento: NombreDepartamento },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/Departamento';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function GuardarCambiosDepartamento() {
    let User = Cookies.get('IdUser');
    let IdPais = $('#SelectEPais').val();
    let IdDepartamento = Cookies.get('IdEdit');
    let NombreDepartamento = $('#InputENombreDepartamento').val();
    let Activo = $('#SelectEstadoDepartamento').val();
    if (NombreDepartamento == '' || NombreDepartamento == null || NombreDepartamento == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese nombre del Departamento / Estado', 'info');
    } else if (IdPais == -1) {
        Swal.fire('Mensaje del Sistema', 'Seleccione el país', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/Departamento/GuardarCambiosDepartamento',
            data: {
                IdPais: IdPais,
                IdDepartamento: IdDepartamento,
                IdUser: User,
                NombreDepartamento: NombreDepartamento,
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
                        window.location.href = '/Departamento';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function EliminarDepartamento() {
    let IdUser = Cookies.get('IdUser');
    let IdDepartamento = $('#IdDepartamento').text();
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Departamento/EliminarDepartamento',
        data: {
            IdUser: IdUser,
            IdDepartamento: IdDepartamento
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

function CargarDatosDepartamento() {
    let IdDepartamento = Cookies.get('IdEdit');
    ListaPais("E");
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Departamento/CargarDatosDepartamento',
        data: { IdDepartamento: IdDepartamento },
        success: function (resultado) {
            $('#SelectEPais').val(resultado[0].IdPais);
            $('#InputENombreDepartamento').val(resultado[0].Nombre);
            $('#SelectEstadoDepartamento').val(resultado[0].Activo);

        }
    });
}

function ListaDepartamento(Tipo) {
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Departamento/ListaDepartamento',
        data: {},
        success: function (resultado) {
            var contador = 0;
            if (Tipo == "N") {
                if (resultado.length === 0) {
                    $("#SelectDepartamento").append('<option value="">No hay Datos</option>');
                } else {
                    $("#SelectDepartamento").empty().append('<option value="-1">Seleccione Departamento</option>');
                    $.each(resultado, function () {
                        $("#SelectDepartamento").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                        contador++;
                    });
                }
            } else {
                $.each(resultado, function () {
                    $("#SelectEDepartamento").append('<option value="' + resultado[contador].Id + '">' + resultado[contador].Nombre + '</option>');
                    contador++;
                });
            }
        },
    });
}

function GridDepartamento() {
    let datatable = $('#gridDepartamento').DataTable({
        "responsive": true,
        dom: 'B<"clear">frtip',
        buttons: [{
            extend: 'excelHtml5',
            footer: true,
            title: 'Lista de Departamentos',
            filename: 'Lista de Departamentos',
            text: 'Excel',
            exportOptions: {
                columns: [1, 2, 3, 4, 5]
            }
        },
        {
            extend: 'pdfHtml5',
            download: 'open',
            footer: true,
            title: 'Lista de Departamentos',
            filename: 'Lista de Departamentos',
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
            "url": '/Departamento/GridDepartamento',
            "type": "GET",
            "datatype": "json"
        },
        columns: [
            { "data": "Id", title: "Id", "visible": false },
            { "data": "Nombre", title: "Departamento" },
            { "data": "NombrePais", title: "País" },
            { "data": "Estado", title: "Estado" },
            { "data": "CreateBy", title: "Creado por" },
            { "data": "DateCreate", title: "Fecha Creación" },
            {
                title: "Editar",
                data: null,
                defaultContent: '<a href="#" class="EditarDepartamento" title="Editar"><i class="bi-pencil-fill" style="Color:green"></i></a>',
                className: '',
                orderable: false,
            },
            {
                title: "Eliminar",
                data: null,
                defaultContent: '<a href="#" class="EliminarDepartamento" title="Eliminar"><i class="bi-trash-fill" style="Color:red"></i></a>',
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
    $('#gridDepartamento').on('click', '.EditarDepartamento', function () {
        let data = datatable.row($(this).parents()).data();
        Cookies.set('IdEdit', data.Id);
        window.location = "/Departamento/Editar_Departamento";
    });


    $('#gridDepartamento').on('click', '.EliminarDepartamento', function () {
        let data = datatable.row($(this).parents()).data();
        $('#ModalEliminarDepartamento').modal('show');
        $('#IdDepartamento').text(data.Id);
        $('#MensajeEliminarDepartamento').text('Esta seguro de Eliminar el Departamento ' + data.Nombre + ' ?');
    })
}

