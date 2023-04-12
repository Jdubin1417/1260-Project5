/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Project: Project 5
// File Name: Weapon.cs
// Description: Creates base Weapon class with constructors
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
    /// Creates the parent Weapon class and its attribute of AdditionalDamage
    /// </summary>
    public class Weapon
    {
        public int AdditionalDamage { get; set; }       

        /// <summary>
        /// Default Construct sets defaul AdditionalDamage to 0
        /// </summary>
        public Weapon() 
        { 
            AdditionalDamage = 0;       
        }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="additionalDamage">variable represents additional damage player will do when with weapon</param>
        public Weapon (int additionalDamage)
        {
            this.AdditionalDamage = additionalDamage;
        }
        
    }
}