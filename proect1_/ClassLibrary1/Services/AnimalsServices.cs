using Shelter.DAL.Repositories;
using Shelter.DAL.Repositories.Interfaces;
using ShelterBLL.Dto;
using ShelterDAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterBLL.Services
{
    public class AnimalsServices : IAnimalsServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnimalsServices(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }
        public async Task<AnimalsResponceDto> GetAnimals(int id) 
        {
            var animal = await _unitOfWork.AnimalsRepository.GetAsync(id);
            var animalsResponceDto = new AnimalsResponceDto();
            animalsResponceDto.Name = animal.Name;
            animalsResponceDto.Age = animal.Age;
            animalsResponceDto.Gender = animal.Gender;

            var kindOfAnimals = await _unitOfWork.KindOfAnimalsRepository.GetAsync(animal.Kind);

            animalsResponceDto.NameKind = kindOfAnimals.NameKind;
            return animalsResponceDto;
        }
    }
}
