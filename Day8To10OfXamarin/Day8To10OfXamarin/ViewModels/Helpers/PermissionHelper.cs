using System;
using System.Threading.Tasks;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace Day8To10OfXamarin.ViewModels.Helpers
{
    public class PermissionsHelper
    {
        public static async Task<PermissionStatus> GetPermission(Permission permissionType)
        {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(permissionType);
            if (status != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(permissionType);
                if (results.ContainsKey(permissionType))
                    status = results[permissionType];
            }
            return status;
        }
    }
}
