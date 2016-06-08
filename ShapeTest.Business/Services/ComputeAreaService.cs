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
            var triangles = _ShapeRepo.GetShapes().Cast<Triangle>();

            return triangles.Sum(triangle => 0.5 * triangle.Base * triangle.Height);
        }
    }
}
