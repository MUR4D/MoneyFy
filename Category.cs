namespace MONEYfy
{
    class Category
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string id;

        public string Id   
        {
            get { return id; }
            set { id = value; }
        }

        public override string ToString() => $"{Name}";

        double sum1 = 0;
        double sum2 = 0;
        public double Money1 { get { return sum1; } set {sum1+=value; } }
        public double Money2 { get { return sum2; } set { sum2 += value; } }

    }
}