using System.ComponentModel;

namespace ShapeTest.Business.Entities
{
    public abstract class Shape : INotifyPropertyChanged
    {
        public abstract event PropertyChangedEventHandler PropertyChanged;
        public abstract double GetArea();
    }
}