namespace Operaciones;

public class Calculadora
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Sumar(int a, int b)
        {
            return a + b;
        }
    public int Restar(int a, int b)
        {
            return a - b;
        }

        public int Multiplicar(int a, int b)
        {
            return a * b;
        }

        public int Dividir(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException("El denominador no puede ser cero.");
            return a / b;
        }

}
