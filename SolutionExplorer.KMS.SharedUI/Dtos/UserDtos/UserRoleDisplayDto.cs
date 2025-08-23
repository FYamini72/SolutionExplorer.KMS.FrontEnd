namespace SolutionExplorer.KMS.SharedUI.Dtos.UserDtos
{
    public class UserRoleDisplayDto : BaseDto
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string RoleTitle { get; set; }
    }
}
