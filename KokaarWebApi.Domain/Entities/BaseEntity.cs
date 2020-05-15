using System;
using System.ComponentModel.DataAnnotations;

namespace KokaarWebApi.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CreationUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateUser { get; set; }
        //[Timestamp]
        //public byte[] RowVersion { get; set; }
    }
}
