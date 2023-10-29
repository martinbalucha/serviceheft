namespace ServiceHeft.Contracts;

public abstract class Entity
{
	public Guid Id { get; init; }

	public Entity(Guid id)
	{
		Id = id;
	}

    public override bool Equals(object? obj)
    {
        if (obj is null)
		{
			return false;
		}

		if (obj.GetType() != GetType() || obj is not Entity entity)
		{
			return false;
		}

		return entity.Id == Id;
    }

    public override int GetHashCode()
    {
		return Id.GetHashCode();
    }
}
