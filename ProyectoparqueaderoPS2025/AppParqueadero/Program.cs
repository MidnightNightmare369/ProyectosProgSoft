//V1.0

//LLENAR CAMPOS


public class TipoVehiculos{
    private int id;
    private string? tipoVehiculo;
    public void TipoVehiculos(int id,string? tipoVehiculo){
        Id=id;
        TipoVehiculo=tipoVehiculo;
    }
    public Int Id {get => id; set=>id=value;}
    public String TipoVehiculo {get => tipoVehiculo; set=>tipoVehiculo=value;}

    public List<Vehiculos>? vehiculos {get; set; }
}

public class TipoClientes{
    private int id;
    private string? tipoCliente;
    public void TipoClientes(int id,string? tipoCliente){
        Id=id;
        TipoCliente=tipoCliente;
    }
    public Int Id {get => id; set=>id=value;}
    public String TipoCliente{get => tipoCliente; set=>tipoCliente=value;}

    public List<Clientes>? clientes {get; set;}
}

public class TipoPagos{
    private int id;
    private string? tipoPago;
    public void TipoPagos(int id,string? tipoPago){
        Id=id;
        TipoPago=tipoPago;
    }
    public Int Id {get => id; set=>id=value;}
    public String TipoPago{get => tipoPago; set=>tipoPago=value;}

    public List<ParqueaderoCliente>? parqueaderoClientes {get;set;}
}

public class Tarifas{
    private int id;
    private string? tipo;
    private double valor;
    public void Tarifas(int id,string? tipo,double valor){
        Id=id;
        Tipo=tipo;
        Valor=valor;
    }    
    public Int Id {get => id; set=>id=value;}
    public String? Tipo{get => tipo; set => tipo=value;}
    public Double Valor{get => valor;set => valor=value;}
    
    //faltan listas
}

public class Parqueaderos{
    private int id;
    private string? nombre;
    public void Parqueaderos(int id,string? nombre,){
        Id=id;
        Nombre=nombre;
    }    
    public Int Id {get => id; set=>id=value;}
    public String? Nombre{get => nombre; set => nombre=value;}
    
    //faltan listas
}

public class Vehiculos{
    private int id;
    private string? placa;
    private int tipoVehiculo;

    public TipoVehiculos? _tipoVehiculo;
    public void Vehiculos(int id,string? placa,double tipoVehiculo,TipoVehiculos? _tipoVehiculo){
        Id=id;
        Placa=placa;
        TipoVehiculo=tipoVehiculo;
        this._tipoVehiculo=_tipoVehiculo;
    }    
    public Int Id {get => id; set=>id=value;}
    public String? Placa{get => placa; set => placa=value;}
    public Int TipoVehiculo{get => tipoVehiculo;set => valor=tipoVehiculo;}
    
    public List<Clientes>? clientes {get; set;}
}

new class Clientes{
    private int id;
    private string? cedula;  
    private string? nombre;  
    private int vehiculo;
    private int tipoCliente;
    private int codigo;
    public TipoClientes? _tipoCliente;
    public Vehiculos? _vehiculo;

    public Int Id { get => id; set => id = value; }
    public String Cedula { get => cedula; set => cedula = value; }
    public String Nombre { get => nombre; set => nombre = value; }
    public Int Vehiculo { get => vehiculo; set => vehiculo = value; }
    public Int Codigo { get => codigo; set => codigo = value; }


    public void Clientes(int id,string? cedula,string? nombre,int vehiculo, int tipoCliente,int codigo,TipoClientes? _tipoCliente,Vehiculos? _vehiculo){
        this.Id=id;
        this.nombre=nombre;
        this.Cedula=cedula;
        this.Vehiculo=vehiculo;
        this.TipoCliente=tipoCliente;
        this.Codigo=codigo;
        this._tipoCliente=_tipoCliente;
        this._vehiculo=_vehiculo
    }


}

new class ParqueaderoCliente{
    private int id;
    private double tiempo;
    private string posicion;
    private double total;
    private int tarifa;
    private int tipoPago;
    private int cliente;
    private int parqueadero;

    public Tarifas? _tarifa;
    public TipoPagos? _tipoPago;
    public Clientes? _cliente;
    public Parqueaderos? _parqueadero;
    
    public Int Id { get => id; set => id = value; }
    public Double Tiempo { get => tiempo; set => tiempo = value; }
    public String Posicion { get => posicion; set => posicion = value; }
    public Double Total { get => total; set => total = value; }
    public Int Tarifa { get => tarifa; set => tarifa = value; }
    public Int TipoPago { get => tipoPago; set => tipoPago = value; }
    public Int Cliente { get => cliente; set => cliente = value; }
    public Int Parqueadero { get => parqueadero; set => parqueadero = value; }
    
    public ParqueaderoCliente(int id, double tiempo, string posicion, double total, int tarifa, int tipoPago, int cliente, int parqueadero,Tarifas? tarifaObj, TipoPagos? tipoPagoObj, Clientes? clienteObj, Parqueaderos? parqueaderoObj)
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


