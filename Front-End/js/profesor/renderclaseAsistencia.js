const entrenamientos=[

{
id:1,
nombre:"Entrenamiento Juveniles",
horario:"Lun/Mié 18:00",
cancha:"Cancha 2",
jugadores:8
},

{
id:2,
nombre:"Entrenamiento Reserva",
horario:"Mar/Jue 19:30",
cancha:"Cancha 1",
jugadores:10
},

{
id:3,
nombre:"Entrenamiento Primera",
horario:"Viernes 20:00",
cancha:"Cancha 3",
jugadores:6
}

];


function renderizarEntrenamientosAsistencia(){

const contenedor=

document.querySelector(
".contenedor-entrenamientos"
);

contenedor.innerHTML="";

entrenamientos.forEach(entrenamiento=>{

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

<span class="jugadores">

${entrenamiento.jugadores}
jugadores

</span>

<button

class="btn-pasar-lista"

onclick="abrirAsistencia(${entrenamiento.id})"

>

Pasar lista

</button>

</div>

`;

});

}

function abrirAsistencia(idEntrenamiento){

renderizarAsistencia(
idEntrenamiento
);

}