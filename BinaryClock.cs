using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryClock
{
    public partial class BinaryClock : Form
    {
        public BinaryClock()
        {
            InitializeComponent();

            this.tick.Interval = 1000;
            this.tick.Start();
        }

        public string ToBinary(int item)
        {
            string res = Convert.ToString(item, 2);
            return new string('0', 4 - res.Length) + res;
        }
        
        public void UpdateLights(string bin, Color fillColour, Panel[] panels)
        {
            bin = bin.Substring(bin.Length - panels.Length);
            bin = new string(bin.Reverse().ToArray());

            for (int i = 0; i < panels.Length; i++)
            {
                Panel panel = panels[i];
                Color colour = bin[i].ToString() == "1" ? fillColour : Color.FromArgb(18, 32, 79);

                panel.BackColor = colour;
            }
        }

        private void Seconds(string seconds)
        {
            string left = seconds[0].ToString();
            string right = seconds[1].ToString();

            string binLeft = this.ToBinary(Convert.ToInt32(left));
            string binRight = this.ToBinary(Convert.ToInt32(right));

            this.SLnum.Text = left;
            this.SRnum.Text = right;

            this.SLbin.Text = binLeft;
            this.SRbin.Text = binRight;

            Color colour = Color.FromArgb(226, 57, 113);

            this.UpdateLights(binLeft, colour, new Panel[] { this.SL1, this.SL2, this.SL3 });
            this.UpdateLights(binRight, colour, new Panel[] { this.SR1, this.SR2, this.SR3, this.SR4 });
        }

        private void Minutes(string minutes)
        {
            string left = minutes[0].ToString();
            string right = minutes[1].ToString();

            string binLeft = this.ToBinary(Convert.ToInt32(left));
            string binRight = this.ToBinary(Convert.ToInt32(right));

            this.MLnum.Text = left;
            this.MRnum.Text = right;
                 
            this.MLbin.Text = binLeft;
            this.MRbin.Text = binRight;

            Color colour = Color.FromArgb(139, 194, 74);

            this.UpdateLights(binLeft, colour, new Panel[] { this.ML1, this.ML2, this.ML3 });
            this.UpdateLights(binRight, colour, new Panel[] { this.MR1, this.MR2, this.MR3, this.MR4 });
        }

        private void Hours(string hours)
        {
            string left = hours[0].ToString();
            string right = hours[1].ToString();

            string binLeft = this.ToBinary(Convert.ToInt32(left));
            string binRight = this.ToBinary(Convert.ToInt32(right));

            this.HLnum.Text = left;
            this.HRnum.Text = right;
                 
            this.HLbin.Text = binLeft;
            this.HRbin.Text = binRight;

            Color colour = Color.FromArgb(3, 170, 243);

            this.UpdateLights(binLeft, colour, new Panel[] { this.HL1, this.HL2 });
            this.UpdateLights(binLeft, colour, new Panel[] { this.HR1, this.HR2, this.HR3, this.HR4 });
        }

        private void Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            string seconds = now.ToString("ss");
            string minutes = now.ToString("mm");
            string hours = now.ToString("HH");

            this.Seconds(seconds);
            this.Minutes(minutes);
            this.Hours(hours);
        }
    }
}
