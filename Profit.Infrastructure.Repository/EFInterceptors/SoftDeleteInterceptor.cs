namespace Profit.Infrastructure.Repository.EFInterceptors;

public sealed class SoftDeleteInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        if (eventData.Context is null)
        {
            return result;
        }

        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            var entity = entry.Entity;
            var entityType = entity.GetType();

            if (entry.State == EntityState.Deleted &&
                entityType.IsGenericType &&
                entityType.GetGenericTypeDefinition() == typeof(Entity<>))
            {
                entry.State = EntityState.Modified;
                var deleteMethod = entityType.GetMethod("Delete");
                deleteMethod?.Invoke(entity, null);
            }
        }

        return result;
    }
}
