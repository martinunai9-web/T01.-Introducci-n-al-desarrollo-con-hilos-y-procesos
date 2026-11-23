
using System;
using System.Threading;

class Reto1
{
    static void Main()
    {
        Thread hilo = new Thread(() =>
        {
            Console.WriteLine("ID del hilo: " + Environment.CurrentManagedThreadId);

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(500);
            }
        });

        Console.WriteLine("ID principal: " + Environment.CurrentManagedThreadId);

        hilo.Start();

        Console.WriteLine("Hola, soy el hilo principal");

        hilo.Join();

        Console.WriteLine("Programa terminado");
    }
}
