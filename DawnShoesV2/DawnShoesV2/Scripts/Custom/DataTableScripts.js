/////////////// Scripts para datatables  ////////////////////////

$(document).ready(function () {
    loadZapatosTable();
});

function loadZapatosTable() {
    $('#tablaEstilos').DataTable({
        ajax: {
            url: '/AdminEstilo/JsonArmarEstilosInfo',
            dataSrc: ''
        },
        "iDisplayLength": 10,
        "dom": '<"parteSuperior"f>t<"parteBaja"p><"clear">',
        responsive: true,
        columns:
            [
                {
                    data: 'Descripcion'
                },
                {
                    data: 'Descuento'
                },
                {
                    data: 'Color'
                },
                {
                    data: 'PrecioTotalVenta'
                },
                {
                    data: 'Ganancia'
                },
                {
                    data: 'Existencia'
                },
                {
                    render: function (data, type, row) {
                        var options = "<a href='/AdminEstilo/PagDetallesEstiloAdm?estiloDMId=" + row.EstiloDMId + "' class='detalles' style='padding:10px'><img src='/Content/Plugins/iconic-master/png/info-3x.png'/></a>";
                        if (row.Existencia === 0) {
                            options = options + "<button class='eliminar' style='padding:10px; border:none; background-color: rgba(0, 0, 0, 0)' value='" + row.EstiloDMId + "'><img src='/Content/Plugins/iconic-master/png/trash-3x.png'/></button>";
                        }
                        return options;
                    }
                }
            ],
        "language": {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Cantidad de registros: _MENU_",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ningún dato disponible en esta tabla",
            "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sInfoPostFix": "",
            "sSearch": "",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
            }
        }
    });

    //Agregar estilos custom para la tabla

    //custom input
    //se convierte la parte superior y baja de la tabla para mover los items
    $('.parteSuperior').addClass("row text-left");
    $('.parteBaja').addClass("row");

    //Se hace una columna para alinear la paginacion
    $('#tablaEstilos_paginate').addClass("col-sm-12 text-center");
    //padding para que el text box se alinie
    $('.parteSuperior').css("padding", "6px");
    //Se cambia el placeholder del campo y se le asigna la clase de form para que se vea como los otros forms
    $('#tablaEstilos_filter input').addClass('form-control mr-sm-12');
    $('#tablaEstilos_filter input').attr("placeholder", "Escriba aquí para buscar");
    
    
}


/////////////// Fin Scripts para datatables  ////////////////////////


/////////////// Scripts para los botones de eliminar de datatables  ////////////////////////


$('#tablaEstilos tbody').on('click', 'button', function (e) {
    e.preventDefault();
    e.stopImmediatePropagation();
    var data = $(this);
    var row = $(this).closest('tr');
    if (data.hasClass("eliminar")) {
        var idZ = $(this).val();
        $.ajax({
            url: "/AdminEstilo/BorrarEstilo",
            data: {
                estiloDMId: $(this).val()
            },
            type: "POST",
            error: function (a) {
                console.log("Ocurrio un error a la hora de guardar el estilo");
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
        }).done(function (result) {
            $('#tablaEstilos').DataTable().ajax.reload();

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
        });
    }
});



/////////////// Find de Scripts para los botones de eliminar de datatables  ////////////////////////
