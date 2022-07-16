// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Busqueda dentro del DOM de los inputs que tengan el name "type_flight"
//let radioButtons = document.querySelectorAll('input[name=type_flight]');

//recorrimos todos los elementos encontrados y le agregamos un evento de tipo clic 
/*radioButtons.forEach(f => f.addEventListener("click", function () {
    //deferenciamos por el valor del input y redirigimos a una pagina en concreto
    if (this.value.toLowerCase() === "nacionales") {
        window.location.href = "https://localhost:5001/Vuelos/Nacionales";
    } else {
        window.location.href = "https://localhost:5001/Vuelos/Internacionales";
    }
}));*/

function mostrarError(form) {
    let nodeError = '<div class="alert alert-danger" role="alert">El origen y el destino no pueden ser iguales!</div>'
    form.innerHTML += nodeError;
}

//obtengo mi formulario
let form = document.querySelector('form');
//le agrego un event listener
form.addEventListener('submit', function (event) {
    //obtengo el valor dentro de los select
    let origin = document.querySelector('select[name=origin]').value;
    let destination = document.querySelector('select[name=destination]').value;
    //imprimo por consola para ver si es que se obtuvieron bien los datos
    console.log(origin, destination);
    //comparo el origen y el destino
    if (origin === destination) {
        mostrarError(form);
        //en caso de que sean iguales cancelo el envío del formulario
        event.preventDefault();
    }
});

//obtengo el nodo que es el select con el name origin
let origin = document.querySelector('select[name=origin]');

//le agrego un evento cuando su valor o selección cambie
origin.addEventListener('change', function () {
    //obtengo los options del select destination
    let children = document.querySelector('select[name=destination]').children;
    //los recorro
    for (i = 0; i < children.length; i++) {
        //pregunto su es igual al del origen seleccionado
        if (children[i].innerText === this.value) {
            //en caso de ser igual lo escondo
            children[i].style = "display:none!important";
        } else {
            //en otro caso lo muestro
            children[i].style = "display:block!important";
        }
    }
});



