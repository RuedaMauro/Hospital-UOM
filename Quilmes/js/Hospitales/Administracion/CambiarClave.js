var Cambio = 0;

$(document).ready(function () {
    var GET = {};
    document.location.search.replace(/\??(?:([^=]+)=([^&]*)&?)/g, function () {
        function decode(s) {
            return decodeURIComponent(s.split("+").join(" "));
        }

        GET[decode(arguments[1])] = decode(arguments[2]);
    });
    if (GET["Cambio"] != null) Cambio = 1;
});


$("#btnGuardar").click(function () {
    var json = JSON.stringify({
        "ClaveAnt": $("#txtCAnterior").val().trim(),
        "ClaveNueva": $("#txtCNueva").val().trim(),
        "ClaveNuevaRep": $("#txtCRNueva").val().trim()
    });

    $.ajax({
        type: "POST",
        data: json,
        url: "../Json/Administracion/CambiarClave.asmx/CambiarLaClave",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: CambiarLaClaveCambiada,
        error: errores
    });
})

function CambiarLaClaveCambiada(Resultado) {
    if (Resultado.d == 1) {
        alert("Clave Cambiada");
        //window.location.href = '...';
        if(Cambio == 0)
            window.location.replace('CambiarClave.aspx');
        else window.location.replace('../Login.aspx');
    }
    else {
        alert("Error al intentar cambiar la clave");
    }



}


function errores(msg) {
    var jsonObj = JSON.parse(msg.responseText);
    alert('Error: ' + jsonObj.Message);
}


function Cancelar()
{
window.location.replace('CambiarClave.aspx');
}
