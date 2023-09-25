
///////////    Scripts para campos del formulario para ingresar zapatos //////////////

var porcentajeImpuestoVenta = 0.13;

var neto = 1.13;


//Guardar los datos de los precios de venta cuando se entre en el campo de descuento y reestablecer los valores si se llego a 0
var precioVtaTmp;
var precioVtaTotalTmp;
var impuestoVtaTmp;
var utilidad;
var gananciaTmp;
var entered = false;

$("#PrecioCompra").on('input', function (e) {
    var precioCompra = $(this).val();

    // Limpiar campos si el campo de precioCompra llega a 0

    if (precioCompra.length === 0) {
        $("#ImpuestoCompra").val(null);
        $("#PrecioTotalCompra").val(null);
    } else {
        var impuestoCompra = parseFloat(precioCompra) * porcentajeImpuestoVenta;
        var precioTotalCompra = parseFloat(precioCompra) + impuestoCompra;

        if (!isNaN(impuestoCompra) && !isNaN(precioTotalCompra)) {
            $("#ImpuestoCompra").val(impuestoCompra.toFixed(2));

            $("#PrecioTotalCompra").val(precioTotalCompra.toFixed(0));
        }

        //Esta parte es en caso de que los campos para la informacion de venta esten llenos para actualizarlos
        var ganancia = $("#Ganancia").val();

        if (ganancia.length !== 0) {
            calcularGanancia(ganancia);
        }
    }
  
});

$("#PrecioTotalCompra").on('input', function (e) {
    var precioTotalCompra = $(this).val();

    // Limpiar campos si el campo de precioTotalCompra llega a 0
    if (precioTotalCompra.length === 0) {
        $("#PrecioCompra").val(null);
        $("#ImpuestoCompra").val(null);
    } else {
        var precioCompra = precioTotalCompra / neto;
        var impuestoCompra = precioCompra * porcentajeImpuestoVenta;

        if (!isNaN(impuestoCompra) && !isNaN(precioTotalCompra)) {
            $("#ImpuestoCompra").val(impuestoCompra.toFixed(2));

            $("#PrecioCompra").val(precioCompra.toFixed(2));
        }

        //Esta parte es en caso de que los campos para la informacion de venta esten llenos para actualizarlos

        var ganancia = $("#Ganancia").val();

        if (ganancia.length !== 0){
            calcularGanancia(ganancia);    
        }
    }    

});

$("#PrecioTotalVenta").on('input', function (e) {
    var precioVentaTotal = $(this).val();

    $("#Descuento").val(null);

    if (precioVentaTotal.length === 0) {
        $("#PrecioVenta").val(null);
        $("#ImpuestoVenta").val(null);
        $("#PrecioTotalVenta").val(null);
        $("#PorcentajeUtilidad").val(null);
        $("#Ganancia").val(null);
        $("#Descuento").attr('readonly', true);
    } else {
        $("#Descuento").attr('readonly', false);
        var precioVentaBruto = parseFloat(precioVentaTotal / neto);
        var impuestoVenta = precioVentaBruto * porcentajeImpuestoVenta;
        var precioCompra = $("#PrecioCompra").val();

        var ganancia = Math.ceil(precioVentaBruto - precioCompra);
        var porcentajeUtilidad = Math.ceil((ganancia / precioVentaBruto) * 100);


        if (!isNaN(impuestoVenta) && !isNaN(precioCompra)) {
            $("#Ganancia").val(ganancia);
            $("#PorcentajeUtilidad").val(porcentajeUtilidad);

            $("#ImpuestoVenta").val(impuestoVenta.toFixed(0));
            $("#PrecioVenta").val((precioVentaBruto).toFixed(0));
        }
    }

});

$("#Ganancia").on('input', function (e) {

    var ganancia = $(this).val();
    calcularGanancia(ganancia);
    
});

//Guardar los valores de los campos de venta cuando se entre en el campo de descuento
$("#Descuento").on('focus', function (e) {
    if (entered === false && $(this).val().length === 0) {
        precioVtaTmp = $("#PrecioVenta").val();

        impuestoVtaTmp = $("#ImpuestoVenta").val();

        precioVtaTotalTmp = $("#PrecioTotalVenta").val();

        utilidad = $("#PorcentajeUtilidad").val();

        gananciaTmp = $("#Ganancia").val();

        entered = true;
    }
    
});

