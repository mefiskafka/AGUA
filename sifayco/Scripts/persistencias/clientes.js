var listadoClientes = new Array();

//Recuperar todos los clientes
function recuperarClientes() {
    $.getJSON("../api/clientes/",
        function (data) {
            $.each(data, function (key, val) {
                var str = '(' + val.Id + ')' + val.Nombre;
                $('<li/>', { html: str }).appendTo($('#clientes'));

                //Agrego el cliente a la lista de clientes
                var cliente = {Id: val.Id,Nombre: val.Nombre};
                listadoClientes.push(cliente);

            });
        });
}

//Buscar cliente
function buscarCliente(id, callback) {
    $.ajax({
        url: "../api/clientes/",
        data: { id: id },
        type: "GET",
        contentType: "application/json;charset=utf-8",
        statusCode: {
            200: function (cliente) {
                callback(cliente);
            },
            404: function() {
                alert("Cliente no encontrado");
            }
        }
    });
}

$('#buscarCliente').live({
    click: function () {
        var id = $('#IdCliente').val();
        buscarCliente(id, function (cliente) {
            var str = '(' + cliente.Id + ')' + cliente.Nombre;
            $('#cliente').html(str);
        });
    }
});

//Crear cliente
function crearCliente(nuevoCliente, callback) {
    $.ajax({
        url: "../api/clientes/",
        data: JSON.stringify(nuevoCliente),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        statusCode: {
            201: function(cliente) {
                callback(cliente);
            }
        }
    });
}

$('#crearCliente').live({    
   click:function() {
       var nuevoCliente = { Nombre: $('#NombreCliente').val() };
       crearCliente(nuevoCliente, function(cliente) {
           alert("El nuevo cliente fue creado con el Id " + cliente.Id);
           
           var str = '(' + cliente.Id + ')' + cliente.Nombre;
           $('<li/>', { html: str }).appendTo($('#clientes'));
           
           //Agrego el cliente a la lista de clientes
           listadoClientes.push(cliente);
       });
   } 
});

//Actualizar cliente
function actualizarCliente(clienteActualizado, callback) {
    $.ajax({
        url: "../api/clientes/",
        data: JSON.stringify(clienteActualizado),
        type: "PUT",
        contentType: "application/json;charset=utf-8",
        statusCode: {
            200: function (cliente) {
                callback(cliente);
            },
            404: function () {
                alert("Cliente no encontrado.");
            }
        }
    });
}

$('#actualizarCliente').live({
    click: function() {
        var cliente = {
            Id: $('#Id').val(),
            Nombre: $('#Nombre').val()
        };
        actualizarCliente(cliente, function () {
            alert("El cliente fue actualizado.");

            $('#clientes').empty();
            for (var i = 0; i < listadoClientes.length; i++) {
                var clienteAux = listadoClientes[i];
                if (clienteAux.Id == cliente.Id)
                    clienteAux.Nombre = cliente.Nombre;
                
                var str = '(' + clienteAux.Id + ')' + clienteAux.Nombre;
                $('<li/>', { html: str }).appendTo($('#clientes'));
            }
            
        });
    }
});

//Elimnar cliente
function eliminarCliente(id, callback) {
    $.ajax({
        url: "../api/clientes/" + id,
        type: "DELETE",
        contentType: "application/json;charset=utf-8",
        statusCode: {
            200: function (cliente) {
                callback(cliente);
            },
            404: function () {
                alert("Cliente no encontrado.");
            }
        }
    });
}

$('#eliminarCliente').live({
    click: function () {
        var id = $('#IdClienteEliminar').val();
        eliminarCliente(id, function (cliente) {
            alert("El cliente fue eliminado.");
            $('#clientes').empty();
            var listadoClientesNvo = new Array();
            for (var i = 0; i < listadoClientes.length; i++) {
                var clienteAux = listadoClientes[i];
                if (clienteAux.Id != id) {
                    listadoClientesNvo.push(clienteAux);
                    var str = '(' + clienteAux.Id + ')' + clienteAux.Nombre;
                    $('<li/>', { html: str }).appendTo($('#clientes'));
                }
            }
            listadoClientes = listadoClientesNvo;
        });
    }
});

$(document).ready(function () {
    recuperarClientes();
});