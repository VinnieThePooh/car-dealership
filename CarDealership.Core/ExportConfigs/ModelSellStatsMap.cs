using CarDealership.Core.Models;
using CsvHelper.Configuration;

namespace CarDealership.Core.ExportConfigs;

public sealed class ModelSellStatsMap : ClassMap<ModelSellStats>
{
    public ModelSellStatsMap()
    {
        Map(m => m.ModelId).Ignore();
        Map(m =>m.ModelName).Name("model-name");
        Map(m => m.JanuaryStats).Name("january");
        Map(m => m.FebruaryStats).Name("february");
        Map(m => m.MarchStats).Name("march");
        Map(m => m.AprilStats).Name("april");
        Map(m => m.MayStats).Name("may");
        Map(m => m.JuneStats).Name("june");
        Map(m => m.JulyStats).Name("july");
        Map(m => m.AugustStats).Name("august");
        Map(m => m.SeptemberStats).Name("september");
        Map(m => m.OctoberStats).Name("october");
        Map(m => m.NovemberStats).Name("november");
        Map(m => m.DecemberStats).Name("december");
    }   
}