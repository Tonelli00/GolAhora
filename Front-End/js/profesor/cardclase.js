function crearCardEntrenamiento(entrenamiento){

return `

<div class="card-entrenamiento">

<div class="card-header">

<h2 class="nombre">

${entrenamiento.nombre}

</h2>

</div>

<div class="card-body">

<p class="horario">

🕒 ${entrenamiento.horario}

</p>

<p class="cancha">

⚽ ${entrenamiento.cancha}

</p>

</div>

<div class="card-footer">

<span class="jugadores">

${entrenamiento.jugadores}
jugadores

</span>

<span class="estado
${entrenamiento.estado}">

${entrenamiento.estado}

</span>

</div>

</div>

`;

}