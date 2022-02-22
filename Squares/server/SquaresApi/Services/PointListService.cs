using AutoMapper;
using SquaresApi.Dtos;
using SquaresApi.Models;
using SquaresApi.Repositories;

namespace SquaresApi.Services
{
    public class PointListService
    {
        private readonly PointListRepository _pointListRepository;
        private readonly IMapper _mapper;

        public PointListService(PointListRepository pointListRepository, IMapper mapper)
        {
            _pointListRepository = pointListRepository;
            _mapper = mapper;
        }

        public async Task<List<PointListDto>> GetAllAsync()
        {
            var pointLists = await _pointListRepository.GetAllAsync();
            if (pointLists == null)
            {
                throw new ArgumentException("No PointLists found");
            }

            return _mapper.Map<List<PointListDto>>(pointLists);
        }

        public async Task<PointList> GetPointByIdAsync(int id)
        {
            var pointList = await _pointListRepository.GetByIdAsync(id);
            if (pointList == null)
            {
                throw new ArgumentException("PointList with such Id does not exist");
            }

            return pointList;
        }

        public async Task RemoveAsync(int id)
        {
            await _pointListRepository.RemoveAsync(id);
        }

        public async Task<int> CreateAsync(PointListDto createPointList)
        {
            var doesPointListExist = await _pointListRepository.CheckNameExistAsync(createPointList.Name);

            var pointList = new PointList()
            {
                Name = createPointList.Name
            };

            var pointListId = await _pointListRepository.CreateAsync(pointList);

            return pointListId;
        }

        public async Task UpdatePointListAsync(int id, PointListDto updatePointList)
        {
            var pointList = await GetPointByIdAsync(id);
            var doesPointListExist = await _pointListRepository.CheckNameExistAsync(updatePointList.Name);

            if (doesPointListExist)
            {
                throw new ArgumentException("PointList with such Name already exists");
            }

            pointList.Name = updatePointList.Name;

            await _pointListRepository.Update(pointList);
        }
    }
}
