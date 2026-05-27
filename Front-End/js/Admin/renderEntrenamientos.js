export function RenderAdminEntrenamientoCards(entrenamientos) {

  if (!Array.isArray(entrenamientos) || entrenamientos.length === 0) {
    return `
      <p style="color: rgba(255,255,255,0.4)">
        No hay entrenamientos disponibles.
      </p>
    `;
  }

  return `
    <div class="admin-entrenamientos-grid">

      ${entrenamientos.map(e => `

        <div class="admin-card">

          <div class="admin-card-header">

            <div>
              <h3 class="admin-card-title">
                Entrenamiento #${e.id_Entrenamiento}
              </h3>

              <p class="admin-card-subtitle">
                ${e.profesional?.nombre ?? ""} ${e.profesional?.apellido ?? ""}
              </p>
            </div>

            <span class="admin-badge">
              Activo
            </span>

          </div>

          <div class="admin-card-info">

            <div class="admin-info-item">
              <span class="admin-info-label">Cupo</span>
              <span class="admin-info-value">${e.cupo}</span>
            </div>

            <div class="admin-info-item">
              <span class="admin-info-label">Precio</span>
              <span class="admin-info-value">$${e.precio}</span>
            </div>

          </div>

          <div class="admin-card-extra">

            <div class="admin-professional-box">
              <span>${e.profesional?.correo ?? ""}</span>
              <span>
                ${e.profesional?.localidad ?? ""} - ${e.profesional?.pais ?? ""}
              </span>
            </div>

          </div>

          <div class="admin-card-actions">

            <button class="admin-btn admin-btn-edit">
              Editar
            </button>

            <button class="admin-btn admin-btn-delete">
              Eliminar
            </button>

          </div>

        </div>

      `).join("")}

    </div>
  `;
}