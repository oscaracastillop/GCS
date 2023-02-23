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














function CargarDatosHVEmpleado() {
    let IdEmpleado = Cookies.get('IdHVEmpleado');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Empleado/CargarDatosHVEmpleado',
        data: { IdEmpleado: IdEmpleado },
        success: function (resultado) {
            $('#InputHVNombre').text(resultado[0].Nombre);
            $('#InputHVApellido').text(resultado[0].Apellido);
            $('#InputHVTipoDocumento').text(resultado[0].TipoDocumento);
            $('#InputHVIdentificacion').text(resultado[0].Identificacion);
            $('#InputHVNacionalidad').text(resultado[0].Nacionalidad);
            $('#InputHVFechaNacimiento').text(resultado[0].FechaNacimiento);
            $('#InputHVLugarNacimiento').text(resultado[0].LugarNacimiento);
            $('#InputHVSexo').text(resultado[0].Sexo);
            $('#InputHVEstadoCivil').text(resultado[0].EstadoCivil);
            $('#InputHVEmail').text(resultado[0].Email);
            $('#InputHVTelefono1').text(resultado[0].Telefono1);
            $('#InputHVTelefono2').text(resultado[0].Telefono2);
            $('#InputHVPaisResidencia').text(resultado[0].PaisResidencia);
            $('#InputHVDepartamentoResidencia').text(resultado[0].DepartamentoResidencia);
            $('#InputHVCiudadResidencia').text(resultado[0].CiudadResidencia);
            $('#InputHVDireccionResidencia').text(resultado[0].DireccionResidencia);
            $('#InputHVTipoVivienda').text(resultado[0].TipoVivienda);
            $('#InputHVNombreArrendador').text(resultado[0].NombreArrendador);
            $('#InputHVTiempoResidiendo').text(resultado[0].TiempoResidiendo);
            $('#InputHVNombreRF1').text(resultado[0].NombreRF1);
            $('#InputHVParentescoRF1').text(resultado[0].ParentescoRF1);
            $('#InputHVTelefonoRF1').text(resultado[0].TelefonoRF1);
            $('#InputHVProfesionRF1').text(resultado[0].ProfesionRF1);
            $('#InputHVNombreRF2').text(resultado[0].NombreRF2);
            $('#InputHVParentescoRF2').text(resultado[0].ParentescoRF2);
            $('#InputHVTelefonoRF2').text(resultado[0].TelefonoRF2);
            $('#InputHVProfesionRF2').text(resultado[0].ProfesionRF2);
            $('#InputHVNombreRP1').text(resultado[0].NombreRP1);
            $('#InputHVDireccionRP1').text(resultado[0].DireccionRP1);
            $('#InputHVTelefonoRP1').text(resultado[0].TelefonoRP1);
            $('#InputHVProfesionRP1').text(resultado[0].ProfesionRP1);
            $('#InputHVNombreRP2').text(resultado[0].NombreRP2);
            $('#InputHVDireccionRP2').text(resultado[0].DireccionRP2);
            $('#InputHVTelefonoRP2').text(resultado[0].TelefonoRP2);
            $('#InputHVProfesionRP2').text(resultado[0].ProfesionRP2);
        }
    });
}

function CargarDatosPersonales() {
    let IdEmpleado = Cookies.get('IdHVEmpleado');    
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Empleado/CargarDatosPersonales',
        data: { IdEmpleado: IdEmpleado },
        success: function (resultado) {            
            $('#SelectPaisNacionalidad').val(resultado[0].IdNacionalidad);
            $('#InputFechaNacimientoEmpleado').val(resultado[0].FechaNacimiento);
            $('#InputLugarNacimientoEmpleado').val(resultado[0].LugarNacimiento);
            $('#SelectSexoEmpleado').val(resultado[0].IdSexo);
            $('#SelectTipoEstadoCivil').val(resultado[0].IdEstadoCivil);
            $('#InputEmailEmpleado').val(resultado[0].Email);
            $('#InputTelefono1Empleado').val(resultado[0].Telefono1);
            $('#InputTelefono2Empleado').val(resultado[0].Telefono2);
        }
    });    
    $('#ModalDatosPersonalesEmpleado').modal('show')
}


