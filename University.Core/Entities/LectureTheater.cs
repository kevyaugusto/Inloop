namespace University.Core.Entities
{
    public class LectureTheater : EntityBase, Interfaces.IAggregateRoot
    {
        public string Name { get; set; }

        public int NominatedCapacity { get; set; }
    }
}
