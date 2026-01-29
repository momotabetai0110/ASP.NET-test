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