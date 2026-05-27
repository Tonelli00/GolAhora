function crearItemAsistencia(
jugador
){

return`

<div class="fila-jugador">

<div class="datos-jugador">

<div class="circulo">

${jugador.nombre
.charAt(0)}

</div>

<div>

<h3>

${jugador.nombre}

</h3>

<p>

${jugador.id}

</p>

</div>

</div>


<div class="acciones">

<button
class="
btn-presente
${jugador.estado=="Presente"?"activo":""}
">

✓ Presente

</button>

<button
class="
btn-ausente
${jugador.estado=="Ausente"?"activo":""}
">

✗ Ausente

</button>

</div>

</div>

`;

}


function agregarEventos(){

document
.querySelectorAll(
".fila-jugador"
)
.forEach(fila=>{

const presente=
fila.querySelector(
".btn-presente"
);

const ausente=
fila.querySelector(
".btn-ausente"
);

presente.addEventListener(
"click",
()=>{

presente.classList.add(
"activo"
);

ausente.classList.remove(
"activo"
);

});

ausente.addEventListener(
"click",
()=>{

ausente.classList.add(
"activo"
);

presente.classList.remove(
"activo"
);

});

});

}