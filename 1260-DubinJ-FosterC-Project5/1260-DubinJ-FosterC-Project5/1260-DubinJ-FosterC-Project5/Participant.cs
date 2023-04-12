/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Project: Project 5
// File Name: Participant.cs
// Description: Creates base participant class with constructors
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
    /// Creates parent Participant class and its attributes and constructors
    /// </summary>
    public class Participant
    {
        public int HealthPoints { get; set; }
        public int DamageDone { get; set; }

        /// <summary>
        /// Default Constructor sets Haelth, Damage, and Miss% to 0
        /// </summary>
        public Participant()
        {
            HealthPoints = 0;
            DamageDone = 0;
        }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="healthPoints">variable represents current participant health</param>
        /// <param name="damageDone">variable represents the damage the participant can do</param>
        public Participant(int healthPoints, int damageDone)
        {
            HealthPoints = healthPoints;
            DamageDone = damageDone;
        }
    }
}
