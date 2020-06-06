namespace MONEYfy
{
    class Currency
    {
        public  string Name { get; set; }

        public  decimal Rate { get; set; }

        public override string ToString() => $"{Name}";
    }
}