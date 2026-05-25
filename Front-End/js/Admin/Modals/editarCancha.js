import { putData } from "../../Global/ApiServices.js";

export async function editarCancha(cancha) {

    const modal = document.createElement("div");
    modal.classList.add("modal-overlay");

    modal.innerHTML = `
      <div class="modal-card">

        <h2>Editar cancha</h2>

        <div class="form-group">
          <label>Nombre</label>
          <input type="text" id="nombre" value="${cancha.nombre}" />
        </div>

        <div class="form-group">
          <label>Tipo de cancha ID</label>
          <input type="number" id="tipoCanchaId" value="${cancha.tipoCancha.id}" />
        </div>

        <hr style="margin:15px 0; opacity:0.2"/>

        <div class="horarios-header">
          <h3>Horarios</h3>
          <button type="button" class="btn-add">
            + Agregar día
          </button>
        </div>

        <div id="horariosContainer"></div>

        <div class="modal-actions">
          <button type="button" class="btn-cancelar">
            Cancelar
          </button>

          <button type="button" class="btn-guardar">
            Guardar
          </button>
        </div>

      </div>
    `;

    document.body.appendChild(modal);

    const container = modal.querySelector("#horariosContainer");

    const dias = {
        1: "Lunes",
        2: "Martes",
        3: "Miércoles",
        4: "Jueves",
        5: "Viernes",
        6: "Sábado",
        0: "Domingo"
    };

    // =========================
    // CREAR FILA
    // =========================

    function crearFila(data = null) {

        const row = document.createElement("div");

        row.classList.add("horario-row");

        row.innerHTML = `
          <select class="dia">

            <option value="1">Lunes</option>
            <option value="2">Martes</option>
            <option value="3">Miércoles</option>
            <option value="4">Jueves</option>
            <option value="5">Viernes</option>
            <option value="6">Sábado</option>
            <option value="0">Domingo</option>

          </select>

          <input 
            type="time" 
            class="inicio"
            value="${data?.horaInicio?.slice(0,5) || ""}"
          />

          <input 
            type="time" 
            class="fin"
            value="${data?.horaFin?.slice(0,5) || ""}"
          />

          <button type="button" class="btn-remove">
            ✕
          </button>
        `;

        // seleccionar día
        if (data?.dia !== undefined) {
            row.querySelector(".dia").value = data.dia;
        }

        // eliminar fila
        row.querySelector(".btn-remove")
            .addEventListener("click", () => {
                row.remove();
            });

        container.appendChild(row);
    }

    // =========================
    // AGRUPAR HORARIOS
    // =========================

    const agrupados = {};

    cancha.disponibilidad?.forEach(h => {

        if (!agrupados[h.dia]) {

            agrupados[h.dia] = {
                dia: h.dia,
                horaInicio: h.horaInicio,
                horaFin: h.horaFin
            };

        } else {

            if (h.horaInicio < agrupados[h.dia].horaInicio) {
                agrupados[h.dia].horaInicio = h.horaInicio;
            }

            if (h.horaFin > agrupados[h.dia].horaFin) {
                agrupados[h.dia].horaFin = h.horaFin;
            }
        }
    });

    // cargar filas agrupadas
    Object.values(agrupados).forEach(h => {
        crearFila(h);
    });

    // si no tiene horarios
    if (Object.keys(agrupados).length === 0) {
        crearFila();
    }

    // =========================
    // AGREGAR DÍA
    // =========================

    modal.querySelector(".btn-add")
        .addEventListener("click", () => {
            crearFila();
        });

    // =========================
    // CERRAR MODAL
    // =========================

    modal.querySelector(".btn-cancelar")
        .addEventListener("click", () => {
            modal.remove();
        });

    modal.addEventListener("click", (e) => {
        if (e.target === modal) {
            modal.remove();
        }
    });

    modal.querySelector(".btn-guardar")
        .addEventListener("click", async () => {

            const filas = container.querySelectorAll(".horario-row");

            const horarios = [];

            filas.forEach(f => {

                const dia = Number(
                    f.querySelector(".dia").value
                );

                const inicio =
                    f.querySelector(".inicio").value;

                const fin =
                    f.querySelector(".fin").value;

                if (!inicio || !fin) return;

                horarios.push({
                    dia,
                    horaInicio: inicio + ":00",
                    horaFin: fin + ":00"
                });
            });

            const body = {
                nombre:
                    modal.querySelector("#nombre").value || null,

                tipoCanchaId:
                    Number(
                        modal.querySelector("#tipoCanchaId").value
                    ),

                horarios
            };

            try {

                await putData(`Cancha/${cancha.idCancha}`,
                    body
                );

               Swal.fire({
                    toast: true,
                    position: "bottom-end",
                    icon: "success",
                    title: "Cancha actualizada con exito",
                    showConfirmButton: false,
                    timer: 2500,
                    timerProgressBar: true,

                    customClass: {
                        popup: "toast-golahora toast-popup-success",
                        title: "toast-title"
                    }
                    });

                setTimeout(()=>
                    {
                        location.reload()
                    },2500)

            } catch (err) {

               Swal.fire({
                    toast: true,
                    position: "bottom-end",
                    icon: "error",
                    title: err.message ?? "Ocurrio un error al actualizar",
                    showConfirmButton: false,
                    timer: 2500,
                    timerProgressBar: true,

                    customClass: {
                        popup: "toast-golahora toast-popup-error",
                        title: "toast-title"
                    }
                    });
            }
        });
}