namespace AdventOfCode2020.Problems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AdventOfCode2020.Utils.Extensions;

    /// <summary>
    /// Solution for <a href="https://adventofcode.com/2020/day/8">Day 8</a>.
    /// </summary>
    public class Problem8 : ProblemBase
    {
        public Problem8() : base(8) { }

        /// <inheritdoc />
        protected override object SolvePartOne()
        {
            return FindAccumulatorValueOnRepeat(Input.WithoutEmptyLines());
        }

        /// <inheritdoc />
        protected override object SolvePartTwo()
        {
            return FindAccumulatorValueAfterModification(Input.WithoutEmptyLines());
        }

        internal static int FindAccumulatorValueOnRepeat(IEnumerable<string> input)
        {
            var bootCode = new BootCode(input);

            bootCode.ExecuteUntilRepeatedInstruction();

            return bootCode.Accumulator;
        }

        internal static int FindAccumulatorValueAfterModification(IEnumerable<string> input)
        {
            var bootCode = new BootCode(input);

            for (var i = 0; i < bootCode.NumberOfInstructions; i++)
            {
                if (!bootCode.Modify(i))
                {
                    bootCode.Reset();
                    continue;
                }

                if (bootCode.ExecuteUntilEndOfProgram())
                {
                    return bootCode.Accumulator;
                }

                bootCode.Reset();
            }

            throw new Exception("ohno");
        }
    }

    internal class BootCode
    {
        private readonly IEnumerable<string> _instructions;

        private IList<Instruction> _code;
        private int _currentInstruction;

        public BootCode(IEnumerable<string> instructions)
        {
            _instructions = instructions;
            Reset();
        }

        public bool Modify(int instruction)
        {
            if (_code[instruction].Operation.Equals("nop"))
            {
                _code[instruction].Operation = "jmp";
                return true;
            }
            
            if (_code[instruction].Operation.Equals("jmp"))
            {
                _code[instruction].Operation = "nop";
                return true;
            }

            return false;
        }

        public int Accumulator { get; private set; }

        public int NumberOfInstructions => _code.Count;

        public void Reset()
        {
            _code = _instructions.Select(line => new Instruction(line)).ToList();
            _currentInstruction = 0;
            Accumulator = 0;
        }

        public bool ExecuteUntilEndOfProgram()
        {
            var executions = 0;

            while (true)
            {
                if (_currentInstruction == NumberOfInstructions)
                {
                    return true;
                }

                executions++;

                // We're probably looping...
                if (executions > NumberOfInstructions*2)
                {
                    return false;
                }

                Execute();
            }
        }

        public void ExecuteUntilRepeatedInstruction()
        {
            _currentInstruction = 0;
            var instructionsExecuted = new HashSet<int>();

            while (true)
            {
                if (!instructionsExecuted.Add(_currentInstruction))
                {
                    break;
                }

                Execute();
            }
        }

        private void Execute()
        {
            switch (_code[_currentInstruction].Operation)
            {
                case "nop":
                    _currentInstruction++;
                    break;
                case "acc":
                    Accumulator += _code[_currentInstruction].Amount;
                    _currentInstruction++;
                    break;
                case "jmp":
                    _currentInstruction += _code[_currentInstruction].Amount;
                    break;
            }
        }
    }

    internal class Instruction
    {
        public Instruction(string input)
        {
            var split = input.Split();

            Operation = split[0];
            Amount = split[1].ToInt();
        }

        public string Operation { get; set; }

        public int Amount { get; }
    }
}
