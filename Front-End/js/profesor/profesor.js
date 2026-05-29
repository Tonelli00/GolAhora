const btnConsultar =
document.getElementById(
"btnConsultar"
);

const btnRegistrarAsistencia =
document.getElementById(
"btnRegistrarAsistencia"
);

const contenidoPrincipal =
document.getElementById(
"contenidoPrincipal"
);

const btnEliminarAsistencia=
document.getElementById(
"btnEliminarAsistencia"
);




/* EVENTOS */

btnEliminarAsistencia.addEventListener(
"click",
mostrarEliminarAsistencia
);

btnConsultar.addEventListener(
"click",
mostrarEntrenamientos
);

btnRegistrarAsistencia.addEventListener(
"click",
mostrarPantallaAsistencia
);



function mostrarEntrenamientos(){

contenidoPrincipal.innerHTML=`

<header class="topbar">

<h1>
Panel Entrenador
</h1>

<div class="user">
👤 Admin
</div>

</header>

<section class="dashboard-entrenamientos">

<div class="perfil">

<div class="info">

<h2>
Mis entrenamientos
</h2>

<p>
Entrenamientos asignados
</p>

</div>

</div>

<div class="contenedor-entrenamientos">

</div>

</section>

`;

renderizarEntrenamientos();

}


function mostrarPantallaAsistencia(){

contenidoPrincipal.innerHTML=`

<header class="topbar">

<h1>

Registrar asistencia

</h1>

<div class="user">

👤 Admin

</div>

</header>

<section class="dashboard-entrenamientos">

<div class="perfil">

<div class="info">

<h2>

Seleccionar entrenamiento

</h2>

<p>

Elegí un entrenamiento para pasar asistencia

</p>

</div>

</div>

<div class="contenedor-entrenamientos">

</div>

</section>

`;

renderizarEntrenamientosAsistencia();

}

function mostrarEliminarAsistencia(){

contenidoPrincipal.innerHTML=`

<header class="topbar">

<h1>

Eliminar asistencia

</h1>

<div class="user">

👤 Admin

</div>

</header>

<section class="dashboard-entrenamientos">

<div class="perfil">

<div class="info">

<h2>

Seleccionar entrenamiento

</h2>

<p>

Elegí un entrenamiento

</p>

</div>

</div>

<div class="contenedor-entrenamientos">

</div>

</section>

`;

renderizarEntrenamientosEliminar();

}