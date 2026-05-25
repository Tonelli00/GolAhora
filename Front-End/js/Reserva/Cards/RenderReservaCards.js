export function render(reserva)
{
  
    const r = reserva.reservaHorarioCanchaResponse;

    const estado = reserva.esValida
        ? { text: "Pagada", class: "estado-pagada" }
        : { text: "Pendiente", class: "estado-pendiente" };

    const card = document.createElement("div");
    card.classList.add("reserva-card");

    card.innerHTML = `
      <div class="reserva-header">

        <div class="reserva-info">

          <span class="reserva-badge">
            Reserva #${reserva.reservaId}
          </span>

          <h3 class="reserva-title">
            ${reserva.nombreCancha}
          </h3>

          <span class="reserva-sub">
            DNI ${reserva.dniCliente}
          </span>

          <span class="estado-badge ${estado.class}">
            ${estado.text}
          </span>

        </div>

        <div class="reserva-price">
          $${reserva.total.toLocaleString("es-AR")}
        </div>

      </div>

      <div class="reserva-body">

        <div class="reserva-meta">

          <span class="meta-pill">${r.fecha}</span>
          <span class="meta-pill">${r.horaInicio} - ${r.horaFin}</span>

        </div>

        <div class="reserva-actions">
          <button class="cancelar-btn">Cancelar reserva</button>
        </div>

      </div>
    `;

     card.querySelector(".reserva-header")
        .addEventListener("click", () => {
            card.classList.toggle("open");
        });

    const btnCancelar = card.querySelector(".cancelar-btn");

    btnCancelar.addEventListener("click", async (e) => {
        e.stopPropagation();

        const confirm = await Swal.fire({
            icon: "warning",
            title: "Cancelar reserva",
            text: "¿Seguro que querés cancelar esta reserva?",
            showCancelButton: true,
            confirmButtonText: "Sí, cancelar",
            cancelButtonText: "No"
        });

        if (!confirm.isConfirmed) return;

        try {
            await eliminarReserva(reserva.reservaId);

            Swal.fire({
                icon: "success",
                title: "Reserva cancelada",
                timer: 2000,
                showConfirmButton: false
            });

            card.remove();

        } catch (err) {
            Swal.fire({
                icon: "error",
                title: "Error al cancelar",
                text: err.message
            });
        }
    });

    return card;
}

