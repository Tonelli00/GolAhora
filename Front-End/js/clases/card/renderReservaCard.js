export function render(clase) {

    const ocupacion = clase.inscriptos?.length ?? 0;
    const porcentaje = clase.cupo > 0 ? (ocupacion / clase.cupo) * 100 : 0;

    const estadoCupo =
        porcentaje >= 100
            ? { text: "Sin cupo", class: "estado-sin-cupo" }
            : porcentaje >= 75
            ? { text: "Casi lleno", class: "estado-casi-lleno" }
            : { text: "Disponible", class: "estado-disponible" };

    const card = document.createElement("div");
    card.classList.add("clase-card");

    card.innerHTML = `
      <div class="clase-header">

        <div class="clase-info">

          <span class="clase-badge">
            Clase #${clase.idClase}
          </span>

          <h3 class="clase-title">
            Clase de profesor ${clase.dniProfesor}
          </h3>

          <span class="clase-sub">
            DNI Profesor: ${clase.dniProfesor}
          </span>

          <span class="estado-badge ${estadoCupo.class}">
            ${estadoCupo.text}
          </span>

        </div>

        <div class="clase-price">
          $${clase.precio.toLocaleString("es-AR")}
        </div>

      </div>

      <div class="clase-body">

        <div class="clase-meta">

          <span class="meta-pill">
            <i class="meta-icon">👥</i>
            ${ocupacion} / ${clase.cupo} inscriptos
          </span>

          <div class="cupo-bar">
            <div class="cupo-fill ${estadoCupo.class}" style="width: ${Math.min(porcentaje, 100)}%"></div>
          </div>

        </div>

        <div class="clase-actions">
          <button class="inscriptos-btn">Ver inscriptos</button>
          <button class="eliminar-btn">Eliminar clase</button>
        </div>

      </div>

      <div class="clase-inscriptos-panel" style="display:none;">
        <ul class="inscriptos-list">
          ${
            clase.inscriptos?.length
                ? clase.inscriptos
                      .map(
                          (i) => `<li class="inscripto-item">DNI ${i.dniCliente ?? i}</li>`
                      )
                      .join("")
                : "<li class='inscripto-item sin-datos'>Sin inscriptos aún</li>"
          }
        </ul>
      </div>
    `;

    // Toggle del body al hacer click en el header
    card.querySelector(".clase-header")
        .addEventListener("click", () => {
            card.classList.toggle("open");
        });

    // Botón ver inscriptos
    const btnInscriptos = card.querySelector(".inscriptos-btn");
    const panel = card.querySelector(".clase-inscriptos-panel");

    btnInscriptos.addEventListener("click", (e) => {
        e.stopPropagation();
        const abierto = panel.style.display !== "none";
        panel.style.display = abierto ? "none" : "block";
        btnInscriptos.textContent = abierto ? "Ver inscriptos" : "Ocultar inscriptos";
    });

    // Botón eliminar clase
    const btnEliminar = card.querySelector(".eliminar-btn");

    btnEliminar.addEventListener("click", async (e) => {
        e.stopPropagation();

        const confirm = await Swal.fire({
            icon: "warning",
            title: "Eliminar clase",
            text: "¿Seguro que querés eliminar esta clase?",
            showCancelButton: true,
            confirmButtonText: "Sí, eliminar",
            cancelButtonText: "No"
        });

        if (!confirm.isConfirmed) return;

        try {
            await eliminarClase(clase.idClase);

            Swal.fire({
                icon: "success",
                title: "Clase eliminada",
                timer: 2000,
                showConfirmButton: false
            });

            card.remove();

        } catch (err) {
            Swal.fire({
                icon: "error",
                title: "Error al eliminar",
                text: err.message
            });
        }
    });

    return card;
}