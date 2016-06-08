namespace ShapeTest.Business.Entities
{
    public class Square : Shape
    {
        public double Lenght { get; set; }
        public override double GetArea()
        {
            return Lenght * Lenght;
        }
    }
}