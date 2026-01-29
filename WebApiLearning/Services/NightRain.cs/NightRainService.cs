using MyApp.Data;
using MyApp.Models.NightRain;
namespace MyApp.Services.NightRain;
public class NightRainService : INightRainService
{
    private readonly Random _random = new Random();
    private readonly AppDbContext _db;
    public NightRainService(AppDbContext db)
    {
        _db = db;
    }
    public object Create(NightRainRequestDto dto)
    {
        var results = new List<NightRainResultDto>();
        for (int i = 0; i < dto.Times; i++)
        {
            //地変の抽選
            //地変は25%
            int terrainEffectId;
            bool isTerrain = (_random.Next(1, 5) % 2) == 0;
            if (isTerrain)
            //地変がある場合
            {
                terrainEffectId = _random.Next(1, 6);
            }
            else
            //地変がない場合
            {
                terrainEffectId = 0;
            }

            //ボスの抽選
            bool isEver = false;
            int bossesId = _random.Next(1, 11);

            if (dto.IsEverIncluded && _random.Next(0, 2) == 0 && bossesId < 9)
            //常夜を含めるがONかつボスが1～8かつ50％で常世フラグをON
            {
                isEver = true;
            }
            var entity = new NightRainEntity
            {
                BossesId = bossesId,
                TerrainEffectId = terrainEffectId,
                IsEver = isEver
            };
            _db.NightRains.Add(entity);
            _db.SaveChanges();
            results.Add(new NightRainResultDto
            {
                BossesId = bossesId,
                TerrainEffectId = terrainEffectId,
                IsEver = isEver
            }
            );
        }

        return results;

    }
}