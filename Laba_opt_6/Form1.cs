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
            for (int i = 0; i < 200; i++)
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
        public double zi(int k)
        {
            double z = 0;

            for (int j = 0; j < k-10 ;j++)
            {
                z = 0;
                for (int i = j; i < j + 10; i++)
                {
                    z = z + (xi(i) * (Math.Sqrt(2500.0 / (Qi(k) * 0.12*19125)) * Math.Exp( -0.12 * 0.025 * (j - i))));
                    
                }
                Z.Add(z / 10);
            }
            
            return( z / 10);
        }
        //Math.Log(k / (Qi(200)*(20 - s)))
        public double Ki(int s)
        {
            double k = 0;
            for (int i = 1; i < 190 - s; i++)
            {
                k = k + ((X[i] - Ni(200)) * (X[ s+i ] - Ni(200)));
                K.Add( k / (190 - s));
                A.Add(Math.Abs(Math.Log(-K[i-1]/Qi(200))/s));

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
            xi(200);
            for (int i = 0; i < 200; i++)
            {
                chart1.Series[0].Points.AddXY(i, X[i]);
            }
            Console.WriteLine("M(x) = " + Ni(200));
            Console.WriteLine("Q(x) = " + Qi(200));

            zi(200);
            for (int i = 0; i < 190; i++)
            {
                chart2.Series[0].Points.AddXY(i, Z[i]);
            }
            Console.WriteLine("Mz(x) = " + Niz(190));
            Console.WriteLine("Qz(x) = " + Qiz(190));

            int n = 0;

            Ki(20);
            foreach (double d in K)
            {
                chart3.Series[0].Points.AddXY(n, K[n]);
                chart4.Series[0].Points.AddXY(n, A[n]);
                n = n + 1;
            }
            Console.WriteLine("a = " + A[n-1]);




        }
    }
}
