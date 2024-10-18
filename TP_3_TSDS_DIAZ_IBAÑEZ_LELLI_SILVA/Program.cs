using System;

class program
{
    static int[][] vuelos = new int[0][];
    static int vueloSeleccionado = 0;
    static void CargarVuelos()
    {
        int i = vuelos.Length + 1;
        Array.Resize(ref vuelos, i);
        vuelos[i - 1] = new int[60];

        for (int j = 0; j < 59; j++)
        {
            vuelos[i - 1][j] = 0;
        }
        Console.WriteLine("Vuelo N° " + (i-1) + " creado");
    }

    static void SeleccionarVuelo()
    {
        Console.WriteLine("seleccione un vuelo");

        for (int i = 0; i < vuelos.Length; i++)
        {
            Console.WriteLine("Vuelo N° " + i);
        }
        Console.Write("Ingrese el N° del vuelo: ");
        vueloSeleccionado = int.Parse(Console.ReadLine());
    }
    static void ReservarAsiento()
    {
        SeleccionarVuelo();
        bool procesoCompletado = false;

        while (procesoCompletado == false)
        {
            int contador = 0;

            Console.WriteLine("Seleccione un asiento para reservar");

            foreach (int i in vuelos[vueloSeleccionado])
            {
                if (i == 1) Console.WriteLine("Asiento: " + contador + " Ocupado");
                else Console.WriteLine("Asiento: " + contador + " Disponible");
                contador++;
            }
            Console.Write("\nIngrese el asiento: ");
            int respuesta = int.Parse(Console.ReadLine());

            if (vuelos[vueloSeleccionado][respuesta] == 0)
            {
                vuelos[vueloSeleccionado][respuesta] = 1;
                procesoCompletado = true;
                Console.WriteLine("Asiento reservado con exito");
            }
            else
            {
                Console.WriteLine("Asiento ocupado, seleccione otro");
            }

        }
    }

    static void CancelarReserva()
    {
        SeleccionarVuelo();

        bool procesoCompletado = false;

        while (procesoCompletado == false)
        {
            int contador = 0;
            Console.WriteLine("Seleccione un asiento para cancelar reservar");

            foreach (int i in vuelos[vueloSeleccionado])
            {
                if (i == 1) Console.WriteLine("Asiento: " + contador + " Ocupado");
                else Console.WriteLine("Asiento: " + contador + " Disponible");
                contador++;
            }
            Console.Write("Ingrese el asiento para cancelar la reserva");
            int respuesta = int.Parse(Console.ReadLine());

            if (vuelos[vueloSeleccionado][respuesta] == 1)
            {
                vuelos[vueloSeleccionado][respuesta] = 0;
                procesoCompletado = true;
                Console.WriteLine("Reserva cancelada con exito");
            }
            else
            {
                Console.WriteLine("Asiento no ocupado, seleccione otro");
            }

        }
    }

    static void VerEstadoVuelo()
    {
        SeleccionarVuelo();
        int contador = 0;
        foreach (int i in vuelos[vueloSeleccionado])
        {
            if (i == 1) Console.WriteLine("Asiento: " + contador + " Ocupado");
            else Console.WriteLine("Asiento: " + contador + " Disponible");
            contador++;
        }
    }

    static void EstadoAsientos()
    {
        SeleccionarVuelo();

        int contadorOcupados = 0;
        int contadorLibres = 0;

        foreach (int i in vuelos[vueloSeleccionado])
        {
            if (i == 1)
            {
                contadorOcupados++;
            }
            else
            {
                contadorLibres++;
            }
        }

        Console.WriteLine("Asientos Libres " + contadorLibres);
        Console.WriteLine("Asientos Ocupados " + contadorOcupados);
    }

    static void BuscarAsientoEspecifico()
    {
        SeleccionarVuelo();

        Console.WriteLine("Selecciones un asiento para ver su estado");
        int respuesta = int.Parse(Console.ReadLine());

        if (vuelos[vueloSeleccionado][respuesta] == 0)
        {
            Console.WriteLine("El asiento N° " + respuesta +" del Vuelo " + vueloSeleccionado + " esta disponible");
        }
        else
        {
            Console.WriteLine("El asiento N° " + respuesta + " del vuelo " +  vueloSeleccionado + " esta ocupado");
        }
    }

    static void Main()
    {
        bool salir = false;

        while (salir == false)
        {
            
            Console.WriteLine("\nSelecciones un opcion\n1_Cargar nuevo vuelo\n2_Reservar asiento\n3_Cancelar reserva\n4_Mostrar estado del vuelo" +
                            "\n5_Mostrar disponibilidad\n6_Buscar asiento especifico\n0_Salir");

            Console.Write("Ingrese la opción: ");
            int respuesta = int.Parse(Console.ReadLine());

            switch (respuesta)
            {
                case 0:
                    salir = true;
                    break;
                case 1:
                    Console.Clear();
                    CargarVuelos();
                    break;
                case 2:
                    Console.Clear();
                    ReservarAsiento();
                    break;
                case 3:
                    Console.Clear();
                    CancelarReserva();
                    break;
                case 4:
                    Console.Clear();
                    VerEstadoVuelo();
                    break;
                case 5:
                    Console.Clear();
                    EstadoAsientos();
                    break;
                case 6:
                    Console.Clear();
                    BuscarAsientoEspecifico();
                    break;
            }
        }

    }
}