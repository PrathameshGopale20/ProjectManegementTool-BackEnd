namespace ProjectManegementTool.Dto_s
{
    public class CreateProjectDto
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string CustomerName { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public string Duration { get; set; }
        public string Status { get; set; }
    }
}
