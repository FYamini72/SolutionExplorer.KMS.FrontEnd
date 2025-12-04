using SolutionExplorer.KMS.SharedUI.Dtos.QCBaseInfoExpectedResultDtos;

namespace SolutionExplorer.KMS.SharedUI.Dtos.QualityControlResultDtos
{
    public class QualityControlResultDisplayDto : BaseDto
    {
        public int QCBaseInfoExpectedResultId { get; set; }
        public QCBaseInfoExpectedResultDisplayDto QCBaseInfoExpectedResult { get; set; }
        public int QualityControlId { get; set; }
        public bool IsConfirmed { get; set; }
        public string? CorrectiveActions { get; set; }
    }
}
