using AutoMapper;
using SchoolManagementApi.Dtos;
using SchoolManagementApi.Models;
using SchoolManagementApi.Repositories;
using SchoolManagementApi.Validators;

namespace SchoolManagementApi.Services
{
    public class SchoolService
    {
        private readonly SchoolRepository _schoolRepository;
        public readonly IMapper _mapper;
        private readonly SchoolValidator _schoolValidator = new();

        public SchoolService(SchoolRepository schoolRepository, IMapper mapper)
        {
            _schoolRepository = schoolRepository;
            _mapper = mapper;
        }

        public async Task<List<GetSchool>> GetAllAsync()
        {
            var schools = await _schoolRepository.GetAllAsync();
            if (schools == null)
            {
                throw new ArgumentException("No Schools found");
            }
              
            return _mapper.Map<List<GetSchool>>(schools);
        }
        
        public async Task RemoveAsync(int id)
        {
            await _schoolRepository.RemoveAsync(id);
        }

        public async Task<int> CreateAsync(CreateSchool createSchool)
        {
            var doesNameExist = await _schoolRepository.CheckNameExistAsync(createSchool.Name);
            if (doesNameExist)
            {
                throw new ArgumentException("The Name already exists")
;           }

            var model = new School()
            {
                Name = createSchool.Name
            };

            SchoolValidation(model);

            var modelId = await _schoolRepository.CreateAsync(model);

            return modelId;
        }

        private School SchoolValidation(School school)
        {
            var validationResult = _schoolValidator.Validate(school);
            if (!validationResult.IsValid)
            {
                foreach (var failure in validationResult.Errors)
                {
                    throw new ArgumentException("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
            }

            return school;
        }
    }
}