$("#Descuento").on('focusout', function (e) {
    if ($(this).val().length === 0) {
        entered = false;
    }
});

$("#Descuento").on('input', function (e) {

    var prcVta = parseFloat(precioVtaTmp);

    var prcntdesc = parseInt($(this).val());
    var desc = prcVta * (prcntdesc / 100);
    var precioVDesc = prcVta - (prcVta * (prcntdesc / 100));

    if ($(this).val().length === 0) {
        $("#PorcentajeUtilidad").val(utilidad);
        $("#PrecioTotalVenta").val(precioVtaTotalTmp);
        $("#ImpuestoVenta").val(impuestoVtaTmp);
        $("#PrecioVenta").val(precioVtaTmp);
        $("#Ganancia").val(gananciaTmp);
    }

    if (!isNaN(precioVDesc)) {
        $("#PrecioVenta").val(precioVDesc.toFixed(0));
        var ganancia = parseInt($("#Ganancia").val());
        var prcVenta = parseInt($("#PrecioVenta").val());

        var nuevaGanancia = ganancia - desc;
        var nuevoImpuesto = prcVenta * porcentajeImpuestoVenta;
        var nuevoPrcVntTotal = prcVenta + nuevoImpuesto;

        var nuevaUtilidad = Math.ceil((nuevaGanancia / prcVenta) * 100);

        $("#Ganancia").val(nuevaGanancia);
        $("#ImpuestoVenta").val(nuevoImpuesto);
        $("#PrecioTotalVenta").val(nuevoPrcVntTotal);
        $("#PorcentajeUtilidad").val(nuevaUtilidad);
    }

});

function calcularGanancia(ganancia) {
    $("#Descuento").val(null);
    // Limpiar campos si el campo de ganancia llega a 0
    if (ganancia.length === 0) {
        $("#PrecioVenta").val(null);
        $("#ImpuestoVenta").val(null);
        $("#PrecioTotalVenta").val(null);
        $("#PorcentajeUtilidad").val(null);
        $("#Descuento").attr('readonly', true);
    } else {
        $("#Descuento").attr('readonly', false);
        var precioTotalCompra = parseFloat($("#PrecioTotalCompra").val());
        var precioCompra = parseFloat($("#PrecioCompra").val());

        var precioVentaNeto = parseInt((ganancia * neto) + precioTotalCompra);

        var precioVentaBruto = parseFloat(precioVentaNeto / neto);

        var impuestoVenta = (parseFloat(precioVentaBruto) * porcentajeImpuestoVenta).toFixed(0);

        var porcentajeUtilidad = Math.ceil((ganancia / precioVentaBruto) * 100);

        if (!isNaN(precioVentaBruto) && !isNaN(precioTotalCompra) && !isNaN(ganancia)) {
            $("#PrecioVenta").val(precioVentaBruto.toFixed(0));
            $("#PrecioTotalVenta").val(Math.ceil(precioVentaNeto));
            $("#ImpuestoVenta").val(impuestoVenta);
            $("#PorcentajeUtilidad").val(porcentajeUtilidad);
        }
    }   
}

////////////////  fin de scripts para formularios de zapatos  //////////////////////


/////////////// Scripts para edicion de tallas ////////////////////////

