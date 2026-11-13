using System;

namespace Program;

struct Angle
{
    public int degre , minuta;
    
    public Angle(int degre , int minuta)
    {
    try
            {
                if (minuta < 0 || minuta >= 60)
                {
                    throw new ArgumentException("Мінути повинні бути в межах від 0 до 59!");
                }

                this.degre = degre;
                this.minuta = minuta;
                Normalize();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"[Помилка конструктора]: {ex.Message} Встановлено значення 0° 0'.");
                this.degre = 0;
                this.minuta = 0;
            }
            finally
            {
                
            }
        }
    public void Normalize()
    {
        int totalMinutes = degre * 60 + minuta;
        totalMinutes = totalMinutes %(360 * 60);
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
        public override string ToString()
        {
            return $"{degre}° {minuta}'";
        }
    }
    



