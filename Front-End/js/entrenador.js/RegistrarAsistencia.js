async function consultarInscriptos() {
  const idClase = document.getElementById('idClase').value;

  // Simulación de llamada al backend
  // En un caso real: fetch(`/api/inscripciones/${idClase}`)
  const alumnos = [
    { id: 1, nombre: "Juan Pérez" },
    { id: 2, nombre: "María Gómez" },
    { id: 3, nombre: "Carlos López" }
  ];

  let html = "<table><tr><th>Alumno</th><th>Estado</th></tr>";
  alumnos.forEach(a => {
    html += `
      <tr>
        <td>${a.nombre}</td>
        <td>
          <select data-id="${a.id}">
            <option value="ausente">Ausente</option>
            <option value="presente">Presente</option>
          </select>
        </td>
      </tr>`;
  });
  html += "</table><button onclick='guardarAsistencia()'>Guardar</button>";
  document.getElementById('listado').innerHTML = html;
}

async function guardarAsistencia() {
  const selects = document.querySelectorAll('#listado select');
  const cambios = Array.from(selects).map(s => ({
    idAlumno: s.dataset.id,
    estado: s.value
  }));

  // En un caso real: enviar al backend
  // await fetch('/api/asistencia', { method:'POST', body: JSON.stringify(cambios) })

  console.log("Cambios guardados:", cambios);
  alert("Asistencia guardada!");
}
