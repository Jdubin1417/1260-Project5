/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Project: Project 5
// File Name: Monster.cs
// Description: Creates the monster and inherits attributes from the Participant class and creates fight method
// Course: CSCI 1260-001 – Introduction to Computer Science II
// Author: Chase Foster, fostercs2@etsu.edu and Justin Dubin, dubinj@etsu.edu
// Created: Friday, November 18, 2022
// Copyright: Chase Foster, Justin Dubin, 2022
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1260_DubinJ_FosterC_Project5
{
    /// <summary>
    /// Creates monster sub class and inherits attributes from parent Participant class. Also allows the monster to fight the player
    /// </summary>
    public class Monster : Participant
    {
        public Player Player { get; set; }
        public Monster monster { get; set; }

        /// <summary>
        /// Default constructor sets the inherited attributes to monster specific numbers
        /// </summary>
        public Monster() : base()
        {
            HealthPoints = 20;          //monster health is 20
            DamageDone = 4;             //damage monster can do is 4
        }

        /// <summary>
        /// Parameterized Constructor using inherited participant attributes
        /// </summary>
        /// <param name="healthPoints">variable represents current monster health</param>
        /// <param name="damageDone">varaibale represents the amount of damage a monster can do</param>
        public Monster(int healthPoints, int damageDone) : base(healthPoints, damageDone)
        {
            HealthPoints = healthPoints;
            DamageDone = damageDone;
        }

        /// <summary>
        /// Checks the monster's health and returns a bool representing if the monster is alive or not
        /// </summary>
        /// <returns>DeadMonster bool that represents if the player is alive or dead</returns>
        public bool CheckMonsterHealth()
        {
            bool DeadMonster = false;       //creates DeadMonster bool

            if (HealthPoints <= 0)          //if the monster's health drops below 0, DeadMonster is set to true
            {
                DeadMonster = true;
            }
            return DeadMonster;             //returns DeadMonster bool
        }

        /// <summary>
        /// MFight method allows the player to deal damage to the monster. It is one of two methods that allows the player
        /// and monsters to fight. It uses a random number to calculate a chance that the player hits or misses the monster.
        /// </summary>
        /// <param name="monster">variable represents the use of a monster</param>
        /// <param name="player">variable represents the use of a player</param>
        public void Mfight(Monster monster, Player player)
        {
            Player Player = player;
            int mHealthPoints = monster.HealthPoints;       //creates int variable and sets the value equal to the player's current health
            Random r = new Random();        //creates new Random object
            if (r.Next(10000) < 1000)       //The monster has a 10% chance to miss the player
            {
                Console.WriteLine("The player missed!");
            }
            else            //if the player hits the monster, the Monster's health subtracts the damage the player does
            {
                HealthPoints = mHealthPoints - Player.DamageDone;
                Console.WriteLine("The player hit the monster! Monster Health: " + monster.HealthPoints);       //displays the monster's current health
                if(HealthPoints <= 0)
                {
                    Console.WriteLine("The monster is dead!");      //if monster's health drops below 0, a message explaining so is displayed
                }
            }
        }        
    }
}
