using System.Collections.Generic;
using dadachMovie.DTOs.Role;
using HeshmastNews.DTOs.Role;
using HeshmastNews.Entities;

namespace dadachMovie.Services.Contracts
{
    public interface IRoleService
    {
        List<RoleDTO> GetAllRoles();
        RoleDTO GetRole(int roleID);
        int AddRole(RoleCreateDTO model);
        int UpdateRole(RoleUpdateDTO model);
        bool RemoveRole(int RoleId);
        List<PermissionViewModelDTO> GetPermissionList();
        List<PermissionViewModelDTO> GetParentPermissionList();
        List<PermissionViewModelDTO> GetSubPermissionList();
        bool AddPermissionToRole(AddPermissionToRoleDTO model);
        RoleSaveDTO GetRoleSave(int roleId);
    }
}