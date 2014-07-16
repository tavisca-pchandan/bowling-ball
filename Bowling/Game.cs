using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class Game
    {


        //Specifications : 
        /*
         * 1. Game consists of 10 frames. In each frame player will get 2 rolls to drop 10 pins.
         * 2. If player drops all 10 pins in 1st roll,it is said to be strike and he/she will get next 2 roll's points as bonus.
         * 3. If player drops all 10 pins in 2nd roll then he/she will get next roll's points as bonus.
         * 4. If player drops all 10 pins in 2 rolls of a frame,it is said to be spare and he/she will get next frame's first roll's points as bonus.
         * 5.Max score can be 300 with strike on every roll
         * 6.Min score can be 0,no pin dropped at any roll.
         */
        private int _score = 0;
        private List<int> _rolls = new List<int>();
       
        //List maitaining Scores of all played rolls..
        public void Roll(int pins)
        {
            _rolls.Add(pins);
        }

        public int GetScore()
        {
            int FrameIndex = 0;
            for (int Frame = 0; Frame < 10; Frame++)
            {
                if (_rolls.Count - 2 == FrameIndex && _rolls[FrameIndex - 1] == 10 && _rolls[FrameIndex] != 10)
                    break;
                else if(FrameIndex % 2 == 0 && _rolls.Count - 1 == FrameIndex && _rolls[FrameIndex] == 10)
                {
                    _score = _score + _rolls[FrameIndex];
                    Roll(10);
                    _score += _rolls[_rolls.Count - 1];
                    Roll(10);
                    _score += _rolls[_rolls.Count - 1];
                    break;
                }
                else if (FrameIndex % 2 == 0 && _rolls.Count - 2 == FrameIndex && _rolls[FrameIndex] == 10)
                {
                   Roll(10);
                   Roll(10);
                }
                else if (FrameIndex % 2 == 0 && _rolls.Count - 1 == FrameIndex && _rolls[FrameIndex - 1] == 10)
                {
                    _score = _score + _rolls[FrameIndex];
                    Roll(1);
                    _score += _rolls[_rolls.Count - 1];
                    break;
                }
                else if (FrameIndex % 2 != 0 && _rolls.Count - 1 == FrameIndex && _rolls[FrameIndex - 1] == 10)
                {
                    _score += _score + _rolls[FrameIndex];
                    Roll(1);
                    _score += _rolls[_rolls.Count - 1];
                    break;
                }
                else if (FrameIndex + 1 == _rolls.Count || FrameIndex == _rolls.Count)
                    break;
                
                //If strike then get next 2 roll's points as bonus...
                if (IsStrike(FrameIndex))
                {
                   _score += StrikeScore(FrameIndex);
                   FrameIndex++;
                }
                else
                {
                    //If Spare then get next frame's first roll's points as bonus...
                    if (IsSpare(FrameIndex))
                    {
                       _score += SpareScore(FrameIndex);
                    }
                    else
                    {
                       _score += FrameScore(FrameIndex);
                    }
                    FrameIndex += 2;
                }
            }
            return _score;
        }

        //Check whether Strike...
        private bool IsStrike(int frameIndex)
        {
            return _rolls[frameIndex] == 10;
        }
        //Calculate Frame score...
        private int FrameScore(int frameIndex)
        {
            return _rolls[frameIndex] + _rolls[frameIndex + 1];
        }
        //If strike then get next 2 roll's points as bonus...
        private int StrikeScore(int frameIndex)
        {
            return 10 + _rolls[frameIndex + 1] + _rolls[frameIndex + 2];
        }
        //If Spare then get next frame's first roll's points as bonus...
        private int SpareScore(int frameIndex)
        {
            return 10 + _rolls[frameIndex + 2];
        }
        //Check whether Spare...
        private bool IsSpare(int frameIndex)
        {
            return (_rolls[frameIndex] + _rolls[frameIndex + 1]) == 10;
        }


    }
}
