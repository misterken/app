using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingGame
{
	public class Game
	{
		private Frame[] frames = new Frame[11];

		public Game()
		{
			FrameNumber = 1;
			for (int i = 0; i < 11; i++)
			{
				frames[i] = new Frame();
			}
		}

		public int FrameNumber { get; set; }

		public void RegisterRoll(int p)
		{
			if (frames[FrameNumber].Roll1 == null)
			{
				frames[FrameNumber].Roll1 = p;

				if (FrameNumber > 1)
				{
					// Previous Frame was a Spare
					if (IsFrameSpare(FrameNumber - 1))
						frames[FrameNumber - 1].Score = (FrameNumber-2 >= 1 ? frames[FrameNumber-2].Score : 0) + 10 + frames[FrameNumber].Roll1;

					// Previous Two Frames were a Strike
					if (IsFrameStrike(FrameNumber - 1) && IsFrameStrike(FrameNumber - 2))
						frames[FrameNumber - 2].Score = (FrameNumber-3 >= 1 ? frames[FrameNumber-3].Score : 0) + 20 + frames[FrameNumber].Roll1;
				}

			}
			else if (frames[FrameNumber].Roll2 == null)
			{
				frames[FrameNumber].Roll2 = p;

				if (IsFrameStrike(FrameNumber - 1))
					frames[FrameNumber - 1].Score = (FrameNumber-2 >= 1 ? frames[FrameNumber-2].Score : 0) + 10 + frames[FrameNumber].Roll1 + frames[FrameNumber].Roll2;
			}
			else if (FrameNumber == 10 && frames[FrameNumber].Roll3 == null)
				frames[FrameNumber].Roll3 = p;

			if (frames[FrameNumber].Roll1 + frames[FrameNumber].Roll2 < 10)
				frames[FrameNumber].Score = (FrameNumber-1 >= 1 ? frames[FrameNumber-1].Score : 0) + Convert.ToInt32(frames[FrameNumber].Roll1) + Convert.ToInt32(frames[FrameNumber].Roll2);

			if (frames[FrameNumber].IsFrameComplete(FrameNumber) == true)
				FrameNumber += 1;
		}

		public Frame GetFrame(int frameNumber)
		{
			return frames[frameNumber];
		}

		private bool IsFrameSpare(int frameNumber)
		{
			if (frames[frameNumber].Roll1 != 0 && frames[frameNumber].Roll2 != null && frames[frameNumber].Roll1 + frames[frameNumber].Roll2 == 10)
				return true;
			else
				return false;
		}

		private bool IsFrameStrike(int frameNumber)
		{
			if (frames[frameNumber].Roll1 == 10 && frames[frameNumber].Roll2 == null)
				return true;
			else
				return false;
		}

		public bool IsGameOver()
		{
			return FrameNumber == 11;
		}

		public void ComputeFinalScore()
		{
			if (FrameNumber == 11)
				frames[10].Score = frames[9].Score + (frames[10].Roll1 != null ? frames[10].Roll1 : 0) +
								   (frames[10].Roll2 != null ? frames[10].Roll2 : 0) +
								   (frames[10].Roll3 != null ? frames[10].Roll3 : 0);
		}
	}
}
