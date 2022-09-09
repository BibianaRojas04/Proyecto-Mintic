using System;
namespace BooleanC.App.Dominio
{

    public class Acudiente:Persona
    {
       public Registro_Matricula RegistroAc {get;set;}

       public int Id_Acudiente {get;set;}       
       public string Contraseña {get;set;}
       public string Ocupacion {get;set;}
       public string Parentesco {get;set;}
       public string Direccion_trabajo {get;set;}            
    }
}