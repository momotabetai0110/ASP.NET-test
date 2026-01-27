using MyApp.Models.Test;

namespace MyApp.Services.Test;
public interface ITestService
{
    void Create(TestCreateDto dto);

    void Delete(int id);

    void Update(int id, TestUpdateDto dto);

    object Get(int? id = null);
}