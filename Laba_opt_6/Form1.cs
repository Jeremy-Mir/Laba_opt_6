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
            for (int i = 0; i < N; i++)
            {

                M = M + (X[i]);
            }
            return M / N;
        }
        public double Qi(int N)
        {
            double Q = 0;
            for (int i = 0; i < N; i++)
            {
                Q = Q + Math.Pow(X[i] - Ni(N), 2);
            }
            return Q / N;
        }
        public double Niz(int N)
        {
            double M = 0;
            double x = 1;
            for (int i = 0; i < N; i++)
            {

                M = M + (Z[i]);
            }
            return M / N;
        }
        public double Qiz(int N)
        {
            double Q = 0;
            for (int i = 0; i < N; i++)
            {
                Q = Q + Math.Pow(Z[i] - Niz(190), 2);
            }
            return Q / N;
        }
        public double xi(int I)
        {
            
            double x = 1;
            for (int i = 0; i < I; i++)
            {
                x = Math.Pow(5, 10) * x % Math.Pow(2, 16);
                X.Add((x / Math.Pow(2, 16)) - 0.5);
            }
            
           return (x / Math.Pow(2, 16)) - 0.5;
        }
        double find_C(double f, int m)
        {
            double A1 = 40000;
            double A2 = 35000;
            double A3 = 16000;
            double E1 = 67000;
            double E2 = 68000;
            double E3 = 70000;
            double R = 8.31;
            double C1 = 0.4;
            double C2 = 0.3;
            double T0 = 300;
            double T = T0;
            double Tt = 285;
            double Kt = 5000;
            double Q1 = 81000;
            double Q2 = 48600;
            double p = 810;
            double Ct = 1200;
            double K1;
            double K2;
            double K3;
            double C3 = 0;
            double C5 = 0;
            double C10 = C1;
            double C20 = C2;
            double C30 = 0;
            double C50 = 0;


            for (int t = 0; t < 1800; t = t+2)
            {
                Tt = Z[t/2];
                K1 = A1 * Math.Exp(-E1 / (R * T));
                K2 = A2 * Math.Exp(-E2 / (R * T));
                K3 = A3 * Math.Exp(-E3 / (R * T));
                C1 = C10 + (-K2 * C10 * C30 - 3 * K1 * C10 * C20 - 2 * K3 * C10 * C20)*2;
                C2 = C20 + (-K1 * C10 * C20 - 4 * K1 * C10 * C20) * 2;
                C3 = C30 + (K1 * C10 * C20 - K2 * C10 * C30) * 2;
                C5 = C50 + (K2 * C10 * C30) * 2;
                T = T0 + ((-Kt * f * (T0 - Tt)) + K1 * 3 * C10 * C20 * Q1 * m / p + K2 * C10 * C30 * Q2 * m / p) / Ct / m * 2;


                C10 = C1;
                C20 = C2;
                C30 = C3;
                C50 = C5;
                T0 = T;
                chart2.Series[0].Points.AddXY(t/2, T);
                Console.WriteLine(T);
                //Console.WriteLine(Math.Abs(T));
            }

            return C5;
        }
        public double zi(int k)
        {
            double z = 0;

            for (int j = 0; j < k-10 ;j++)
            {
                z = 0;
                for (int i = j; i < j + 10; i++)
                {
                    z = z + (xi(i) * (Math.Sqrt(25.0 / (Qi(k) * 0.05 * 0.6)) * Math.Exp( -0.05 * 0.1 * (j - i)))+285);
                    
                }
                Z.Add(z / 10);
            }
            
            return( z / 10);
        }
        public double Ki(int s)
        {
            double k = 0;
            for (int i = 1; i < 200 - s; i++)
            {
                k = k + ((X[i] - Ni(285)) * (X[ s+i ] - Ni(285)));
                K.Add( k / (200 - s));
                A.Add(Math.Log(-K[i-1]/Qi(285))/s);

            }
            return k / (190-s);
        }
       
        public List<double> X = new List<double>();
        public List<double> Z = new List<double>();
        public List<double> K = new List<double>();
        public List<double> A = new List<double>();

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
            xi(910);
            chart1.ChartAreas[0].AxisY.Maximum = 350;
            chart2.ChartAreas[0].AxisY.Maximum = 350;
            chart1.ChartAreas[0].AxisY.Minimum = 250;
            chart2.ChartAreas[0].AxisY.Minimum = 250;

            

            zi(910);
            for (int i = 0; i < 900; i++)
            {
                chart1.Series[0].Points.AddXY(i, Z[i]);

                Console.WriteLine(Z[i]);
                

                
            }
            Console.WriteLine(find_C(7, 3000));




        }
    }
}
