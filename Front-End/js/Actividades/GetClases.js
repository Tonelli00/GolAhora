import { getData } from "../Global/ApiServices.js";

export async function getClases(){
    const endpointUrl = "Clase";
    return await getData(endpointUrl);
}