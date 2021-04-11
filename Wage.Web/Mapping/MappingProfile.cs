using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wage.Core.Entities;
using Wage.Web.DTOs;
using Wage.Web.Extensions;
using Wage.Web.Functionality;

namespace Wage.Web.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {


            //domain to dto to fetch data from db
            CreateMap<GroupManager, GroupManagerDto>()
                 .ForMember(u => u.CouncilDate, opt => opt.MapFrom(ur => string.IsNullOrEmpty(ur.CouncilDate) ? "" : ur.CouncilDate.ToStandardPersianDate()));

            CreateMap<GroupManagerDetails, GroupManagerDetailesDto>();
            ;

            CreateMap<GroupManagerDetails, GroupManagerDetailes_ReadDto>()
             .ForMember(u => u.IsOnline, opt => opt.MapFrom(ur => ur.IsOnline ? "آنلاین" : "فیزیکی"));

            //dto to momain to affect over db

            //CreateMap<SaveBaseAmountDto, GroupManager>();
            //CreateMap<SaveResearchCouncilDto, GroupManager>();
            CreateMap<SaveGroupManagerDetailesDto, GroupManagerDetails>()
               .ForMember(u => u.EntranceDate, opt => opt.MapFrom(ur => ur.EntranceDate.ToStandardPersianDate()))
               .ForMember(u => u.EntranceTime, opt => opt.MapFrom(ur => ur.EntranceTime.ToStandardPersianTime()))
               .ForMember(u => u.ExitTime, opt => opt.MapFrom(ur => ur.ExitTime.ToStandardPersianTime())
               );

            CreateMap<SaveGroupManagerScheduleDto, GroupManagerSchedule>()
               .ForMember(u => u.EntranceDate, opt => opt.MapFrom(ur => ur.EntranceDate.ToStandardPersianDate()))
               .ForMember(u => u.EntranceTime, opt => opt.MapFrom(ur => ur.EntranceTime.ToStandardPersianTime()))
               .ForMember(u => u.ExitTime, opt => opt.MapFrom(ur => ur.ExitTime.ToStandardPersianTime()))
               .ForMember(u => u.MinTime, opt => opt.MapFrom(ur => ur.MinTime.ToStandardPersianTime())
               );


            CreateMap<SaveUserDto, User>()
                .ForMember(u => u.Password, opt => opt.MapFrom(ur => ur.Password.Encrypt()));

            CreateMap<User, UserDto>()
                 .ForMember(u => u.Password, opt => opt.MapFrom(ur => ur.Password.Decrypt()));

            CreateMap<User, SaveLoginDto>();
            CreateMap<User, ResetPasswordDto>();
            CreateMap<User, ChangePasswordDto>();

            CreateMap<UserRoleDto, UserRole>();
            CreateMap<RoleDto, Role>();

        }
    }
}
