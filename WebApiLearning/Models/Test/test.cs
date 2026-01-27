namespace MyApp.Models.Test;

public class TestEntity
{
    public int Id { get; set; }   // 主キー（PK）
    public string Name { get; set; }
}

public class TestCreateDto{
    public string Name { get; set; } = null!;
}

public class TestUpdateDto{
    public string Name { get; set; } = null!;
}