using SwachBharat.CMS.Bll.ViewModels.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwachBharat.CMS.Bll.Repository.GridRepository.Grid
{
  public  class NewEmpolyeeSummaryGridRepository : IDataTableRepository
    {
        IEnumerable<SBAEmpolyeeSummaryGrid> dataset;

        DashBoardRepository objRep = new DashBoardRepository();

        public NewEmpolyeeSummaryGridRepository(long wildcard, string SearchString, DateTime? fdate, DateTime? tdate, int userId,string Vehiclenumber, int appId)
        {
            dataset = objRep.NewGetEmployeeSummaryData(wildcard, SearchString, fdate, tdate, userId,Vehiclenumber, appId);
           
        } 

        public string GetDataTabelJson(string sortColumn, string sortColumnDir, string draw, string length, string searchValue, string start)
        {
            var json = dataset.GetDataTableJson(sortColumn, sortColumnDir, draw, length, searchValue, start);
            return json;
        }
    }
}
