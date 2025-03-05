//V1.0

//Lista tipoVehiculos
var listaTipoVh = new List<TipoVehiculos>();
listaTipoVh.Add(new TipoVehiculos(1,"moto"));
listaTipoVh.Add(new TipoVehiculos(2,"automovil"));

//Lista tipoClientes
var listaTipoCli = new List<TipoClientes>();
listaTipoCli.Add(new TipoClientes(1,"regular"));
listaTipoCli.Add(new TipoClientes(2,"VIP"));
 
//Lista Vehiculos
var listaVh = new List<Vehiculos>();
listaVh.Add(new Vehiculos(1,"HSF369",1,listaTipoVh.FirstOrDefault(x => x.Id == 1)));
listaVh.Add(new Vehiculos(2,"THL666",2,listaTipoVh.FirstOrDefault(x=>x.Id==2)));
listaVh.Add(new Vehiculos(3,"LDL666",2,listaTipoVh.FirstOrDefault(x=>x.Id==2)));
listaVh.Add(new Vehiculos(4,"PYK555",1,listaTipoVh.FirstOrDefault(x=>x.Id==1)));
listaVh.Add(new Vehiculos(5,"NPY693",2,listaTipoVh.FirstOrDefault(x=>x.Id==2)));
listaVh.Add(new Vehiculos(6,"ETN527",1,listaTipoVh.FirstOrDefault(x=>x.Id==1)));
listaVh.Add(new Vehiculos(7,"CLT009",1,listaTipoVh.FirstOrDefault(x=>x.Id==1)));
listaVh.Add(new Vehiculos(8,"FCK911",2,listaTipoVh.FirstOrDefault(x=>x.Id==2)));

//Lista tipoPagos
var listaTipoPagos = new List<TipoPagos>();
listaTipoPagos.Add(new TipoPagos(1,"efectivo"));
listaTipoPagos.Add(new TipoPagos(2,"tarjeta"));

//Lista Parqueaderos
var listaParqueaderos = new List<Parqueaderos>();
listaParqueaderos.Add(new Parqueaderos(1,"Parqueaderoo"));

//Lista Tarifas
var listaTarifas = new List<Tarifas>();
listaTarifas.Add(new Tarifas(1,"MotoR",9000));
listaTarifas.Add(new Tarifas(2,"MotoVIP",15000));
listaTarifas.Add(new Tarifas(3,"AutoR",12000));
listaTarifas.Add(new Tarifas(4,"AutoVIP",18000));

//Lista Clientes 
var listaClientes = new List<Clientes>();
listaClientes.Add(new Clientes(1,"1000","Pedro Sanchez",1,1,1,listaTipoCli.FirstOrDefault(x=>x.Id==1),listaVh.FirstOrDefault(x=>x.Id==1)));
listaClientes.Add(new Clientes(2,"1333","Alex Crowley",2,2,2,listaTipoCli.FirstOrDefault(x=>x.Id==2),listaVh.FirstOrDefault(x=>x.Id==2)));
listaClientes.Add(new Clientes(3,"1333","Alex Crowley",3,2,2,listaTipoCli.FirstOrDefault(x=>x.Id==2),listaVh.FirstOrDefault(x=>x.Id==3)));
listaClientes.Add(new Clientes(4,"1369","Juan Zapata",4,2,3,listaTipoCli.FirstOrDefault(x=>x.Id==2),listaVh.FirstOrDefault(x=>x.Id==4)));
listaClientes.Add(new Clientes(5,"1666","Esteban Gomez",5,1,4,listaTipoCli.FirstOrDefault(x=>x.Id==1),listaVh.FirstOrDefault(x=>x.Id==5)));
listaClientes.Add(new Clientes(6,"1234","Andres Garcia",6,1,5,listaTipoCli.FirstOrDefault(x=>x.Id==1),listaVh.FirstOrDefault(x=>x.Id==6)));
listaClientes.Add(new Clientes(7,"1111","Pedro Ortiz",7,1,6,listaTipoCli.FirstOrDefault(x=>x.Id==1),listaVh.FirstOrDefault(x=>x.Id==7)));
listaClientes.Add(new Clientes(8,"1245","Alvaro Loaiza",8,2,7,listaTipoCli.FirstOrDefault(x=>x.Id==2),listaVh.FirstOrDefault(x=>x.Id==8)));

