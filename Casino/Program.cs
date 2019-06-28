using System;
using System.Collections.Generic;
using System.Linq;

class MainClass
{

    public static void Main(string[] args)
    {

        //TEST SECTION 
        //-------------------------------------------------


        /*Printing a random card
        //Random rnd = new Random();

        string[,] deck = new string[52,2];
        //int r = rnd.Next(GetUpperBound(deck));
        deck = createdeck();

        Console.WriteLine("{0} of {1}",deck[randomcard(deck),0],deck[randomcard(deck),1]);
        */

        /* replacing element in single array
        string[] a = new string[3]{"1","2","3"};
        string[] b = new string[3]{"4","5","6"};

        Console.Write("(before) a: ");
        for(int i = 0; i <= a.GetUpperBound(0); i++)
        {

          Console.Write("{0} ",a[i]);
        }
        Console.WriteLine();
        Console.Write("(before) b: ");
        for(int i = 0; i <= a.GetUpperBound(0); i++)
        {
          Console.Write("{0} ",b[i]);
        }

        //Array.Copy(source, sindex, dest, dindex, #element);
        Array.Copy(a,0,b,1,2);

        Console.WriteLine();
        Console.Write("(after)  a: ");
        for(int i = 0; i <= a.GetUpperBound(0); i++)
        {

          Console.Write("{0} ",a[i]);
        }
        Console.WriteLine();
        Console.Write("(after)  b: ");
        for(int i = 0; i <= a.GetUpperBound(0); i++)
        {
          Console.Write("{0} ",b[i]);
        }
        */

        /*Remove a (random) card from deck
        string[,] deck = new string[52,2];
        string[,] ndeck = new string[deck.GetUpperBound(0),2];
        deck = createdeck();

        for(int i = 0; i <= deck.GetUpperBound(0); i++)
        {
          Console.Write("{0} ",deck[i,0]);
        }

        Console.WriteLine();
        Console.WriteLine();


        ndeck = removecard(deck, randomcard(deck));

        for(int i = 0; i <= ndeck.GetUpperBound(0); i++)
        {
          Console.Write("{0} ",ndeck[i,0]);
        }
        */


        //update the board with the card dealt to each player

        string[,] deck = new string[52, 2];
        deck = createdeck();
        string board = createblackjack(2);
        Console.WriteLine("Board \n{0}", board);

        string nboard = updateblackjack(deck, board);
        Console.WriteLine("New Board \n{0}", nboard);






        //-------------------------------------------------

        //BLACKJACK GAME

        /*
        Console.WriteLine("WELCOME TO THE GAME OF BLACKJACK!");
        Console.WriteLine();

        int numplayers = 0;
        Console.Write("Enter the number of players: ");
        while(numplayers <= 0)
        {
          numplayers = Convert.ToInt32(Console.ReadLine());
          if(numplayers <= 0)
            Console.Write("Please enter a number greater than 0: ");
        }

        Console.WriteLine(createblackjack(numplayers));

        Console.Write("Are you ready to play? (y/n): ");
        var start = Console.Read();
        Console.WriteLine();

        if(start == 121)
          Console.WriteLine("Let's begin!");
        else if(start == 110)
          Console.WriteLine("Goodbye!");
        else
          Console.WriteLine("Invalid input");

        */


    }

    //(Not fully functional when called repeatedly. Works for 1 use at a time) 
    //Generate a single random card by returning its index. 
    public static int randomcard(string[,] deck)
    {
        Random rnd = new Random();
        int card = rnd.Next(deck.GetUpperBound(0));

        return card;
    }

    //Remove a card at the given index and return the new deck
    public static string[,] removecard(string[,] deck, int index)
    {
        string[,] ndeck = new string[deck.GetUpperBound(0), 2];

        int i = 0;
        int j = 0;
        while (i <= deck.GetUpperBound(0))
        {
            if (i != index)
            {
                ndeck[j, 0] = deck[i, 0];
                ndeck[j, 1] = deck[i, 1];
                j++;
            }
            i++;
        }

        return ndeck;

    }

    //Create a double array deck of cards. {card,suits} 
    public static string[,] createdeck()
    {
        string[,] deck = new string[52, 2];

        //fill array with cards
        for (int i = 0; i <= 12; i++)
        {
            for (int j = 0; j <= 3; j++)
            {
                switch (i)
                {
                    case 0:
                        deck[j + (i * 4), 0] = "Ace";
                        break;
                    case 1:
                        deck[j + (i * 4), 0] = "2";
                        break;
                    case 2:
                        deck[j + (i * 4), 0] = "3";
                        break;
                    case 3:
                        deck[j + (i * 4), 0] = "4";
                        break;
                    case 4:
                        deck[j + (i * 4), 0] = "5";
                        break;
                    case 5:
                        deck[j + (i * 4), 0] = "6";
                        break;
                    case 6:
                        deck[j + (i * 4), 0] = "7";
                        break;
                    case 7:
                        deck[j + (i * 4), 0] = "8";
                        break;
                    case 8:
                        deck[j + (i * 4), 0] = "9";
                        break;
                    case 9:
                        deck[j + (i * 4), 0] = "10";
                        break;
                    case 10:
                        deck[j + (i * 4), 0] = "Jack";
                        break;
                    case 11:
                        deck[j + (i * 4), 0] = "Queen";
                        break;
                    case 12:
                        deck[j + (i * 4), 0] = "King";
                        break;
                    default:
                        deck[j + (i * 4), 0] = "NULL";
                        break;
                }
            }
        }

        //fill array with suits
        for (int i = 0; i <= 12; i++)
        {
            for (int j = 0; j <= 3; j++)
            {
                switch (j)
                {
                    case 0:
                        deck[j + (i * 4), 1] = "Spades";
                        break;
                    case 1:
                        deck[j + (i * 4), 1] = "Clubs";
                        break;
                    case 2:
                        deck[j + (i * 4), 1] = "Diamond";
                        break;
                    case 3:
                        deck[j + (i * 4), 1] = "Heart";
                        break;
                    default:
                        deck[j + (i * 4), 1] = "NULL";
                        break;
                }
            }
        }

        return deck;
    }

    //Create a string format of the blackjack table.
    public static string createblackjack(int numplayers)
    {
        string board = "";

        string dealer = " |DEALER|\n";
        string blankhand = "   [][]   ";


        board = String.Concat(Enumerable.Repeat("-", numplayers * 10)) + "\n\n";
        board += String.Concat(Enumerable.Repeat(" ", numplayers * 5 - 5));
        board += dealer;
        board += "\n";
        board += String.Concat(Enumerable.Repeat(blankhand, numplayers));
        board += "\n";
        for (int i = 1; i <= numplayers; i++)
        {
            board += " Player " + i + " ";
        }
        board += "\n\n" + String.Concat(Enumerable.Repeat("-", numplayers * 10));

        return board;
    }

    public static string updateblackjack(string[,] deck, string board)
    {
        string updatedtable = board;

        int index = board.IndexOf("[");
        Console.WriteLine(index);

        updatedtable = updatedtable.Insert(index + 1, deck[randomcard(deck), 0]);

        return updatedtable;
    }
}