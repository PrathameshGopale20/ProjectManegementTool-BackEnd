namespace ProjectManegementTool.Dto_s
{
    public class CreateUserDto
    {
        public string Name { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; } 
        public string Designation { get; set; }
        public DateOnly DOB { get; set; }

        public int RolesId { get; set; }
        public string? Profile_Img { get; set; }  
    }
}






