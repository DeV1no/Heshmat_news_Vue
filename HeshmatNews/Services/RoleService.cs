using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using dadachMovie.Services.Contracts;
using HeshmastNews.Data;
using HeshmastNews.DTOs.Role;
using HeshmastNews.Entities;

namespace HeshmastNews.Services
{
    public class RoleService : IRoleService
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public RoleService(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public List<RoleDTO> GetAllRoles()
        {
            var roleDb = _context.Roles.ToList();
            var Roles = new List<RoleDTO>();
            foreach (var item in roleDb)
            {
                Roles.Add(_mapper.Map<RoleDTO>(item));
            }

            return Roles;
        }

        public RoleDTO GetRole(int roleID)
        {
            var roleDb = _context.Roles.FirstOrDefault(r => r.Id == roleID);
            return _mapper.Map<RoleDTO>(roleDb);
        }

        public int AddRole(RoleDTO model)
        {
            var roleMDl = _mapper.Map<Role>(model);
            var isExisted = _context.Roles.Any(r => r.RoleName == roleMDl.RoleName);
            if (isExisted)
                return 0;
            _context.Add(roleMDl);
            _context.SaveChanges();
            return roleMDl.Id;
        }

        public int UpdateRole(RoleDTO model)
        {
            var roleMDl = _mapper.Map<Role>(model);
            var isExisted = _context.Roles.Any(r => r.Id == roleMDl.Id);
            if (!isExisted)
                return 0;
            _context.Update(roleMDl);
            _context.SaveChanges();
            return roleMDl.Id;
        }

        public bool RemoveRole(int roleID)
        {
            var roleDb = _context.Roles.FirstOrDefault(r => r.Id == roleID);
            if (roleDb == null)
                return false;
            _context.Roles.Remove(roleDb);
            _context.SaveChanges();
            return true;
        }

        public List<PermissionViewModelDTO> GetPermissionList()
        {
            var permissionsDb = _context.Permission.ToList();
            var permission = new List<PermissionViewModelDTO>();
            foreach (var item in permissionsDb)
            {
                permission.Add(_mapper.Map<PermissionViewModelDTO>(item));
            }

            return permission;
        }

        public List<PermissionViewModelDTO> GetParentPermissionList()
        {
            var permissionsDb = _context.Permission.Where(p => p.ParentId == null).ToList();
            var permission = new List<PermissionViewModelDTO>();
            foreach (var item in permissionsDb)
            {
                permission.Add(_mapper.Map<PermissionViewModelDTO>(item));
            }

            return permission;
        }

        public List<PermissionViewModelDTO> GetSubPermissionList()
        {
            var permissionsDb = _context.Permission.Where(p => p.ParentId != null).ToList();
            var permission = new List<PermissionViewModelDTO>();
            foreach (var item in permissionsDb)
            {
                permission.Add(_mapper.Map<PermissionViewModelDTO>(item));
            }

            return permission;
        }

        
    }
}