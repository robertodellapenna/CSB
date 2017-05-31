namespace CSB_Project.src.model.Booking
{
    public struct Property
    {
        private string _name;
        private string _value;
        private double _price;

        public Property(string name, string value, double price)
        {
            _name = name;
            _value = value;
            _price = price;
        }

        public Property(string name, string value) : this(name, value, 0) { }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string Value
        {
            get
            {
                return _value;
            }
        }

        public double Price
        {
            get
            {
                return _price;
            }
        }
    }
}