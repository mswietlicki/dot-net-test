using ShapeTest.Business.Entities;
using ShapeTest.Business.Repositories;

namespace ShapeTest.Business.Services
{
    using System.Linq;

    public class ComputeAreaService : IComputeAreaService
    {
        private readonly IShapeRepository _ShapeRepo;

        public ComputeAreaService(IShapeRepository shapeRepo)
        {
            _ShapeRepo = shapeRepo;
        }

        public double ComputeTotalArea()
        {
            var shapes = _ShapeRepo.GetShapes();
            return shapes.Sum(_ => _.GetArea());
        }
    }
}
