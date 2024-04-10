using System;
using starwars.Domain;
using starwars.Domain.Enums;
using starwars.IBusinessLogic;

namespace starwars.BusinessLogic
{
    public class SithStrategy : IForceCalcStrategy
    {
        public int CalculateForce(IEnumerable<QuestionAnswer> answers)
        {
            int totalForce = 0;

            foreach (var answer in answers)
            {
                int multiplier = GetCategoryMultiplierForSith(answer.Question.Category);
                totalForce += answer.Question.ForceValue * multiplier;
            }

            return totalForce;
        }

        private int GetCategoryMultiplierForSith(QuestionCategory category)
        {
            switch (category)
            {
                case QuestionCategory.Power:
                case QuestionCategory.Domination:
                case QuestionCategory.Emotion:
                    return 3;  // Higher impact for Sith

                case QuestionCategory.Peace:
                case QuestionCategory.Diplomacy:
                case QuestionCategory.Wisdom:
                    return 2;  // Lower impact for Sith

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
                    Id = 11,
                    Name = "Darth Sidious (Emperor Palpatine)",
                    Description = "The cunning Sith Lord who orchestrated the fall of the Republic and rise of the Empire.",
                    ImageUrl = "darth_sidious_image_url"
                };
            }
            else if (forceLevel >= 80)
            {
                return new Character
                {
                    Id = 12,
                    Name = "Darth Vader (Anakin Skywalker)",
                    Description = "The iconic Sith Lord who was once a Jedi Knight but succumbed to the Dark Side.",
                    ImageUrl = "darth_vader_image_url"
                };
            }
            else if (forceLevel >= 70)
            {
                return new Character
                {
                    Id = 13,
                    Name = "Darth Maul",
                    Description = "A fearsome warrior with a double-bladed lightsaber, driven by vengeance.",
                    ImageUrl = "darth_maul_image_url"
                };
            }
            else if (forceLevel >= 60)
            {
                return new Character
                {
                    Id = 14,
                    Name = "Darth Tyranus (Count Dooku)",
                    Description = "A former Jedi Master who became a Sith Lord and played a role in galactic conflict.",
                    ImageUrl = "darth_tyranus_image_url"
                };
            }
            else if (forceLevel >= 50)
            {
                return new Character
                {
                    Id = 15,
                    Name = "Asajj Ventress",
                    Description = "A dark acolyte of Count Dooku who became a fearsome assassin and Sith apprentice.",
                    ImageUrl = "asajj_ventress_image_url"
                };
            }
            else if (forceLevel >= 40)
            {
                return new Character
                {
                    Id = 16,
                    Name = "Sith Acolyte",
                    Description = "A promising Sith initiate on the path to gaining power through the Dark Side.",
                    ImageUrl = "sith_acolyte_image_url"
                };
            }
            else if (forceLevel >= 30)
            {
                return new Character
                {
                    Id = 17,
                    Name = "Dark Side Cultist",
                    Description = "A follower of the Sith ideology, channeling the power of the Dark Side.",
                    ImageUrl = "dark_side_cultist_image_url"
                };
            }
            else if (forceLevel >= 20)
            {
                return new Character
                {
                    Id = 18,
                    Name = "Dark Side Initiate",
                    Description = "An individual beginning their journey into the ways of the Dark Side of the Force.",
                    ImageUrl = "dark_side_initiate_image_url"
                };
            }
            else if (forceLevel >= 10)
            {
                return new Character
                {
                    Id = 19,
                    Name = "Force-sensitive Individual",
                    Description = "You possess a connection to the Dark Side, but your true potential awaits.",
                    ImageUrl = "force_sensitive_image_url"
                };
            }
            else
            {
                return new Character
                {
                    Id = 20,
                    Name = "Dark Side Novice",
                    Description = "A novice exploring the temptations of the Dark Side, with much to learn.",
                    ImageUrl = "dark_side_novice_image_url"
                };
            }
        }
    }
}
