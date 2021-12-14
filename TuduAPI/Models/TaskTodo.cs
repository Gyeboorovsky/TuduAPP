using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuduAPI.Models
{
    public class TaskTodo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public string TaskType { get; set; }
        public DateTime TaskCreationDate { get; set; }
        public DateTime PlannedCompletionDate { get; set; }
        public DateTime CompletionDate { get; set; }
    }
}
