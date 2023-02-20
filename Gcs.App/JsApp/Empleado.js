function CrearEmpleado() {
    let User = Cookies.get('IdUser');
    let NombreEmpleado = $('#InputNombreEmpleado').val();
    let ApellidoEmpleado = $('#InputApellidoEmpleado').val();
    let IdTipoDocumento = $('#SelectTipoDocumento').val();
    let Identificacion = $('#InputIdentificacionEmpleado').val();   
    if (NombreEmpleado == null || NombreEmpleado == '' || NombreEmpleado == undefined) {
        Swal.fire('Mensaje del Sistema', 'Ingrese el nombre', 'info');
    } else if (ApellidoEmpleado == undefined || ApellidoEmpleado == null || ApellidoEmpleado == '') {
        Swal.fire('Mensaje del Sistema', 'Ingrese el apellido', 'info');
    } else if (IdTipoDocumento == -1 || IdTipoDocumento == null || IdTipoDocumento == '') {
        Swal.fire('Mensaje del Sistema', 'Seleccione tipo documento', 'info');
    } else if (Identificacion == undefined || Identificacion == null || Identificacion == '') {
        Swal.fire('Mensaje del Sistema', 'Ingrese número de identificación', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/Empleado/CrearEmpleado',
            data: {
                IdUser: User,
                NombreEmpleado: NombreEmpleado,
                ApellidoEmpleado: ApellidoEmpleado,
                IdTipoDocumento: IdTipoDocumento,
                Identificacion: Identificacion,
            },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/Empleado';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}

function GridEmpleado() {
    let datatable = $('#gridEmpleado').DataTable({
        "responsive": true,
        dom: 'B<"clear">frtip',
        buttons: [{
            extend: 'excelHtml5',
            footer: true,
            title: 'Lista de Empleado',
            filename: 'Lista de Empleado',
            text: 'Excel',
            exportOptions: {
                columns: [1, 2, 3, 4, 5, 6]
            }
        },
        {
            extend: 'pdfHtml5',
            download: 'open',
            footer: true,
            title: 'Lista de Empleado',
            filename: 'Lista de Empleado',
            text: 'Pdf',
            orientation: 'landscape',
            pageSize: 'LEGAL',
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
            "url": '/Empleado/GridEmpleado',
            "type": "GET",
            "datatype": "json"
        },
        columns: [
            { "data": "Id", title: "Id", "visible": false },
            { "data": "Nombre", title: "Empleado" },
            { "data": "TipoDocumento", title: "Documento" },
            { "data": "Identificacion", title: "Identificación" },            
            { "data": "Estado", title: "Estado" },
            { "data": "CreateBy", title: "Creado por" },
            { "data": "DateCreate", title: "Fecha Creación", "autoWidth": false },
            {
                title: "Hoja Vida",
                data: null,
                defaultContent: '<a href="#" class="HojaVidaEmpleado" title="Ver hoja de vida"><i class="bi-file-earmark-medical-fill" style="Color:blue"></i></a>', 
                className: '',
                orderable: false,
                "autoWidth": false,
            },
            {
                title: "Inf. Personal",
                data: null,
                defaultContent: '<a href="#" class="DatosPersonalesEmpleado">Ver</a>',
                className: '',
                orderable: false,
                "autoWidth": false,
            },
            {
                title: "Inf. Laboral",
                data: null,
                defaultContent: '<a href="#" class="DatosFamiliaresEmpleado">Ver</a>',
                className: '',
                orderable: false,
                "autoWidth": false,
            },
            {
                title: "Inf. Familiar",
                data: null,
                defaultContent: '<a href="#" class="DatosFamiliaresEmpleado">Ver</a>',
                className: '',
                orderable: false,
                "autoWidth": true,
            },
            {
                title: "Inf. Hijos",
                data: null,
                defaultContent: '<a href="#" class="DatoHijosEmpleado">Ver</a>',
                className: '',
                orderable: false,
                "autoWidth": false,
            },
            {
                title: "Ref. Personal",
                data: null,
                defaultContent: '<a href="#" class="DatosPersonalesEmpleado">Ver</a>',
                className: '',
                orderable: false,
                "autoWidth": false,
            },
            {
                title: "Ref. Familiar",
                data: null,
                defaultContent: '<a href="#" class="DatosFamiliaresEmpleado">Ver</a>',
                className: '',
                orderable: false,
                "autoWidth": false,
            },
            {
                title: "Inf. Educación",
                data: null,
                defaultContent: '<a href="#" class="DatosFamiliaresEmpleado">Ver</a>',
                className: '',
                orderable: false,
                "autoWidth": false,
            },
            {
                title: "Editar",
                data: null,
                defaultContent: '<a href="#" class="EditarEmpleado" title="Editar"><i class="bi-pencil-fill" style="Color:green"></i></a>',
                className: '',
                orderable: false,
                "autoWidth": false,
            },
            {
                title: "Eliminar",
                data: null,
                defaultContent: '<a href="#" class="EliminarEmpleado" title="Eliminar"><i class="bi-trash-fill" style="Color:red"></i></a>',
                className: '',
                orderable: false,
                "autoWidth": false,
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
    $('#gridEmpleado').on('click', '.EditarEmpleado', function () {
        let data = datatable.row($(this).parents()).data();
        Cookies.set('IdEdit', data.Id);
        window.location = "/Empleado/Editar_Empleado";
    });


    $('#gridEmpleado').on('click', '.EliminarEmpleado', function () {
        let data = datatable.row($(this).parents()).data();
        $('#ModalEliminarEmpleado').modal('show');
        $('#IdEmpleado').text(data.Id);
        $('#MensajeEliminarEmpleado').text('Esta seguro de eliminar la Empleado ' + data.Nombre + ' ?');
    })
}
