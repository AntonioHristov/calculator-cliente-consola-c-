using System;

namespace calculator
{
    class Calculator
    {


        static bool siCondicionTexto(bool condicion=false, string texto="")
        {
            if(condicion)
            {
                Console.WriteLine(texto);
            }
            return condicion;
        }

        static bool stringIsDouble(string valueString)
        {
            double variableDouble;
            return Double.TryParse(valueString, out variableDouble);
        }

        static bool arrayCharContieneChar(char caracter, params char[] arrayChar )
        {
            foreach (var item in arrayChar)
            {
                if(item == caracter)
                {
                    return true;
                }
            }
            return false;
        }



        static double pedirDouble(string mensajePedirDouble="", string mensajeDatoNoValido="")
        {
            string stringIntroducidoPorUsuario = "";
            bool valorValido = true;
            double resultado = 0;

            do
            {
                Console.WriteLine(mensajePedirDouble);
                stringIntroducidoPorUsuario = Console.ReadLine();
                Console.Clear();

                valorValido = stringIsDouble(stringIntroducidoPorUsuario);

                if (valorValido)
                {
                    resultado = double.Parse(stringIntroducidoPorUsuario);
                }
                else
                {
                    Console.WriteLine(mensajeDatoNoValido);
                }
            } while (!valorValido);

            return resultado;
        }

        static char pedirChar(string mensajePedirChar = "", string mensajeDatoNoValido = "", params char[] valoresPermitidos )
        {
            string stringIntroducidoPorUsuario = "";
            bool valorValido = true;
            int longitudChar = 1;
            char resultado = ' ';

            do
            {
                Console.WriteLine(mensajePedirChar);
                stringIntroducidoPorUsuario = Console.ReadLine();
                Console.Clear();

                if
                    (
                    stringIntroducidoPorUsuario.Length == longitudChar
                    &&
                    arrayCharContieneChar(char.Parse(stringIntroducidoPorUsuario), valoresPermitidos)
                    )
                {
                    valorValido = true;
                }
                else
                {
                    valorValido = false;
                }
                


                if (valorValido)
                {
                    resultado = char.Parse(stringIntroducidoPorUsuario);
                }
                else
                {
                    Console.WriteLine(mensajeDatoNoValido);
                }
            } while (!valorValido);

            return resultado;
        }