//Borrar imagen en los detalles del estilo
$('.borrarImg').on("click", function (ev) {
    var dato = $(this).val();
    $.ajax({
        url: "/AdminEstilo/BorrarImagen",
        data: {
            id: dato
        },
        type: "POST",
        error: function () {
            $.toast({
                text: "Ocurrio un error a la hora de borrar el elemento. Vuélvalo a intentar", // Text that is to be shown in the toast

                icon: 'error', // Type of toast icon
                showHideTransition: 'fade', // fade, slide or plain
                allowToastClose: true, // Boolean value true or false
                hideAfter: 6000, // false to make it sticky or number representing the miliseconds as time after which toast needs to be hidden
                stack: 5, // false if there should be only one toast at a time or a number representing the maximum number of toasts to be shown at a time
                position: 'bottom-center', // bottom-left or bottom-right or bottom-center or top-left or top-right or top-center or mid-center or an object representing the left, right, top, bottom values



                textAlign: 'center',  // Text alignment i.e. left, right or center
                loader: true,  // Whether to show loader or not. True by default
                loaderBg: '#9EC600',  // Background color of the toast loader
                beforeShow: function () { }, // will be triggered before the toast is shown
                afterShown: function () { }, // will be triggered after the toat has been shown
                beforeHide: function () { }, // will be triggered before the toast gets hidden
                afterHidden: function () { }  // will be triggered after the toast has been hidden
            });
        }
    }).done(function (response) {
        if (response === null) {
            $.toast({
                text: "Ocurrio un error a la hora de borrar el elemento. Vuélvalo a intentar", // Text that is to be shown in the toast

                icon: 'error', // Type of toast icon
                showHideTransition: 'fade', // fade, slide or plain
                allowToastClose: true, // Boolean value true or false
                hideAfter: 6000, // false to make it sticky or number representing the miliseconds as time after which toast needs to be hidden
                stack: 5, // false if there should be only one toast at a time or a number representing the maximum number of toasts to be shown at a time
                position: 'bottom-center', // bottom-left or bottom-right or bottom-center or top-left or top-right or top-center or mid-center or an object representing the left, right, top, bottom values



                textAlign: 'center',  // Text alignment i.e. left, right or center
                loader: true,  // Whether to show loader or not. True by default
                loaderBg: '#9EC600',  // Background color of the toast loader
                beforeShow: function () { }, // will be triggered before the toast is shown
                afterShown: function () { }, // will be triggered after the toat has been shown
                beforeHide: function () { }, // will be triggered before the toast gets hidden
                afterHidden: function () { }  // will be triggered after the toast has been hidden
            });
        } else {
            //Se remueve el contenedor con el ID de la imagen
            $("#ContenedorImagen-" + dato).remove();
            $.toast({
                text: "Elemento eliminado de manera exitosa", // Text that is to be shown in the toast

                icon: 'success', // Type of toast icon
                showHideTransition: 'fade', // fade, slide or plain
                allowToastClose: true, // Boolean value true or false
                hideAfter: 6000, // false to make it sticky or number representing the miliseconds as time after which toast needs to be hidden
                stack: 5, // false if there should be only one toast at a time or a number representing the maximum number of toasts to be shown at a time
                position: 'bottom-center', // bottom-left or bottom-right or bottom-center or top-left or top-right or top-center or mid-center or an object representing the left, right, top, bottom values



                textAlign: 'center',  // Text alignment i.e. left, right or center
                loader: true,  // Whether to show loader or not. True by default
                loaderBg: '#9EC600',  // Background color of the toast loader
                beforeShow: function () { }, // will be triggered before the toast is shown
                afterShown: function () { }, // will be triggered after the toat has been shown
                beforeHide: function () { }, // will be triggered before the toast gets hidden
                afterHidden: function () { }  // will be triggered after the toast has been hidden
            });
        }
            
    });
});

