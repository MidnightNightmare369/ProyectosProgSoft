namespace asp_presentacion.Helpers
{
    public static class PermisosHelper
    {
        public static bool TienePermisoGestionCaja(string? tipoUsuario)
        {
            return tipoUsuario == "Administrador" || tipoUsuario == "Root" || tipoUsuario == "Cajero";
        }

        public static bool TienePermisoConfiguracion(string? tipoUsuario)
        {
            return tipoUsuario == "Administrador" || tipoUsuario == "Root";
        }

        public static bool TienePermisoGestionEmpleados(string? tipoUsuario)
        {
            return tipoUsuario == "Administrador" || tipoUsuario == "Root";
        }

        public static bool TienePermisoAuditorias(string? tipoUsuario)
        {
            return tipoUsuario == "Administrador" || tipoUsuario == "Root";
        }
    }
}