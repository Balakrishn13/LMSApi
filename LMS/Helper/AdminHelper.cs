using LMS.DAO;
using LMS.DbSettings.Interface;
using LMS.Models;
using MongoDB.Driver;
using System;

namespace LMS.Helper
{
    public class AdminHelper: IAdminHelper
    {
        private readonly IMongoCollection<RegistorDAO> _registorDAO;
        
        
        public AdminHelper(ILMSDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _registorDAO = database.GetCollection<RegistorDAO>(settings.LMSCollectionName);                  
        }


        public bool Registor(Registor registor)
        {
            try
            {
                RegistorDAO registorDAO  = new RegistorDAO();
                registorDAO.Name = registor.Name;
                registorDAO.Email = registor.Email;
                registorDAO.Role = "User";
                registorDAO.Password = registor.Password;
                registorDAO.bsonDateTime = registor.DateTime;
                _registorDAO.InsertOne(registorDAO);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
