using System.Collections.Generic;
using WPF_Resume.Models;

namespace WPF_Resume.Services
{
    public interface IPresonService
    {
        List<Person> GetAllPreson();

        List<Experience> GetAllExperiences(int personId);
    }
}