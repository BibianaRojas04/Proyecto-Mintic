using System;
namespace BooleanC.App.Dominio
{

    public class Persona
    {
       public int Id_persona {get;set;}
       public string Dni {get;set;}
       public string Tipo_documento {get;set;}
       public string Nombre_apellidos {get;set;}
       public date Fecha_nacimiento {get;set;}
       public string Direccion_casa {get;set;}
       public string TelefonoCasa {get;set;}
       public string TelefonoOpcional {get;set;}
       public  Genero Genero {set;get;}
       public string E_mail {get;set;}
       public string clave_Password {get;set;}
    }
}