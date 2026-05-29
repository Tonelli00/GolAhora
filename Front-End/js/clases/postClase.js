import { postData } from "../Global/ApiServices.js";
export async function CrearClase(cupo,DniProfesor,precio) {

    const endpointUrl ='clase';
    
    const body =
    {
    cupo : cupo,
    DniProfesor : DniProfesor,
    precio : precio
    };
    return await postData(endpointUrl,body);
}