//Lista ParqueaderoCliente /Preguntar respecto al metodo para el campo total
var listaParqClientes = new List<ParqueaderoCliente>();
listaParqClientes.Add(new ParqueaderoCliente(1,2,"A1",18000.0,1,1,1,1,listaTarifas.FirstOrDefault(x=>x.Id==1),listaTipoPagos.FirstOrDefault(x=>x.Id==1),listaClientes.FirstOrDefault(x=>x.Id==1),listaParqueaderos.FirstOrDefault(x=>x.Id==1)));
listaParqClientes.Add(new ParqueaderoCliente(2,24,"H5",435000.0,4,2,2,1,listaTarifas.FirstOrDefault(x=>x.Id==4),listaTipoPagos.FirstOrDefault(x=>x.Id==2),listaClientes.FirstOrDefault(x=>x.Id==2),listaParqueaderos.FirstOrDefault(x=>x.Id==1)));
listaParqClientes.Add(new ParqueaderoCliente(3,5,"H6",90000.0,4,2,3,1,listaTarifas.FirstOrDefault(x=>x.Id==4),listaTipoPagos.FirstOrDefault(x=>x.Id==2),listaClientes.FirstOrDefault(x=>x.Id==3),listaParqueaderos.FirstOrDefault(x=>x.Id==1)));
listaParqClientes.Add(new ParqueaderoCliente(4,12,"E1",180000.0,2,1,4,1,listaTarifas.FirstOrDefault(x=>x.Id==2),listaTipoPagos.FirstOrDefault(x=>x.Id==1),listaClientes.FirstOrDefault(x=>x.Id==4),listaParqueaderos.FirstOrDefault(x=>x.Id==1)));
listaParqClientes.Add(new ParqueaderoCliente(5,2,"A2",24000.0,3,2,5,1,listaTarifas.FirstOrDefault(x=>x.Id==3),listaTipoPagos.FirstOrDefault(x=>x.Id==2),listaClientes.FirstOrDefault(x=>x.Id==5),listaParqueaderos.FirstOrDefault(x=>x.Id==1)));
listaParqClientes.Add(new ParqueaderoCliente(6,10,"A6",90000.0,1,1,6,1,listaTarifas.FirstOrDefault(x=>x.Id==1),listaTipoPagos.FirstOrDefault(x=>x.Id==1),listaClientes.FirstOrDefault(x=>x.Id==6),listaParqueaderos.FirstOrDefault(x=>x.Id==1)));
listaParqClientes.Add(new ParqueaderoCliente(7,5,"A5",45000.0,1,1,7,1,listaTarifas.FirstOrDefault(x=>x.Id==1),listaTipoPagos.FirstOrDefault(x=>x.Id==1),listaClientes.FirstOrDefault(x=>x.Id==7),listaParqueaderos.FirstOrDefault(x=>x.Id==1)));
listaParqClientes.Add(new ParqueaderoCliente(8,10,"H3",180000.0,4,2,8,1,listaTarifas.FirstOrDefault(x=>x.Id==4),listaTipoPagos.FirstOrDefault(x=>x.Id==2),listaClientes.FirstOrDefault(x=>x.Id==8),listaParqueaderos.FirstOrDefault(x=>x.Id==1)));

Console.WriteLine("All ok");

public class TipoVehiculos{
    private int id;
    private string? tipoVehiculo;
    public TipoVehiculos(int id,string? tipoVehiculo){
        Id=id;
        TipoVehiculo=tipoVehiculo;
    }
    public int Id {get => id; set=>id=value;}
    public String? TipoVehiculo {get => tipoVehiculo; set=>tipoVehiculo=value;}

    public List<Vehiculos>? vehiculos {get; set; }
}

public class TipoClientes{
    private int id;
    private string? tipoCliente;
    public TipoClientes(int id,string? tipoCliente){
        Id=id;
        TipoCliente=tipoCliente;
    }
    public int Id {get => id; set=>id=value;}
    public String? TipoCliente{get => tipoCliente; set=>tipoCliente=value;}

    public List<Clientes>? clientes {get; set;}
}

public class TipoPagos{
    private int id;
    private string? tipoPago;
    public TipoPagos(int id,string? tipoPago){
        Id=id;
        TipoPago=tipoPago;
    }
    public int Id {get => id; set=>id=value;}
    public String? TipoPago{get => tipoPago; set=>tipoPago=value;}

    public List<ParqueaderoCliente>? parqueaderoClientes {get;set;}
}

