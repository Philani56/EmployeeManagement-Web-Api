namespace EmployeeManagement.Models.Entitties
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Client_Name { get; set; }
        public int Age { get; set; }
        public DateTime Birth {  get; set; }
        public string Phone_Number { get; set; }
    }
}
