using System;

namespace ChallengeRooftop
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            int m;
            Console.WriteLine("Tamaño de la matriz a ingresar n x m");
            Console.Write("Ingrese el valor de n: ");
            n = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese el valor de m: ");
            m = Convert.ToInt32(Console.ReadLine());

            string[,] matriz = new string[n, m];

            Cargar(matriz);

            Console.WriteLine("Matriz cargada: ");
            Mostrar(matriz);

            Console.WriteLine("Matriz con diagonal ordenada: ");
            Ordenar(matriz);
            Mostrar(matriz);


            Console.ReadKey();

        }
        public static void Cargar(string[,] matriz)
        {
            int num;

            for (int fila = 0; fila < matriz.GetLength(0); fila++)
            {
                for (int columna = 0; columna < matriz.GetLength(1); columna++)
                {

                    Console.Write("Ingrese un componente de la matriz: ");
                    num = int.Parse(Console.ReadLine());

                    matriz[fila, columna] = num.ToString();
                }
            }
        }
        public static void Mostrar(string[,] matriz)
        {

            for (int fila = 0; fila < matriz.GetLength(0); fila++)
            {
                for (int columna = 0; columna < matriz.GetLength(1); columna++)
                {
                    Console.Write(matriz[fila, columna] + "   ");
                }
                Console.WriteLine();
            }
        }

        public static void Ordenar(string[,] matriz)
        {
            //Guardo en vectores los valores positivos, negativos, y los ceros para luego conbinarlos ordenados en un vector diagonal
            int[] vectorPositivos;
            int[] vectorNegativos;
            int[] vectorCeros;
            int[] vectorDiagonal;
            int cantPositivos = 0;
            int cantCeros = 0;
            int cantNegativos = 0;

            //Obtengo el tamaño de cada vector
            for (int fila = 0; fila < matriz.GetLength(0); fila++)
            {
                for (int columna = 0; columna < matriz.GetLength(1); columna++)
                {
                    if (fila == columna)
                    {
                        if (Convert.ToInt32(matriz[fila, columna]) > 0)
                        {
                            cantPositivos++;
                        }
                        if (Convert.ToInt32(matriz[fila, columna]) == 0)
                        {
                            cantCeros++;
                        }
                        if (Convert.ToInt32(matriz[fila, columna]) < 0)
                        {
                            cantNegativos++;
                        }
                    }

                }

            }
            int cantDiagonal = (cantCeros + cantNegativos + cantPositivos);
            vectorPositivos = new int[cantPositivos];
            vectorNegativos = new int[cantNegativos];
            vectorCeros = new int[cantCeros];
            vectorDiagonal = new int[cantDiagonal];
            int contadorPos = 0;
            int contadorNeg = 0;
            int contadorCero = 0;

            //Guardo los valores correspondientes en cada vector
            for (int fila = 0; fila < matriz.GetLength(0); fila++)
            {
                for (int columna = 0; columna < matriz.GetLength(1); columna++)
                {
                    if (fila == columna)
                    {
                        if (Convert.ToInt32(matriz[fila, columna]) > 0)
                        {
                            vectorPositivos[contadorPos] = Convert.ToInt32(matriz[fila, columna]);
                            contadorPos++;
                        }
                        if (Convert.ToInt32(matriz[fila, columna]) == 0)
                        {
                            vectorCeros[contadorCero] = Convert.ToInt32(matriz[fila, columna]);
                            contadorCero++;
                        }
                        if (Convert.ToInt32(matriz[fila, columna]) < 0)
                        {
                            vectorNegativos[contadorNeg] = Convert.ToInt32(matriz[fila, columna]);
                            contadorNeg++;
                        }
                    }

                }

            }
            //Ordeno los vectores ya cargados
            Array.Sort(vectorPositivos);
            Array.Sort(vectorNegativos);
            Array.Sort(vectorCeros);
            contadorPos = 0;
            contadorNeg = 0;
            contadorCero = 0;

            //Cargo los 3 vectores en el vector diagonal
            for (int fila = 0; fila < vectorDiagonal.Length; fila++)
            {
                if (fila < cantPositivos)
                {
                    vectorDiagonal[fila] = vectorPositivos[contadorPos];
                    contadorPos++;
                }
                else
                {
                    if (fila < (cantPositivos + cantCeros))
                    {
                        vectorDiagonal[fila] = vectorCeros[contadorCero];
                        contadorCero++;
                    }
                    else
                    {
                        if (fila < (cantDiagonal))
                        {
                            vectorDiagonal[fila] = vectorNegativos[contadorNeg];
                            contadorNeg++;
                        }
                    }
                }

            }


            //Cargo el vector diagonal en la matriz y reemplazo los demas valores por "**"
            for (int fila = 0; fila < matriz.GetLength(0); fila++)
            {
                for (int columna = 0; columna < matriz.GetLength(1); columna++)
                {
                    if (fila == columna)
                    {
                        matriz[fila, columna] = vectorDiagonal[fila].ToString();
                    }
                    else matriz[fila, columna] = "**";

                }
            }
            return;




        }
    }
}
