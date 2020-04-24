using KokaarWebApi.DataAccess.Repository.Abstract;
using KokaarWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KokaarWepApi.Service.Core
{
    /// <summary>
    /// The BaseService class is the Base for any business object class that will retrieve data from the database.
    /// </summary>    
    [Serializable()]
    public abstract class BaseService
    {
        #region Enumerations

        public enum DatabaseActionEnum
        {
            Save,
            Delete
        }

        #endregion Enumerations

        #region Constructor

        /// <summary>
        /// Default constructor.
        /// </summary>
        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            DatabaseAction = DatabaseActionEnum.Save;
        }

        public BaseService()
        {
            
        }

        #endregion Constructor

        #region Properties

        protected IUnitOfWork _unitOfWork { get; set; }

        public DatabaseActionEnum DatabaseAction { get; set; }

        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreationUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateUser { get; set; }

        /// <summary>
        /// This returns the text that should appear in a list box or drop down list for this object.
        /// The property is used when binding to a control.
        /// </summary>
        public string DisplayText
        {
            get { return GetDisplayText(); }
        }

        #endregion Properties

        #region Abstract Methods

        /// <summary>
        /// Get the record from the database and load the object's properties
        /// </summary>
        /// <returns>Returns true if the record is found.</returns>
        public abstract bool Load(int id);


        /// <summary>
        /// This returns the text that should appear in a list box or drop down list for this object.
        /// </summary>
        protected abstract string GetDisplayText();

        /// <summary>
        /// This method will add or update a record.
        /// </summary>
        public abstract bool Save(ref ValidationErrors validationErrors, string userName);

        /// <summary>
        /// This method validates the object's data before trying to save the record.  If there is a validation error
        /// the validationErrors will be populated with the error message.
        /// </summary>
        protected abstract void ValidateBeforeSave(ref ValidationErrors validationErrors);

        /// <summary>
        /// This should call the business object's data class to delete the record.
        /// </summary>
        protected abstract void DeleteForReal();

        /// <summary>
        /// This method validates the object's data before trying to delete the record.  If there is a validation error
        /// the validationErrors will be populated with the error message.
        /// </summary>
        protected abstract void ValidateDelete(ref ValidationErrors validationErrors, string userName);

        /// <summary>
        /// This will load the object with the default properties.
        /// </summary>
        public abstract void Init();

        #endregion Abstratct Methods

        #region Public Methods

        public bool IsNewRecord()
        {
            return Id == 0;
        }

        /// <summary>
        /// This method will map the fields in the data reader to the member variables in the object.
        /// </summary>     
        public abstract void MapCustomEntityPropertiesToBusinesObject(BaseEntity entity);

        /// <summary>
        /// This method will load all the properties of the object from the entity.
        /// </summary>        
        public void MapEntityToBusinesObject(BaseEntity entity)
        {
            if (entity != null)
            {
                Id = entity.Id;
                CreationDate = entity.CreationDate;
                CreationUser = entity.CreationUser;
                UpdateDate = entity.UpdateDate;
                UpdateUser = entity.UpdateUser;

                this.MapCustomEntityPropertiesToBusinesObject(entity);
            }
        }

        public abstract void MapCustomBusinessObjectPropertiesToEntity(ref BaseEntity entity);

        public void MapBusinessObjectToEntity(ref BaseEntity entity, string userName)
        {
            if (IsNewRecord())
            {
                entity.CreationDate = DateTime.Now;
                entity.CreationUser = CreationUser;
            }
            entity.UpdateDate = DateTime.Now;
            entity.UpdateUser = UpdateUser;

            this.MapCustomBusinessObjectPropertiesToEntity(ref entity);
        }

        /// <summary>
        /// This method will connect to the database and start a transaction.
        /// </summary>
        public bool Delete(ref ValidationErrors validationErrors, string userName)
        {           
            if (DatabaseAction == DatabaseActionEnum.Delete)
            {               
                ValidateDelete(ref validationErrors, userName);

                if (validationErrors.Count == 0)
                {
                    this.DeleteForReal();
                    _unitOfWork.Save();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new Exception("DatabaseAction is not set to Delete.");
            }            
        }

        #endregion Public Methods
    }
}
