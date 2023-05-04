

using System.Collections.Generic; // vamos a usar el namesspace. (LAS LISTAS, COLAS , DICCIONARIOS , PILAS) 
// VAMOS A TRABAJAR CON LAS LISTAS.
// COLLECIONES DEL TIPO DE OBJETOS. PUEDEN SER TAMBIEN DEL DATO PRIMITIVO.
using System.Linq; // LENGUAJE DE CONSULTA
//METODOS DE EXTENSION DE LINQ.
//CONSULTAS DE SQL

//Colecciones genéricas.
//Colecciones de alumnos.
// Las más usadas son las listas.
//Vamos a trabjar con los tipos primitivos hasta las clases

////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////


List<Alumno> lista2=new List<Alumno>() //CREACION SEGUNDA LISTA (FORMA ANTIGUA)
{
    //LISTA 2
    //OTRA FORMA VALIDA PARA CREAR UNA LISTA Y DESPUES INICIALIZARLA.
    new Alumno(){Nombre="Luciano", Apellido="Robles",DNI=555323,Edad=20},
    new Alumno(){Nombre="Romina", Apellido="Romano",DNI=4444232,Edad=18},
    new Alumno(){Nombre="Juan", Apellido="Martinez",DNI=2436462,Edad=18}
};

var listaAlumnos=new List<Alumno>(); // CREACION PRIMERA LISTA (FORMA MODERNA)
// UNA LISTA DE ALUMNOS TAMBIEN ES UN OBJETO, PERO ACA LO VEMOS COMO UNA COLECCION, UNA TIPO ESPECIFICO DE OBJETO.

var alumno1=new Alumno();
alumno1.Apellido="Alonso";
alumno1.Nombre="Laura";
alumno1.DNI=2129121;
alumno1.Edad=29;

var alumno2=new Alumno();
alumno2.Apellido="Lopez";
alumno2.Nombre="Marina";
alumno2.DNI=3323822;
alumno2.Edad=30;

// YA CREADO LOS OBJETOS LOS AGREGAMOS A LA LISTA. (LA PRIMERA LISTA DECLARADA)
listaAlumnos.Add(alumno1); // ADD AGREGA ELEMENTOS A LISTA DE ALUMNOS.
listaAlumnos.Add(alumno2);
//var alumno3=new Alumno(){Nombre="Santiago", Apellido="Robles",DNI=2385838}; // TAMBIEN DE ESTE MODO. ESTO ME CREO UN OBJETO Y LO AGREGO DIRECTAMENTE

listaAlumnos.Add(new Alumno(){Nombre="Santiago", Apellido="Robles",DNI=2385838,Edad=31}); // NOS AHORRAMOS ACA DE PONER ALUMNO3.



listaAlumnos.AddRange(lista2); // agrega elementos de la lista 2 a listalumnos. // AGREGA LOS ELEMENTOS DE LA COLECCION AL FINAL DE LA OTRA.
// ELEMENTOS DE LA LISTA EMPIEZA DESDE 0 HASTA (EN ESTE CASO EL 5) PORQUE SON 6 OBJETOS (6 ALUMNOS CREADOS) 3 EN UNA LISTA Y OTROS 3 EN OTRA LISTA QUE FUERON AGREGADOS A LA OTRA LISTA.
//listaAlumnos.RemoveAt(4); // REMOVER ELEMENTO 4. (OSEA INDICE 4 POSICION 5)
Console.WriteLine($"antes de borrar {listaAlumnos.Count()} ");
//listaAlumnos.Clear(); // BORRA TODOS LOS ELEMENTOS DE LA LISTA
//Console.WriteLine($"Tiene cantidad elementos {listaAlumnos.Count()} "); // EN ESTE CASO 0.
listaAlumnos.Reverse(); // DA VUELTA LOS ELEMENTOS DE LA LISTA

// PREDICADOS SON FUNCIONES (EXPRESION LANDA) (TOMAN VALOR DE ENTRADA Y VAN A DEVOLVER UN BOOLEANO (SI LO CUMPLE O NO // TRUE/FALSE))
// REPRESENTADO POR  
// PREDICADO VA A TENER :LISTA DE PARAMETROS - x=> - CUERPO DE LA FUNCION.
 //SE USA PARA REALIZAR BUSQUEDAS

var nombrebuscado="anti";
var listafiltrada= listaAlumnos //  var listafiltrada= listaAlumnos.where(x=>x.Apellido=="Robles") --> me trae todos los apellidos robles.
                                //  var listafiltrada= listaAlumnos.where(x=>x.Apellido=="Robles" && x.nombre=="Santiago") 
                                //   var listafiltrada= listaAlumnos.where(x=>x.Apellido=="Alonso" || x.nombre.Contains("o")) 
                        .Where(x=>  // WHERE (CONDICION X VA REPRESENTAR UN ELEMENTO DE LA LISTA) //PREDICADO (X) REPRESENTA A CUALQUIER ELEMENTO DE LA LISTA 
                                    x.Apellido=="Alonso" || 
                                    // x.Nombre.Contains ("o") ||
                                    x.Edad==18 || 
                                    x.Nombre.ToUpper().Contains(nombrebuscado.ToUpper()) // x.Nombre.ToUpper convertir en mayuscula // EL NOMBRE DE SANTI CONTIENE A SANTI.
                                        // SANTIAGO                       //(SANTI)
                                    )
                        .OrderByDescending(x=> x.Edad); // ORDENALO EN FORMA DESCENDENTE POR EDAD.

var listaordenada= listaAlumnos.OrderByDescending(x=> x.Edad); // ORDEN DESCENDENTE.
//                              Order.by(x=> x.DNI) (ORDEN ASCENDENTE / DE MENOR A MAYOR)

var MayorEdad=listaAlumnos.Max(x=> x.Edad); // Calcular el máximo. (en este caso la edad)

Console.WriteLine("Mayor edad: " + MayorEdad);
Console.WriteLine("Promedio edad: " + listaAlumnos.Average(x=> x.Edad) ); // IMPRIME PROMEDIO DE EDAD (hacemos todo directamente en la misma linea)
foreach(var alu in listafiltrada){
// foreach(var alu in listaAlumnos) // ALu --> ELEMENTO/VARIABLE DE ITERACION / SE VA A POSICIONAR EN CADA ELEMENTO DE LA LISTA. // NO SE HACE FALTA HACER UN FOR.
// LAS LISTAS NO TENEMOS QUE DEFINIRLE EL TAMAñO.
// foreach(var alu in Lista2) TAMBIEN PODEMOS RECORRER LA SEGUNDA LISTA.
    Console.WriteLine($"Nombre {alu.Nombre} Apellido {alu.Apellido.ToUpper()} Documento {alu.DNI} Edad: {alu.Edad}");
    // APELLIDO LO PODEMOS CONVERTIR EN MAYUSCULA CON toUpper. (metodo de la clase string)
    // toLower (en minuscula)
}

// TIPICA CLASE ALUMNO
class Alumno{
    //ATRIBUTOS
    public string Nombre{get;set;}
    public string Apellido{get;set;}
    public int DNI {get;set;}

    public int Edad {get;set;}

}

//INTERFACES
// SECUENCIA DE ELEMENTOS QUE YA VAN A ESTAR EN NUESTRA MEMORIA IEnumerable (elementos que nos van a representar una secuencia que vamos a poder iterar).
// FUENTE DE DATOS EXTERNA IQueryable (representar elemenos/extension, agrupación, aplicar filtros.)