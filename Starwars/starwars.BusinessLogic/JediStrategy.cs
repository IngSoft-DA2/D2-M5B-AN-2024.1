using starwars.Domain;
using starwars.Domain.Enums;
using starwars.IBusinessLogic;

namespace starwars.BusinessLogic
{
    public class JediStrategy : IForceCalcStrategy
    {
        public int CalculateForce(IEnumerable<QuestionAnswer> answers)
        {
            int totalForce = 0;

            foreach (var answer in answers)
            {
                int multiplier = GetCategoryMultiplierForJedi(answer.Question.Category);
                totalForce += answer.Question.ForceValue * multiplier;
            }

            return totalForce;
        }

        private int GetCategoryMultiplierForJedi(QuestionCategory category)
        {
            switch (category)
            {
                case QuestionCategory.Peace:
                case QuestionCategory.Diplomacy:
                case QuestionCategory.Wisdom:
                    return 3;  // Higher impact for Jedi

                case QuestionCategory.Power:
                case QuestionCategory.Domination:
                case QuestionCategory.Emotion:
                    return 2;  // Lower impact for Jedi

                default:
                    return 1;  // Neutral impact
            }
        }
        public Character DetermineCharacter(int forceLevel)
        {
            if (forceLevel >= 90)
            {
                return new Character
                {
                    Id = 1,
                    Name = "Jedi Master Yoda",
                    Description = "A wise and powerful Jedi Master, known for his vast knowledge and unique speech pattern.",
                    ImageUrl = "yoda_image_url"
                };
            }
            else if (forceLevel >= 80)
            {
                return new Character
                {
                    Id = 2,
                    Name = "Jedi Knight Obi-Wan Kenobi",
                    Description = "A skilled Jedi Knight who trained under Qui-Gon Jinn and later mentored Anakin Skywalker.",
                    ImageUrl = "obi_wan_image_url"
                };
            }
            else if (forceLevel >= 70)
            {
                return new Character
                {
                    Id = 3,
                    Name = "Jedi Knight Ahsoka Tano",
                    Description = "Former Padawan of Anakin Skywalker, known for her courage and determination.",
                    ImageUrl = "ahsoka_image_url"
                };
            }
            else if (forceLevel >= 60)
            {
                return new Character
                {
                    Id = 4,
                    Name = "Jedi Knight Qui-Gon Jinn",
                    Description = "A maverick Jedi Master who discovered the secret to living after death through the Force.",
                    ImageUrl = "qui_gon_image_url"
                };
            }
            else if (forceLevel >= 50)
            {
                return new Character
                {
                    Id = 5,
                    Name = "Jedi Knight Mace Windu",
                    Description = "A powerful Jedi with exceptional skills in lightsaber combat and a distinctive purple lightsaber.",
                    ImageUrl = "mace_windu_image_url"
                };
            }
            else if (forceLevel >= 40)
            {
                return new Character
                {
                    Id = 6,
                    Name = "Jedi Consular",
                    Description = "A diplomatic and knowledge-seeking Jedi who serves as a healer and scholar.",
                    ImageUrl = "jedi_consular_image_url"
                };
            }
            else if (forceLevel >= 30)
            {
                return new Character
                {
                    Id = 7,
                    Name = "Jedi Sentinel",
                    Description = "A versatile Jedi who balances combat and knowledge, often working as a spy or investigator.",
                    ImageUrl = "jedi_sentinel_image_url"
                };
            }
            else if (forceLevel >= 20)
            {
                return new Character
                {
                    Id = 8,
                    Name = "Jedi Guardian",
                    Description = "A Jedi specializing in combat and physical prowess, often found at the forefront of battles.",
                    ImageUrl = "jedi_guardian_image_url"
                };
            }
            else if (forceLevel >= 10)
            {
                return new Character
                {
                    Id = 9,
                    Name = "Jedi Youngling",
                    Description = "A young Jedi initiate just starting their training on the path to becoming a true Jedi Knight.",
                    ImageUrl = "jedi_youngling_image_url"
                };
            }
            else
            {
                return new Character
                {
                    Id = 10,
                    Name = "Force-sensitive Individual",
                    Description = "You possess a connection to the Force, but your journey as a Jedi is yet to begin.",
                    ImageUrl = "force_sensitive_image_url"
                };
            }
        }

    }

}

