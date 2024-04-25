
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
            _weight = '0';
            _height = '0';
        }

        // Greedy Constructor.
        public Client(string FirstName, string LastName, int weight, int height)
        {
            _firstname = FirstName;
            _lastname = LastName;
            _weight = weight;
            _height = height;
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
                double BmiScore = Weight / Math.Pow(Height, 2) * 703;
                return BmiScore;
            }
        }

        public string BmiStatus
        {
            get
            {
                string BmiStatus = "";
                if (BmiScore <= 18.4)
                    BmiStatus = "Underweight";
                else if (BmiScore <= 24.9)
                    BmiStatus= "Normal";
                else if (BmiScore >= 39.9)
                    BmiStatus= "Overweight";
                else
                    BmiStatus= "Obese";
                return BmiStatus;
            }
        }
        public string FullName
        {
            get
            {
                return $"{LastName}, {FirstName}";
            }
        }

        public override string ToString()
        {
            return $"{LastName}, {FirstName}, {Weight}, {Height}";
    
        }

        public string ToCsvString()
        {
            return $"{FirstName}, {LastName},{Weight}, {Height} ";
        }
    }

}