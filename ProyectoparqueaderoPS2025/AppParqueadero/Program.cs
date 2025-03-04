//V1.0

//LLENAR CAMPOS
Console.WriteLine("Todo ok");

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


