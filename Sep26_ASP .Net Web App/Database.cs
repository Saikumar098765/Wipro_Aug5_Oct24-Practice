using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.DBContext
{
    public class Database
    {
        public int Id { get; set; }
        [Column("ProductId", TypeName = "Varchar(200")]
        public string Name { get; set; }
        public string Description { get; set; }
       
    }
}
