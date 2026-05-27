import { getClase } from "../GetClase.js";
import { render } from "./RenderClaseCard.js";

export async function createClaseCard() {
    const dni = localStorage.getItem("DniProfesor");
    const clases = await getClase(Number(DniProfesor));

    const container = document.getElementById("clasesContainer");
    container.innerHTML = "";

    if (!clases || clases.length === 0) {
        container.innerHTML = "<p>No tenés clases registradas</p>";
        return;
    }

    clases.forEach(c => {
        const card = render(c);
        container.appendChild(card);
    });
}