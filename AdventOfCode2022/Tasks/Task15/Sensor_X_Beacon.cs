using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Tasks.Task15
{
    public class Sensor_X_Beacon
    {
        public Position Sensor { get; private set; }
        public Position Beacon { get; private set; }
        public Int32 SignalStrength { get; private set; }
        public Sensor_X_Beacon(Position sensor, Position beacon)
        {
            Sensor = sensor;
            Beacon = beacon;
            SignalStrength = Math.Abs(Beacon.X - Sensor.X) + Math.Abs(Beacon.Y - Sensor.Y);
        }
        public Boolean CanReachPosition(Position position) => (Abs(position.X - Sensor.X) + Abs(position.Y - Sensor.Y)) <= SignalStrength;
        public Int32 Abs(Int32 number) => number > 0 ? number : -number;
        public Position[] GetOuterCircle()
        {
            List<Position> coveredPositions = new List<Position>();
            Int32 size = SignalStrength + 1;
            for (int i = 0; i < size; i++)
            {
                coveredPositions.Add(new Position(Sensor.X - i, Sensor.Y + size - i));
                coveredPositions.Add(new Position(Sensor.X - size + i, Sensor.Y - i));
                coveredPositions.Add(new Position(Sensor.X + i, Sensor.Y - size + i));
                coveredPositions.Add(new Position(Sensor.X + size - i, Sensor.Y + i));
            }
            return coveredPositions.ToArray();
        }
    }
}
