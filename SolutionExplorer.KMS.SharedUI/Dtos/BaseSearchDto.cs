namespace SolutionExplorer.KMS.SharedUI.Dtos
{
    public class BaseSearchDto
    {
        public BaseSearchDto()
        {
            this.GetAllItems = false;
        }

        public int? Id { get; set; }

        public int? Take { get; set; }
        public int? Skip { get; set; }

        public bool GetAllItems { get; set; }

        public List<OrderByInfo> OrderByInfos { get; set; }

        public void CalculateTakeAndSkip(int page = 1, int pageSize = 10)
        {
            Take = pageSize;
            Skip = page * pageSize;
        }
    }

    public class OrderByInfo
    {
        /// <summary>
        /// Name of column to order
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// ASC or DESC
        /// </summary>
        public string OrderDirection { get; set; }
    }
}
