using Cns_presentacion.Repositorios;

Console.WriteLine("Proyecto consola");

var conexion = new RepositorioParqueaderos();
conexion.Select();

Console.WriteLine("All ok");