public class Tarifas{
    private int id;
    private string? tipo;
    private double valor;
    public Tarifas(int id,string? tipo,double valor){
        Id=id;
        Tipo=tipo;
        Valor=valor;
    }    
    public int Id {get => id; set=>id=value;}
    public String? Tipo{get => tipo; set => tipo=value;}
    public Double Valor{get => valor;set => valor=value;}
    
    public List<ParqueaderoCliente>? parqueaderoClientes {get;set;}
}

public class Parqueaderos{
    private int id;
    private string? nombre;
    public Parqueaderos(int id,string? nombre){
        Id=id;
        Nombre=nombre;
    }    
    public int Id {get => id; set=>id=value;}
    public String? Nombre{get => nombre; set => nombre=value;}
    
    public List<ParqueaderoCliente>? parqueaderoClientes {get;set;}
}

public class Vehiculos{
    private int id;
    private string? placa;
    private int tipoVehiculo;

    public TipoVehiculos? _tipoVehiculo;
    public Vehiculos(int id,string? placa,int tipoVehiculo,TipoVehiculos? __tipoVehiculo){
        Id=id;
        Placa=placa;
        TipoVehiculo=tipoVehiculo;
        _tipoVehiculo=__tipoVehiculo;
    }    
    public int Id {get => id; set=>id=value;}
    public String? Placa{get => placa; set => placa=value;}
    public int TipoVehiculo{get => tipoVehiculo;set => tipoVehiculo=value;}
    
    public List<Clientes>? clientes {get; set;}
}

public class Clientes{
    private int id;
    private string? cedula;  
    private string? nombre;  
    private int vehiculo;
    private int tipoCliente;
    private int codigo;
    public TipoClientes? _tipoCliente;
    public Vehiculos? _vehiculo;

    public int Id { get => id; set => id = value; }
    public String? Cedula { get => cedula; set => cedula = value; }
    public String? Nombre { get => nombre; set => nombre = value; }
    public int Vehiculo { get => vehiculo; set => vehiculo = value; }    
    public int TipoCliente { get => tipoCliente; set => tipoCliente = value; }
    public int Codigo { get => codigo; set => codigo = value; }


    public Clientes(int id,string? cedula,string? nombre,int vehiculo, int tipoCliente,int codigo,TipoClientes? _tipoCliente,Vehiculos? _vehiculo){
        this.Id=id;
        this.Nombre=nombre;
        this.Cedula=cedula;
        this.Vehiculo=vehiculo;
        this.TipoCliente=tipoCliente;
        this.Codigo=codigo;
        this._tipoCliente=_tipoCliente;
        this._vehiculo=_vehiculo;
    }

    public List<ParqueaderoCliente>? parqueaderoClientes {get;set;}
}

public class ParqueaderoCliente{
    private int id;
    private double tiempo;
    private string? posicion;
    private double total;
    private int tarifa;
    private int tipoPago;
    private int cliente;
    private int parqueadero;

    public Tarifas? _tarifa;
    public TipoPagos? _tipoPago;
    public Clientes? _cliente;
    public Parqueaderos? _parqueadero;
    
    public int Id { get => id; set => id = value; }
    public Double Tiempo { get => tiempo; set => tiempo = value; }
    public String? Posicion { get => posicion; set => posicion = value; }
    public Double Total { get => total; set => total = value; }
    public int Tarifa { get => tarifa; set => tarifa = value; }
    public int TipoPago { get => tipoPago; set => tipoPago = value; }
    public int Cliente { get => cliente; set => cliente = value; }
    public int Parqueadero { get => parqueadero; set => parqueadero = value; }
    
    public ParqueaderoCliente(int id, double tiempo, string? posicion, double total, int tarifa, int tipoPago, int cliente, int parqueadero,Tarifas? tarifaObj, TipoPagos? tipoPagoObj, Clientes? clienteObj, Parqueaderos? parqueaderoObj)
    {
        this.Id = id;
        this.Tiempo = tiempo;
        this.Posicion = posicion;
        this.Total = total;
        this.Tarifa = tarifa;
        this.TipoPago = tipoPago;
        this.Cliente = cliente;
        this.Parqueadero = parqueadero;
        this._tarifa = tarifaObj;
        this._tipoPago = tipoPagoObj;
        this._cliente = clienteObj;
        this._parqueadero = parqueaderoObj;
    }



}