function GuardarCambiosDatosPersonales() {
    let User = Cookies.get('IdUser');
    let IdEmpleado = Cookies.get('IdHVEmpleado');
    let IdNacionalidad = $('#SelectPaisNacionalidad').val();
    let FechaNacimientoEmpleado = $('#InputFechaNacimientoEmpleado').val();
    let LugarNacimientoEmpleado = $('#InputLugarNacimientoEmpleado').val();
    let IdSexoEmpleado = $('#SelectSexoEmpleado').val();
    let IdTipoEstadoCivil = $('#SelectTipoEstadoCivil').val();
    let EmailEmpleado = $('#InputEmailEmpleado').val();
    let Telefono1Empleado = $('#InputTelefono1Empleado').val();
    let Telefono2Empleado = $('#InputTelefono2Empleado').val();
    if (IdNacionalidad == '' || IdNacionalidad == null || IdNacionalidad == -1) {
        Swal.fire('Mensaje del Sistema', 'Seleccione nacionalidad', 'info');
    } else if (IdSexoEmpleado == '' || IdSexoEmpleado == null || IdSexoEmpleado == -1) {
        Swal.fire('Mensaje del Sistema', 'Seleccione el sexo', 'info');
    } else if (IdTipoEstadoCivil == '' || IdTipoEstadoCivil == null || IdTipoEstadoCivil == -1) {
        Swal.fire('Mensaje del Sistema', 'Seleccione estado civil', 'info');
    } else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/Empleado/GuardarCambiosDatosPersonales',
            data: {
                IdEmpleado: IdEmpleado,
                IdUser: User,
                IdNacionalidad: IdNacionalidad,
                FechaNacimientoEmpleado: FechaNacimientoEmpleado,
                LugarNacimientoEmpleado: LugarNacimientoEmpleado,
                IdSexoEmpleado: IdSexoEmpleado,
                IdTipoEstadoCivil: IdTipoEstadoCivil,
                EmailEmpleado: EmailEmpleado,
                Telefono1Empleado: Telefono1Empleado,
                Telefono2Empleado: Telefono2Empleado
            },
            success: function (resultado) {
                valor = resultado.split('*');
                if (valor[0] == 'OK') {
                    Swal.fire({
                        title: 'Mensaje del Sistema',
                        text: valor[1],
                        icon: 'success',
                    }).then((result) => {
                        window.location.href = '/Empleado/Hoja_Vida_Empleado';
                    })
                } else {
                    Swal.fire('Mensaje del Sistema', valor[1], 'info');
                }
            }
        });
    }
}



function CargarDatosResidencia() {
    let IdEmpleado = Cookies.get('IdHVEmpleado');
    //$.ajax({
    //    type: 'POST',
    //    dataType: 'json',
    //    url: '/Empleado/CargarDatosResidencia',
    //    data: { IdEmpleado: IdEmpleado },
    //    success: function (resultado) {
    //        $('#SelectPaisNacionalidad').val(resultado[0].IdNacionalidad);
    //        $('#InputFechaNacimientoEmpleado').val(resultado[0].FechaNacimiento);
    //        $('#InputLugarNacimientoEmpleado').val(resultado[0].LugarNacimiento);
    //        $('#SelectSexoEmpleado').val(resultado[0].IdSexo);
    //        $('#SelectTipoEstadoCivil').val(resultado[0].IdEstadoCivil);
    //        $('#InputEmailEmpleado').val(resultado[0].Email);
    //        $('#InputTelefono1Empleado').val(resultado[0].Telefono1);
    //        $('#InputTelefono2Empleado').val(resultado[0].Telefono2);
    //    }
    //});
    $('#ModalDatosResidenciaEmpleado').modal('show')
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
            //{
            //    title: "Inf. Personal",
            //    data: null,
            //    defaultContent: '<a href="#" class="DatosPersonalesEmpleado">Ver</a>',
            //    className: '',
            //    orderable: false,
            //    "autoWidth": false,
            //},
            //{
            //    title: "Inf. Laboral",
            //    data: null,
            //    defaultContent: '<a href="#" class="DatosFamiliaresEmpleado">Ver</a>',
            //    className: '',
            //    orderable: false,
            //    "autoWidth": false,
            //},
            //{
            //    title: "Inf. Familiar",
            //    data: null,
            //    defaultContent: '<a href="#" class="DatosFamiliaresEmpleado">Ver</a>',
            //    className: '',
            //    orderable: false,
            //    "autoWidth": true,
            //},
            //{
            //    title: "Inf. Hijos",
            //    data: null,
            //    defaultContent: '<a href="#" class="DatoHijosEmpleado">Ver</a>',
            //    className: '',
            //    orderable: false,
            //    "autoWidth": false,
            //},
            //{
            //    title: "Ref. Personal",
            //    data: null,
            //    defaultContent: '<a href="#" class="DatosPersonalesEmpleado">Ver</a>',
            //    className: '',
            //    orderable: false,
            //    "autoWidth": false,
            //},
            //{
            //    title: "Ref. Familiar",
            //    data: null,
            //    defaultContent: '<a href="#" class="DatosFamiliaresEmpleado">Ver</a>',
            //    className: '',
            //    orderable: false,
            //    "autoWidth": false,
            //},
            //{
            //    title: "Inf. Educación",
            //    data: null,
            //    defaultContent: '<a href="#" class="DatosFamiliaresEmpleado">Ver</a>',
            //    className: '',
            //    orderable: false,
            //    "autoWidth": false,
            //},
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

    $('#gridEmpleado').on('click', '.HojaVidaEmpleado', function () {
        let data = datatable.row($(this).parents()).data();
        Cookies.set('IdHVEmpleado', data.Id);
        window.location = "/Empleado/Hoja_Vida_Empleado";
    });
}
