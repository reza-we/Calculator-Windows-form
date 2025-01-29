using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace mashin_hesab
{
    public partial class Mains : Form
    {

        double Adad1, Adad2;
        string Amalyat;
        List<string> h = new List<string>();
        public Mains()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) 
        {
            this.Width = 339;
            btnequal.Width = 120;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e) 
        {
     
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DialogResult khroj = MessageBox.Show
                ("آیا میخواهید از ماشین حساب خارج شوید ؟",
                "خروج", 
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );
            if (khroj == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void standardToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Width = 339;
            btnequal.Width = 120;
        }

        private void scientificToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Width = 466;
            btnequal.Width = 246;
        }

        private void btn_adad(object sender, EventArgs e)
        {
            Button adad = (Button)sender ;

            if (display.Text == "0") 
                {
                display.Text = "";
                }
            if (adad.Text == ".")
            {
                if (display.Text.Contains("."))
                {

                }
                else
                {
                    display.Text += adad.Text;
                }
            }
            else
            {
                display.Text += adad.Text;
            }

        }

        private void btnequal_Click(object sender, EventArgs e)
        {
            try
            {
                Adad2 = Convert.ToDouble(display.Text);

                switch (Amalyat)
                {
                    case "+":
                        display.Text = (Adad1 + Adad2).ToString();
                        break;
                    case "-":
                        display.Text = (Adad1 - Adad2).ToString();
                        break;
                    case "×":
                        display.Text = (Adad1 * Adad2).ToString();
                        break;
                    case "÷":
                        display.Text = (Adad1 / Adad2).ToString();
                        break;
                    case "Mod":
                        display.Text = (Adad1 % Adad2).ToString();
                        break;
                    case "Exp":
                        display.Text = (Math.Pow(Adad1, Adad2)).ToString();
                        break;
                }
            }
            catch
            {
                display.Text = "You can only input numbers";
            }
        }

        private void btnpm_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(display.Text);
                display.Text = (-x).ToString();
            }
            catch
            {
                display.Text = "You can only input numbers";
            }
        }

        private void btndarsad_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(display.Text);
                display.Text = (x / 100).ToString();
            }
            catch
            {
                display.Text = "You can only input numbers";
            }
        }

        private void btnpie_Click(object sender, EventArgs e)
        {
            display.Text = "3.14159265359";
        }

        private void btne_Click(object sender, EventArgs e)
        {
            display.Text = "2.71828182846";
        }

        private void btnx2_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(display.Text);
                display.Text = (x * x).ToString();
            }
            catch
            {
                display.Text = "You can only input numbers";
            }
        }

        private void btnx3_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(display.Text);
                display.Text = (x * x * x).ToString();
            }
            catch
            {
                display.Text = "You can only input numbers";
            }
        }

        private void btnx4_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(display.Text);
                display.Text = (x * x * x * x).ToString();
            }
            catch
            {
                display.Text = "You can only input numbers";
            }
        }

        private void btnradical_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(display.Text);

                if (x < 0)
                {
                    display.Text = "      accepted range :       x >= 0";
                    return;
                }
                double hads = x / 2.0;
                double deghat = 0.00000000000001;

                while ((hads * hads - x) > deghat || (x - hads * hads) > deghat)
                {
                    hads = (hads + x / hads) / 2.0;
                }

                display.Text = Convert.ToString(hads);
            }
            catch
            {
                display.Text = "You can only input numbers";
            }

        }

        private void btnlog_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(display.Text);

                if (x <= 0)
                {
                    display.Text = "      accepted range :       x > 0";
                    return;
                }

                double result = 0.0;
                double term = (x - 1) / (x + 1);
                double termSquared = term * term;
                double currentTerm = term;
                int n = 1;

                while (currentTerm > 1e-15 || currentTerm < -1e-15)
                {
                    result += currentTerm / n;
                    currentTerm *= termSquared;
                    n += 2;
                }


                double log10e = 0.4342944819032518;
                result = 2 * result * log10e;

                display.Text = result.ToString();
            }
            catch
            {
                display.Text = "You can only input numbers";
            }
        }

        private void btnsin_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(display.Text);

                x = x * (3.14159265358979323846 / 180.0);
                double sinValue = 0;
                double term = x;
                int n = 1;

                double ghadr(double value)
                {
                    return value < 0 ? -value : value;
                }

                while (ghadr(term) > 0.000001)
                {
                    sinValue += term;
                    term *= -x * x / (2 * n * (2 * n + 1));
                    n++;
                }
                display.Text = Convert.ToString(sinValue);
            }
            catch
            {
                display.Text = "You can only input numbers";
            }
        }

        private void btncos_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(display.Text);

                x = x * (3.14159265358979323846 / 180.0);
                double cosValue = 0;
                double term = 1;
                int n = 0;

                double ghadr(double value)
                {
                    return value < 0 ? -value : value;
                }

                while (ghadr(term) > 0.000001)
                {
                    cosValue += term;
                    n++;
                    term *= -x * x / (2 * n * (2 * n - 1));
                }
                cosValue = (int)(cosValue * 10000 + 0.5) / 10000.0;
                display.Text = Convert.ToString(cosValue);
            }
            catch
            {
                display.Text = "You can only input numbers";
            }
        }

        private void btntan_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(display.Text);
                x = x * (3.14159265358979323846 / 180.0);
                double sinValue = 0;
                double termSin = x;
                int nSin = 1;
                double ghadr(double value)
                {
                    return value < 0 ? -value : value;
                }

                while (ghadr(termSin) > 0.000001)
                {
                    sinValue += termSin;
                    termSin *= -x * x / (2 * nSin * (2 * nSin + 1));
                    nSin++;
                }
                double cosValue = 0;
                double termCos = 1;
                int nCos = 0;

                while (ghadr(termCos) > 0.000001)
                {
                    cosValue += termCos;
                    nCos++;
                    termCos *= -x * x / (2 * nCos * (2 * nCos - 1));
                }
                double tanValue;
                if (ghadr(cosValue) < 0.000001)
                {
                    tanValue = double.NaN;
                }
                else
                {
                    tanValue = sinValue / cosValue;
                }
                tanValue = (int)(tanValue * 10000 + 0.5) / 10000.0;
                display.Text = Convert.ToString(tanValue);
            }
            catch
            {
                display.Text = "You can only input numbers";
            }
        }



        private void btnfx_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(display.Text);
                if (x == 0)
                {
                    display.Text = "Can't divide by zero";
                }
                else
                {
                    display.Text = Convert.ToString(1 / x);
                }
            }
            catch
            {
                display.Text = "You can only input numbers";
            }
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            if (display.Text.Length > 0)
            {
                display.Text = display.Text.Remove(display.Text.Length - 1, 1);
            }
      
            if (display.Text == "")
            {
                display.Text = "0";
            }
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            if (display.Text.Length > 0)
            {
                Adad1 = 0;
                Adad2 = 0;
                Amalyat = "";
                display.Text = "0";
            }
        }

        private void btnSinh_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(display.Text);
                x = Math.Sinh(x);
                display.Text = x.ToString();
            }
            catch 
            {
                display.Text = "You can only input numbers";
            }
        }

        private void btnCosh_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(display.Text);
                x = Math.Cosh(x);
                display.Text = Convert.ToString(x);
            }
            catch
            {
                display.Text = "You can only input numbers";
            }
        }

        private void btnTanh_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(display.Text);
                x = Math.Tanh(x);
                display.Text = Convert.ToString(x);
            }
            catch
            {
                display.Text = "you can only input numbers";
            }
        }

        private void btnSinm_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(display.Text);

                if (x >= -1 && x <= 1)
                {
                    x = Math.Asin(x);
                    display.Text = Convert.ToString(x);
                }
                else
                {
                    display.Text = "      accepted range :      -1 <= x <= 1";
                }
            }
            catch
            {
                display.Text = "You can only input numbers";
            }
        }

        private void btnCosm_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(display.Text);

                if (x >= -1 && x <= 1)
                {
                    x = Math.Acos(x);
                    display.Text = Convert.ToString(x);
                }
                else
                {
                    display.Text = "      accepted range :      -1 <= x <= 1";
                }
            }
            catch
            {
                display.Text = "You can only input numbers";
            }
        }

        private void btnTanm_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(display.Text);
                x = Math.Atan(x);
                display.Text = Convert.ToString(x);
            }
            catch
            {
                display.Text = "You can only input numbers";
            }
        }

        private void btnln_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(display.Text);

                if (x <= 0)
                {
                    display.Text = "      accepted range :       x > 0";
                    return;
                }

                double result = 0;

                while (x > 2)
                {
                    result += 0.693147;
                    x /= 2;
                }
                double y = x - 1;
                double term = y;
                int n = 1;

                while (term != 0)
                {
                    result += term;
                    n++;
                    term *= -y;
                    term /= n;
                }

                display.Text = Convert.ToString(result);
            }
            catch
            {
                display.Text = "You can only input numbers";
            }
        }

        private void btnMp_Click(object sender, EventArgs e)
        {
            if (h.Count == 0)
            {
                h.Add(display.Text);
            }
            else
            {
                h.Clear();
                h.Add(display.Text);
            }
        }

        private void btnMm_Click(object sender, EventArgs e)
        {
            if (h.Count == 0)
            {
                display.Text = "list is empty";
            }
            else
            {
                h.Clear();
            }
        }

        private void btnMc_Click(object sender, EventArgs e)
        {
            h.Clear();
            display.Text = "list is empty";
         
        }

        private void btnMs_Click(object sender, EventArgs e)
        {
            if (h.Count == 0)
            {
                display.Text = "list is empty";
            }
            else
            {
                display.Text = h[0];
            }
        }

        private void btnDec_Click(object sender, EventArgs e)
        {
            string input = display.Text;
            int decimalValue;

            try
            {
                decimalValue = Convert.ToInt32(input, 2);
                display.Text = decimalValue.ToString();
            }
            catch
            {
                display.Text = "you can only input binary numbers";
            }
        }

        private void btnHex_Click(object sender, EventArgs e)
        {
            try
            {

                string input = display.Text;

                int dec = Convert.ToInt32(input, 10);

                string hex = Convert.ToString(dec, 16).ToUpper();

                display.Text = hex;
            }
            catch
            {
                display.Text = "You can only input numbers";
            }
        }

        private void btnOct_Click(object sender, EventArgs e)
        {
            try
            {

                string input = display.Text;

                int dec = Convert.ToInt32(input, 10);

                string oct = Convert.ToString(dec, 8);

                display.Text = oct;
            }
            catch
            {
                display.Text = "You can only input numbers";
            }
        }

        private void btnBin_Click(object sender, EventArgs e)
        {
            try
            {

                string input = display.Text;


                int dec = Convert.ToInt32(input, 10);


                string bin = Convert.ToString(dec, 2);

                display.Text = bin;
            }
            catch
            {
                display.Text = "You can only input numbers";
            }
        }

        private void btn_amalyat(object sender, EventArgs e)
        {
            Button amalyat = (Button)sender;

            try
            {
                Adad1 = Convert.ToDouble(display.Text);
                Amalyat = amalyat.Text;
                display.Text = "0";
            }
            catch
            {
                display.Text = "You can only input numbers";
            }
        }
    }
}
