namespace SolutionExplorer.KMS.SharedUI.Dtos.PhysicalSpecificationDtos
{
    public class PhysicalSpecificationCreateDto : BaseDto
    {
        public string? Title { get; set; }
        public int QCBaseInfoPhysicalSpecificationId { get; set; }
        public int QualityControlId { get; set; }
        public bool IsChecked { get; set; }
    }

    public class PhysicalSpecificationDisplayDto : BaseDto
    {
        public int QCBaseInfoPhysicalSpecificationId { get; set; }
        public string QCBaseInfoPhysicalSpecificationTitle { get; set; }
        public int QualityControlId { get; set; }
        public bool IsChecked { get; set; }
    }
}
