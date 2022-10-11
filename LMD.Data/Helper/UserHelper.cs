using LMD.Data.Models;
using LMS.Data.DAO;
using LMS.Data.DbSettings.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LMD.Data.Helper
{
    public class UserHelper : IUserHelper
    {
        private readonly IMongoCollection<CourseDAO> _coruseDAO;


        public UserHelper(ILMSDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _coruseDAO = database.GetCollection<CourseDAO>(settings.LMSCourse);

        }

        public List<CourseDAO> GetAllCourse(Course course)
        {
            try
            {
                if (!string.IsNullOrEmpty(course.Technology) && !string.IsNullOrEmpty(course.Startdate.ToString()) && !string.IsNullOrEmpty(course.Enddate.ToString()))
                {
                    return _coruseDAO.Find(x => x.Technology == course.Technology && x.CourseStartDate >= course.Startdate && x.CourseEndDate <= course.Enddate && x.IsDelete == 1).ToList();
                }
                else if (!string.IsNullOrEmpty(course.Technology) && !string.IsNullOrEmpty(course.Startdate.ToString()) && string.IsNullOrEmpty(course.Enddate.ToString()))
                {
                    return _coruseDAO.Find(x => x.Technology == course.Technology && x.CourseStartDate >= course.Startdate && x.IsDelete == 1).ToList();
                }
                else if (!string.IsNullOrEmpty(course.Technology) && string.IsNullOrEmpty(course.Startdate.ToString()) && !string.IsNullOrEmpty(course.Enddate.ToString()))
                {
                    return _coruseDAO.Find(x => x.Technology == course.Technology && x.CourseEndDate <= course.Enddate && x.IsDelete == 1).ToList();
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
