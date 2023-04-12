/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Project: Project 5
// File Name: Driver.cs
// Description: Handles input/output and calls methods to allow user to play Zork game
// Course: CSCI 1260-001 – Introduction to Computer Science II
// Author: Chase Foster, fostercs2@etsu.edu and Justin Dubin, dubinj@etsu.edu
// Created: Friday, November 18, 2022
// Copyright: Chase Foster, Justin Dubin, 2022
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _1260_DubinJ_FosterC_Project5
{
    /// <summary>
    /// Driver class handles all input/output and all interaction with the user. It also only allows the user to move the player east or west.
    /// The Driver calls methods to carry out all actions of the zork game
    /// </summary>
    public class Driver
    {
        public static bool FinishGame { get; set; }

        public static CellHolder cells { get; set; }

        public static int playerLocation { get; set; }

        public static Player Player { get; set; }
        public static Monster Monster { get; set; }
        public static Weapon Weapon { get; set; }

        public static Cell cell { get; set; }

        /// <summary>
        /// Main method displays a welcome message and overview of the game. It then dispalys the randomly generated dungeon
        /// and the player's healthallows the user to move east of west depending on where they are in the cell. It calls methods 
        /// from other classes so that all actions of the Zork game can be carried out appropriately. The game runs until the 
        /// player's health drops below 0 or if the player reaches the end of the dungeon
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Welcome to the Zork Game");
            Console.WriteLine("\n-----------------------------------------------------------------------");     //welcome message and game overview
            Console.WriteLine("In this game, there is a dungeon with a range of 5-10 cells." +
                              "\nThe player begins in the west-most cell and tries to get" +
                              "\nto the east-most cell which contains the dungeon exit." +
                              "\nA successful exit from the final cell wins the game." +
                              "\nAlong the way, each cell may have a monster that must be defeated." +
                              "\nOne cell contains a weapon which may be used on the monster, if any." +
                              "\n\nThe game continues until the player is defeated by a monster" +
                              "\nor until the player successfully exits the eastmost cell." +
                              "\nIn each cell, a player may move one cell to the east or one cell" +
                              "\nto the west if there is an exit in that direction.");
            Console.WriteLine("-----------------------------------------------------------------------");

            Player = new Player();          //creates new Player object
            Monster = new Monster();        //creates new Monster object
            Weapon = new Weapon();          //creates new Weapon object
            cells = new CellHolder();       //creates new CellHolder (Dungeon) object
            cell = new Cell();              //creates new cell object
            FinishGame = false;             //creates FinishGame bool
            playerLocation = 0;             //creates playerLocation int used for a tracker

            cells.AddCell();        //generates the random dungeon, spawns monsters, player, and a weapon
            do
            {
                Console.WriteLine("");
                Console.WriteLine(cells.ToString());        //displays the dungeon to the player
                Console.WriteLine("");

                if (cells.WeaponCheck() == true)            //allows the player to pick up a weapon if they are in the same cell
                {
                    cells.PickupWeapon(Player, Weapon);
                    cells.RemoveWeapon(Weapon);
                }
               
                Console.WriteLine("Your remaining health points: " + Player.HealthPoints + "\n");       //displays the player's health
                PlayerDecision();       //gets the player's decision to move east or west

                if (cells.WeaponCheck() == true)        //allows the player to pick up a weapon if they are in the same cell
                {
                    cells.PickupWeapon(Player, Weapon);
                    cells.RemoveWeapon(Weapon);
                }

                if (cells.MonsterCheck() == true)       //forces the player to fight a monster if he/she enters a cell containing one
                {
                    Fight(Player, Monster);
                }

            }while (Player.HealthPoints != 0 && FinishGame != true);        //game continues unless player dies or reaches end of dungeon
                    
            if(Player.HealthPoints <= 0)        //if the player dies, a message is displayed
            {
                Console.WriteLine("The player is dead. The game is over!");
            }
            else if(FinishGame == true)         //if the player reaches the end of the dungeon, the game ends and a congrats message is displayed
            {
                Console.WriteLine(cells.ToString());
                Console.WriteLine("Your remaining health points: " + Player.HealthPoints + "\n");
                Console.WriteLine("You have beaten the dungeon and all of its monsters - congratulations!");
            }
        }

        /// <summary>
        /// PlayerDecision method allows the user to only move the player east or west. It tracks where the player is currently
        /// located and allows the player to only move east if they are in the first cell. It also ends the game if the player
        /// reaches the final cell
        /// </summary>
        public static void PlayerDecision()
        {
            bool ValidPlayerChoice = false;

            do
            {
                Console.WriteLine("What would you like to do next? Your choices are 'go east' and 'go west'.");     //prompts user for direction
                string playerChoice = Console.ReadLine().ToUpper();

                if (playerChoice == "GO EAST" || playerChoice == "EAST")        //allows the player to move east until they reach the end of the dungeon
                {
                    playerLocation++;           //increments player location
                    ValidPlayerChoice = true;       //ends loop
                    cells.AdvancePlayerEast(Player);        //advance player east

                    if(playerLocation == cells.GetNumCells() - 1)       //if player reaches final cell, the game ends
                    {
                        FinishGame = true;
                    }
                }
                else if (playerChoice == "GO WEST" || playerChoice == "WEST")   //allows the player to move west as long as they are not in the first cell
                {
                    if(playerLocation != 0)
                    {
                        playerLocation--;           //decrements player location
                        ValidPlayerChoice = true;       //ends loop
                        cells.AdvancePlayerWest(Player);    //advances player west
                    }
                    else
                    {
                        Console.WriteLine("Sorry, but I can't go in that direction.");      //error message and loops back
                        ValidPlayerChoice = false;
                    }
                }
                else
                {
                    Console.WriteLine("I do not know what you mean...");        //error message and loops back 
                    ValidPlayerChoice = false;   
                }
            }while(ValidPlayerChoice != true);          //do while loop ensures the player enters valid input (east/west)
        }

        /// <summary>
        /// Fight method calls both the MFight and the PFight methods which allow the monsters and player to fight. It informs the user
        /// that a fight has started. The fight continues until either the player or the monster die
        /// </summary>
        /// <param name="player">variable represents the use of a player</param>
        /// <param name="monster">variable represents the use of a monster</param>
        public static void Fight(Player player, Monster monster)
        {
            Console.WriteLine("A monster is here!");        //informs the user a monster is in the cell
            Console.WriteLine("A Fight has started!");      //informs the user a fight has started
            while (player.CheckPlayerHealth() == false && monster.CheckMonsterHealth() == false)    //fight continues until either player or monster die
            {
                Player.Pfight(Player, Monster);
                Monster.Mfight(Monster, Player);
            }
            Monster.HealthPoints = 20;      //sets every monster health to 20
            cells.RemoveMonster(Monster);       //removes the monster from the cell if the monster dies          
        }
    }
}
