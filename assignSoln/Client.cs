using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAssign
{
    public class Client
    {
        private string _firstname;
        private string _lastname;
        private int _weight;
        private int _height;

        //Non-Greedy Constructor.
        public Client()
        {
            _firstname = "XXXX";
            _lastname = "YYYY";
            _weight = 0;
            _height = 0;
        }

        // Greedy Constructor.
        public Client(string FirstName, string LastName, int weight, int height)
        {
            _firstname = FirstName;
            _lastname = LastName;
            _weight = Weight;
            _height = Height;
        }

        //Fully Implemented Properties.
        public string FirstName
        {
            get { return _firstname; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("FirstName is required. Must Not be empty or blank.");
                _firstname = value;
            }
        }

        public string LastName
        {
            get { return _lastname; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("LastName is required. Must not be empty or blank. ");
                _lastname = value;
            }
        }

        public int Weight
        {
            get { return _weight; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Weight must be positive value and greater than zero.");
                _weight = value;
            }
        }

        public int Height
        {
            get { return _height; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Height must be a positive value and greater than zero.");
                _height = value;
            }
        }

        // Read only Fully Implemented Properties.

        public double BmiScore
        {
            get
            {
                return _weight / Math.Pow(_height, 2) * 703;
            }
        }

        public string BmiStatus
        {
            get
            {
                double bmi = BmiScore;
                if (bmi <= 18.4)
                    return "Underweight";
                else if (bmi <= 24.9)
                    return "Normal";
                else if (bmi <= 39.9)
                    return "Overweight";
                else
                    return "Obese";
            }
        }
        public string FullName
        {
            get
            {
                return $"{LastName}, {FirstName}";
            }
        }
    }
}