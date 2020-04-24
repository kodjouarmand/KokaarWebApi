using System;
using System.ComponentModel.DataAnnotations;

namespace KokaarWebApi.Domain.DTO
{
    public abstract class BaseDTO
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreationUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateUser { get; set; }        
        public byte[] RowVersion { get; set; }
    }
}
