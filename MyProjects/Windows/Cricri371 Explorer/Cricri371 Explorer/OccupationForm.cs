using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cricri371_Explorer
{
	public partial class OccupationForm
    {
        #region OccupationForm
        public OccupationForm(string message)
		{
			InitializeComponent();
			
			lOccupation.Text=message;
			
			pBarOccupation.Maximum=10;
        }
        #endregion

        #region TimerOccupationTick
        void TimerOccupationTick(object sender, System.EventArgs e)
		{
			if(pBarOccupation.Value!=pBarOccupation.Maximum)
				pBarOccupation.Increment(1);
			else
				pBarOccupation.Value=0;
        }
        #endregion

        #region FOccupationFormClosed
        void FOccupationFormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
		{
			timerOccupation.Stop();
        }
        #endregion
    }
}
