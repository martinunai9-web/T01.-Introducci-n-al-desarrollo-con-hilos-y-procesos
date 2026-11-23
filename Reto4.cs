
using System;
using System.Diagnostics;

class Reto4
{
    static void Main()
    {
        ProcessStartInfo inicio = new ProcessStartInfo();

        inicio.FileName = "dotnet";
        inicio.Arguments = "--version";
        inicio.UseShellExecute = false;
        inicio.RedirectStandardOutput = true;
        inicio.CreateNoWindow = true;

        Process proceso = Process.Start(inicio);

        string resultado = proceso.StandardOutput.ReadToEnd();

        proceso.WaitForExit();

        Console.WriteLine("Version de dotnet:");
        Console.WriteLine(resultado);

        Console.WriteLine("Codigo de salida: " + proceso.ExitCode);

        proceso.Close();
    }
}
