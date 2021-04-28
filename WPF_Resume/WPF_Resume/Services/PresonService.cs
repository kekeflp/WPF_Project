using System;
using System.Collections.Generic;
using System.Data.SQLite;
using WPF_Resume.Data;
using WPF_Resume.Models;

namespace WPF_Resume.Services
{
    public class PresonService : IPresonService
    {
        public List<Person> GetAllPreson()
        {
            List<Person> resumes = new List<Person>();
            string sql = "select * from Preson;";
            SQLiteDataReader dr = DataHelper.ExecuteDataReader(sql);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Person person = new Person
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = dr["Name"].ToString(),
                        Gender = dr["Gender"].ToString(),
                        Birthday = Convert.ToDateTime(dr["Birthday"]).Date,
                        PhoneNumber = dr["PhoneNumber"].ToString(),
                        Address = dr["Address"].ToString(),
                        School = dr["School"].ToString(),
                        Job = dr["Job"].ToString(),
                        Image = dr["Image"].ToString(),
                        EducationExperience = dr["EducationExperience"].ToString(),
                        WorkExperience = dr["WorkExperience"].ToString(),
                    };
                    resumes.Add(person);
                }
            }
            return resumes;
        }

        public List<Experience> GetAllExperiences(int personId)
        {
            string sql = $"select * from Experience where PersonId={personId}";
            SQLiteDataReader dr = DataHelper.ExecuteDataReader(sql);
            List<Experience> experiences = new List<Experience>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Experience experience = new Experience();
                    experience.Id = dr.GetInt32(0);
                    experience.StartDate = Convert.ToDateTime(dr["StartDate"]).Date;
                    experience.EndDate = Convert.ToDateTime(dr["EndDate"]).Date;
                    experience.Location = dr["Location"].ToString();
                    experiences.Add(experience);
                }
            }
            return experiences;
        }
    }
}