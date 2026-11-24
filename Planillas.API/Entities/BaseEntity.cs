using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planillas.API.Entities
{
    public class BaseEntity
    {
        [Key]
        [Column("id")]
        public Guid id { get; set; } 
        [Column("created_date")]
        public DateTime CreatedDate { get; set; }
        [Column("created_by_id")]
        public string? CreatedById { get; set; }
        [Column("update_date")]
        public DateTime UpdatedDate { get; set; } 
        [Column("update_by_id")]
        public string? UpdatedAtById { get; set; }
        //Se hace asi porque debe de tener un codigo unico para cada entidad, y el Guid es un tipo de dato que genera un codigo unico para cada entidad
    }

    
}