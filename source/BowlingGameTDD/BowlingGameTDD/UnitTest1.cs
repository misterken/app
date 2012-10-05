using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingGame;

namespace BowlingGameTDD
{
	/// <summary>
	/// Summary description for UnitTest1
	/// </summary>
	[TestClass]
	public class UnitTest1
	{
		public UnitTest1()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region Additional test attributes
		//
		// You can use the following additional attributes as you write your tests:
		//
		// Use ClassInitialize to run code before running the first test in the class
		// [ClassInitialize()]
		// public static void MyClassInitialize(TestContext testContext) { }
		//
		// Use ClassCleanup to run code after all tests in a class have run
		// [ClassCleanup()]
		// public static void MyClassCleanup() { }
		//
		// Use TestInitialize to run code before running each test 
		// [TestInitialize()]
		// public void MyTestInitialize() { }
		//
		// Use TestCleanup to run code after each test has run
		// [TestCleanup()]
		// public void MyTestCleanup() { }
		//
		#endregion

		[TestMethod]
		public void InstantiateGame()
		{
			// Arrange

			// Act
			Game g = new Game();

			// Assert
			Assert.IsNotNull(g);
		}

		[TestMethod]
		public void InitializeGame()
		{
			// Arrange

			// Act
			Game g = new Game();
			int frameNumber = g.FrameNumber;

			// Assert
			Assert.AreEqual(1, frameNumber);
		}

		[TestMethod]
		public void RegisterRoll1()
		{
			// Arrange

			// Act
			Game g = new Game();
			int currentFrameNumber = g.FrameNumber;
			g.RegisterRoll(5);
			Frame currentFrame = g.GetFrame(currentFrameNumber);

			// Assert
			Assert.AreEqual(5, currentFrame.Roll1);
		}

		[TestMethod]
		public void RegisterRoll2()
		{
			// Arrange

			// Act
			Game g = new Game();
			int currentFrameNumber = g.FrameNumber;
			g.RegisterRoll(5);
			g.RegisterRoll(3);
			Frame currentFrame = g.GetFrame(currentFrameNumber);


			// Assert
			Assert.AreEqual(3, currentFrame.Roll2);
			Assert.AreEqual(2, g.FrameNumber);
		}

		[TestMethod]
		public void IsFrameComplete_IfStrke()
		{
			// Arrange

			// Act
			Game g = new Game();
			int currentFrameNumber = g.FrameNumber;
			g.RegisterRoll(10);

			// Assert
			Assert.IsTrue(g.GetFrame(currentFrameNumber).IsFrameComplete(currentFrameNumber));
		}

		[TestMethod]
		public void IsFrameComplete_NoRolls()
		{
			// Arrange

			// Act
			Game g = new Game();
			int currentFrameNumber = g.FrameNumber;

			// Assert
			Assert.IsFalse(g.GetFrame(currentFrameNumber).IsFrameComplete(currentFrameNumber));
		}

		[TestMethod]
		public void IsFrameComplete_OnlyOneRoll()
		{
			// Arrange

			// Act
			Game g = new Game();
			int currentFrameNumber = g.FrameNumber;
			g.RegisterRoll(6);

			// Assert
			Assert.IsFalse(g.GetFrame(currentFrameNumber).IsFrameComplete(currentFrameNumber));
		}

		[TestMethod]
		public void IsFrameComplete_TwoRolls()
		{
			// Arrange

			// Act
			Game g = new Game();
			int currentFrameNumber = g.FrameNumber;
			g.RegisterRoll(6);
			g.RegisterRoll(3);

			// Assert
			Assert.IsTrue(g.GetFrame(currentFrameNumber).IsFrameComplete(currentFrameNumber));
		}

		[TestMethod]
		public void Calculate_Score()
		{
			// Arrange

			// Act
			Game g = new Game();
			int currentFrameNumber = g.FrameNumber;
			g.RegisterRoll(6);
			g.RegisterRoll(3);

			// Assert
			Assert.AreEqual(9, g.GetFrame(currentFrameNumber).Score);
		}

		[TestMethod]
		public void Calculate_ScoreAfterTwoNormalFrames()
		{
			// Arrange

			// Act
			Game g = new Game();
			int currentFrameNumber = g.FrameNumber;
			g.RegisterRoll(6);
			g.RegisterRoll(3);
			currentFrameNumber = g.FrameNumber;
			g.RegisterRoll(4);
			g.RegisterRoll(2);
			
			// Assert
			Assert.AreEqual(15, g.GetFrame(currentFrameNumber).Score);
		}

