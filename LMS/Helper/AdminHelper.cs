using LMS.DAO;
using LMS.DbSettings.Interface;
using LMS.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace LMS.Helper
{
    public class AdminHelper: IAdminHelper
    {
        private readonly IMongoCollection<RegistorDAO> _registorDAO;

        private readonly IMongoCollection<CourseDAO> _addCoruseDAO;


        public AdminHelper(ILMSDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _registorDAO = database.GetCollection<RegistorDAO>(settings.LMSCollectionName);
            _addCoruseDAO = database.GetCollection<CourseDAO>(settings.LMSCourse);
         
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

        public bool AddCourse(AddCourse addCourse)
        {
            try
            {
                CourseDAO addCourseDAO = new CourseDAO();
                addCourseDAO.Technology = addCourse.Technology;
                addCourseDAO.CourseName = addCourse.CourseName;
                addCourseDAO.CourseStartDate = addCourse.CourseStartDate;
                addCourseDAO.CourseEndDate = addCourse.CourseEndDate;
                addCourseDAO.IsDelete = 1;
                _addCoruseDAO.InsertOne(addCourseDAO);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteCourse(string courseId)
        {
            try
            {
                var filter = Builders<CourseDAO>.Filter.Eq(e => e.Id, courseId);
                var update = Builders<CourseDAO>.Update.Set(t => t.IsDelete, 0);
                _addCoruseDAO.UpdateOne(filter, update);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Activate(string courseId)
        {
            try
            {
                var filter = Builders<CourseDAO>.Filter.Eq(e => e.Id, courseId);
                var update = Builders<CourseDAO>.Update.Set(t => t.IsDelete, 1);
                _addCoruseDAO.UpdateOne(filter, update);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CourseDAO> GetAllCourse(string isActive)
        {
            try
            {
                if (string.IsNullOrEmpty(isActive))
                {
                    return _addCoruseDAO.Find(x => true).ToList();
                }
                else if (isActive == "1")
                {
                    return _addCoruseDAO.Find(d => d.IsDelete == 1).ToList();
                }
                else if (isActive == "0")
                {
                    return _addCoruseDAO.Find(d => d.IsDelete == 0).ToList();
                }
                else
                {
                    List<CourseDAO> courseDAOs = new List<CourseDAO>();
                    return courseDAOs;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
