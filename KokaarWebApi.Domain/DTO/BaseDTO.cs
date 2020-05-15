using KokaarWepApi.Domain.Attributes;
using System;

namespace KokaarWepApi.Domain.DTO
{
    /// <summary>
    /// The BaseBO class is the Base for any business object class that will retrieve data from the database.
    /// </summary>    
    [Serializable()]
    public abstract class BaseDTO
    {       
        public int Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CreationUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateUser { get; set; }
        //public byte[] RowVersion { get; set; }

        public bool IsNew() => Id == 0;
        public string CurrentUser { get; set; }
    }
}
