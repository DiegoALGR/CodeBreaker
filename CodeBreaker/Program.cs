using System;
using System.Linq;

namespace CodeBreaker
{
    class Program
    {
        static private string randomNumber = "";

        static void Main(string[] args)
        {
            generateRandomNumber();
            printInstructions();
            Console.WriteLine("Presiona cualquier letra para comenzar");
            Console.ReadKey();
            while (true){
                if (game()) {
                    break;
                }
            }
        }

        static void printInstructions() {
            Console.WriteLine("*-------------------CodeBreaker-------------------*");
            Console.WriteLine("|        Instrucciones: Se ha generado un         |");
            Console.WriteLine("|        numero aleatorio de 4 digitos.           |");
            Console.WriteLine("|        Deberas de adivinar el numero            |");
            Console.WriteLine("|        que ha sido generado siguiendo           |");
            Console.WriteLine("|        las pistas que dejaremos a lo            |");
            Console.WriteLine("|        largo de la partida.                     |");
            Console.WriteLine("*-------------------------------------------------*");
            Console.WriteLine("*----------------------Pistas---------------------*");
            Console.WriteLine("| (*) -> El número esta correctamente posicionado |");
            Console.WriteLine("| (-) -> El número esta en la combinación pero    |");
            Console.WriteLine("|        no esta correctamente posicionado        |");
            Console.WriteLine("*-------------------------------------------------*");
        }

        static void generateRandomNumber() {
            Random random = new Random();
            int numberGenerated;
            for (int i = 0; i < 4; i++) {
                while (true) {
                    numberGenerated = random.Next(0, 9);
                    if (!(randomNumber.Contains(numberGenerated.ToString()))) {
                        randomNumber += numberGenerated;
                        break;
                    }
                }
            }
            Console.WriteLine(randomNumber);
        }

        static bool validateNumber(string number) {
            return number.All(Char.IsDigit) && number.Distinct().Count() == 4 && number.Count() == 4;
        }

        static void processClues(string number) {
            string correctlyPositioned = "", notCorrectlyPositioned = "";
            for (int i = 0; i < 4; i++){
                if (number[i] == randomNumber[i]) {
                    correctlyPositioned += "*";
                } else if (randomNumber.Contains(number[i])) {
                    notCorrectlyPositioned += "-";
                }
            }
            Console.WriteLine(correctlyPositioned + notCorrectlyPositioned);
        }

        static bool game() {
            string number;
            Console.WriteLine("Escribe el numero de 4 digitos que crees que se ha generado");
            number = Console.ReadLine();
            if (validateNumber(number))
            {
                if (number.Equals(randomNumber))
                {
                    Console.WriteLine("¡Felicidades has ganado! (:");
                    Console.ReadKey();
                    return true;
                }
                processClues(number);
            }
            return false;
        }
    }
}
