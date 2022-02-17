using AutoMapper;
using SquaresApi.Dtos;
using SquaresApi.Models;
using SquaresApi.Repositories;

namespace SquaresApi.Services
{
    public class PointService
    {
        private readonly PointRepository _pointRepository;
        private readonly IMapper _mapper;

        public PointService(PointRepository pointRepository, IMapper mapper)
        {
            _pointRepository = pointRepository;
            _mapper = mapper;
        }

        public async Task<List<PointCrudDto>> GetAllAsync()
        {
            var points = await _pointRepository.GetAllAsync();
            if (points == null)
            {
                throw new ArgumentException("No Points found");
            }

            return _mapper.Map<List<PointCrudDto>>(points);
        }

        public async Task<PointCrudDto> GetPointByIdAsync(int id)
        {
            var point = await _pointRepository.GetByIdAsync(id);
            if (point == null)
            {
                throw new ArgumentException("Point with such Id does not exist");
            }

            return _mapper.Map<PointCrudDto>(point);
        }

        public async Task RemoveAsync(int id)
        {
            await _pointRepository.RemoveAsync(id);
        }

        public async Task<int> CreateAsync(PointCrudDto createPoint)
        {
            var doesPointExist = await _pointRepository.CheckPointExistAsync(createPoint.XCoordinate, createPoint.YCoordinate);

            var point = new PointModel()
            {
                XCoordinate = createPoint.XCoordinate,
                YCoordinate = createPoint.YCoordinate
            };

            var pointId = await _pointRepository.CreateAsync(point);

            return pointId;
        }

        public async Task UpdatePointAsync(int id, PointCrudDto updatePoint)
        {
            var point = await GetPointByIdAsync(id);
            var doesPointExist = await _pointRepository.CheckPointExistAsync(updatePoint.XCoordinate, updatePoint.YCoordinate);

            if (doesPointExist)
            {
                throw new ArgumentException("Point with such Coordinates already exists");
            }

            point.XCoordinate = updatePoint.XCoordinate;
            point.YCoordinate = updatePoint.YCoordinate;

            await _pointRepository.Update(_mapper.Map<PointModel>(point));
        }
    }
}
