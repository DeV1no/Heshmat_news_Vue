using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using dadachMovie.DTOs.Role;
using dadachMovie.Services.Contracts;
using HeshmastNews.Data;
using HeshmastNews.DTOs.Role;
using HeshmastNews.Entities;
using Microsoft.EntityFrameworkCore;

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

        public int AddRole(RoleCreateDTO model)
        {
            var permissions = new List<Permission>();
            foreach (var item in model.PermissionsId)
            {
                var permissionDb = _context.Permission.FirstOrDefault(x => x.PermissionId == item);
                permissions.Add(permissionDb);
            }

            var roleMDl = new Role
            {
                RoleName = model.RoleName,
                Permissions = permissions
            };
            var isExisted = _context.Roles.Any(r => r.RoleName == roleMDl.RoleName);
            if (isExisted)
                return 0;
            _context.Add(roleMDl);
            _context.SaveChanges();
            return roleMDl.Id;
        }

        public int UpdateRole(RoleUpdateDTO model)
        {
            var roleDb = _context.Roles.Include(x => x.Permissions).FirstOrDefault(r => r.Id == model.Id);
            if (roleDb == null)
                return 0;
            var permissions = new List<Permission>();
            roleDb.Permissions.Clear();
            roleDb.RoleName = model.RoleName;

            foreach (var item in model.PermissionsId)
            {
                var permissionDb = _context.Permission.FirstOrDefault(x => x.PermissionId == item);

                roleDb.Permissions.Add(permissionDb);
            }
            _context.Update(roleDb);
            _context.SaveChanges();
            return roleDb.Id;
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

        public bool AddPermissionToRole(AddPermissionToRoleDTO model)
        {
            var roleDb = _context.Roles.Include(p => p.Permissions)
                .SingleOrDefault(r => r.Id == model.RoleId);
            if (roleDb == null)
                return false;
            foreach (var item in model.PermissionIds)
            {
                var permissionDb = _context.Permission.SingleOrDefault(p => p.PermissionId == item);
                if (permissionDb == null)
                    return false;
                roleDb.Permissions.Add(permissionDb);
            }

            _context.Roles.Update(roleDb);
            _context.SaveChanges();
            return true;
        }

        public RoleSaveDTO GetRoleSave(int roleId)
        {
            var roleDb = _context.Roles.Include(p => p.Permissions)
                .FirstOrDefault(r => r.Id == roleId);
            return _mapper.Map<RoleSaveDTO>(roleDb);
        }
    }
}