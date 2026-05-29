import { postData } from "../Global/ApiServices.js";

export async function crearCompeticion(tipo,nombre,descripcion,cupo,precio)
{
    const endpointUrl = "Competencia"
    const body = 
    {   
       tipo:tipo,
       nombre:nombre,
       descripcion:descripcion,
       cupos:cupo,
       precio:precio
    };
    return await postData(endpointUrl,body);
}