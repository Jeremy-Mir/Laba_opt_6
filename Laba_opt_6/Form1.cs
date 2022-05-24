using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_opt_6
{
    public partial class Form1 : Form
    {
        public double Ni(int N)
        {
            double M = 0;
            double x = 1;
            for (int i = 0; i<200;i++)
            {
                x = Math.Pow(5, 10) * x % Math.Pow(2, 16);
                M = M + ((x / Math.Pow(2, 16)) - 0.5);
            }
            return M / N;
        }
        public double Qi(int N)
        {
            double Q = 0;
            double x = 1;
            for (int i = 0; i < N; i++)
            {
               
                Q = Q + Math.Pow(xi(N) - Ni(N), 2);
            }
            return Q / N;
        }
        public double xi(int I)
        {
            double x = 1;
            for (int i = 0; i < I; i++)
            {
                x = Math.Pow(5, 10) * x % Math.Pow(2, 16);
                
            }
           return (x / Math.Pow(2, 16)) - 0.5;
        }
        public double zi(int k)
        {
            double Z = 0;
           
            for (int i = k; i < k+10; i++)
            {
                Z = Z + (xi(i) * Math.Pow(2500.0 / (Qi(k) * 0.12), 1.0 / 2.0)*Math.Pow(Math.E,-0.12*(i-k))+ 200);
                chart2.Series[0].Points.AddXY(i-k, Z);

            }
            return Z / 10;
        }
        //Math.Log(k / (Qi(200)*(20 - s)))
        public double Ki(int s)
        {
            double k = 0;
            for (int i = 1; i < 200 - s; i++)
            {
                k = k + (xi(i) - Ni(i)) * (xi(s + i) - Ni(i));

                chart4.Series[0].Points.AddXY(i, k / (200 - s));

            }
            return k / (200-s);
        }
        public Form1()
        {
            InitializeComponent();
            double h1 = Math.Pow(5, 10);
            double h2 = Math.Pow(2, 16);
            double M0 = 200;
            double q0 = 2500;
            double a = 0.12;
            int N = 200;
            double z0 = 1;
            double k = 20;
            double x = 1;
            for (int i = 0; i < 200; i++)
            {
                x = Math.Pow(5, 10) * x % Math.Pow(2, 16);

                chart1.Series[0].Points.AddXY(i, (x / Math.Pow(2, 16)) - 0.5);

                
            }
            for (int i = 0; i < 20; i++)
            {
                k = Qi(200) * Math.Exp(-0.12 * Math.Abs(i));
                chart3.Series[0].Points.AddXY(i,k);


            }


            Console.WriteLine(Ni(200));
            Console.WriteLine(Qi(200));
            Console.WriteLine(zi(200));
            Console.WriteLine(Ki(20));
            
        }
    }
}
