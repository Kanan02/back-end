﻿using back_end.Data;
using back_end.Models;
using back_end.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_end.Services.Concrete
{
    public class RoleService : IRoleService
    {
        private readonly IDataContext _dataContext;

        public RoleService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Add(Role role)
        {
            _dataContext.Roles?.Add(role);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var roleToDelete = await _dataContext.Roles.FindAsync(id);
            if (roleToDelete == null)
            {
                throw new NullReferenceException();
            }

            _dataContext.Roles.Remove(roleToDelete);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Role> Get(int id)
        {
            var role = await _dataContext.Roles.FindAsync(id);
            if (role == null)
            {
                throw new NullReferenceException();
            }
            return role;
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            return await _dataContext.Roles.ToListAsync();
        }

        public async Task Update(int id, Role role)
        {
            Role roleToUpdate = await _dataContext.Roles.FindAsync(id);

            if (roleToUpdate == null)
            {
                throw new NullReferenceException();
            }

            roleToUpdate.Id = role.Id;
            role.Role1 = role.Role1;
            role.RoleDescription = role.RoleDescription;
            role.RolePhoto = role.RolePhoto;

            await _dataContext.SaveChangesAsync();
        }
    }

}