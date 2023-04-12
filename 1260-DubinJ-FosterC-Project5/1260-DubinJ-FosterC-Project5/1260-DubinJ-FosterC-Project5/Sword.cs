/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Project: Project 5
// File Name: Sword.cs
// Description: Creates Sword class and inherits damage attribute from Weapon class
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
    /// Creates sub class Sword that inherits its attributes from the Parent Weapon class
    /// </summary>
    public class Sword : Weapon
    {
        /// <summary>
        /// Default Constructor sets the inherited attribute AdditionalDamage to 3 for Sword
        /// </summary>
        public Sword() : base()
        {
            AdditionalDamage = 3;       //Sword allows player to do 3 more damage
        }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="additionaldamage">variable represents additional damage player will do when with sword</param>
        public Sword(int additionaldamage) : base(additionaldamage)
        {
            AdditionalDamage = additionaldamage;
        }       
    }
}
