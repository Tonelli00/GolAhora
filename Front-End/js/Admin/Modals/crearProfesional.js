import { postData } from "../../Global/ApiServices.js";

export function abrirModalCrearProfesional(tipo) {

  const modalExistente = document.querySelector(".modal-overlay");

  if(modalExistente) return;

  const modal = document.createElement("div");

  modal.classList.add("modal-overlay");

  modal.innerHTML = `

    <div class="modal-content">

      <div class="modal-header">

        <h2 class="modal-title">
          Crear ${tipo}
        </h2>

        <button class="modal-close">
          ✕
        </button>

      </div>

      <form class="modal-form" id="form-crear-profesional">

        <input type="number" id="dni" class="modal-input" placeholder="DNI">

        <input type="text" id="nombre" class="modal-input" placeholder="Nombre">

        <input type="text" id="apellido" class="modal-input" placeholder="Apellido">

        <input type="email" id="correo" class="modal-input" placeholder="Correo">

        <input type="password" id="password" class="modal-input" placeholder="Contraseña">

        <input type="text" id="localidad" class="modal-input" placeholder="Localidad">

        <input type="text" id="pais" class="modal-input" placeholder="País">

        <input type="date" id="fechaNac" class="modal-input">

        <input type="text" id="certificado" class="modal-input" placeholder="Certificado">

        <div class="modal-actions">

          <button type="button" class="btn-cancel">
            Cancelar
          </button>

          <button type="submit" class="btn-save">
            Guardar
          </button>

        </div>

      </form>

    </div>
  `;

  document.body.appendChild(modal);

  function cerrarModal() {
    modal.remove();
  }

  modal.querySelector(".modal-close")
    .addEventListener("click", cerrarModal);

  modal.querySelector(".btn-cancel")
    .addEventListener("click", cerrarModal);

  modal.querySelector("#form-crear-profesional")
    .addEventListener("submit", async (e) => {

      e.preventDefault();

      try {

        const fecha = new Date(
          document.querySelector("#fechaNac").value
        );

        const body = {

          dni: Number(document.querySelector("#dni").value),

          nombre: document.querySelector("#nombre").value,

          apellido: document.querySelector("#apellido").value,

          correo: document.querySelector("#correo").value,

          password: document.querySelector("#password").value,

          localidad: document.querySelector("#localidad").value,

          pais: document.querySelector("#pais").value,
          
          fechaNac: document.querySelector("#fechaNac").value,

          certificado: document.querySelector("#certificado").value
        };

        const endpoint =
          tipo === "Profesor"
            ? "Profesionales/profesores"
            : "Profesionales/entrenadores";

        const profesionalCreado =
          await postData(endpoint, body);

        Swal.fire({
          toast: true,
          position: "bottom-end",
          icon: "success",
          title: `${tipo} creado correctamente`,
          showConfirmButton: false,
          timer: 2500,
          timerProgressBar: true
        });



        const list =
          document.querySelector("#profesionales-list");

        const cardsGrid =
          list.querySelector(".profesionales-grid");

        if(cardsGrid){

          cardsGrid.insertAdjacentHTML(
            "beforeend",
            RenderProfesionalCards(
              [profesionalCreado],
              tipo
            ).replace(
              '<div class="profesionales-grid">',
              ""
            ).replace("</div>", "")
          );

        }

        cerrarModal();

      } catch(error) {

        console.error(error);

        Swal.fire({
          toast: true,
          position: "bottom-end",
          icon: "error",
          title: error.message ?? "Error al crear profesional",
          showConfirmButton: false,
          timer: 2500
        });
      }

    });
}