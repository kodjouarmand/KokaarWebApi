using AutoMapper;
using KokaarWebApi.DataAccess.Repository.Contracts;
using KokaarWebApi.Domain.Entities;
using KokaarWepApi.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace KokaarWepApi.Business.Contracts
{
    /// <summary>
    /// The BaseService class is the Base for any business object class that will retrieve data from the database.
    /// </summary>    
    [Serializable()]
    public abstract class BaseService<TBusinessObject, TEntity> : IBaseService<TBusinessObject> where TBusinessObject : BaseDTO where TEntity : BaseEntity
    {
        public enum DBActionEnum
        {
            Save,
            Delete
        }

        #region Constructor

        /// <summary>
        /// Default constructor.
        /// </summary>
        //public BaseService()
        //{

        //}

        public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            DBAction = DBActionEnum.Save;
        }

        #endregion Constructor

        #region Properties

        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public DBActionEnum DBAction { get; set; }

        #endregion Properties

        #region Abstract Methods

        /// <summary>
        /// This method validates the object's data before trying to save the record.  If there is a validation error
        /// the validationErrors will be populated with the error message.
        /// </summary>
        protected abstract void ValidateAdd(ref StringBuilder validationErrors, TBusinessObject businessObject);

        /// <summary>
        /// This method validates the object's data before trying to save the record.  If there is a validation error
        /// the validationErrors will be populated with the error message.
        /// </summary>
        protected abstract void ValidateUpdate(ref StringBuilder validationErrors, TBusinessObject businessObject);

        /// <summary>
        /// This method validates the object's data before trying to delete the record.  If there is a validation error
        /// the validationErrors will be populated with the error message.
        /// </summary>
        protected abstract bool ValidateDelete(ref StringBuilder validationErrors, TBusinessObject businessObject = null);

        protected abstract bool Validate(ref StringBuilder validationErrors, TBusinessObject businessObject, ref TEntity entity);

        public abstract TBusinessObject Get(int id);
        public abstract IEnumerable<TBusinessObject> GetAll();

        /// <summary>
        /// This method will add a record.
        /// </summary>
        public abstract int Add(ref StringBuilder validationErrors, TBusinessObject businessObject);

        /// <summary>
        /// This method will update a record.
        /// </summary>
        public abstract bool Update(ref StringBuilder validationErrors, TBusinessObject businessObject);

        /// <summary>
        /// This method will connect to the database and start a transaction.
        /// </summary>
        public abstract bool Delete(ref StringBuilder validationErrors, int businessObjectId);

        #endregion Abstratct Methods

        #region Public Methods

        /// <summary>
        /// This method will map the fields in the data reader to the member variables in the object.
        /// </summary>             

        protected TBusinessObject MapEntityToBusinesObject(TEntity entity)
        {
            return _mapper.Map<TBusinessObject>(entity);
        }

        protected IEnumerable<TBusinessObject> MapEntitiesToBusinesObjects(IEnumerable<TEntity> entities)
        {
            return _mapper.Map<IEnumerable<TBusinessObject>>(entities);
        }

        protected void MapBusinessObjectToEntity(ref TEntity entity, TBusinessObject businessObject)
        {
            entity = _mapper.Map<TEntity>(businessObject);

            if (businessObject.IsNew())
            {
                entity.CreationDate = DateTime.Now;
                entity.CreationUser = businessObject.CurrentUser;
            }
            else
            {
                entity.UpdateDate = DateTime.Now;
                entity.UpdateUser = businessObject.CurrentUser;
            }
        }

        #endregion Public Methods
    }
}
