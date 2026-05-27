export function RenderCompetitionAdminCards(competiciones)
{
  if (!competiciones?.length) {

    return `
      <p style="color: rgba(255,255,255,0.4)">
        No se encontraron competencias.
      </p>
    `;
  }

  return `

    <div class="admin-competencias-grid">

      ${competiciones.map(c => `

        <div class="competencia-admin-card">

          <div class="competencia-admin-header">

            <div>

              <span class="competencia-badge">
                ${c.tipo ?? "Competencia"}
              </span>

              <h3 class="competencia-title">
                ${c.nombre}
              </h3>

            </div>

            <span class="competencia-precio">
              $${c.precio ?? 0}
            </span>

          </div>

          <div class="competencia-body">

            <p class="competencia-descripcion">
              ${c.descripcion ?? "Sin descripción"}
            </p>

            <div class="competencia-info">

              <div class="competencia-info-item">

                <span class="competencia-label">
                  Cupos
                </span>

                <span class="competencia-value">
                  ${c.cupos ?? 0}
                </span>

              </div>

              <div class="competencia-info-item">

                <span class="competencia-label">
                  Estado
                </span>

                <span class="competencia-value">
                  ${c.estado ? "Activa" : "Inactiva"}
                </span>

              </div>

            </div>

          </div>

          <div class="competencia-footer">

            <button 
              class="competencia-btn competencia-btn-edit"
              data-id="${c.competenciaId}"
            >
              Editar
            </button>

            <button 
              class="competencia-btn competencia-btn-delete"
              data-id="${c.competenciaId}"
            >
              Eliminar
            </button>

          </div>

        </div>

      `).join("")}

    </div>
  `;
}