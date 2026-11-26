using System.Net;
using Microsoft.EntityFrameworkCore;
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
        
        //**MÉTODO QUE HAGA DE PUENTE ENTRE LOS DATOS DE LA LISTA
        public static EmployeeDto EntityToDto(EmployeeEntity employeeEntity)
        {
            return new EmployeeDto{
               FullName = ($"{employeeEntity.FirstName} {employeeEntity.LastName}"),
               DNI = employeeEntity.DNI,
               Gender = employeeEntity.Gender,
               Id = employeeEntity.id
            };
        }


        //**PERO ANTES SE DEBE DE HACER UN MÉTODO QUE HAGA DE PUENTE ENTRE LOS DATOS DE LA LISTA
        //**SE HACE UN MÉTODO ASYNC PARA AMBOS Y SE USA QUERY DEBIDO A QUE ESTOY TRABAJANDO CON LA OTRA LISTA DE ESE TIPO
        //**ES MAS FACIL MANDAR LOS DATOS YA OBTENIDOS EN UNA LISTA A OTRA QUE MAPEAR CADA DATO INDIVIDUALMENTE
        //TODO: Este es para cuando no hay await antes
        #region Distintos casos
        public static async Task<List<EmployeeDto>> ListEntityToListDtoOnlyAsyncsIncludeAndNoDefineMetod(IQueryable<EmployeeEntity> employeeEntity)
        {
           List<EmployeeEntity> entities = await employeeEntity.ToListAsync();
           List<EmployeeDto> mapper = new List<EmployeeDto>();

            foreach(var data in entities)
            {
                mapper.Add(EntityToDto(data));
            }

            return mapper;

           /**
           *TODO: Este tiene que se usarse como conversor de datos para la lista 
           *!new EmployeeDto{
               *!FullName = ($"{employeeEntity.FirstName} {employeeEntity.LastName}"),
               *!DNI = employeeEntity.DNI,
               *!Gender = employeeEntity.Gender,
               *!Id = employeeEntity.id*/


           }
        #endregion

        public static List<EmployeeDto> ListEntityToListDto(List<EmployeeEntity> employeeEntities)
        //**También se puede usar IEnumerable es mas recomendable debido a que acepta valores arreglos
        //**(EmployeeEntity[]) o el resultado de otro LINQ que no sea List<T>, te pedirá hacer .ToList().
        //**Con IEnumerable<EmployeeEntity>: Acepta List<EmployeeEntity> sin problema, pero también acepta arreglos o secuencias enumerable
        //**Sin obligarte a convertirlos antes.
        {
            List<EmployeeDto> mapper = new List<EmployeeDto>();

            foreach (var data in employeeEntities)
            {
                mapper.Add(EntityToDto(data));
            }

            return mapper;
        }
    }
}
