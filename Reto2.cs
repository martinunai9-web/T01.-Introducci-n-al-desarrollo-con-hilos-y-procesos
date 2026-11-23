
using System;
using System.Threading;

class Reto2
{
    static int contador = 0;
    static object candado = new object();

    static void Main()
    {
        // Sin proteccion
        contador = 0;

        Thread hilo1 = new Thread(() =>
        {
            for (int i = 0; i < 1000000; i++)
            {
                contador++;
            }
        });

        Thread hilo2 = new Thread(() =>
        {
            for (int i = 0; i < 1000000; i++)
            {
                contador++;
            }
        });

        hilo1.Start();
        hilo2.Start();

        hilo1.Join();
        hilo2.Join();

        Console.WriteLine("Sin lock: " + contador);

        // Con lock
        contador = 0;

        Thread hilo3 = new Thread(() =>
        {
            for (int i = 0; i < 1000000; i++)
            {
                lock (candado)
                {
                    contador++;
                }
            }
        });

        Thread hilo4 = new Thread(() =>
        {
            for (int i = 0; i < 1000000; i++)
            {
                lock (candado)
                {
                    contador++;
                }
            }
        });

        hilo3.Start();
        hilo4.Start();

        hilo3.Join();
        hilo4.Join();

        Console.WriteLine("Con lock: " + contador);

        // Con Interlocked
        contador = 0;

        Thread hilo5 = new Thread(() =>
        {
            for (int i = 0; i < 1000000; i++)
            {
                Interlocked.Increment(ref contador);
            }
        });

        Thread hilo6 = new Thread(() =>
        {
            for (int i = 0; i < 1000000; i++)
            {
                Interlocked.Increment(ref contador);
            }
        });

        hilo5.Start();
        hilo6.Start();

        hilo5.Join();
        hilo6.Join();

        Console.WriteLine("Con Interlocked: " + contador);
    }
}
