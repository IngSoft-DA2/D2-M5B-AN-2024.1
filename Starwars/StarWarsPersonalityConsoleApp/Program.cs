using System;
using System.Collections.Generic;
using System.Linq;
using starwars.BusinessLogic;
using starwars.Domain;
using starwars.IBusinessLogic;

namespace StarWarsPersonalityConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear instancia de PersonalityQuestionnaire
            IPersonalityQuestion questionProvider = new PersonalityQuestionnaire();

            // Crear instancias de las estrategias JediStrategy y SithStrategy
            IForceCalcStrategy jediStrategy = new JediStrategy();
            IForceCalcStrategy sithStrategy = new SithStrategy();

            // Crear instancia de ForceCalculator
            ForceCalculator forceCalculator = new ForceCalculator(jediStrategy, sithStrategy, questionProvider);

            Console.WriteLine("¡Bienvenido a la Prueba de Personalidad de Star Wars!");
            Console.WriteLine("Responde las siguientes preguntas para descubrir qué personaje eres.\n");

            IEnumerable<Question> questions = forceCalculator.GetQuestions();
            List<QuestionAnswer> answers = new List<QuestionAnswer>();

            foreach (var question in questions)
            {
                Console.WriteLine($"Pregunta: {question.Text}");
                Console.Write("Respuesta (1- sí/2- no): ");
                bool yesAnswer = Console.ReadLine().ToLower() == "1";
                answers.Add(new QuestionAnswer { Question = question, AnswerValue = yesAnswer });
                Console.WriteLine();
            }

            Character character = forceCalculator.DetermineCharacter(answers);

            Console.WriteLine("¡Tus respuestas han sido evaluadas!");
            Console.WriteLine($"Basado en tus respuestas, eres: {character.Name}");
            Console.WriteLine($"Descripción: {character.Description}");
            Console.WriteLine($"Imagen: {character.ImageUrl}");
            Console.ReadLine();
        }
    }
}
