using System;
using System.Windows.Forms;
using DartsBoard.Controls.DartsBoard;
using DartsLogic;

namespace DartsBoard
{
	/// <summary>
	/// Summary description for ctlDartbord.
	/// </summary>
	public class ctlDartbord : System.Windows.Forms.UserControl
    {
		private System.ComponentModel.Container components = null;

		public ctlDartbord()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlDartbord));
            this.picDartboard = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDartboard)).BeginInit();
            this.SuspendLayout();
            // 
            // picDartboard
            // 
            this.picDartboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picDartboard.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picDartboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picDartboard.Image = ((System.Drawing.Image)(resources.GetObject("picDartboard.Image")));
            this.picDartboard.Location = new System.Drawing.Point(0, 0);
            this.picDartboard.Name = "picDartboard";
            this.picDartboard.Size = new System.Drawing.Size(300, 300);
            this.picDartboard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDartboard.TabIndex = 0;
            this.picDartboard.TabStop = false;
            this.picDartboard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picDartbord_MouseUp);
            // 
            // ctlDartbord
            // 
            this.Controls.Add(this.picDartboard);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ctlDartbord";
            this.Size = new System.Drawing.Size(300, 300);
            ((System.ComponentModel.ISupportInitialize)(this.picDartboard)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// This Init region is to declare the private class variables
		/// </summary>
		#region Init

		private int mintThrow = 1;
		private bool mIsNoScore = false;
		private bool mIsSingle = false;
		private bool mIsDouble = false;
		private bool mIsTriple = false;

		private enum enumRingType
		{
			None = 0,
			Single,
			Double,
			Triple,
			SingleBullsEye,
			DoubleBullsEye
		}

		#endregion

		/// <summary>
		/// This Properties region defines all the properties of the control.
		/// </summary>
		#region Properties

		private int mintScore = 0;
        private PictureBox picDartboard;
    
		public int Score
		{
		    get
		    {
		        return mintScore;
		    }
		}

		private string mstrScoreText = "";
		public string ScoreText
		{
			get
			{
				return mstrScoreText;
			}
		}

		#endregion

		/// <summary>
		/// This Methods region defines all the methods of the control.
		/// </summary>
		#region Methods
		
		public void ResetThrows()
		{
			mintThrow = 0;
		}

		#endregion

		/// <summary>
		/// This Events region defines all the events of the control.
		/// </summary>
		#region Events

		public event NoScoreThrownEventHandler NoScoreThrown;
		protected virtual void OnNoScoreThrown( DartbordEventArgs e )
		{
			if( NoScoreThrown != null )
			{
				NoScoreThrown( this, e );
			}
		}

		public event SingleThrownEventHandler SingleThrown;
		protected virtual void OnSingleThrown( DartbordEventArgs e )
		{
			if( SingleThrown != null )
			{
				SingleThrown( this, e );
			}
		}

		public event DoubleThrownEventHandler DoubleThrown;
		protected virtual void OnDoubleThrown( DartbordEventArgs e )
		{
			if( DoubleThrown != null )
			{
				DoubleThrown( this, e );
			}
		}

		public event TripleThrownEventHandler TripleThrown;
		protected virtual void OnTripleThrown( DartbordEventArgs e )
		{
			if( TripleThrown != null )
			{
				TripleThrown( this, e );
			}
		}

		#endregion

		/// <summary>
		/// This ControlActions region shows all the eventhandlers for the controls
		/// </summary>
		#region ControlActions
		private void picDartbord_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			try
			{
				int posX = (e.X - (Width / 2));
				int posY = ((Height / 2) - e.Y);

				mintScore = GetScore( posX, posY );

				//Raise the event(s)
				DartbordEventArgs dea = new DartbordEventArgs( mintScore, mstrScoreText, mintThrow );

				if( mIsTriple ) OnTripleThrown( dea );
				if( mIsDouble ) OnDoubleThrown( dea );
				if( mIsSingle ) OnSingleThrown( dea );
				if( mIsNoScore ) OnNoScoreThrown( dea );

				mintThrow++;
				if( mintThrow == 4 )
				{
					mintThrow = 1;
				}

			}
			catch( Exception ex )
			{
				throw ex;
			}

		}
		#endregion

		/// <summary>
		/// This Utilities region shows all the private procedures used in
		/// the Control Eventhandlers, Methods and Properties.
		/// </summary>
		#region Utilities

		/// <summary>
		/// Calculates the thrown score based on the X and Y coordinates
		/// </summary>
		/// <param name="posX"></param>
		/// <param name="posY"></param>
		/// <returns></returns>
		private int GetScore( int posX, int posY )
		{
			try
			{
				int intScore = 0;

				double dblHoekInRadians = System.Math.Atan2( posY, posX );
				double dblHoekInGraden = dblHoekInRadians * 180 / System.Math.PI;

				int intHoek = (int)dblHoekInGraden;
				if( intHoek < 0 )
				{
					intHoek = 180 + (intHoek+180);
				}

				int intNummer = GetNumber( intHoek );
				enumRingType enmRing = GetRing(posX, posY);
				mIsNoScore = false;
				mIsSingle = false;
				mIsDouble = false;
				mIsTriple = false;

				switch( enmRing )
				{
					case enumRingType.None:
						mstrScoreText = "-";
						intScore = 0;
						mIsNoScore = true;
						break;

					case enumRingType.Single:
						mstrScoreText = "S" + intNummer.ToString();
						intScore = intNummer;
						mIsSingle = true;
						break;

					case enumRingType.Double:
						mstrScoreText = "D" + intNummer.ToString();
						intScore = intNummer * 2;
						mIsDouble = true;
						break;

					case enumRingType.Triple:
						mstrScoreText = "T" + intNummer.ToString();
						intScore = intNummer * 3;
						mIsTriple = true;
						break;

					case enumRingType.SingleBullsEye:
						mstrScoreText = "SingleBull";
						intScore = 25;
						mIsSingle = true;
						break;

					case enumRingType.DoubleBullsEye:
						mstrScoreText = "DoubleBull";
						intScore = 50;
						mIsDouble = true;
						break;
				}

				return intScore;
			}
			catch( Exception ex )
			{
				throw ex;
			}
		}

		/// <summary>
		/// Gets the "pie slice" based on given degree
		/// </summary>
		/// <param name="HoekInGraden"></param>
		/// <returns></returns>
		private int GetNumber( int HoekInGraden )
		{
			try
			{
				if( HoekInGraden >= 351 ) return 6;
				if( HoekInGraden >= 333 ) return 10;
				if( HoekInGraden >= 315 ) return 15;
				if( HoekInGraden >= 297 ) return 2;
				if( HoekInGraden >= 279 ) return 17;
				if( HoekInGraden >= 261 ) return 3;
				if( HoekInGraden >= 243 ) return 19;
				if( HoekInGraden >= 225 ) return 7;
				if( HoekInGraden >= 207 ) return 16;
				if( HoekInGraden >= 189 ) return 8;
				if( HoekInGraden >= 171 ) return 11;
				if( HoekInGraden >= 153 ) return 14;
				if( HoekInGraden >= 135 ) return 9;
				if( HoekInGraden >= 117 ) return 12;
				if( HoekInGraden >= 99 ) return 5;
				if( HoekInGraden >= 81 ) return 20;
				if( HoekInGraden >= 63 ) return 1;
				if( HoekInGraden >= 45 ) return 18;
				if( HoekInGraden >= 27 ) return 4;
				if( HoekInGraden >= 9 ) return 13;

				return 6;
			}
			catch( Exception ex )
			{
				throw ex;
			}
		}

		/// <summary>
		/// Gets one of the rings based on the X and Y coordinates
		/// </summary>
		/// <param name="posX"></param>
		/// <param name="posY"></param>
		/// <returns></returns>
		private enumRingType GetRing(int posX, int posY)
		{
			try
			{
				double dblLengte = System.Math.Sqrt( posX*posX + posY*posY );
				int intLengte = (int)System.Math.Floor( dblLengte );

			    var realRadius = Width/2;
			    var normCoeff = (double)150/realRadius;
			    var normalLength = intLengte*normCoeff;

                if (normalLength > 112) return enumRingType.None;

                if (normalLength <= 5) return enumRingType.DoubleBullsEye;
                if (normalLength > 5 && normalLength <= 12) return enumRingType.SingleBullsEye;
                if (normalLength >= 65 && normalLength <= 71) return enumRingType.Triple;
                if (normalLength >= 106 && normalLength <= 112) return enumRingType.Double;

				return enumRingType.Single;
			}
			catch( Exception ex )
			{
				throw ex;
			}
		}
		#endregion

        private void picDartbord_Click(object sender, EventArgs e)
        {

        }

	}

}
