using BeautyServices.Domain.Enums;

namespace BeautyServices.Domain.Commons;

public class Auditable
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public RoleTypes userRole { get; set;} = RoleTypes.user;
}
