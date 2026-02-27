using SolutionExplorer.KMS.SharedUI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionExplorer.KMS.SharedUI.Dtos.PeriodicQC
{
    public class PeriodicQualityControlCreateDto : BaseDto
    {
        public int QualityControlBaseInfoId { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int PerformedByUserId { get; set; }
        public string? ManufacturerCompany { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string? BatchNumber { get; set; }
        public DateTime OpeningDate { get; set; }
        public float PowderGramPerLiter { get; set; }
        public string? UsageStartAcceptanceNumber { get; set; }
        public MediumCountEnum MediumCount { get; set; }
        public StorageTemperatureEnum StorageTemperature { get; set; }
        public ShelfLifeDurationEnum ShelfLifeDuration { get; set; }
        public AutoclaveConditionEnum AutoclaveConditions { get; set; }
        public string? ExtraAutoclaveCondition { get; set; }
        public MediumTypeEnum MediumType { get; set; }
        public QualityControlPeriodEnum QualityControlPeriod { get; set; }
        public DateTime QualityControlDate { get; set; }
        public int FirstConfirmerUserId { get; set; }
        public int SecondConfirmerUserId { get; set; }

    }
}
