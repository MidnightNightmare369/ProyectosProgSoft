using libr_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentacion.Pages
{
    public class IndexModel : PageModel
    {
        public bool EstaLogueado = false;
        public string? TipoUsuario { get; set; } // Nuevo campo para el tipo de usuario

        [BindProperty] public string? Email { get; set; }
        [BindProperty] public string? Contrasena { get; set; }

        public void OnGet()
        {
            var variable_session = HttpContext.Session.GetString("Usuario");
            var tipo_usuario_session = HttpContext.Session.GetString("TipoUsuario");

            if (!String.IsNullOrEmpty(variable_session))
            {
                EstaLogueado = true;
                TipoUsuario = tipo_usuario_session;
                return;
            }
        }
        public void OnPostBtClean()
        {
            try
            {
                Email = string.Empty;
                Contrasena = string.Empty;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtEnter()
        {
            try
            {
                if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Contrasena))
                {
                    OnPostBtClean();
                    return;
                }

                string credencialCompleta = Email + "." + Contrasena;
                string tipoUsuario = "";

                // Definir roles según credenciales
                switch (credencialCompleta)
                {
                    case "admin.123":
                        tipoUsuario = "Administrador";
                        break;
                    case "root001.6663":
                    case "root002.9639":
                        tipoUsuario = "Root";
                        break;
                    case "cj001.3693":
                    case "cj002.9999":
                    case "cj003.1266":
                        tipoUsuario = "Cajero";
                        break;
                    default:
                        OnPostBtClean();
                        return;
                }

                // Guardar en sesión
                HttpContext.Session.SetString("Usuario", Email!);
                HttpContext.Session.SetString("TipoUsuario", tipoUsuario);

                ViewData["Logged"] = true;
                EstaLogueado = true;
                TipoUsuario = tipoUsuario;
                OnPostBtClean();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtClose()
        {
            try
            {
                HttpContext.Session.Clear();
                HttpContext.Response.Redirect("/");
                EstaLogueado = false;
                TipoUsuario = null;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }


}