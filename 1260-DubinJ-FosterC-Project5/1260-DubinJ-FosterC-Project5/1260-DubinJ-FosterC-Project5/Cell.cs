/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Project: Project 5
// File Name: Cell.cs
// Description: Creates Cell objects and allows cells to contain other objects (player/monster/weapon). Also checks
//              for if there is another object in the cell and game continues appropriately
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
    /// Cell class handles actions regarding individual cells. It creates cell objects and allows monsters, weapons, and players to be 
    /// added to them. It also allows monsters, weapons, and players to be removed from the cell if the monster dies, if the weapon is
    /// picked up, or if they player moves or dies.
    /// </summary>
    public class Cell
    {
        public Weapon Weapon { get; set; }

        public Monster Monster { get; set; }

        public Player Player { get; set; }

        public List<Weapon> WeaponInCell { get; set; }
        public List<Monster> MonsterInCell { get; set; }

        public List<Player> PlayerInCell { get; set; }
        
        /// <summary>
        /// Default Constructor allows for an empty cell and gives a 50% chance that a monster spawns. Allows them to hold a list of weapons,
        /// monsters, and players
        /// </summary>
        public Cell()
        {
            MonsterInCell = new List<Monster>();
            WeaponInCell = new List<Weapon>();
            PlayerInCell = new List<Player>();
            Random rand = new Random();

            if(rand.Next(10000) < 5000)
            {
                MonsterInCell.Add(new Monster());       //50% chance a monster spawns in a cell
            }

        }

        /// <summary>
        /// Parameterized constructor for a cell that contains a weapon and a player
        /// </summary>
        /// <param name="weapon">variable represents the use of a weapon</param>
        /// <param name="player">variable represents the use of a player</param>
        public Cell(List<Weapon> weapon, List<Player> player)
        {
            WeaponInCell = weapon;
            PlayerInCell = player;
            MonsterInCell = new List<Monster>();
        }

        /// <summary>
        /// Parameterized constructor ensures the starting cell is reset or emptied after the player leaves it the first time
        /// </summary>
        /// <param name="Advance">variable represents the player moving out of the beginning cell</param>
        public Cell(String Advance)
        {
            WeaponInCell = new List<Weapon>();
            PlayerInCell = new List<Player>();
            MonsterInCell = new List<Monster>();
        }

        /// <summary>
        /// Parameterized constructor for a cell containing a weapon and/or a monster
        /// </summary>
        /// <param name="weapon"></param>
        public Cell(List<Weapon> weapon)
        {
            MonsterInCell = new List<Monster>();
            WeaponInCell = weapon;
            PlayerInCell = new List<Player>();
            
            Random rand = new Random();
            if (rand.Next(10000) < 5000)                //50% chance a monster spawns in a cell
            {
                MonsterInCell.Add(new Monster());
            }
        }

        /// <summary>
        /// ToString method for cell allows the player and monsters to be represented in cells that they are in. If a monster is in a cell,
        /// it is shown by a M. If a player is in a cell, it is shown by a P. If a player or monster aren't in a cell, their position is 
        /// replace with a _ or an empty floor
        /// </summary>
        /// <returns>The string containing cells which can contain monsters or players</returns>
        public override string ToString()
        {
            string CellString = "";     //creates CellString

            if (MonsterInCell.Count == 0)       //if a monster is not in a cell, then an empty floor is added to the string
            {
                CellString += "_";
            }
            else
            {
                CellString += "M";              //if monster is in a cell, a M is added to the string
            }
            
            if (PlayerInCell.Count == 0)        //if a player is not in a cell, then an empty floor is added to the string
            {
                CellString += "_";
            }
            else                                //if a player is in a cell, a P is added to the string
            {
                CellString += "P";
            }
        
            return CellString;                  //returns the cell string that can contain a player or a monster
        }
    }
}
