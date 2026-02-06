namespace MyApp.Models.NightRain;
public class NightRainEntity
{
    public int Id { get; set; }

    public int BossesId { get; set; }

    public int TerrainEffectId { get; set; }

    public bool IsEver { get; set; }

}

public class NightRainRequestDto
{
    public int Times { get; set; }
    public bool IsEverIncluded { get; set; }
}

public class NightRainResultDto
{
    public int BossesId { get; set; }
    public int TerrainEffectId { get; set; }
    public bool IsEver { get; set; }
}

public class NightRainCreateDto
{
    public int BossesId { get; set; }
    public int TerrainEffectId { get; set; }
}

public class NightRainStatisticsResponseDto
{
    public int AllCount { get; set; }
    public List<BossStatisticsDto> Bosses { get; set; } = new();
    public List<TerrainStatisticsDto> Terrains { get; set; } = new();
}

public class BossStatisticsDto
{
    public int BossId { get; set; }
    public int Count { get; set; }
    public decimal Probability { get; set; }
}

public class TerrainStatisticsDto
{
    public int TerrainId { get; set; }
    public int Count { get; set; }
    public decimal Probability { get; set; }
}