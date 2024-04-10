using System;
using starwars.Domain;
using starwars.Domain.Enums;
using starwars.IBusinessLogic;

namespace starwars.BusinessLogic
{
    public class PersonalityQuestionnaire : IPersonalityQuestion
    {
        public List<Question> GetQuestions()
        {
            return new List<Question>
        {
            new Question
            {
                Id = 1,
                Text = "¿Prefieres la paz o el conflicto?",
                ForceValue = 10,
                Category = QuestionCategory.Peace
            },
            new Question
            {
                Id = 2,
                Text = "¿Eres impulsado por la ambición?",
                ForceValue = 5,
                Category = QuestionCategory.Ambition
            },
            new Question
            {
                Id = 3,
                Text = "¿Valoras el conocimiento y la sabiduría?",
                ForceValue = 8,
                Category = QuestionCategory.Wisdom
            },
            new Question
            {
                Id = 4,
                Text = "¿Prefieres resolver los problemas a través de la diplomacia?",
                ForceValue = 7,
                Category = QuestionCategory.Diplomacy
            },
            new Question
            {
                Id = 5,
                Text = "¿Te dejas llevar por tus emociones?",
                ForceValue = 6,
                Category = QuestionCategory.Emotion
            },
            new Question
            {
                Id = 6,
                Text = "¿Buscas el poder y la dominación?",
                ForceValue = 9,
                Category = QuestionCategory.Power
            },
            new Question
            {
                Id = 7,
                Text = "¿Valoras la protección y la seguridad?",
                ForceValue = 7,
                Category = QuestionCategory.Protection
            },
            new Question
            {
                Id = 8,
                Text = "¿Prefieres actuar individualmente o en equipo?",
                ForceValue = 6,
                Category = QuestionCategory.Individualism
            },
            new Question
            {
                Id = 9,
                Text = "¿Ayudas a los demás desinteresadamente?",
                ForceValue = 8,
                Category = QuestionCategory.HelpOthers
            },
            new Question
            {
                Id = 10,
                Text = "¿Buscas el conocimiento y el aprendizaje constante?",
                ForceValue = 7,
                Category = QuestionCategory.Knowledge
            },
            new Question
            {
                Id = 11,
                Text = "¿Te dejas llevar por la pasión en tus acciones?",
                ForceValue = 6,
                Category = QuestionCategory.Passion
            },
            new Question
            {
                Id = 12,
                Text = "¿Valoras la sabiduría ancestral?",
                ForceValue = 9,
                Category = QuestionCategory.AncientWisdom
            },
            new Question
            {
                Id = 13,
                Text = "¿Prefieres resolver conflictos a través del combate?",
                ForceValue = 8,
                Category = QuestionCategory.ConflictResolution
            },
            new Question
            {
                Id = 14,
                Text = "¿Actúas con astucia y manipulación?",
                ForceValue = 7,
                Category = QuestionCategory.Cunning
            },
            new Question
            {
                Id = 15,
                Text = "¿Te preocupas por el equilibrio de la Fuerza?",
                ForceValue = 9,
                Category = QuestionCategory.Balance
            }
        };
        }
    }

}

