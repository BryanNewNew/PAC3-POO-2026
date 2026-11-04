using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planillas.API.Entities
{
    public class BaseEntity
    {
        public Guid id { get; set; } 

        public DateTime CreatedAt { get; set; }

        public string? CreatedById { get; set; } 

        public DateTime UpdatedAt { get; set; }

        public string? Gender { get; set; }
        //Se hace asi porque debe de tener un codigo unico para cada entidad, y el Guid es un tipo de dato que genera un codigo unico para cada entidad
    }
}