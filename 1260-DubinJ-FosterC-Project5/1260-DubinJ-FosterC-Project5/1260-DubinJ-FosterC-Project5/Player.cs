/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Project: Project 5
// File Name: Player.cs
// Description: Creates the player and inherits attributes from the Participant class and creates fight method
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
using System.Threading;
using System.Threading.Tasks;

namespace _1260_DubinJ_FosterC_Project5
{
    /// <summary>
    /// Creates player sub class and inherits attributes from parent Participant class. Also allows the player to fight a monster
    /// and allows the player to pickup a weapon with corresponding methods
    /// </summary>
    public class Player : Participant
    {
        public Weapon Weapon { get; set; }
        public Sword Sword { get; set; }
        public Stick Stick { get; set; }
        public Monster Monster { get; set; }

        public bool DeadPlayer;

        /// <summary>
        /// Default constructor sets the inherited attributes to player specific numbers
        /// </summary>
        public Player() : base()
        {
            HealthPoints = 100;         //player health is 100
            DamageDone = 5;             //player damage without a weapon is 5
        }

        /// <summary>
        /// Parameterized Constructor using inherited participant attributes
        /// </summary>
        /// <param name="healthPoints">variable represents current player health</param>
        /// <param name="damageDone">variable represents the damage the player can do</param>
        public Player(int healthPoints, int damageDone) : base(healthPoints, damageDone)
        {
            HealthPoints = healthPoints;
            DamageDone = damageDone;
        }

        /// <summary>
        /// Copy constructor allows for the use of another player object with the same values as the original
        /// </summary>
        /// <param name="existingPlayer">variable represents the use of an existing player object</param>
        public Player(Player existingPlayer)
        {
            existingPlayer.HealthPoints = HealthPoints;                  //copies values from original player to copy player
            existingPlayer.DamageDone = DamageDone;
        }

        /// <summary>
        /// Checks the players health and returns a bool representing if the player is alive or not
        /// </summary>
        /// <returns>DeadPlayer bool that represents if the player is alive or dead</returns>
        public bool CheckPlayerHealth() 
        {
            bool DeadPlayer = false;        //creates DeadPlayer bool

            if(HealthPoints <= 0)           //if the player's health drops below 0, DeadPlayer is set to true
            {
                DeadPlayer = true;
            }
            return DeadPlayer;              //retruns DeadPlayer bool
        }

        /// <summary>
        /// PickupWeapon method allows the player to pickup a weapon and do more damage if the player enters a cell that contains the weapon
        /// </summary>
        /// <param name="player">variable represents the use of a player</param>
        /// <param name="WeaponInCell">variable represents the List of weapons and where a weapon is in a cell</param>
        public void PickupWeapon(Player player, List<Weapon> WeaponInCell)
        {
            foreach (Weapon w in WeaponInCell)      //foreach loop loops for each weapon in the WeaponInCell list
            {
                if (w is Sword)         //if the weapon is a sword, the player's damage is increased to 8
                {
                    player.DamageDone = player.DamageDone + w.AdditionalDamage;
                    Console.WriteLine("You Picked Up a SWORD! +3 Damage!");
                }
                else if (w is Stick)        //if the weapon is a stick, the player's damage is increased to 6
                {
                    player.DamageDone = player.DamageDone + w.AdditionalDamage;
                    Console.WriteLine("You Picked Up a STICK! +1 Damage!");
                }
            }
        }

        /// <summary>
        /// PFight method allows the monster to deal damage to the player. It is one of two methods that allows the player
        /// and monsters to fight. It uses a random number to calculate a chance that the monster hits or misses the player.
        /// </summary>
        /// <param name="player">variable represents the use of a player</param>
        /// <param name="monster">variable represents the use of a monster</param>
        public void Pfight(Player player, Monster monster)
        {
            int pHealthPoints = player.HealthPoints;        //creates int variable and sets the value equal to the player's current health
            Random r = new Random();        //creates new Random object
            if (r.Next(10000) < 2000)       //The monster has a 20% chance to miss the player
            {
                Console.WriteLine("The monster missed the player!");
            }
            else            //if the monster hits the player, the Player's health subtracts the damage the monster does
            {
                HealthPoints = pHealthPoints - monster.DamageDone;
                Console.WriteLine("The monster hit the player! Player health: " + player.HealthPoints);     //displays current player's health
            }         
        }
    }
}
