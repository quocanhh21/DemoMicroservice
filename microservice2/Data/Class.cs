using System.ComponentModel.DataAnnotations;

namespace microservice2.Data
{
    public class Class
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int IdStudent { get; set; }
    }
}
