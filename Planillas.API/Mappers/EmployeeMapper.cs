using System.Net;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Planillas.API.Dtos.Common;
using Planillas.API.Dtos.Employees;
using Planillas.API.Entities;

namespace Planillas.API.Mappers
{
    public class EmployeeMapper
    {
        public static EmployeeOneDto EntityToOneDto(EmployeeEntity entity )
        {
            return new EmployeeOneDto
            {
                id = entity.id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                DNI = entity.DNI,
                Gender = entity.Gender
            };
        }

        public static EmployeeEntity CreateOneDtoToEntity(EmployeeCreateDto dto)
        {
            return new EmployeeEntity
            {
                 id = Guid.NewGuid(),//se genera el guid
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                DNI = dto.DNI,
                Gender = dto.Gender
            };
        }

        public static EmployeeActionResponseDto EntityToActionResponse(EmployeeEntity dto)
        {
            return new EmployeeActionResponseDto
            {
              Id = dto.id
            };
        }

        public static EmployeeEntity EditDtoToEntity(EmployeeEditDto dto, EmployeeEntity entity)
        {
            entity.FirstName = dto.FirstName;
            entity.LastName = dto.LastName;
            entity.DNI = dto.DNI;
            entity.Gender = dto.Gender;

            return entity;
        }
    }
}