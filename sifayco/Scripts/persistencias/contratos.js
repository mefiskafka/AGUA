//Buscar cliente
function buscarContrato(id, callback) {
    $.ajax({
        url: "../api/Contratos/",
        data: { id: id },
        type: "Get",
        contentType: "application/json;charset=utf-8",
        statusCode: {
            200: function (contrato) {
                callback(contrato);
            },
            404: function () {
                alert("Contrato no encontrado");
            },
            500: function() {
                alert("Error interno de servidor");
            }
        },
        error: function (e) {
            console.log(e.statusText);
        },
        success: function () {
            console.log("success");
        },
    });
}

function limpiarFormulario() {
    $('#txtNombre').val("");
    $('#txtCalle').val("");
    $('#txtNumInterior').val("");
    $('#txtNumExterior').val("");
    $('#txtColonia').val("");
    $('#txtCorreo').val("");
    $('#txtTelefono').val("");

    $('#txtSector').val("");
    $('#txtManzana').val("");
    $('#txtLote').val("");
    $('#txtRuta').val("");
    $('#txtProgresivo').val("");
    $('#txtHabitantes').val("");
}

function btnBuscar_onclick() {
    var id = $('#txtBuscar').val();
            limpiarFormulario();
            buscarContrato(id, function (contrato) {
                $('#txtNombre').val(contrato.T_USUARIO_SERVICIO.NOMBRE_USUARIO);
                $('#txtCalle').val(contrato.T_USUARIO_SERVICIO.CALLE);
                $('#txtNumInterior').val(contrato.T_USUARIO_SERVICIO.NUMERO_INTERIOR);
                $('#txtNumExterior').val(contrato.T_USUARIO_SERVICIO.NUMERO_EXTERIOR);
                $('#txtColonia').val(contrato.T_USUARIO_SERVICIO.COLONIA);
                $('#txtCorreo').val(contrato.T_USUARIO_SERVICIO.CORREO_ELECTRONICO);
                $('#txtTelefono').val(contrato.T_USUARIO_SERVICIO.TELEFONO);

                $('#txtSector').val(contrato.SECTOR);
                $('#txtManzana').val(contrato.MANZANA);
                $('#txtLote').val(contrato.LOTE);
                $('#txtRuta').val(contrato.RUTA);
                $('#txtProgresivo').val(contrato.PROGRESIVO);
                $('#txtHabitantes').val(contrato.NUMERO_HABITANTES);
            });
}