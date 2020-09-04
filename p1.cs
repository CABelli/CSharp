using System.IO;
using System;
using System.Linq;
using System.Collections.Generic;

delegate int delegado(int i);

public delegate void Del(string message);

class Program
{   
    static void Main()
    {
        delegado meuDelegate = x => x * x;  
        int valor = meuDelegate(5);  
        Console.WriteLine("delegado  x * x com 5 => valor: " + valor);
        
        Del handler = DelegateMethod;
        handler("DelegateMethod mensagem => Valeu !!!");
        
        List<string> nomes = new List<string> { "Yuri", "Jeff", "Jess", "Janice", "Miriam" };
        string resultado = nomes.Find(nome => nome.StartsWith("M"));
        Console.WriteLine("List Find StartsWith M => " + resultado);
        
        IEnumerable<int> squares =  Enumerable.Range(1, 4).Select(aoQuadrado).ToList();
        foreach (int num in squares) {  Console.WriteLine( "Func Range 1, 4 => " + num); }
        
        Func<string> saudacoes = BomDia;
        string bomdia = saudacoes();
        Console.WriteLine("Func string => " + bomdia);
        
        Func<double, double, double> CalcularA = AdicionarRetDou;
        double x1 = 9.7, x2 = 12.6, resultadoSoma = CalcularA(x1, x2);
        Console.WriteLine("Func double " + x1 + " e " + x2 + " => " + resultadoSoma);
        
        Func<double,double,object> CalcularB = AdicionarRetObj;
        object resultSoma2 = CalcularB(x1, x2);
        Console.WriteLine("Func object => " + resultSoma2.GetType() + " - " + resultSoma2);
        if (resultSoma2.GetType() == typeof(String) )
           { Console.WriteLine("Retorna: string"); } 
        
        Func<double,double,object> CalcularC = AdicionarRetObj;
        resultSoma2 = CalcularC(0.7, x2);
        Console.WriteLine("Func object => " + resultSoma2.GetType() + " - " + resultSoma2);
        if (resultSoma2.GetType() == typeof(Double) )
           { Console.WriteLine("Retorna: Double"); }
        
    }
    
    public static void DelegateMethod(string message) { 
        Console.WriteLine( message + " Show !!! "); }
                   
    public static Func<int, int> aoQuadrado = x => x * x;
    
    private static string BomDia() { 
        return  "Bom dia"; }
        
    private static double AdicionarRetDou(double n1, double n2) { 
        return n1 + n2; }
        
    private static object AdicionarRetObj(double n1, double n2) {
        if  (n1 + n2 > 20) { 
            object a1 = "Nok";
            return a1;  
        }   else {  
                   object a2 = n1 + n2;
                   return a2 ; } }
}