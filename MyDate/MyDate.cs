using System;

namespace MyDate_Namespace
{
    internal class MyDate
    {
        static (int month, int days)[] months_days =
        {
            (1, 31),
            (2, 28),
            (3, 31),
            (4, 30),
            (5, 31),
            (6, 30),
            (7, 31),
            (8, 31),
            (9, 30),
            (10, 31),
            (11, 30),
            (12, 31)
        };

        private int? year, month, day;

        public int? Year
        {
            get { return year; }
            set {
                try
                {
                    if (value < 0)
                        throw new Exception("Год не может быть отрицательным");
                    else
                        year = value;
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public int? Month
        {
            get { return month; }
            set
            {
                try
                {
                    if (value >= 1 && value <= 12)
                        month = value;
                    else
                        throw new Exception("Такого месяца нет");
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        public int? Day
        {
            get { return day; }
            set
            {
                try
                {
                    if (month.HasValue && value >= 1 && value <= months_days[month.Value - 1].days)
                        day = value;
                    else throw new Exception("День в неверном формате");
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        public MyDate()
        {
            Year = 2024;
            Month = 10;
            Day = 14;
        }

        public MyDate(int year)
        {
            Year = year;
            Month = null;
            Day = null;
        }

        public MyDate(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }

        public bool IsNotNullable() => (this.Year != null && this.Month != null && this.Day != null);

        public MyDate SmallerDate(MyDate second)
        {
            try
            {
                if (!this.IsNotNullable() || !second.IsNotNullable())
                    throw new Exception("Какая-то из дат в неверном формате");
                else
                {
                    if (this.Year < second.Year) return this;
                    if (this.Year > second.Year) return second;

                    if (this.Month < second.Month) return this;
                    if (this.Month > second.Month) return second;

                    if (this.Day < second.Day) return this;
                    if (this.Day > second.Day) return second;
                    return null;

                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public int CountDays()
        {
            int totalDays = 0;

            for (int y = 1; y < this.Year; y++)
                totalDays += 365; 

            for (int m = 1; m < this.Month; m++)
                totalDays += months_days[m - 1].days; 

            totalDays += this.Day ?? 0;

            return totalDays;
        }

        public int DatesDifference(MyDate second)
        {
            try
            {
                if (!this.IsNotNullable() || !second.IsNotNullable())
                    throw new Exception("Какая-то из дат в неверном формате");
                else
                    return Math.Abs(this.CountDays() - second.CountDays());
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }

        }

        public MyDate PlusDays(int days)
        {
            if (this.IsNotNullable())
            {
                try
                {
                    while (days > 0)
                    {
                        if (this.Day == months_days[this.Month.Value - 1].days)
                        {
                            if (this.Month == 12)
                            {
                                this.Month = 1;
                                this.Year++;
                            }
                            else
                            {
                                this.Month++;
                            }
                            this.Day = 1;
                        }
                        else
                        {
                            this.Day++;
                        }
                        days--;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return this;
            }
            else
            {
                throw new Exception("Дата пуста");
            }
        }



        public void PrintDate()
        {
            Console.WriteLine("{0}-{1}-{2}", this.Year, this.Month, this.Day);
        }
    }


}
