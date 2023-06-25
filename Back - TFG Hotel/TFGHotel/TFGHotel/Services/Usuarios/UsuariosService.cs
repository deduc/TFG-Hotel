using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFGHotel.Context;
using TFGHotel.DTO;
using TFGHotel.Entities;
//using TFGHotel.Utilities;

namespace TFGHotel.Services.Usuarios
{
    public class UsuariosService : IUsuariosService
    {
        public FCT10Context _context { get; set; }

        // constructor
        public UsuariosService(FCT10Context context)
        {
            _context = context;
        }

        // -- GET --
        public List<UsuariosDTO> GetUsuarios()
        {
            // obtengo todos los datos de la tabla usuarios
            var usuarios = _context.Usuarios.ToList();

            /*
             * retorno los datos que YO QUIERO devolver, en forma de lista, 
             * a los clientes que hagan una peticion http en modo GET
             */
            return usuarios.Select(resultadoSelect => new UsuariosDTO()
            {
                NOMBRE = resultadoSelect.NOMBRE,
                APELLIDOS = resultadoSelect.APELLIDOS,
                USERNAME = resultadoSelect.USERNAME
            }).ToList();
        }

        public List<string> AddNewUser(UsuariosDTO usuarioDTO)
        {
            var errorsList = this.CheckIfUniqueValues(usuarioDTO.USERNAME, usuarioDTO.EMAIL, usuarioDTO.DNI);
            int errorsNumber = errorsList.Count;
            
            if (errorsNumber == 0)
            {
                USUARIOS usuario = new()
                {
                    ID_USUARIO = 0,
                    USERNAME = usuarioDTO.USERNAME,
                    EMAIL = usuarioDTO.EMAIL,
                    DNI = usuarioDTO.DNI,
                    NOMBRE = usuarioDTO.NOMBRE,
                    APELLIDOS = usuarioDTO.APELLIDOS,
                    PASS = usuarioDTO.PASSWORD,
                    FOTO_DE_PERFIL_BASE_64 = "",
                    ADMINISTRADOR = false,
                    USUARIO_ACTIVO = true,
                };

                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
            }

            return errorsList;
        }

        public List<string> CheckIfUniqueValues(string username, string email, string dni)
        {
            List<string> errorList = new List<string> { };

            if ((_context.Usuarios.Any(tabla => tabla.USERNAME == username)))
            {
                errorList.Add("ERROR: Campo username repetido");
            }
            if ((_context.Usuarios.Any(tabla => tabla.EMAIL == email)))
            {
                errorList.Add("ERROR: Campo email repetido.");
            }
            if ((_context.Usuarios.Any(tabla => tabla.DNI == dni)))
            {
                errorList.Add("ERROR: Campo dni repetido.");
            };
            if ((_context.Usuarios.Any(tabla => tabla.PASS.Length == 8)))
            {
                errorList.Add("ERROR: Campo contraseña no tiene 8 o más caracteres.");
            };

            return errorList;
        }

        // -- DELETE --
        public bool DeleteUserById(int idUsuarioABorrar)
        {
            var existe = _context.Usuarios.Any(columna => columna.ID_USUARIO == idUsuarioABorrar);

            if (!existe)
            {
                return false;
            }

            // Ejecuto una consulta Remove en la base de datos
            // No estoy creando un nuevo autor, lo estoy instanciando
            _context.Remove(new USUARIOS() { ID_USUARIO = idUsuarioABorrar });
            _context.SaveChanges();

            return true;
        }


        public UsuarioLoginDTO LoginUsuario(UsuarioLoginDTO usuario)
        {
            USUARIOS LoginUser = _context.Usuarios
                .Where(x => x.EMAIL == usuario.Email && x.PASS == usuario.Password)
                .FirstOrDefault();


            if (LoginUser != null)
            {
                UsuarioLoginDTO usuarioLoginDTO = new UsuarioLoginDTO()
                {
                    Email = LoginUser.EMAIL,
                    Password = LoginUser.PASS,
                };

                return usuarioLoginDTO;
            }
            else
            {
                return new UsuarioLoginDTO() { Email = "", Password = "" };
            }

            // fin metodo
        }

        public Boolean ComprobarSiLoginCorrecto(UsuarioLoginDTO datosLogin)
        {
            USUARIOS LoginUser = _context.Usuarios
                .Where(x => x.EMAIL == datosLogin.Email && x.PASS == datosLogin.Password)
                .FirstOrDefault();

            if(LoginUser != null)
            {
                return true;
            }

            return false;
        }

        public USUARIOS GetUserDataByEmail(string email)
        {
            USUARIOS usuario = _context.Usuarios
                .FirstOrDefault(x => x.EMAIL == email);

            if(usuario != null)
            {
                return usuario;
            }
            else
            {
                throw new Exception("ERROR: No existe un usuario con ese correo electrónico");
            }
        }

        public USUARIOS GetUserDataByUsername(string username)
        {
            USUARIOS usuario = _context.Usuarios
                .SingleOrDefault( u => u.USERNAME.ToLower() == username.ToLower() );



            if (usuario != null)
            {
                return usuario;
            }
            else
            {
                throw new Exception("ERROR: Usuario " + username + " no encontrado.");
            }
        }

        public bool DoCheckIfUserExists(string username)
        {
            bool semaforo;

            USUARIOS usuario = _context.Usuarios
                .Where(x => x.USERNAME == username)
                .FirstOrDefault();

            if (usuario != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DoChangeUserPassword(DoChangeUserPasswordDTO obj)
        {
            USUARIOS usuario = _context.Usuarios
                .Where(x =>
                    x.USERNAME == obj.Username &&
                    x.PASS == obj.OldPassword
                )
                .FirstOrDefault();

            if(usuario != null)
            {
                usuario.PASS = obj.NewPassword;
                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public bool CambiarFotoPerfilUsuario(UsernameFotoPerfilBase64DTO usernameFotoPerfilObj)
        {
            bool returnValue;

            USUARIOS usuario = _context.Usuarios
                .Where(x => x.USERNAME == usernameFotoPerfilObj.Username)
                .FirstOrDefault();

            if(usuario != null)
            {
                usuario.FOTO_DE_PERFIL_BASE_64 = usernameFotoPerfilObj.FotoPerfilBase64;
                _context.SaveChanges();

                returnValue = true;
            }
            else returnValue = false;

            return returnValue;
        }



        // fin clase
    }

    // fin namespace
}