using System;

namespace KokaarWebApi.Domain.DataTransfertObjects
{
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreationUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateUser { get; set; }        
        public byte[] RowVersion { get; set; }
    }
}
