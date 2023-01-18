function ListaMenu() {
    let Usuario = Cookies.get('IdUser');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Menu/ListaMenu',
        data: { Usuario: Usuario },
        success: function (resultado) {
            var contador = 0;
            $.each(resultado, function () {
                $("#MenuBotones").append('<a href="' + resultado[contador].Ruta + '" class="btn btnMenu" id = "' + resultado[contador].Id + '">' +
                    '' + resultado[contador].Icono + '<br>' +
                    '<span class="spanMenu"> ' + resultado[contador].Nombre + '</span>' +
                    '</a>'
                );
                contador++;
            });
        },
    });
}