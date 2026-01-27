using MyApp.Models.Test;
namespace MyApp.Services.Test;

using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Blazor;
using MyApp.Data;
public class TestService : ITestService
{
    private readonly AppDbContext _db;

    public TestService(AppDbContext db)
    {
        _db = db;
    }

    public void Create(TestCreateDto dto)
    {
        var entity = new TestEntity
        {
            Name = dto.Name,
        };

        _db.Tests.Add(entity);
        _db.SaveChanges();

    }

    public object Get(int? id = null)
    {
        if (id.HasValue)
        {
            // 1件取得
            return _db.Tests.Find(id.Value);
        }
        else
        {
            // 全件取得
            return _db.Tests.ToList();
        }
    }

    public void Delete(int id)
    {
        var entity = _db.Tests.Find(id);
        if (entity == null) return;

        _db.Tests.Remove(entity);
        _db.SaveChanges();
    }

    public void Update(int id, TestUpdateDto dto)
    {
        var entity = _db.Tests.Find(id);
        if (entity == null) return;

        entity.Name = dto.Name;

        _db.SaveChanges();
    }
}