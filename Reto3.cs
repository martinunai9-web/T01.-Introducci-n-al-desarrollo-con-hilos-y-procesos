
using System;
using System.Diagnostics;
using System.Threading.Tasks;

class Reto3
{
    static async Task Main()
    {
        Stopwatch reloj = new Stopwatch();

        // Descargas una detras de otra
        reloj.Start();

        Console.WriteLine("Descarga 1");
        await Task.Delay(1000);

        Console.WriteLine("Descarga 2");
        await Task.Delay(2000);

        Console.WriteLine("Descarga 3");
        await Task.Delay(3000);

        reloj.Stop();

        Console.WriteLine("Tiempo una detras de otra: " + reloj.ElapsedMilliseconds + " ms");

        // Descargas a la vez
        reloj.Restart();

        Task descarga1 = Task.Delay(1000);
        Task descarga2 = Task.Delay(2000);
        Task descarga3 = Task.Delay(3000);

        await Task.WhenAll(descarga1, descarga2, descarga3);

        reloj.Stop();

        Console.WriteLine("Tiempo a la vez: " + reloj.ElapsedMilliseconds + " ms");
    }
}
