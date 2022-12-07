using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Tasks.Task7
{
    class Task7 : TaskBase
    {
        public override int TaskNumber => 7;

        public override void Solve()
        {
            // Get data
            (File[] files, Folder[] folders) = LoadData();

            // First half
            Answer1 = folders
                .Select(folder => files
                    .Where(file => file.Name.StartsWith(folder.Name))
                    .Select(file => file.Size)
                    .Sum())
                .Where(size => size < 100_000)
                .Sum()
                .ToString();

            // Second half
            Int32 emptySpace = 70_000_000 - files.Select(file => file.Size).Sum();

            Answer2 = folders
                .Select(folder => files
                    .Where(file => file.Name.StartsWith(folder.Name))
                    .Select(file => file.Size)
                    .Sum())
                .Where(size => emptySpace + size > 30_000_000)
                .OrderBy(size => size)
                .First()
                .ToString();

            // Save data
            SaveData();
        }

        public (File[] files, Folder[] folders) LoadData()
        {
            List<File> fsEntities = new List<File>();
            List<Folder> folders = new List<Folder>();

            String currentDirPath = "/";

            foreach(var line in Data.Split("\r\n"))
            {
                switch (CheckForCommand(line))
                {
                    case CommandType.NoCommand:
                        if (line.StartsWith("dir"))
                            folders.Add(new Folder(currentDirPath + line.Split()[1]));
                        else
                        {
                            String[] splitted = line.Split();
                            Int32 size = Convert.ToInt32(splitted[0]);
                            String name = splitted[1];
                            fsEntities.Add(new File(size, currentDirPath + name));
                        }
                        break;
                    case CommandType.Cd:
                        currentDirPath += $"{line[5..]}/";
                        break;
                    case CommandType.CdBack:
                        var currentDirSplitted = currentDirPath.Split('/').ToList();
                        currentDirPath = String.Join("/", currentDirSplitted.GetRange(0, currentDirSplitted.Count - 2)) + "/";
                        break;
                    case CommandType.CdBackAll:
                        currentDirPath = "/";
                        break;
                    case CommandType.Ls:
                        break;
                }
            }

            return (fsEntities.Distinct().ToArray(), folders.Distinct().ToArray());
        }

        public Boolean IsCommand(String line) => line[0] == '$';
        public CommandType CheckForCommand(String line)
        {
            if (IsCommand(line))
            {
                String sub = line.Substring(2, 2);
                switch (sub)
                {
                    case "ls":
                        return CommandType.Ls;
                    case "cd":
                        switch(line.Substring(5))
                        {
                            case "/":
                                return CommandType.CdBackAll;
                            case "..":
                                    return CommandType.CdBack;
                            default:
                                    return CommandType.Cd;
                        }
                    default:
                        return CommandType.NoCommand;
                }
            }
            else
                return CommandType.NoCommand;
        }
    }
}
