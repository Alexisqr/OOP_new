using ShelterEF.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShelterEF.DAL.Repositories;
namespace ShelterEF.BLL.Services
{
    public class ComentGlobResponceServic : IComentGlobResponceServic
    {
        private readonly IUnitOfWork _unitOfWork;

        public ComentGlobResponceServic(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }
        public async Task<ComentGlobResponceDto> GetAnimals(int id)
        {
            var glob = await _unitOfWork.AnimalsRepository.GetAsync(id);
            var comentGlobResponceDto = new ComentGlobResponceDto();
            comentGlobResponceDto.Text = glob.Text;
            comentGlobResponceDto.Date = glob.Date;
            comentGlobResponceDto.ID = glob.ID;
            comentGlobResponceDto.IDVolonter = glob.IDVolonter;

            return comentGlobResponceDto;
        }
    }
}
