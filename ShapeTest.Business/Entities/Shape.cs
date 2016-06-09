using System.ComponentModel;

namespace ShapeTest.Business.Entities
{
    public abstract class Shape : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Name { get; set; }
        public abstract double GetArea();
    }
}