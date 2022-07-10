using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppMyTelegrammBot
{
    internal class GuessNumberGame
    {
        private Random random;
        private int compNumber;
        private int countTries;

        public GuessNumberGame()
        {
            random = new Random();
        }

        private void Init()
        {
            compNumber = random.Next(1, 100 + 1);
            countTries = 0;
        }

        private string GameLogic(int userNumber)
        {
            countTries++;
            if (userNumber > compNumber)
            {
                return "введи поменьше";
            }
            else if (userNumber < compNumber)
            {
                return "введи побольше";
            }
            else
            {
                return $"угадал!!! за {countTries} попыток\nдля рестарта введи команду /start";
            }
        }

        public string ProcessMessage(string messageText)
        {
            bool isNumber = int.TryParse(messageText, out int userNumber);

            if (!isNumber)
            {
                if (messageText == "/start")
                {
                    Init();

                    return "я загадал число от 1 до 100, угадай какое число я загадал\nвведи свой вариант";
                }
                else
                {
                    return "неизвестная команда, для начала игры напиши команду /start";
                }
            }
            else
            {
                return GameLogic(userNumber);
            }
        }
    }
}
