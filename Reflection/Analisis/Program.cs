using System;
using System.Reflection;

Console.WriteLine("Hello, World!");
string path = @"../Operaciones/bin/Debug/net8.0/Operaciones.dll";
Assembly assembly = Assembly.LoadFrom(path);

foreach (Type type in assembly.GetTypes())
{
    Console.WriteLine($"Tipo: {type.FullName}");
    foreach (MethodInfo method in type.GetMethods())
    {
        Console.WriteLine($"  Método: {method.Name}");
    }
    foreach (PropertyInfo property in type.GetProperties())
    {
        Console.WriteLine($"  Propiedad: {property.Name} ({property.PropertyType})");
    }
}

// Crear una instancia de la clase Calculadora y usar sus métodos
Type calculadoraType = assembly.GetType("Operaciones.Calculadora");
object calculadoraInstance = Activator.CreateInstance(calculadoraType);

// Invocar el método Sumar
MethodInfo sumarMethod = calculadoraType.GetMethod("Sumar");
int resultadoSumar = (int)sumarMethod.Invoke(calculadoraInstance, new object[] { 5, 3 });
Console.WriteLine($"Resultado de sumar: {resultadoSumar}");

// Invocar el método Multiplicar
MethodInfo multiplicarMethod = calculadoraType.GetMethod("Multiplicar");
int resultadoMultiplicar = (int)multiplicarMethod.Invoke(calculadoraInstance, new object[] { 4, 6 });
Console.WriteLine($"Resultado de multiplicar: {resultadoMultiplicar}");
