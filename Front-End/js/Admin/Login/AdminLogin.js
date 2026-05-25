import {postData} from "../../Global/ApiServices.js"
export async function adminLogin() {
    
    const correo = document.getElementById("email").value;
    const psw = document.getElementById("password").value;
    console.log(correo,psw)
    const endpointUrl = "Administrador/login"

    const body =
    {   
        correo:correo,
        password:psw
    }
    try
    {
        const response = await postData(endpointUrl,body);

        if(localStorage.getItem("dni"))
        {
            localStorage.removeItem("dni")    
        }
        if(localStorage.getItem("nombre"))
        {
            localStorage.removeItem("nombre")    
        }
        if(localStorage.getItem("logged"))
        {
            localStorage.removeItem("logged")    
        }

        localStorage.setItem("dni",response.dni);
        localStorage.setItem("nombre",response.nombre);
        localStorage.setItem("Adminlogged",true);
        
        Swal.fire({
        toast: true,
        position: "bottom-end",
        icon: "success",
        title: "Sesión iniciada correctamente",
        showConfirmButton: false,
        timer: 2500,
        timerProgressBar: true,

        customClass: {
            popup: "toast-golahora toast-popup-success",
            title: "toast-title"
        }
        });
    setTimeout(() => {
      window.location.href = 'admin.html';

    }, 2500);
    }
    
    catch(error)
    {
    Swal.fire({
      toast: true,
      position: "bottom-end",
      icon: "error",
      title: error.message ?? "Credenciales invalidas",
      showConfirmButton: false,
      timer: 2500,
      timerProgressBar: true,

      customClass: {
        popup: "toast-golahora toast-popup-error",
        title: "toast-title"
      }
    });

    }
}
window.adminLogin = adminLogin;