		[TestMethod]
		public void Calculate_ScoreAfterFirstRollAfterSpare()
		{
			// Arrange

			// Act
			Game g = new Game();
			int currentFrameNumber = g.FrameNumber;
			g.RegisterRoll(6);
			g.RegisterRoll(4);
			currentFrameNumber = g.FrameNumber;
			g.RegisterRoll(4);

			// Assert
			Assert.AreEqual(14, g.GetFrame(currentFrameNumber-1).Score);
		}

		[TestMethod]
		public void Calculate_ScoreAfterTwoBallsRolledFollowingAStrike_IfTwoBallsAreInFollowingFrame()
		{
			// Arrange

			// Act
			Game g = new Game();
			int currentFrameNumber = g.FrameNumber;
			g.RegisterRoll(10);
			currentFrameNumber = g.FrameNumber;
			g.RegisterRoll(4);
			g.RegisterRoll(3);

			// Assert
			Assert.AreEqual(17, g.GetFrame(currentFrameNumber - 1).Score);
		}

		[TestMethod]
		public void Calculate_ScoreAfterTwoBallsRolledFollowingAStrike_AreTwoStrikeAreInTwoDifferentFrames()
		{
			// Arrange

			// Act
			Game g = new Game();
			int currentFrameNumber = g.FrameNumber;	// Frame 1
			g.RegisterRoll(10);
			g.RegisterRoll(10);
			g.RegisterRoll(10);
			currentFrameNumber = g.FrameNumber; // Frame 4 now

			// Assert
			Assert.AreEqual(30, g.GetFrame(currentFrameNumber - 3).Score);
			Assert.IsFalse(g.IsGameOver());
		}

		[TestMethod]
		public void CalculateScoreForWholeGame()
		{
			// Arrange

			// Act
			Game g = new Game();

			// Frame 1, Score: 8 
			g.RegisterRoll(3);
			g.RegisterRoll(5);

			// Frame 2, Score: 26
			g.RegisterRoll(3);
			g.RegisterRoll(7);

			// Frame 3, Score: 34
			g.RegisterRoll(8);
			g.RegisterRoll(0);

			// Frame 4, Score:  54
			g.RegisterRoll(6);
			g.RegisterRoll(4);

			// Frame 5, Score:  69
			g.RegisterRoll(10);

			// Frame 6, Score:  74
			g.RegisterRoll(2);
			g.RegisterRoll(3);

			// Frame 7, Score:  97
			g.RegisterRoll(10);

			// Frame 8, Score:  114
			g.RegisterRoll(10);

			// Frame 9, Score:  121
			g.RegisterRoll(3);
			g.RegisterRoll(4);

			// Frame 10, Score:  151
			g.RegisterRoll(10);
			g.RegisterRoll(10);
			g.RegisterRoll(10);

			if (g.IsGameOver())
				g.ComputeFinalScore();

			Console.WriteLine("Frame {0}: {1}", 1, g.GetFrame(1).Score);
			Console.WriteLine("Frame {0}: {1}", 2, g.GetFrame(2).Score);
			Console.WriteLine("Frame {0}: {1}", 3, g.GetFrame(3).Score);
			Console.WriteLine("Frame {0}: {1}", 4, g.GetFrame(4).Score);
			Console.WriteLine("Frame {0}: {1}", 5, g.GetFrame(5).Score);
			Console.WriteLine("Frame {0}: {1}", 6, g.GetFrame(6).Score);
			Console.WriteLine("Frame {0}: {1}", 7, g.GetFrame(7).Score);
			Console.WriteLine("Frame {0}: {1}", 8, g.GetFrame(8).Score);
			Console.WriteLine("Frame {0}: {1}", 9, g.GetFrame(9).Score);
			Console.WriteLine("Frame {0}: {1}", 10, g.GetFrame(10).Score);

			// Assert
			Assert.IsTrue(g.IsGameOver());
			Assert.AreEqual(30, 30);
			Assert.IsNotNull(g.GetFrame(10).Score);	// Confirms g.ComputeFinalScore() activated
			Assert.AreEqual(151, g.GetFrame(10).Score);	// Confirms.g.ComputeFinalScore() scored correctly as well as computation across all frames
		}
	}
}
