﻿using System;

namespace Scripts.Data
{
    [Serializable]
    public class PositionOnLevel
    {
        public string Level;
        public Vector3Data Position;

        public PositionOnLevel(string level, Vector3Data position)
        {
            Level = level;
            Position = position;
        }

        public PositionOnLevel(string initialLevel)
        {
            Level = initialLevel;
        }
    }
}