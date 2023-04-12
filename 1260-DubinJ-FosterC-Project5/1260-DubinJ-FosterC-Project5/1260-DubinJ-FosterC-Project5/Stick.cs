/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Project: Project 5
// File Name: Stick.cs
// Description: Creates Stick class and inherits damage attribute from Weapon class
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
    /// Creates sub class Stick that inherits its attributes from the Parent Weapon class
    /// </summary>
    public class Stick : Weapon
    {
        /// <summary>
        /// Default Constructor sets the inherited attribute AdditionalDamage to 1 for stick
        /// </summary>
        public Stick() : base()
        {
            AdditionalDamage = 1;       //Stick allows player to do 1 more damage
        }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="additionaldamage">variable represents additional damage player will do when with stick</param>
        public Stick(int additionaldamage) : base(additionaldamage)
        {
            AdditionalDamage = additionaldamage;
        }
    }
}
