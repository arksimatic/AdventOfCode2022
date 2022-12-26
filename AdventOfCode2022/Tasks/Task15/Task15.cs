using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2022.Tasks.Task15
{
    class Task15 : TaskBase
    {
        public override int TaskNumber => 15;

        public override void Solve()
        {
            // Get data
            Sensor_X_Beacon[] data = LoadData();

            // First half
            Int32 amountOfCoveredPositions = 0;
            for(int i = -5_000_000; i < 5_000_000; i++)
            {
                if (data.Where(bcn => bcn.CanReachPosition(new Position(i, 2_000_000))).Any())
                    amountOfCoveredPositions++;
            }

            Int32 spaceBlockedByBeacons = data.Select(sxb => sxb.Beacon).Where(bcn => bcn.Y == 2_000_000).Select(pos => pos.X).Distinct().Count();
            Answer1 = (amountOfCoveredPositions - spaceBlockedByBeacons).ToString();

            // Second half
            Position[] potentialPositions = data
                .SelectMany(sxb => sxb.GetOuterCircle()).
                Where(pos => pos.X > 0 && pos.X <= 4_000_000 && pos.Y > 0 && pos.Y <= 4_000_000)
                .ToArray();

            Position searchedPosition = potentialPositions.Where(pos => !data.Where(sxb => sxb.CanReachPosition(pos)).Any()).First();
            Answer2 = $"{searchedPosition.X} * 4 000 000 + {searchedPosition.Y}";

            // Save answer
            SaveData();
        }

        public Sensor_X_Beacon[] LoadData()
        {
            List<Sensor_X_Beacon> sensors_x_beacons = new List<Sensor_X_Beacon>();

            foreach(var line in Data.Split("\r\n"))
            {
                String sensor = Regex.Matches(line, "Sensor at x=.*, y=.*:").First().Value;
                String beacon = Regex.Matches(line, "closest beacon is at x=.*, y=.*").First().Value;

                String sensorX = Regex.Matches(sensor, "x=.*,").First().Value.Substring(2).Trim(',');
                String sensorY = Regex.Matches(sensor, "y=.*:").First().Value.Substring(2).Trim(':');
                String beaconX = Regex.Matches(beacon, "x=.*,").First().Value.Substring(2).Trim(',');
                String beaconY = Regex.Matches(beacon, "y=.*").First().Value.Substring(2);

                sensors_x_beacons.Add(new Sensor_X_Beacon 
                (
                    new Position(Convert.ToInt32(sensorX), Convert.ToInt32(sensorY)),
                    new Position(Convert.ToInt32(beaconX), Convert.ToInt32(beaconY))
                ));
            }

            return sensors_x_beacons.ToArray();
        }

    }
}
