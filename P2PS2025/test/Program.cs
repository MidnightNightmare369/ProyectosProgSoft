var lista_estudiantes = new List<Estudiantes>();
lista_estudiantes.Add(new Estudiantes() 
{ 
    Id = 1, 
    Codigo = "743", 
    Nombre = "Nikol", 
    Apellido = "Jimenez" 
});
lista_estudiantes.Add(new Estudiantes() 
{ 
    Id = 2, 
    Codigo = "521", 
    Nombre = "Maria", Apellido = "Lopez" 
});
lista_estudiantes.Add(new Estudiantes() 
{ 
    Id = 3, 
    Codigo = "923", 
    Nombre = "Felipe", 
    Apellido = "Naranjo" 
});

var lista_materias = new List<Materias>();
lista_materias.Add(new Materias()
{ 
    Id = 1, 
    Codigo = "KR3", 
    Nombre = "DB" 
});
lista_materias.Add(new Materias()
{ 
    Id = 2, 
    Codigo = "KR4", 
    Nombre = "PS" 
});
lista_materias.Add(new Materias()
{ 
    Id = 3, 
    Codigo = "KR5", 
    Nombre = "EN" 
});
lista_materias.Add(new Materias()
{ 
    Id = 4, 
    Codigo = "KR6", 
    Nombre = "MB" 
});

var lista_materiasestudiantes = new List<MateriasEstudiantes>();
lista_materiasestudiantes.Add(new MateriasEstudiantes()
{ 
    Id = 1, 
    Materia = 1, 
    Estudiante = 1, 
    _Estudiante = lista_estudiantes[0], 
    _Materia= lista_materias[0]
});
lista_materiasestudiantes.Add(new MateriasEstudiantes()
{ 
    Id = 1,
    Materia = 3, 
    Estudiante = 1, 
    _Estudiante = new Estudiantes() { Id = 1, Codigo = "743", Nombre = "Nikol", Apellido = "Jimenez" }, 
    _Materia = new Materias() { Id = 3, Codigo = "KR5", Nombre = "EN" }
});
lista_materiasestudiantes.Add(new MateriasEstudiantes()
{
    Id = 1,
    Materia = 4,
    Estudiante = 3,
    _Estudiante = lista_estudiantes.FirstOrDefault(x => x.Id == 3),
    _Materia = lista_materias.FirstOrDefault(x => x.Id == 4)
});


var estudiante_materia = lista_materiasestudiantes.FirstOrDefault(z => z._Materia!.Codigo == "KR4");

Hijos hijo1 = new Hijos();
Abuelos hijo2 = new Hijos();
Abuelos hijo3 = (Abuelos)hijo1;
Abuelos hijo4 = (Abuelos)(Padres)hijo1;
Padres hijo5 = new Hijos();
IHijos2 hijo6 = (IHijos2)new Hijos();


Console.WriteLine(lista_estudiantes.Count);
Console.WriteLine(lista_materias.Count);
Console.WriteLine(lista_materiasestudiantes.Count);

public class Estudiantes
{
    public int Id { get; set; }
    public string? Codigo { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }

    public List<MateriasEstudiantes>? MateriasEstudiantes { get; set; }
}

public class Materias
{
    public int Id { get; set; }
    public string? Codigo { get; set; }
    public string? Nombre { get; set; }

    public List<MateriasEstudiantes>? MateriasEstudiantes { get; set; }
}

public class MateriasEstudiantes
{
    public int Id { get; set; }
    public int Materia { get; set; }
    public int Estudiante { get; set; }

    public Materias? _Materia { get; set; }
    public Estudiantes? _Estudiante { get; set; }
}

// Herencia - Interfaces
public abstract class Abuelos
{
    public virtual bool Canas()
    {
        return false;
    }
}

public class Padres : Abuelos
{

}

public class Hijos : Padres, IHijos1, IHijos2
{
    public override bool Canas()
    {
        return true;
    }

    public bool Check()
    {
        return true;
    }
}

public interface IHijos1
{

}

public interface IHijos2
{
    bool Check();
}