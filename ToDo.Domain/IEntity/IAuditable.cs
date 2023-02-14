namespace ToDo.Domain.IEntity
{
    public interface IAuditable
    {
        public DateTime DateCreated { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
