using System.ComponentModel.DataAnnotations;

namespace ToDo.Domain
{
    public class ToDo
    {
        public int ItemNumber { get; set; }

        public int Id { get; set; }

        public string Task { get; set; }

        public string Date { get; set; }

        public bool Done { get; set; } = false;
    }
}