        static void hacerNuevoCalculo()
        {

            // DECLARAR VARIABLES
            double operatorOne = 0, operatorTwo = 0; // VALORES DEL USUARIO EN DOUBLE SI SON VÁLIDOS
            char operatorChar = ' '; // VALOR DEL USUARIO EN CHAR SI ES VÁLIDO


            string textoElResultadoEs = ""; // EL RESULTADO DE (ejemplo) 2 + 2 ES

            const string nuevaLineaString = "\n";

            const char operatorSuma = '+';
            const char operatorResta = '-';
            const char operatorMultiplicar = '*';
            const char operatorDividir = '/';
            char[] operadoresPermitidos = { operatorSuma, operatorResta, operatorMultiplicar, operatorDividir };

            const string textoPedirPrimerNumero = "Dime el primer número (Si quieres decimales usa coma ',', si usas punto '.' ignoraré el punto)";
            const string textoPedirSegundoNumero = "Dime el segundo número (Si quieres decimales usa coma ',', si usas punto '.' ignoraré el punto)";
            const string textoPedirCaracterOperacion = "Dime el caracter de la operación";
            const string textoEjemplosCaracteresOperacion = "+ = Suma, - = Resta, * = Multiplicar, / = Dividir";
            const string textoErrorCaracterOperacion = "Error, carácter de operación no identificado.";
            const string textoErrorValorNoNumerico = "Por favor, escribe un número";
            const string textoErrorDividirEntre0 = "No se puede dividir entre 0";
            // FIN DECLARAR VARIABLES



            // PEDIR DATOS AL USUARIO

            do
            {

                operatorOne = pedirDouble
                    (
                    nuevaLineaString + textoPedirPrimerNumero + nuevaLineaString
                    ,
                    nuevaLineaString + textoErrorValorNoNumerico
                    );

                operatorTwo = pedirDouble
                    (
                    nuevaLineaString + textoPedirSegundoNumero + nuevaLineaString
                    ,
                    nuevaLineaString + textoErrorValorNoNumerico
                    );

                operatorChar = pedirChar
                    (
                    nuevaLineaString + textoPedirCaracterOperacion + nuevaLineaString + textoEjemplosCaracteresOperacion + nuevaLineaString
                    ,
                    nuevaLineaString + textoErrorCaracterOperacion
                    ,
                    operadoresPermitidos
                    );

                if (operatorTwo == 0 && operatorChar == operatorDividir)
                {
                    Console.WriteLine(nuevaLineaString + textoErrorDividirEntre0);
                }


            } while (operatorTwo == 0 && operatorChar == operatorDividir);



            // FIN PEDIR DATOS AL USUARIO



            // CALCULAR Y MOSTRAR RESULTADO AL USUARIO


            /*
            DIFICULTAD DE COMPILACIÓN AL CREAR LAS VARIABLES POR REFERENCIA CON LA IDEA DE DECLARAR ESE TEXTO
            EN LA DECLARACIÓN DE VARIABLES DE LA FUNCIÓN
            error CS8174: La declaración de una variable por referencia debe tener un inicializador.
            */
            textoElResultadoEs = "El resultado de " + operatorOne + " " + operatorChar + " " + operatorTwo + " es: ";
            /**/
            Console.Write(textoElResultadoEs);

            if (operatorChar == operatorSuma)
            {
                Console.Write(operatorOne + operatorTwo);
            }
            else if (operatorChar == operatorResta)
            {
                Console.Write(operatorOne - operatorTwo);
            }
            else if (operatorChar == operatorMultiplicar)
            {
                Console.Write(operatorOne * operatorTwo);
            }
            else if (operatorChar == operatorDividir)
            {
                Console.Write(operatorOne / operatorTwo);
            }
            else // NO DEBERÍA LLEGAR AQUI, PERO POR SI ACASO...
            {
                Console.Write(textoErrorCaracterOperacion);
            }
            // FIN CALCULAR Y MOSTRAR RESULTADO AL USUARIO

        }


        static void Main(string[] args)
        {
            // DECLARACIÓN VARIABLES "GLOBALES"
            const string nuevaLineaString = "\n";

            bool hacerCalculos = true;
            bool respuestaIdentificada = false;
            char respuestaUsuario = ' ';
            const string textoBienvenida = "Te doy la bienvenida a mi calculadora";
            const string textoDespedida = "Hasta otra.";
            const string textoPedirNuevoCalculo = "¿Quieres hacer otro cálculo?";
            const string textoEjemplosCaracteresNuevoCalculo = "s = Si. n = No.";
            const string textoErrorCaracterNuevoCalculo = "Error, respuesta no identificada.";
            

            const char respuestaSi = 's';
            const char respuestaNo = 'n';
            char[] respuestasPermitidas = { respuestaSi, respuestaNo };


            // FIN DECLARACIÓN VARIABLES "GLOBALES"


            // BIENVENIDA AL USUARIO
            Console.Clear();
            Console.WriteLine(textoBienvenida);
            // FIN BIENVENIDA AL USUARIO


            do
            {
                hacerNuevoCalculo();

                do
                {

                    respuestaUsuario = pedirChar
                    (
                    nuevaLineaString + textoPedirNuevoCalculo + nuevaLineaString + textoEjemplosCaracteresNuevoCalculo
                    ,
                    nuevaLineaString + textoErrorCaracterNuevoCalculo
                    ,
                    respuestasPermitidas
                    );

                    if(respuestaUsuario == respuestaSi)
                    {
                        hacerCalculos = true;
                        respuestaIdentificada = true;
                    }
                    else if (respuestaUsuario == respuestaNo)
                    {
                        hacerCalculos = false;
                        respuestaIdentificada = true;
                        Console.WriteLine(textoDespedida);
                    }
                    else // NO DEBERÍA LLEGAR AQUI, PERO POR SI ACASO...
                    {
                        respuestaIdentificada = false;
                        Console.Write(textoErrorCaracterNuevoCalculo);               
                    }


                } while (!respuestaIdentificada);



            } while (hacerCalculos);
            
        }
    }
}
