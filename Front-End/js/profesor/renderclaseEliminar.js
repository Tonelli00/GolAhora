const entrenamientosEliminar=[

{
id:1,
nombre:"Entrenamiento Juveniles",
horario:"Lun/Mié 18:00",
cancha:"Cancha 2"
},

{
id:2,
nombre:"Entrenamiento Reserva",
horario:"Mar/Jue 19:30",
cancha:"Cancha 1"
},

{
id:3,
nombre:"Entrenamiento Primera",
horario:"Viernes 20:00",
cancha:"Cancha 3"
}

];


function renderizarEntrenamientosEliminar(){

const contenedor=
document.querySelector(
".contenedor-entrenamientos"
);

contenedor.innerHTML="";

entrenamientosEliminar.forEach(
entrenamiento=>{

contenedor.innerHTML+=`

<div class="card-entrenamiento">

<h2>

${entrenamiento.nombre}

</h2>

<p>

🕒 ${entrenamiento.horario}

</p>

<p>

⚽ ${entrenamiento.cancha}

</p>

<button

class="btn-eliminar-lista"

onclick=
"abrirEliminarAsistencia(${entrenamiento.id})"

>

Ver asistencias

</button>

</div>

`;

});

}

function abrirEliminarAsistencia(
idEntrenamiento
){

renderizarEliminarAsistencia(
idEntrenamiento
);

}