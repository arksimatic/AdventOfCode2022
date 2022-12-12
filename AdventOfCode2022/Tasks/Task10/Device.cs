using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Tasks.Task10
{
    public class Device
    {
        private Instruction[] _instructions { get; set; }
        public Device(Instruction[] instructions) => _instructions = instructions;
        private Int32 _currentCycle = 0;
        private Int32 _currentRegisterValue = 1;
        private readonly Int32[] _imageChange = new Int32[] { -1, 0, 1 };
        private Int32[] _imagePosition = new Int32[] { 0, 1, 2 };
        public Int32 CurrentRegisterValue => _currentRegisterValue;
        public Int32 GetSignalStrengthFromCycle(Int32 requestedCycle)
        {
            Int32[] simplifiedInstruction = GetSimplifiedInstructions();

            if (_currentCycle > requestedCycle)
                Reset();
            while(_currentCycle < requestedCycle)
            {
                _currentRegisterValue += simplifiedInstruction[_currentCycle];
                _currentCycle++;
            }

            return _currentRegisterValue * requestedCycle;
        }
        public String GetImage()
        {
            String outputImage = "";
            Int32 widthLength = 40;
            Int32 heightLength = 6;
            for (int height = 0; height < heightLength; height++)
            {
                for(int width = 0; width < widthLength; width++)
                {
                    outputImage += _imagePosition.Contains(width) ? "#" : ".";
                    GetSignalStrengthFromCycle(height * widthLength + width + 1);
                    _imagePosition = new Int32[] { _currentRegisterValue + _imageChange[0], _currentRegisterValue + _imageChange[1], _currentRegisterValue + _imageChange[2] };
                }
                outputImage += "\r\n";
            }

            return outputImage;
        }
        private void Reset()
        {
            _currentCycle = 0;
            _currentRegisterValue = 1;
        }
        private Int32[] GetSimplifiedInstructions()
        {
            List<Int32> simplifiedInstructions = new List<Int32>();
            foreach(var instruction in _instructions)
            {
                if (instruction.InstructionType == InstructionType.noop)
                    simplifiedInstructions.Add(0);
                else
                {
                    for (int i = 0; i < instruction.Cycles - 1; i++)
                        simplifiedInstructions.Add(0);
                    simplifiedInstructions.Add((Int32)instruction.NumberToAdd);
                }
            }

            return simplifiedInstructions.ToArray();
        }
    }
}
