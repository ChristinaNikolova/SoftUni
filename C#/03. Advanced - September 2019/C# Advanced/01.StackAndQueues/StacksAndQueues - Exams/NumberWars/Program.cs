using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberWars
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isGameOver = false;

            Queue<string> cardsFirstPlayer = new Queue<string>(Console.ReadLine()
                 .Split(' '));

            Queue<string> cardsSecondPlayer = new Queue<string>(Console.ReadLine()
                .Split(' '));

            int counterTurns = 0;

            while (cardsFirstPlayer.Any() && cardsSecondPlayer.Any() && counterTurns < 1_000_000 && !isGameOver)
            {
                counterTurns++;

                string firstCard = cardsFirstPlayer.Dequeue();
                string secondCard = cardsSecondPlayer.Dequeue();

                int firstNumber = GetTheNumber(firstCard);
                int secondNumber = GetTheNumber(secondCard);

                if (firstNumber > secondNumber)
                {
                    cardsFirstPlayer.Enqueue(firstCard);
                    cardsFirstPlayer.Enqueue(secondCard);
                }
                else if (firstNumber < secondNumber)
                {
                    cardsSecondPlayer.Enqueue(secondCard);
                    cardsSecondPlayer.Enqueue(firstCard);
                }
                else
                {
                    int sumFirst = 0;
                    int sumSecond = 0;

                    List<string> cardsToAdd = new List<string>() { firstCard, secondCard };

                    while (!isGameOver)
                    {
                        if (cardsFirstPlayer.Count >= 3 && cardsSecondPlayer.Count >= 3)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                firstCard = cardsFirstPlayer.Dequeue();
                                secondCard = cardsSecondPlayer.Dequeue();

                                cardsToAdd.Add(firstCard);
                                cardsToAdd.Add(secondCard);

                                sumFirst += GetTheCharacterValue(firstCard);
                                sumSecond += GetTheCharacterValue(secondCard);
                            }

                            if (sumFirst > sumSecond)
                            {
                                GetTheNewCards(cardsToAdd, cardsFirstPlayer);
                                break;
                            }
                            else if (sumFirst < sumSecond)
                            {
                                GetTheNewCards(cardsToAdd, cardsSecondPlayer);
                                break;
                            }
                        }
                        else
                        {
                            isGameOver = true;
                            break;
                        }
                    }
                }
            }

            if (cardsFirstPlayer.Count > cardsSecondPlayer.Count)
            {
                Console.WriteLine($"First player wins after {counterTurns } turns");
            }
            else if (cardsFirstPlayer.Count < cardsSecondPlayer.Count)
            {
                Console.WriteLine($"Second player wins after {counterTurns } turns");
            }
            else
            {
                Console.WriteLine($"Draw after {counterTurns } turns");
            }
        }

        static void GetTheNewCards(List<string> cardsToAdd, Queue<string> cards)
        {
            foreach (string card in cardsToAdd
                .OrderByDescending(x => GetTheNumber(x))
                .ThenByDescending(x => GetTheCharacterValue(x)))
            {
                cards.Enqueue(card);
            }
        }

        static int GetTheCharacterValue(string card)
        {
            int number = int.Parse((card[card.Length - 1] - 97 + 1).ToString());

            return number;
        }

        static int GetTheNumber(string card)
        {
            int number = int.Parse(card.Substring(0, card.Length - 1));

            return number;
        }
    }
}
