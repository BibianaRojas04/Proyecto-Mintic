sing System;
namespace BooleanC.App.Dominio
{

    public class Registro_Matricula
    {
       
       public int Id_Matricula {get;set;}       
       public string Fecha_Matricula {get;set;}
       public Decimal Valor_Matricula {get;set;}
       public string Parentesco {get;set;}
       public string Direccion_trabajo {get;set;}
       public int Id_Estudiante {get;set;}
       public int Id_Acudiente {get;set;}
       public int Id_Personal_Admin {get;set;}
       public string Curso {get;set;}            
    }
}