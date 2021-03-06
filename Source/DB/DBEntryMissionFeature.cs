﻿/*
==========================================================================
This file is part of Briefing Room for DCS World, a mission
generator for DCS World, by @akaAgar (https://github.com/akaAgar/briefing-room-for-dcs)

Briefing Room for DCS World is free software: you can redistribute it
and/or modify it under the terms of the GNU General Public License
as published by the Free Software Foundation, either version 3 of
the License, or (at your option) any later version.

Briefing Room for DCS World is distributed in the hope that it will
be useful, but WITHOUT ANY WARRANTY; without even the implied warranty
of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with Briefing Room for DCS World. If not, see https://www.gnu.org/licenses/
==========================================================================
*/

using BriefingRoom4DCSWorld.Debug;
using System.IO;

namespace BriefingRoom4DCSWorld.DB
{
    /// <summary>
    /// Stores information about a mission feature.
    /// </summary>
    public class DBEntryMissionFeature : DBEntryExtension
    {
        /// <summary>
        /// Unit group to spawn when this mission feature is enabled.
        /// </summary>
        public DBUnitGroup UnitGroup { get; private set; }

        /// <summary>
        /// Initial position (index #0) and destination (index #1) of the unit group.
        /// </summary>
        public DBEntryMissionFeatureUnitGroupLocation[] UnitGroupCoordinates { get; private set; }

        /// <summary>
        /// Loads a database entry from an .ini file.
        /// </summary>
        /// <param name="iniFilePath">Path to the .ini file where entry inforation is stored</param>
        /// <returns>True is successful, false if an error happened</returns>

        protected override bool OnLoad(string iniFilePath)
        {
            if (!base.OnLoad(iniFilePath)) return false;

            using (INIFile ini = new INIFile(iniFilePath))
            {
                UnitGroup = new DBUnitGroup(ini, "UnitGroup");
                UnitGroupCoordinates = new DBEntryMissionFeatureUnitGroupLocation[2];
                UnitGroupCoordinates[0] = ini.GetValue<DBEntryMissionFeatureUnitGroupLocation>("UnitGroup", "Position.Initial");
                UnitGroupCoordinates[1] = ini.GetValue<DBEntryMissionFeatureUnitGroupLocation>("UnitGroup", "Position.Destination");
            }

            return true;
        }
    }
}