//Agregar talla
$('#saveTallaBtn').on("click", function (ev) {
    var dato = $(this).val();
    $.ajax({
        url: "/AdminEstilo/GuardarEstiloTalla",
        data: {
            estiloDMId: $("#EstilosTallasViewModel_TallaDMId").val(),
            medidaCM: $("#EstilosTallasViewModel_MedidaCM").val(),
            cantidadDisponible: $("#EstilosTallasViewModel_CantidadDisponible").val(),
            tallaDMId: $("#EstilosTallasViewModel_TallaDMId").val(),
            numeroTalla: $("#EstilosTallasViewModel_TallaDMId option:selected").text()
        },
        type: "POST",
        error: function () {
            $.toast({
                text: "Ocurrio un error a la hora de guardar el elemento. Vuélvalo a intentar", // Text that is to be shown in the toast

                icon: 'error', // Type of toast icon
                showHideTransition: 'fade', // fade, slide or plain
                allowToastClose: true, // Boolean value true or false
                hideAfter: 6000, // false to make it sticky or number representing the miliseconds as time after which toast needs to be hidden
                stack: 5, // false if there should be only one toast at a time or a number representing the maximum number of toasts to be shown at a time
                position: 'bottom-center', // bottom-left or bottom-right or bottom-center or top-left or top-right or top-center or mid-center or an object representing the left, right, top, bottom values



                textAlign: 'center',  // Text alignment i.e. left, right or center
                loader: true,  // Whether to show loader or not. True by default
                loaderBg: '#9EC600',  // Background color of the toast loader
                beforeShow: function () { }, // will be triggered before the toast is shown
                afterShown: function () { }, // will be triggered after the toat has been shown
                beforeHide: function () { }, // will be triggered before the toast gets hidden
                afterHidden: function () { }  // will be triggered after the toast has been hidden
            });
        }
    }).done(function (response) {
        if (response === null) {
            $.toast({
                text: "Ocurrio un error a la hora de guardar el elemento. Vuélvalo a intentar", // Text that is to be shown in the toast

                icon: 'error', // Type of toast icon
                showHideTransition: 'fade', // fade, slide or plain
                allowToastClose: true, // Boolean value true or false
                hideAfter: 6000, // false to make it sticky or number representing the miliseconds as time after which toast needs to be hidden
                stack: 5, // false if there should be only one toast at a time or a number representing the maximum number of toasts to be shown at a time
                position: 'bottom-center', // bottom-left or bottom-right or bottom-center or top-left or top-right or top-center or mid-center or an object representing the left, right, top, bottom values



                textAlign: 'center',  // Text alignment i.e. left, right or center
                loader: true,  // Whether to show loader or not. True by default
                loaderBg: '#9EC600',  // Background color of the toast loader
                beforeShow: function () { }, // will be triggered before the toast is shown
                afterShown: function () { }, // will be triggered after the toat has been shown
                beforeHide: function () { }, // will be triggered before the toast gets hidden
                afterHidden: function () { }  // will be triggered after the toast has been hidden
            });
        } else {
            $('#tablaEstilosTallas').append
            (
                "" +
                "<tr id='" + response.EstiloDMTallaDMId + "'>" +
                "<td>" + response.NumeroTalla + "</td>" +
                "<td>" + response.MedidaCM + "</td>" +
                "<td>" + response.CantidadDisponible + "</td>" +
                "<td>" +
                "<button type='button' class='btn btn-default agregar' value='" + response.EstiloDMTallaDMId + "'>Agregar</button>" +
                "<button type='button' class='btn btn-default agregar' value='" + response.EstiloDMTallaDMId + "'> Reducir</button >" +
                "<button type='button' class='btn btn-default agregar' value='" + response.EstiloDMTallaDMId + "'> Eliminar</button >" +
                "</td>" +
               "</tr >"
            );
            $.toast({
                text: "Elemento agregado de manera exitosa", // Text that is to be shown in the toast

                icon: 'success', // Type of toast icon
                showHideTransition: 'fade', // fade, slide or plain
                allowToastClose: true, // Boolean value true or false
                hideAfter: 6000, // false to make it sticky or number representing the miliseconds as time after which toast needs to be hidden
                stack: 5, // false if there should be only one toast at a time or a number representing the maximum number of toasts to be shown at a time
                position: 'bottom-center', // bottom-left or bottom-right or bottom-center or top-left or top-right or top-center or mid-center or an object representing the left, right, top, bottom values



                textAlign: 'center',  // Text alignment i.e. left, right or center
                loader: true,  // Whether to show loader or not. True by default
                loaderBg: '#9EC600',  // Background color of the toast loader
                beforeShow: function () { }, // will be triggered before the toast is shown
                afterShown: function () { }, // will be triggered after the toat has been shown
                beforeHide: function () { }, // will be triggered before the toast gets hidden
                afterHidden: function () { }  // will be triggered after the toast has been hidden
            });
        }

    });
});

//En caso de que algun boton de editar se le da click se le asignan valores a los campos del modal
$('.editar').on("click", function (ev) {
    //se le asigna el valor o ID que tiene este boton al de guardar para usarlo cuando se vaya a guardar el color
    $('#saveColorBtn').attr('value', $(this).val());

    //Se le asigna el text field el valor del color que se quiere editar
    var color = $(this).closest('tr').find('td').text().trim();
    $('#Descripcion').val(color);
});


//Para limpiar el textfield del color
$('#agregarColorBtn').on("click", function (ev) {
    $('#Descripcion').val("");
    $('#saveColorBtn').val("");
});

