namespace Group
{
    public class Group
    {
        public Group(string departmentName, byte groupNumber)
        {
            this.DepartmentName = departmentName;
            this.GroupNumber = groupNumber;
        }

        public byte GroupNumber { get; set; }

        public string DepartmentName { get; set; }
    }
}