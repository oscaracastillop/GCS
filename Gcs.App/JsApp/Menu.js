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
                $("#MenuBotones").append('<a href="' + resultado[contador].Ruta + '" class="btn" style="margin-left:10px;margin-right:10px;margin-top: 10px;margin-bottom:10px; height:100px; width:120px;border-radius:10%;" id = "' + resultado[contador].Id + '">' +
                    '' + resultado[contador].Icono + '<br>' +
                    '<span style="font-size: 12px; color:black; font-weight:bold"> ' + resultado[contador].Nombre + '</span>' +
                    '</a>'
                );
                contador++;
            });
        },
    });
}