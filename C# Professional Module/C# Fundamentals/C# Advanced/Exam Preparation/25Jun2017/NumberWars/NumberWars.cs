using System;
using System.Collections.Generic;
using System.Linq;

class NumberWars
{
    static void Main()
    {
        var firstPlayerCards = new Queue<string>(Console.ReadLine().Split());
        var secondPlayerCards = new Queue<string>(Console.ReadLine().Split());

        int turns = 0;
        bool gameOver = false;

        while (turns < 1000000 && firstPlayerCards.Count > 0 && secondPlayerCards.Count > 0 && !gameOver)
        {
            turns++;

            var firstCard = firstPlayerCards.Dequeue();
            var secondCard = secondPlayerCards.Dequeue();

            if (GetNumber(firstCard) > GetNumber(secondCard))
            {
                firstPlayerCards.Enqueue(firstCard);
                firstPlayerCards.Enqueue(secondCard);
            }
            else if (GetNumber(secondCard) > GetNumber(firstCard))
            {
                secondPlayerCards.Enqueue(secondCard);
                secondPlayerCards.Enqueue(firstCard);
            }
            else
            {
                var cardsHand = new List<string> { firstCard, secondCard };

                while (!gameOver)
                {
                    if (firstPlayerCards.Count >= 3 && secondPlayerCards.Count >= 3)
                    {
                        int firstSum = 0;
                        int secondSum = 0;

                        for (int i = 0; i < 3; i++)
                        {
                            var firstHand = firstPlayerCards.Dequeue();
                            var secondHand = secondPlayerCards.Dequeue();

                            firstSum += GetLetter(firstHand);
                            secondSum += GetLetter(secondHand);

                            cardsHand.Add(firstHand);
                            cardsHand.Add(secondHand);
                        }

                        if (firstSum > secondSum)
                        {
                            AddCardsToWinner(cardsHand, firstPlayerCards);
                            break;
                        }
                        else if (secondSum > firstSum)
                        {
                            AddCardsToWinner(cardsHand, secondPlayerCards);
                            break;
                        }
                    }
                    else
                    {
                        gameOver = true;
                    }
                }
            }
        }

        if (firstPlayerCards.Count == secondPlayerCards.Count)
        {
            Console.WriteLine($"Draw after {turns} turns");
        }
        else if (firstPlayerCards.Count > secondPlayerCards.Count)
        {
            Console.WriteLine($"First player wins after {turns} turns");
        }
        else
        {
            Console.WriteLine($"Second player wins after {turns} turns");
        }

    }

    private static void AddCardsToWinner(List<string> cardsHand, Queue<string> firstPlayerCards)
    {
        foreach (var card in cardsHand.OrderByDescending(c => GetNumber(c)).ThenByDescending(c => GetLetter(c)))
        {
            firstPlayerCards.Enqueue(card);
        }
    }

    static int GetNumber(string card)
    {
        return int.Parse(card.Substring(0, card.Length - 1));
    }

    static int GetLetter(string card)
    {
        return card[card.Length - 1];
    }
}

