//V1.0

public class TipoVehiculos{
    private int id;
    private string? tipoVehiculo;
    public void TipoVehiculos(int id,string? tipoVehiculo_){
        Id=id;
        TipoVehiculo=tipoVehiculo_;
    }
    public int Id {get => id; set=>id=value;}
    public int TipoVehiculo {get => tipoVehiculo; set=>tipoVehiculo=value;}

    //faltan listas
}

public class TipoClientes{
    private int id;
    private string? tipoCliente;
    public void TipoClientes(int id,string? tipoCliente_){
        Id=id;
        TipoCliente=tipoCliente_;
    }
    public int Id {get => id; set=>id=value;}
    public int TipoCliente{get => tipoCliente; set=>tipoCliente=value;}

    //faltan listas
}

public class TipoPagos{
    private int id;
    private string? tipoPago;
    public void TipoPagos(int id,string? tipoPago_){
        Id=id;
        TipoPago=tipoPago_;
    }
    public int Id {get => id; set=>id=value;}
    public int TipoPago{get => tipoPago; set=>tipoPago=value;}

    //faltan listas
}

public class Tarifas{
    private int id;
    private string? tipo;
    private double valor;
    public void Tarifas(int id,string? tipo_,double valor_){
        Id=id;
        Tipo=tipo_;
        Valor=valor_;
    }    
    public int Id {get => id; set=>id=value;}
    public string? Tipo{get => tipo; set => tipo=value;}
    public double Valor{get => valor;set => valor=value;}
    
    //faltan listas
}

public class Parqueaderos{
    private int id;
    private string? nombre;
    public void Parqueaderos(int id,string? nombre_,){
        Id=id;
        Nombre=nombre_;
    }    
    public int Id {get => id; set=>id=value;}
    public string? Nombre{get => nombre; set => nombre=value;}
    
    //faltan listas
}

public class Vehiculos{
    private int id;
    private string? placa;
    private TipoVehiculos tipoVehiculo;
    public void Vehiculos(int id,string? placa_,double tipoVehiculo_){
        Id=id;
        Placa=placa_;
        TipoVehiculo=tipoVehiculo_;
    }    
    public int Id {get => id; set=>id=value;}
    public string? Placa{get => placa; set => placa=value;}
    public TipoVehiculos TipoVehiculo{get => tipoVehiculo;set => valor=tipoVehiculo;}
    
    //faltan listas
}


