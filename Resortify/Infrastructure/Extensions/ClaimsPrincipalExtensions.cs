namespace Resortify.Infrastructure.Extensions
{
    using System.Security.Claims;

    using static Areas.Admin.AreasConstants.AdminConstants;
    using static Areas.Admin.AreasConstants.OwnerConstants;

    public static class ClaimsPrincipalExtensions
    {
        public static string Id(this ClaimsPrincipal user)
            => user.FindFirst(ClaimTypes.NameIdentifier).Value;

        public static bool IsAdmin(this ClaimsPrincipal user)
            => user.IsInRole(AdministratorRoleName);
        public static bool IsOwner(this ClaimsPrincipal user)
           => user.IsInRole(OwnerRoleName);

    }
}
