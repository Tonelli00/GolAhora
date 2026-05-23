
using Application.DTOs.Request.Administrador;
using Application.DTOs.Request.Cliente;
using Application.DTOs.Response;
using Application.Exceptions;
using Application.Interfaces.Administrador;
using BCrypt.Net;
using Domain.Entities;

namespace Application.UseCases
{
    public class AdministadorService : IAdministradorService
    {
        private readonly IAdministradorQuery _query;
        private readonly IAdministradorCommand _command;

        public AdministadorService(IAdministradorQuery query, IAdministradorCommand command)
        {
            _query = query;
            _command = command;
        }

        public async Task<AdministradorResponse> Login(LoginRequest request)
        {
            if (String.IsNullOrEmpty(request.Correo))
            {
                throw new ExceptionBadRequest("Complete el campo correo");
            }
            if (String.IsNullOrEmpty(request.Password))
            {
                throw new ExceptionBadRequest("Complete el campo contraseña");
            }

            var administrador = await _query.Login(request.Correo);

            if (!BCrypt.Net.BCrypt.Verify(request.Password,administrador.Password)) 
            {
                throw new ExceptionBadRequest("Credenciales invalidas");
            }

            return new AdministradorResponse
            {
                Dni = administrador.Dni,
                Nombre = administrador.Nombre,
                Apellido = administrador.Apellido,
            };
        }


        public async Task<AdministradorResponse> RegistrarAdministrador(CrearAdministradorRequest request)
        {
            if(request == null) 
            {
                throw new ExceptionBadRequest("Ingrese los datos correspondientes");
            }
            if (request.Dni <=0)
            {
                throw new ExceptionBadRequest("Ingrese un DNI valido");
            }
            if (String.IsNullOrEmpty(request.Nombre))
            {
                throw new ExceptionBadRequest("Complete el campo nombre");
            }
            if (String.IsNullOrEmpty(request.Apellido))
            {
                throw new ExceptionBadRequest("Complete el campo apellido");
            }
            if (String.IsNullOrEmpty(request.Localidad))
            {
                throw new ExceptionBadRequest("Complete el campo localidad");
            }
            if (String.IsNullOrEmpty(request.Pais))
            {
                throw new ExceptionBadRequest("Complete el campo pais");
            }
            if (String.IsNullOrEmpty(request.Correo))
            {
                throw new ExceptionBadRequest("Complete el campo correo");
            }
            if (String.IsNullOrEmpty(request.Password))
            {
                throw new ExceptionBadRequest("Complete el campo contraseña");
            }
            if (request.FechaNac > DateOnly.FromDateTime(DateTime.Now))
            {
                throw new ExceptionBadRequest("Ingrese un nacimiento valido");
            }

            var HashedPsw = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var admin = new Administrador
            {
                Dni = request.Dni,
                Nombre = request.Nombre,
                Apellido = request.Apellido,
                Localidad = request.Localidad,
                Pais = request.Pais,
                Correo = request.Correo,
                Password = HashedPsw,
                FechaNac = request.FechaNac,
                Estado = true
            };

            var adminCreado = await _command.CrearAdministrador(admin);

            return new AdministradorResponse
            {
                Dni = adminCreado.Dni,
                Nombre = adminCreado.Nombre,
                Apellido = adminCreado.Apellido,
            };

        }
    }
}
