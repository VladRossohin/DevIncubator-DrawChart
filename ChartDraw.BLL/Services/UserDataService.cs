using ChartDraw.BLL.DTO;
using ChartDraw.BLL.Interfaces;
using ChartDraw.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using ChartDraw.DAL.Entities;

namespace ChartDraw.BLL.Services
{
    public class UserDataService : IUserDataService
    {
        IUnitOfWork Database { get; set; }

        public UserDataService(IUnitOfWork database)
        {
            Database = database;
        }

        public void AddUserData(UserDataDTO userDataDto)
        {
            if (userDataDto == null)
                throw new ValidationException("Empty User Data!");
            UserData userData = new UserData(userDataDto.PointFrom, userDataDto.PointTo, userDataDto.Step, userDataDto.A, userDataDto.B, userDataDto.C);
            Database.UserData.Create(userData);
            Database.Save();

        }


        public IEnumerable<UserDataDTO> GetAllUserDatas()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserData, UserDataDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<UserData>, List<UserDataDTO>>(Database.UserData.GetAll());
        }
        public IEnumerable<UserDataDTO> GetPoints(UserDataDTO userData)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserData, UserDataDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<UserData>, List<UserDataDTO>>(Database.UserData.GetAll());
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
