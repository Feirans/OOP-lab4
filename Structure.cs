using System;

namespace Program;

struct Angle
{
    public int degre , minuta;
    
    public Angle(int degre , int minuta)
    {
        this.degre = degre;
        this.minuta = minuta;
        Normalize();
    }
    
    public void Normalize()
    {
        int TotalMinutes = degre * 60 + minuta;
        TotalMinutes = TotalMinutes %(360 * 60);
         if(totalMinutes < 0)
            {
                totalMinutes += 360 * 60; 
            }
            degre = totalMinutes / 60;
            minuta = totalMinutes % 60;
    }
        public double ToRadians()
        {
            double allDegrees = degre + minuta / 60.0;
            return allDegrees * Math.PI / 180.0;
    }
       
        
        public double GetSin()
        {
            return Math.Sin(ToRadians());
        }
        public void Add(Angle other)
        {
            degre += other.degre;
            minuta += other.minuta;
            Normalize();
            }
        public void Subtract(Angle other)
        {
            degre -= other.degre;
            minuta -= other.minuta;
            Normalize(); 
        }
        public bool IsEqual(Angle other)
        {
            return (degre * 60 + minuta) == (other.degre * 60 + other.minuta);
        }

        public bool IsGreater(Angle other)
        {
            return (degre * 60 + minuta) > (other.degre * 60 + other.minuta);
        }

        public bool IsLess(Angle other)
        {
            return (degre * 60 + minuta) < (other.degre * 60 + other.minuta);
        }
    }
    



