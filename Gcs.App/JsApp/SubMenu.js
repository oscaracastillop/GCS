function ListaSubMenu(Modulo) {
    let Usuario = Cookies.get('IdUser');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/SubMenu/ListaSubMenu',
        data: {
            Usuario: Usuario,
            Modulo: Modulo
        },
        success: function (resultado) {
            var contador = 0;
            $.each(resultado, function () {
                $("#SubMenuBotones").append('<a href="' + resultado[contador].Ruta + '"class="btn btnMenu" id = "' + resultado[contador].Id + '">' +
                    '' + resultado[contador].Icono + '<br>' +
                    '<span class="spanMenu"> ' + resultado[contador].Nombre + '</span>' +
                    '</a>'
                );
                contador++;
            });
        },
    });
}