//Agregar o Modificar color
$('#saveColorBtn').on("click", function (ev) {
    var creado = false;

    //Se fija si el val viene vacio. Si viene vacio el estilo que se va a guardar es nuevo
    if ($(this).val() !== "") {
        creado = true;
    }

    $.ajax({
        url: "/Color/GuardarColor",
        data: {
            colorDMId: $(this).val(),
            descripcion: $('#Descripcion').val()
        },
        type: "POST",
        error: function () {
            $.toast({
                text: "Ocurrio un error a la hora de guardar el elemento. Vuélvalo a intentar", // Text that is to be shown in the toast

                icon: 'error', // Type of toast icon
                showHideTransition: 'fade', // fade, slide or plain
                allowToastClose: true, // Boolean value true or false
                hideAfter: 6000, // false to make it sticky or number representing the miliseconds as time after which toast needs to be hidden
                stack: 5, // false if there should be only one toast at a time or a number representing the maximum number of toasts to be shown at a time
                position: 'bottom-center', // bottom-left or bottom-right or bottom-center or top-left or top-right or top-center or mid-center or an object representing the left, right, top, bottom values



                textAlign: 'center',  // Text alignment i.e. left, right or center
                loader: true,  // Whether to show loader or not. True by default
                loaderBg: '#9EC600',  // Background color of the toast loader
                beforeShow: function () { }, // will be triggered before the toast is shown
                afterShown: function () { }, // will be triggered after the toat has been shown
                beforeHide: function () { }, // will be triggered before the toast gets hidden
                afterHidden: function () { }  // will be triggered after the toast has been hidden
            });
        }
    }).done(function (response) {
        RefreshColorTable(response, creado);
        $("#coloresPop").modal('hide');
        $.toast({
            text: "Elemento agregado de manera exitosa", // Text that is to be shown in the toast

            icon: 'success', // Type of toast icon
            showHideTransition: 'fade', // fade, slide or plain
            allowToastClose: true, // Boolean value true or false
            hideAfter: 6000, // false to make it sticky or number representing the miliseconds as time after which toast needs to be hidden
            stack: 5, // false if there should be only one toast at a time or a number representing the maximum number of toasts to be shown at a time
            position: 'bottom-center', // bottom-left or bottom-right or bottom-center or top-left or top-right or top-center or mid-center or an object representing the left, right, top, bottom values



            textAlign: 'center',  // Text alignment i.e. left, right or center
            loader: true,  // Whether to show loader or not. True by default
            loaderBg: '#9EC600',  // Background color of the toast loader
            beforeShow: function () { }, // will be triggered before the toast is shown
            afterShown: function () { }, // will be triggered after the toat has been shown
            beforeHide: function () { }, // will be triggered before the toast gets hidden
            afterHidden: function () { }  // will be triggered after the toast has been hidden
        });
    });
});

//creado aqui es para saber si se reemplaza una celda o no
function RefreshColorTable(response, creado) {

    if (creado === true) {
        $('#celda-' + response.ColorDMId).remove();
    }

    $('#tablaColores tbody').append
        (
        "<tr id='celda-" + response.ColorDMId + "' >" +
            "<td class='align-middle'>" +
             response.Descripcion +
            "</td>" +
            "<td>" +
            "<button class='eliminar' style='padding:10px; border:none; background-color: rgba(0, 0, 0, 0)' value='" + response.ColorDMId + "'><img src='/Content/Plugins/iconic-master/png/trash-3x.png' /></button>" +
            "<button class='editar' style='padding:10px; border:none; background-color: rgba(0, 0, 0, 0)' value='" + response.ColorDMId + "'><img src='/Content/Plugins/iconic-master/png/pencil-3x.png' /></button>" +
            "</td>" +
        "</tr >"
    );
}

$('#tablaEstilosTallas tbody').on('click', 'button', function (e) {
    e.preventDefault();
    e.stopImmediatePropagation();
    var data = $(this);
    var row = $(this).closest('tr');
    if (data.hasClass("agregar")) {
        
        modificarTallasAjax("addSize", data, 1, row);

    } else if (data.hasClass("reducir")) {
        var cantidad = parseInt(row.find("td:eq(2)").text());
        if (cantidad !== 0) {
            row = $(this).closest('tr');
            modificarTallasAjax("removeSize", data, -1, row);
        }
        
    } else if (data.hasClass("eliminar")) {
        modificarTallasAjax("eliminateSize", data, -1, row);
    }
});

function modificarTallasAjax(action, data, cantidad, row) {
    $.ajax({
        url: "/Zapato_Talla/" + action,
        data: {
            id: data.val(),
            cantidad: cantidad
        },
        type: "POST",
        error: function (a) {
            console.log(a.responseText);
        }
    }).done(function (result) {
        //console.log(result.cantidad);
        if (action !== 'eliminateSize') {
            row.find("td:eq(2)").text(result.cantidad);
        } else {
            $('#' + row.attr('id')).remove();
        }
    });
}

/////////////// Scripts para edicion de tallas ////////////////////////
