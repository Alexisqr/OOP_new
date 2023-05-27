using ShelterBLL.Dto;
using ShelterDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShelterBLL.Services
{
    public interface IAnimalsServices
    {
        public Task<AnimalsResponceDto> GetAnimals(int id);
    }
}
