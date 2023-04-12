/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Project: Project 5
// File Name: CellHolder.cs
// Description: Creates CellHolder object to hold all the cells in the dungeon. Allows the player to move between
//              cells and allows the player to pick up a wepon. Also spawns monsters and a weapon in random cells
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
    /// CellHolder class creates a CellHolder object that holds all the cells in the dungeon. It has methods that allows the
    /// player to move between cells and pick up a weapon. It also spawns monsters and weapons and allows them to be removed
    /// for the cells if the monster dies or if the weapon is picked up
    /// </summary>
    public class CellHolder
    {
        public List<Cell> cells { get; set; }
        public List<Weapon> WeaponInCell { get; set; }
        public List<Monster> MonsterInCell { get; set; }
        public List<Player> PlayerInCell { get; set; }
        public Monster monster { get; set; }
        public bool monsterCheck { get; set; }
        public bool weaponCheck { get; set; }

        public Cell cell { get; set; }

        public Player player { get; set; }

        public int PlayerLocation { get; set; } 

        /// <summary>
        /// Creates default CellHolder object which contains a list of cells, a player and a monster, and a player location
        /// </summary>
        public CellHolder()
        {
            cells = new List<Cell>();
            player = new Player();
            monster = new Monster();
            PlayerLocation = 0;
        }

        /// <summary>
        /// AddCell method a dungeon containing 5-10 cells and it spawns a weapon in one of the cells and randomly spawns a monster(s)
        /// in any of the cells. It also ensures that the player spawns in the first cell and that the monster cannot spawn in the first one
        /// </summary>
        public void AddCell()
        {
            Player player = new Player();
            WeaponInCell = new List<Weapon>();
            PlayerInCell = new List<Player>();
            PlayerInCell.Add(player);
            Random r = new Random();
            int numCell = r.Next(5, 11);
            cells = new List<Cell>(numCell);            //generates a dungeon containing a range of 5-10 cells

            for (int i = 0; i < numCell; i++)
            {
                cell = new Cell();
                cells.Add(cell);            //adds each cell to the CellHolder
            }
            int TotalWeaponChance = r.Next(0, cells.Capacity);

            if (TotalWeaponChance == 0)
            {
                if (r.Next(10000) < 5000)
                {
                    Sword sword = new Sword();
                    WeaponInCell.Add(sword);
                    Cell WeaponCell = new Cell(WeaponInCell, PlayerInCell);         //Creates new Cell object with a list of weapons (with sword) and players inside, and inserts it into the list of cells
                    cells.RemoveAt(0);
                    cells.Insert(0, WeaponCell);
                }
                else
                {
                    Stick stick = new Stick();
                    WeaponInCell.Add(stick);
                    Cell WeaponCell = new Cell(WeaponInCell, PlayerInCell);         //Creates new Cell object with a list of weapons (with stick) and players inside, and inserts it into the list of cells
                    cells.RemoveAt(0);
                    cells.Insert(0, WeaponCell);
                }
            }
            else
            {
                Cell WeaponCell = new Cell(WeaponInCell, PlayerInCell);            //Creates new Cell object with empty weapon list and player list and inserts it into the list of cells
                cells.RemoveAt(0);
                cells.Insert(0, WeaponCell);
                AddWeapons();
            }
        }

        /// <summary>
        /// Allows the player to move east through the dungeon. It removes the player from his/her previos cell and adds te player to the
        /// cell to the right
        /// </summary>
        /// <param name="player">variable represents the use of a player</param>
        public void AdvancePlayerEast(Player player)
        {
            Player CopyPlayer = new Player();
            CopyPlayer = player;
            string ADVANCE = "ADVANCE";
            Cell WeaponCell = new Cell(ADVANCE);
            cells.RemoveAt(0);
            cells.Insert(0, WeaponCell);
            cells[PlayerLocation].PlayerInCell.Remove(player);              //Ensures player is removed from cell
            PlayerLocation++;
            cells[PlayerLocation].PlayerInCell.Add(CopyPlayer);             //Ensures exact replica of player is added to next cell
        }

        /// <summary>
        /// Allows the player to move west throught the dungeon. It removes the player from his/her previous cell and adds the player to the
        /// cell to the left
        /// </summary>
        /// <param name="player">variable represents the use of a player</param>
        public void AdvancePlayerWest(Player player)
        {
            Player CopyPlayer = new Player();
            CopyPlayer = player;
            cells[PlayerLocation].PlayerInCell.Remove(player);      //removes player from his/her cell
            PlayerLocation--;       //decrements player location
            cells[PlayerLocation].PlayerInCell.Add(CopyPlayer);     //adds player to the new cell
        }

        /// <summary>
        /// AddWeapons method randomly adds a weapon to one of the cells in the dungeon. It also uses a random number generator to determine
        /// if the weapon spawned is either a sword or a stick
        /// </summary>
        public void AddWeapons()
        {
            Random r = new Random();
            WeaponInCell = new List<Weapon>();
            if (r.Next(10000) < 5000)               //50% chance a sword spawns in a sincgle cell
            {
                Sword sword = new Sword();
                WeaponInCell.Add(sword);                    //adds sword to the Weapons list
                Cell WeaponCell = new Cell(WeaponInCell);       //creates a new cell with the weapons list
                Random rand = new Random();
                int RandomWeapon = rand.Next(1, cells.Capacity);        //randomly decides which cell the sword spawns in
                cells.RemoveAt(RandomWeapon);       //removes original cell that sword spawns in
                cells.Insert(RandomWeapon, WeaponCell);     //replaces original cell with the cell containing the sword
            }
            else                                    //50% chance a stick spawns in a single cell
            {
                Stick stick = new Stick();
                WeaponInCell.Add(stick);            //adds stick to the Weapons list
                Cell WeaponCell = new Cell(WeaponInCell);       //creates a new cell with the weapons list
                Random rand = new Random();
                int RandomWeapon = rand.Next(1, cells.Capacity);        //randomly decides which cell the stick spawns in
                cells.RemoveAt(RandomWeapon);       //removes original cell that the stick spawns in
                cells.Insert(RandomWeapon, WeaponCell);     //replaces original cell with the cell containing the stick
            }
        }

        /// <summary>
        /// Gets the number of cells in the CellHolder and returns it
        /// </summary>
        /// <returns>returns the int containg the number of cells in the dungeon</returns>
        public int GetNumCells()
        {
            int NumCells = (cells.Count);
            return NumCells;
        }

        /// <summary>
        /// MonsterCheck method checks if a player and a monster are in the same cell
        /// </summary>
        /// <returns>returns the bool representing if a monster and a player are in the same cell</returns>
        public bool MonsterCheck()
        {
            monsterCheck = false;
            if (cells[PlayerLocation].MonsterInCell.Any())      //checks if a monster exists in the cell
            {
                if (cells[PlayerLocation].PlayerInCell.Any())       //if monster exists in the cell, checks if player exists in the cell
                    monsterCheck = true;                            //if player also exists in the cell, boolean is set to true
            }
            else
            {
                monsterCheck = false;
            }
            return monsterCheck;
        }

        /// <summary>
        /// WeaponCheck method checks if a player and a weapon are in the same cell
        /// </summary>
        /// <returns>returns the bool representing if a weapon and a player are in the same cell</returns>
        public bool WeaponCheck()
        {
            weaponCheck = false;
            if (cells[PlayerLocation].WeaponInCell.Any())       //checks if a weapon is in a cell
            {
                if (cells[PlayerLocation].PlayerInCell.Any())       //if weapon is in a cell, checks if player is in the cell
                    weaponCheck = true;                             //if player also exists in the cell, boolean is set to true
            }
            else
            {
                weaponCheck = false;
            }
            return weaponCheck;
        }

        /// <summary>
        /// RemoveMonster method removes the monster from the cell
        /// </summary>
        /// <param name="monster">variable represents the use of a monster</param>
        public void RemoveMonster(Monster monster)
        {          
            if (cells[PlayerLocation].MonsterInCell.Any())      //if monster is in the cell, replaces the monster with empty monster list
            {
                cells[PlayerLocation].MonsterInCell = new List<Monster>();
            }
        }

        /// <summary>
        /// RemovePlayer method removes the player from the cell
        /// </summary>
        /// <param name="player">variable represents the use of a player</param>
        public void RemovePlayer(Player player)
        {
            if (cells[PlayerLocation].PlayerInCell.Any())       //if player is in the cell, replaces player with empty player list
            {
                cells[PlayerLocation].PlayerInCell = new List<Player>();
            }
        }

        /// <summary>
        /// RemoveWeapon method removes the weapon from the cell
        /// </summary>
        /// <param name="weapon">variable represents the use of a weapon</param>
        public void RemoveWeapon(Weapon weapon)
        {
            if (cells[PlayerLocation].WeaponInCell.Any())       //if player is in the cell, replaces player with empty weapon list
            {
                cells[PlayerLocation].WeaponInCell = new List<Weapon>();
            }
        }

        /// <summary>
        /// PickupWeapon method adds the weapons additional damage to the player's default damage if the player picks up the weapon.
        /// Displays a confirmation message to the user
        /// </summary>
        /// <param name="player">variable represents the use of a player</param>
        /// <param name="weapon">variale represents the use of a weapon</param>
        public void PickupWeapon(Player player, Weapon weapon)
        {
            foreach (Weapon w in WeaponInCell)          //loops for each weapon in the weapon list
            {
                if (w is Sword)
                {   
                        player.DamageDone = player.DamageDone + w.AdditionalDamage;     //if weapon picked up is a sword, 3 damage is added to the players damage
                        Console.WriteLine("You Picked Up a SWORD! +3 Damage!");  
                }
                if (w is Stick)
                {
                    player.DamageDone = player.DamageDone + w.AdditionalDamage;     //if weapon picked up is a stick, 1 damage is added to the players default damage
                    Console.WriteLine("You Picked Up a STICK! +1 Damage!");
                }
            }
        }

        /// <summary>
        /// ToString method creates the basis for each visual dispaly of the cells. It also allows the weapons to be displayed if they
        /// exist in a cell.
        /// </summary>
        /// <returns>the string containg the entire dungeon which contains every cell in the CellHolder</returns>
        public override string ToString()
        {
            string GameString = "";     //creates gamestring

                foreach (Cell c in cells)       //loops for each cell in the CellHolder
                {
                    GameString += "|_";         //first part of each cell

                    if (c.WeaponInCell.Count == 0)      //if there is no weapon in the cell, the floor is displayed in its place
                    {
                        GameString += "_";
                    }
                    else
                    {
                        foreach (Weapon w in WeaponInCell)      //if weapon is in a cell, the weapon is represented in the cell
                        {
                            if (w is Sword)
                            {
                                GameString += "Sw";             //if the weapon is a sword, Sw is added to the string
                            }
                            if (w is Stick)
                            {
                                GameString += "St";             //if the weapon is a stick, St is added to the string 
                            }
                        }
                                       
                    }
                    GameString += c.ToString();         //adds the cell string to the GameString

                    GameString += "| ";     //end of each cell
                
                }
           
            return GameString;      //returns the string containg every cell in the dungeon
        }
    }
}
