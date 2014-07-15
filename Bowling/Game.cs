using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class Game
    {
        private int _score = 0;
        private int[] _rolls = new int[21];
        private int _currentRoll;

        public void Roll(int pins)
        {
            _rolls[_currentRoll++] = pins;
        }

        public int GetScore()
        {
             int FrameIndex = 0;
             for (int Frame = 0; Frame < 10; Frame++)
             {
                if ((FrameIndex==9) &&_rolls[_currentRoll + FrameIndex - 1] == 0)
                        break;
                   
                    if ((_currentRoll-FrameIndex<1) && _rolls[_currentRoll + FrameIndex - 1] == 0 && _rolls[_currentRoll + FrameIndex] == 0)
                        break;
                    
                    if (_currentRoll == 12)
                        break;
                   
                    if((_currentRoll-FrameIndex==1 || _currentRoll-FrameIndex==2) && _rolls[_currentRoll]==0 && _rolls[FrameIndex]==10)
                    {
                       Console.WriteLine("2 more rolls");
                       Roll(10);
                       Roll(10);
                      _score += _rolls[FrameIndex] + _rolls[_currentRoll - 1] + _rolls[_currentRoll - 2];
                      if (_currentRoll == 3 || _currentRoll == 6 || _currentRoll == 9)
                          break;

                    }
                    if (_currentRoll - FrameIndex == 3 && _rolls[_currentRoll] == 0 && _rolls[_currentRoll - 1] == 0)
                        break;
                    if (_currentRoll - FrameIndex == 2 && _rolls[_currentRoll] == 0)
                        break;
                    if (_currentRoll - FrameIndex == 1 && _rolls[_currentRoll] == 0)
                        break;
                    
                    if (IsStrike(FrameIndex))
                    {
                       _score += StrikeScore(FrameIndex);
                       FrameIndex++;
                    }
                    else
                    {
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


        private bool IsStrike(int frameIndex)
        {
            return _rolls[frameIndex] == 10;
        }


        private int FrameScore(int frameIndex)
        {
            return _rolls[frameIndex] + _rolls[frameIndex + 1];
        }
        private int StrikeScore(int frameIndex)
        {

            return 10 + _rolls[frameIndex + 1] + _rolls[frameIndex + 2];

        }
        private int SpareScore(int frameIndex)
        {
            return 10 + _rolls[frameIndex + 2];
        }
        private bool IsSpare(int frameIndex)
        {
            return (_rolls[frameIndex] + _rolls[frameIndex + 1]) == 10;
        }


    }
}
