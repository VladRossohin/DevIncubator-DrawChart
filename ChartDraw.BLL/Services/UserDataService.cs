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
using ChartDraw.DAL.Repositories;

namespace ChartDraw.BLL.Services
{
    public class UserDataService : IUserDataService
    {
        IUnitOfWork Database { get; set; }
        

        public UserDataService(IUnitOfWork database)
        {
            Database = database;
        }

        public UserDataService()
        {
            Database = new EFUnitOfWork("Data Source=DESKTOP-TJ6V82E;Initial Catalog=chartdb;Integrated Security=True");
        }

        public void AddUserData(UserDataDTO userDataDto)
        {
            if (userDataDto == null)
                throw new ValidationException("Empty User Data!");
            UserData userData = new UserData(userDataDto.PointFrom, userDataDto.PointTo, userDataDto.Step, userDataDto.A, userDataDto.B, userDataDto.C);
            Database.UserData.Create(userData);
            Database.Save();

        }

        public List<PointDTO> Plot(UserDataDTO userDataDTO)
        {
            if (Validate(userDataDTO))
            {
                UserData userData = new UserData(userDataDTO.PointFrom, userDataDTO.PointTo, userDataDTO.Step, userDataDTO.A, userDataDTO.B, userDataDTO.C);
                List<PointDTO> pointDTOs = new List<PointDTO>();
                for (double i = userDataDTO.PointFrom; i <= userDataDTO.PointTo; i += userDataDTO.Step)
                {
                    if (userDataDTO.PointFrom == userDataDTO.PointTo)
                    {
                        break;
                    }
                    Point currentPoint = new Point(userDataDTO.Id, i, userDataDTO.A * i * i + userDataDTO.B * i + userDataDTO.C, userData);
                    pointDTOs.Add(new PointDTO(userDataDTO.Id, i, userDataDTO.A * i * i + userDataDTO.B * i + userDataDTO.C));
                    Database.Points.Create(currentPoint);

                }
                return pointDTOs;
            }
            else
            { 
                throw new ValidationException("Bad values!");
            }
        }

        public bool Validate(UserDataDTO userDataDTO)
        {
            if (userDataDTO == null)
                return false;
            if (!userDataDTO.A.GetType().IsValueType || !userDataDTO.B.GetType().IsValueType || !userDataDTO.C.GetType().IsValueType || !userDataDTO.PointFrom.GetType().IsValueType || !userDataDTO.PointTo.GetType().IsValueType || !userDataDTO.Step.GetType().IsValueType)
                return false;
            return true;
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
