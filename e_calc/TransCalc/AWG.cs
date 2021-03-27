using System;

namespace TransCalc
{
    public class AWG
    {
        private int gauge;
        private double diameter_mm;
        private const double meters_in_inch = 0.0254;
        public static double meters_in_foot = meters_in_inch * 12;
        private const double mm_in_mils = 1 / 0.0254;
        // private const double copper_resistivity = 1.678e-8;
        // Annealed copper
        private const double copper_resistivity = 1.728e-8;

        private const double copper_density_kg_m3 = 8950;
        private const double copper_temperature_coeff = 0.00393;

        public AWG(int number, double value)
        {
            this.gauge = number;
            this.diameter_mm = value;
        }

        public int Gauge
        {
            get { return gauge; }
        }

        public double Diameter_mm
        {
            get { return diameter_mm; }
        }

        public double Diameter_m
        {
            get { return diameter_mm / 1000; }
        }

        public double Csa_m2
        {
            get { return Math.PI * Math.Pow(Diameter_m / 2, 2); }
        }

        public double Diameter_mils
        {
            get { return diameter_mm * mm_in_mils; }
        }

        public double GetCircularMils()
        {
            return Diameter_mils * Diameter_mils;
        }

        public double GetMaxCurrent(double ampacity_mil_per_amp)
        {
            return GetCircularMils() / ampacity_mil_per_amp;
        }

        public double CalculateResistance(double length_m, double tempC)
        {
            double res = copper_resistivity * (1 + (tempC - 20) * copper_temperature_coeff);
            return length_m * res / (Math.PI * Math.Pow(Diameter_m / (double)2, 2));
        }

        public double CalculateMass_g(double length_m)
        {
            double v = Csa_m2 * length_m;
            return v * copper_density_kg_m3 * 1000;
        }
    }
}
