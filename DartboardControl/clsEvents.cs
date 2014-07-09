using System;

namespace DartsBoard.Controls.DartsBoard
{
	//Declare the delegates for each event
	public delegate void NoScoreThrownEventHandler( object sender, DartbordEventArgs e );
	public delegate void SingleThrownEventHandler( object sender, DartbordEventArgs e );
	public delegate void DoubleThrownEventHandler( object sender, DartbordEventArgs e );
	public delegate void TripleThrownEventHandler( object sender, DartbordEventArgs e );

	/// <summary>
	/// Holds data about the score and throw
	/// </summary>
	public class DartbordEventArgs : EventArgs
	{
		private readonly int mintScore;
		private readonly string mstrScore;
		private readonly int mintThrow;

		//Constructor
		public DartbordEventArgs( int Score, string ScoreText, int Throw )
		{
			this.mintScore = Score;
			this.mstrScore = ScoreText;
			this.mintThrow = Throw;
		}

		#region Properties
		public int Score
		{
			get
			{
				return mintScore;
			}
		}

		public string ScoreText
		{
			get
			{
				return mstrScore;
			}
		}

		public int Throw
		{
			get
			{
				return mintThrow;
			}
		}
		#endregion

	}

}
