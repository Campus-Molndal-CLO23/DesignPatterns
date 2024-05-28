using System;

namespace StoryGenerator
{
    /// <summary>
    /// Simple factory for generating stories.
    /// </summary>
    public static class StoryFactory
    {
        private static Random random = new Random();

        public static string CreateStory(int storyType)
        {
            string character = GetCharacter(storyType);
            string action = GetAction(storyType);
            string encounter = GetEncounter(storyType);
            string friend = GetFriend(storyType);
            string detail1 = GetDetail1(storyType);
            string detail2 = GetDetail2(storyType);
            string detail3 = GetDetail3(storyType);

            return $"{character} {action} {encounter} {friend}. {detail1} {detail2} {detail3}.";
        }

        public static string CreateRandomStory()
        {
            string character = GetCharacter(random.Next(1, 6));
            string action = GetAction(random.Next(1, 6));
            string encounter = GetEncounter(random.Next(1, 6));
            string friend = GetFriend(random.Next(1, 6));
            string detail1 = GetDetail1(random.Next(1, 6));
            string detail2 = GetDetail2(random.Next(1, 6));
            string detail3 = GetDetail3(random.Next(1, 6));

            return $"{character} {action} {encounter} {friend}. {detail1} {detail2} {detail3}.";
        }

        private static string GetCharacter(int storyType)
        {
            return storyType switch
            {
                1 => "A girl",
                2 => "A boy",
                3 => "A robot",
                4 => "An alien",
                5 => "A wizard",
                _ => "A mysterious figure"
            };
        }

        private static string GetAction(int storyType)
        {
            return storyType switch
            {
                1 => "went out for a walk",
                2 => "was headed for work",
                3 => "took a walk in the woods",
                4 => "flew across the city",
                5 => "traveled through time",
                _ => "started an adventure"
            };
        }

        private static string GetEncounter(int storyType)
        {
            return storyType switch
            {
                1 => "and met",
                2 => "and encountered",
                3 => "and ran into",
                4 => "and discovered",
                5 => "and found",
                _ => "and was surprised by"
            };
        }

        private static string GetFriend(int storyType)
        {
            return storyType switch
            {
                1 => "his friend",
                2 => "the terrible dragon",
                3 => "a nice stranger",
                4 => "James Blackbear",
                5 => "Oscar Paymyrenta",
                _ => "Carl Igula"
            };
        }

        private static string GetDetail1(int storyType)
        {
            return storyType switch
            {
                1 => "They shared stories",
                2 => "They fought bravely",
                3 => "They explored new places",
                4 => "They uncovered secrets",
                5 => "They cast powerful spells",
                _ => "They embarked on a quest"
            };
        }

        private static string GetDetail2(int storyType)
        {
            return storyType switch
            {
                1 => "and laughed together.",
                2 => "and won the battle.",
                3 => "and made new friends.",
                4 => "and solved mysteries.",
                5 => "and saved the day.",
                _ => "and changed the world."
            };
        }

        private static string GetDetail3(int storyType)
        {
            return storyType switch
            {
                1 => "It was a memorable day.",
                2 => "It was a heroic day.",
                3 => "It was an adventurous day.",
                4 => "It was a day full of wonder.",
                5 => "It was a magical day.",
                _ => "It was a day to remember."
            };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 5; i++)
            {
                string story = StoryFactory.CreateStory(i);
                Console.WriteLine($"Story {i}: {story}\n");
            }

            string randomStory = StoryFactory.CreateRandomStory();
            Console.WriteLine($"Random Story: {randomStory}\n");
        }
    }
}
