using System.ComponentModel.DataAnnotations;


namespace SolutionExplorer.KMS.SharedUI.Enums
{

    /// <summary>
    /// نام محیط
    /// </summary>
    public enum EnvironmentNameEnum { }

    /// <summary>
    /// تعداد محیط
    /// </summary>
    public enum MediumCountEnum
    {
        [Display(Name = "بیشتر از 100")]
        MoreThan100,
        [Display(Name = "کمتر از 100")]
        LessThan100
    }

    /// <summary>
    /// دمای نگهداری
    /// </summary>
    public enum StorageTemperatureEnum
    {
        [Display(Name = "-70 °C")]
        Minus70,

        [Display(Name = "-20 °C")]
        Minus20,

        [Display(Name = "2-8 °C")]
        TwoTo8,

        [Display(Name = "20-25 °C")]
        TwentyTo25,

        [Display(Name = "37 °C")]
        ThirtySeven
    }

    /// <summary>
    /// زمان قابل نگهداری
    /// </summary>
    public enum ShelfLifeDurationEnum
    {
        [Display(Name = "3 روز")]
        ThreeDays,

        [Display(Name = "1 هفته")]
        OneWeek,

        [Display(Name = "2 هفته")]
        TwoWeeks,

        [Display(Name = "3 هفته")]
        ThreeWeeks,

        [Display(Name = "4 هفته")]
        FourWeeks,

        [Display(Name = "1 ماه")]
        OneMonth,

        [Display(Name = "6 هفته")]
        SixWeeks,

        [Display(Name = "2 ماه")]
        TwoMonths,

        [Display(Name = "3 ماه")]
        ThreeMonths,

        [Display(Name = "4 ماه")]
        FourMonths,

        [Display(Name = "5 ماه")]
        FiveMonths,

        [Display(Name = "6 ماه")]
        SixMonths
    }

    /// <summary>
    /// نوع محیط
    /// </summary>
    public enum MediumTypeEnum
    {
        [Display(Name = "لوله ای درب پیچ دار")]
        ScrewCapTube,

        [Display(Name = "لوله ای درب پنبه ای")]
        CottonCapTube,

        [Display(Name = "پلیتی cm 6")]
        Plate6Cm,

        [Display(Name = "پلیتی cm 8")]
        Plate8Cm,

        [Display(Name = "پلیتی cm 10")]
        Plate10Cm,

        [Display(Name = "پلیتی cm 12")]
        Plate12Cm,

        [Display(Name = "پلیتی cm 15")]
        Plate15Cm,

        [Display(Name = "پلیتی 2 خانه ای")]
        TwoCompartmentPlate
    }

    /// <summary>
    /// دوره انجام کنترل کیفی
    /// </summary>
    [Flags]
    public enum QualityControlPeriodEnum
    {
        [Display(Name = "هر سری ساخت")]
        EachBatch,

        [Display(Name = "هفتگی")]
        Weekly,

        [Display(Name = "ماهانه")]
        Monthly,

        [Display(Name = "3 ماهه")]
        ThreeMonths,

        [Display(Name = "6 ماهه")]
        SixMonths
    }

    /// <summary>
    /// گروه مشخصات ظاهری
    /// </summary>
    public enum AppearanceGroupEnum
    {
        [Display(Name = "رنگ و ظاهر محیط پایه")]
        BaseMediaColorAndAppearance,

        [Display(Name = "حالت محیط بعد از ژله شدن")]
        AfterGelationCondition,

        [Display(Name = "رنگ و شفافیت محیط آماده شده")]
        PreparedMediaColorAndClarity
    }

    /// <summary>
    /// شرایط اتوکلاو
    /// </summary>
    [Flags]
    public enum AutoclaveConditionEnum
    {
        [Display(Name = "فشار 15 lbs (دمای 121 C° برای 15 دقیقه)")]
        Pressure15_121C_15Min,

        [Display(Name = "فشار 12 تا 15 lbs (دمای 118 تا 121 C° برای 15 دقیقه)")]
        Pressure12To15_118To121C_15Min,

        [Display(Name = "فشار 12 تا 15 lbs (دمای 118 تا 121 C° برای 10 دقیقه)")]
        Pressure12To15_118To121C_10Min,

        [Display(Name = "فشار 5 lbs (دمای 118 تا 121 C° برای 3 دقیقه)")]
        Pressure5_118To121C_3Min,

        [Display(Name = "فشار 10 تا 12 lbs (دمای 116 تا 118 C° برای 15 دقیقه)")]
        Pressure10To12_116To118C_15Min,

        [Display(Name = "فشار 10 lbs (دمای 115 C° برای 15 دقیقه)")]
        Pressure10_115C_15Min,

        [Display(Name = "نیاز به اتوکلاو ندارد")]
        NoAutoclaveRequired,

        [Display(Name = "پایه اوره: بدون اتوکلاو، پایه آگار: فشار 10 lbs (دمای 115 C° برای 20 دقیقه)")]
        UreaNoAutoclave_AgarPressure10_115C_20Min
    }
}

