import { getData } from "../Global/ApiServices.js";

export async function getEntrenamientos() {
    const endpointUrl = "Entrenamiento";
    return await getData(endpointUrl);
}