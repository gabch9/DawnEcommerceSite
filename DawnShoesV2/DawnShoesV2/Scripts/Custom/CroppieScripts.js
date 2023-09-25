/////////////// Croppie scripts  ////////////////////////////
// Start upload preview image
var $uploadCrop,
    tempFilename,
    rawImg,
    imageId;

var formData = new FormData();



function readFile(input) {
    $uploadCrop = $('#upload-demo').croppie({
        viewport: {
            width: 300,
            height: 300
        },
        enforceBoundary: false,
        enableExif: true
    });
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('.upload-demo').addClass('ready');
            $('#cropImagePop').modal('show');
            rawImg = e.target.result;
        };
        reader.readAsDataURL(input.files[0]);
    }
    else {
        swal("Sorry - you're browser doesn't support the FileReader API");
    }
}

function EnviarInfo($croppedResult) {
    
}

$('#cropImagePop').on('shown.bs.modal', function () {
    // alert('Shown pop');
    $uploadCrop.croppie('bind', {
        url: rawImg
    }).then(function () {
        console.log('jQuery bind complete');
    });
});

$('#cerrarModalBtn').on("click", function (ev) {
    $uploadCrop.croppie('destroy');
    $uploadCrop = undefined;
});

$('#cropImageBtn').on("click", function (ev) {
    //Aqui va a guardar el valor del boton que es el id del estilo. Se va a usar para pasar por ajax
    var id = $(this).val();

    //Se obtiene el resultado final del crop
    $uploadCrop.croppie('result', {
        type: 'canvas',
        size: 'viewport',
        format: 'jpeg'
    }).then(function (response) {
        //el response va a tener todos los datos de la imagen recortada en un blob

        $.ajax({
            type: 'POST',
            data:
            {
                "estiloDMId": id,
                "blob": response
            },
            //se contacta el controller
            url: "/AdminEstilo/GuardarImagen",

            //si todo sale bien se concatena la imagen nueva a la galeria
            success: function (data) {

                //variable para guardar el tipo de boton dependiendo de la imagen. Si es principal la clase lleva outline, si no lo es no lo lleva
                var esPrincipal = '';

                //Se evalua el bool y dependiendo de lo que sea se construye el string para concatenar mas adelante
                if (data.EsPrincipal === true) {
                    esPrincipal =
                        "<div class='col text-center'>" +
                        "<button type='button' class='btn btn-warning'><img src='/Content/Plugins/iconic-master/png/star-3x.png' class='align-top' /></button>" +
                        "</div>";
                } else {
                    esPrincipal =
                        "<div class='col text-center'>" +
                        "<button type='button' class='btn btn-outline-warning'><img src='/Content/Plugins/iconic-master/png/star-3x.png' class='align-top' /></button>" +
                        "</div>";
                }

                $('#Galeria').append
                    (
                    ""+
                    "<div class='col-sm-4'>" +
                        "<div class='col-sm-4'><br /></div>" +
                        "<div class='col-sm-12 img-thumbnail'>" +
                            "<div class='row text-center'>" +
                                "<div class='col-sm-12'>" +
                                    "<hr />" +
                                "</div>" +
                                "<div class='col-sm-12'>" +
                                    "<img src='" + data.Path + "' class='img-fluid rounded' />" +
                                "</div>" +
                                "<div class='col-sm-12'>" +
                                    "<hr />" +
                                "</div>" +
                            "</div>" +
                            "<div class='row'>" +
                                //Se concatena el boton que se contruyo arriba
                                esPrincipal +
                                "<div class='col text-center'>" +
                                    "<button type='button' class='btn btn-outline-danger'><img src='/Content/Plugins/iconic-master/png/trash-3x.png' class='align-top' /></button>" +
                                "</div>" +
                            "</div>" +
                            "<hr />" +
                        "</div>" + 
                    "</div >" +
                    ""
                );
                //Se destruye el croppie antes de esconder el modal
                $uploadCrop.croppie('destroy');
                $uploadCrop = undefined;

                //se esconde el modal
                $('#cropImagePop').modal("hide");

                //se muestra el mensaje diciendo que se hizo de manera exitosa la imagen
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
  
});

function GuardarImagenExitoso() {
    
}

$('.item-img').on('change', function () {
    imageId = $(this).data('id'); tempFilename = $(this).val();
    $('#cancelCropBtn').data('id', imageId); readFile(this);
});

				// End upload preview image

/////////////// Fin de scripts para crops de imagenes  ////////////////////////