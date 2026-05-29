const asistencias=[

{
id:1,
jugador:"Agustina López",
estado:"Presente"
},

{
id:2,
jugador:"Bruno Martínez",
estado:"Ausente"
},

{
id:3,
jugador:"Carla Díaz",
estado:"Presente"
}

];


function renderizarEliminarAsistencia(
idEntrenamiento
){

contenidoPrincipal.innerHTML=`

<header class="topbar">

<h1>

Eliminar asistencia

</h1>

<div class="user">

👤 Admin

</div>

</header>

<section>

<h2>

Entrenamiento
#${idEntrenamiento}

</h2>

<div
class="contenedor-asistencias"
>

</div>

</section>

`;

const contenedor=

document.querySelector(
".contenedor-asistencias"
);

asistencias.forEach(
asistencia=>{

contenedor.innerHTML+=`

<div class="fila-asistencia">

<div>

<h3>

${asistencia.jugador}

</h3>

<p>

${asistencia.estado}

</p>

</div>

<button

class="btn-eliminar"

onclick=
"eliminarAsistencia(${asistencia.id})"

>

Eliminar

</button>

</div>

`;

});

}


function eliminarAsistencia(id){

const indice=
asistencias.findIndex(
a=>a.id==id
);

if(indice!=-1){

asistencias.splice(
indice,
1
);

renderizarEliminarAsistencia(
1
);

}

}