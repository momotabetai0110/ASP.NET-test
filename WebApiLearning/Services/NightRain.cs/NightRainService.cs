using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using MyApp.Data;
using MyApp.Models.NightRain;
using NuGet.Protocol.Plugins;
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
            bool isTerrain = _random.Next(1, 6) == 1;
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

            if (dto.IsEverIncluded && _random.Next(0, 3) == 0 && bossesId < 9)
            //常夜を含めるがONかつボスが1～8かつ1/3で常世フラグをON
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

    public object Get()
    {
        decimal allGachaCount = _db.NightRains.Count();

        //全てのボスの出現回数とその確率を集計
        var bossesStatistics = new List<BossStatisticsDto>();
        for (int i = 1; i < 11; i++)
        {
            decimal bossCount = _db.NightRains.Where(x => x.BossesId == i).Count();
            var bossProbability = Math.Round(bossCount / allGachaCount * 100, 2);

            bossesStatistics.Add(new BossStatisticsDto
            {
                BossId = i,
                Count = (int)bossCount,
                Probability = bossProbability
            });
        }

        //全ての地変の出現回数とその確率を集計
        var terrainStatistics = new List<TerrainStatisticsDto>();
        for (int i = 0; i < 6; i++)
        {
            decimal terrainCount = _db.NightRains.Where(x => x.TerrainEffectId == i).Count();
            var terrainProbability = Math.Round(terrainCount / allGachaCount * 100, 2);

            terrainStatistics.Add(new TerrainStatisticsDto
            {
                TerrainId = i,
                Count = (int)terrainCount,
                Probability = terrainProbability
            });
        }

        return new NightRainStatisticsResponseDto
        {
            AllCount = (int)allGachaCount,
            Bosses = bossesStatistics,
            Terrains = terrainStatistics
        };
    }
}