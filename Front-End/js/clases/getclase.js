import {getData} from "../Global/ApiServices.js"
export async function getClase(dniProfesor)
{
    const endpointUrl =`clase/${dniProfesor}`;
    const reservas = await getData(endpointUrl);
    return clases;
}