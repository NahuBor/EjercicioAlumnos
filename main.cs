using System;

class Program {

      public static void InfoAlumno (string[] nombres, int[] nota) {
        string nombre;
        Console.WriteLine("Ingrese el nombre del alumno a buscar (* para salir).");
        Console.WriteLine("");
        nombre = Console.ReadLine();  
         while (!nombre.Equals("*")) {
           int posicion = BusquedaAlumno(nombre, nombres);
           if (posicion >= 0) {
             Console.WriteLine("");
             Console.WriteLine($"El alumno: {nombres[posicion]}. Nota: {nota[posicion]}. Estado examen: {EstadoExamen(nota[posicion])}."); 
           } else {
             Console.WriteLine("");
             Console.WriteLine($"Alumno {nombre} inexistente");
           }
           Console.WriteLine("");
           Console.WriteLine("Ingrese el nombre del alumno a buscar (* para salir ).");
           nombre = Console.ReadLine();
          }
          Console.WriteLine("Ha terminado la busqueda. Vuelva pronto.");
        }

    public static int BusquedaAlumno (string nombre, string[] nombres) {
      int posicion = -1;
          for (int i = 0; i < nombres.Length; i++) {
            if (nombre.ToLower() == nombres[i].ToLower()) {
              posicion = i;
              break;
          } 
        }
        return posicion;
      } 
    public static string EstadoExamen (int nota)  {
        if (nota >= 7 && nota <= 10) {
          return "Promocionado";
        } else {
          if (nota >= 4 && nota <=6) {
            return "Aprobado";
            } 
          else {
             return "Desaprobado";
          }
        }  
      }

    public static void CargarArray(string[] nombres, int[] nota)
    {

        for (int i = 0; i < nota.Length; i++)
        {
            Console.WriteLine("");
            Console.WriteLine($"Ingrese los datos del alumno {i + 1}.");
            Console.WriteLine("");
            Console.WriteLine("Ingrese el nombre del alumno:");
            nombres[i] = Console.ReadLine();
            Console.WriteLine("Ingrese la nota del alunno:");
            nota[i] = int.Parse(Console.ReadLine());
        }
    }

    public static void OrdenamientoInsercion(string[] nombre, int[] nota)
    {
        for (int i = 1; i < nombre.Length; i++)
        {
            string posActual = nombre[i];
            int auxNota = nota[i];
            int j = i - 1;
            while (j >= 0 && nombre[j].CompareTo(posActual) > 0)
            {
                nombre[j + 1] = nombre[j];
                nota[j + 1] = nota[j];
                j--;
            }
            nombre[j + 1] = posActual;
            nota[j + 1] = auxNota;
        }
    }

    public static void ImprimirArray(string[] nombres, int[] nota)
    {
        for (int i = 0; i < nota.Length; i++)
        {
            Console.WriteLine($"Nombre del alumno: {nombres[i]}. Nota: {nota[i]}. Estado examen: {EstadoExamen(nota[i])}.");
          Console.WriteLine("");
        }
    }


    public static void Main(string[] args)
    {
        bool cantidadValida;
        int cantidadSocios = 0;
        do
        {
          Console.WriteLine("Ingrese la cantidad de alumnos por agregar:");
          cantidadValida = int.TryParse(Console.ReadLine(), out cantidadSocios);
        }
        while (!cantidadValida);

        string[] alumnnoNombre = new string[cantidadSocios];
        int[] alumnoNota = new int[cantidadSocios];

        CargarArray(alumnnoNombre, alumnoNota); // Func 1
        Console.WriteLine("");
        ImprimirArray(alumnnoNombre, alumnoNota); // Func 3
        Console.WriteLine("");
        OrdenamientoInsercion(alumnnoNombre, alumnoNota); // Func 2
        Console.WriteLine("");
        ImprimirArray(alumnnoNombre, alumnoNota); // Func 3  
        Console.WriteLine("");
        InfoAlumno(alumnnoNombre, alumnoNota); // Func 4
    }
}