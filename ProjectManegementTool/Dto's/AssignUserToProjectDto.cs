namespace ProjectManegementTool.Dto_s
{
    public class AssignUserToProjectDto
    {
        public int UsersId { get; set; }
        public int ProjectId { get; set; }
        public string? AssignedRole { get; set; }
    }
}
