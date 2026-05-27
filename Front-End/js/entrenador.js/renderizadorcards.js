const entrenamientos=[

{
nombre:"Entrenamiento Juveniles",
horario:"Lun/Mié 18:00",
cancha:"Cancha 2",
jugadores:8,
estado:"activo"
},

{
nombre:"Entrenamiento Reserva",
horario:"Mar/Jue 19:30",
cancha:"Cancha 1",
jugadores:10,
estado:"activo"
},

{
nombre:"Entrenamiento Primera",
horario:"Viernes 20:00",
cancha:"Cancha 3",
jugadores:6,
estado:"activo"
},

{
nombre:"Entrenamiento Femenino",
horario:"Lun/Vie 17:00",
cancha:"Cancha 4",
jugadores:7,
estado:"activo"
}

];

function renderizarEntrenamientos(){

const contenedor=
document.querySelector(
".contenedor-entrenamientos"
);

contenedor.innerHTML="";

entrenamientos.forEach(entrenamiento=>{

contenedor.innerHTML+=
crearCardEntrenamiento(
entrenamiento
);

});

}