using System;

namespace University.Application.ViewModels
{
    public class StudentViewModel : ViewModelBase
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdate { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
