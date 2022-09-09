using System;
namespace BooleanC.App.Dominio
{

    public class Personal_administrativo:Persona
    {
       public Registro_Matricula RegistroPa {get;set;}
       
       public int Id_Personal_admin {get;set;}
       public string Contraseña_admin {get;set;}
       public string Cargo {get;set;}
       public Decimal Salario_Personal_Admin {get;set;}
       public Date Fecha_Ingreso {get;set;}
       public Date Fecha_salida {get;set;}
       public string Eps {get;set;}
       public string Contacto {get;set;}
       public string Telefono_Contacto {get;set;}

    }
}