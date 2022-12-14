using AutoMapper;
using DataAccess.Entites;
using DataAccess;
using DTO;
using Microsoft.EntityFrameworkCore;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper;
using Helper.Constants;

namespace Services
{
    public class UserService : BaseService<UserDTO, User, UserDTO>, IUserService
    {

        public UserService(AppDbContext db, IMapper mapper) : base(db, mapper)
        {

        }

        public UserDTO Login(UserDTO model)
        {

            var res = _db.Users
                                                    .Where(x => x.Username == model.Username)
                                                    .Include(u=>u.Role);

            if (res.Count() == 1)
            {
                var user = res.FirstOrDefault();

                

                var hash = Crypto.GenerateSHA256Hash(model.Password, user.Salt);

                if (hash == user.PasswordHash)
                {
                    var dto = _mapper.Map<User, UserDTO>(res.First());
                    return dto;
                }
                else
                {
                    throw new Exception("Wrong password!");
                }
            }
            else
            {
                throw new Exception("User not found");
            }

        }

        public override UserDTO Create(UserDTO model)
        {
            var res = _db.Users.Where(x => x.Username == model.Username);

            var role = _db.Roles.Where(x => x.Name == RoleKeywords.UserRole)?.First();
            model.RoleId = role.Id; //just User

            //var role = _db.Roles.Where(x => x.Name == "User")?.First();
            //model.RoleId = role.Id; //just User

            //model.RoleId = 2;

            if (res.Any())
                throw new Exception("Username exists!");


            model.Salt = Crypto.GenerateSalt();
            model.PasswordHash = Crypto.GenerateSHA256Hash(model.Password, model.Salt);

            return base.Create(model);
        }

    }
}
