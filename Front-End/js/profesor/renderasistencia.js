const jugadores=[

{
id:"P101",
nombre:"Agustina López",
estado:"Presente"
},

{
id:"P102",
nombre:"Bruno Martínez",
estado:"Ausente"
},

{
id:"P103",
nombre:"Carla Díaz",
estado:"Presente"
},

{
id:"P104",
nombre:"Diego Fernández",
estado:"Presente"
}

];


function renderizarAsistencia(
idEntrenamiento
){

contenidoPrincipal.innerHTML=`

<header class="topbar">

<h1>

Asistencia

</h1>

<div class="user">

👤 Admin

</div>

</header>

<section class="lista-asistencia">

<div class="cabecera-asistencia">

<h2>

Entrenamiento #${idEntrenamiento}

</h2>

</div>

<div
class="contenedor-jugadores"
>

</div>

</section>

`;

const contenedor=

document.querySelector(
".contenedor-jugadores"
);

jugadores.forEach(jugador=>{

contenedor.innerHTML+=
crearItemAsistencia(
jugador
);

});

agregarEventos();

}