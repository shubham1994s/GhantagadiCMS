﻿using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using SwachBharat.CMS.Bll.Repository.GridRepository;
using SwachBharat.CMS.Bll.ViewModels.ChildModel.Grid;

namespace SwachBharat.CMS.Bll.Repository.GridRepository.Grid
{
    public class OnePointFourEditGridRepository : IDataTableRepository
    {
        IEnumerable<OnePointfourGridRow> dataset;
        DashBoardRepository objRep = new DashBoardRepository();

        public OnePointFourEditGridRepository(long wildcard, string SearchString, int AppId,string INSERT_ID)
        {
            dataset = objRep.GetOnepointfourEditData(wildcard, SearchString, AppId,INSERT_ID);
        }
        public string GetDataTabelJson(string sortColumn, string sortColumnDir, string draw, string length, string searchValue, string start)
        {
            var json = dataset.GetDataTableJson(sortColumn, sortColumnDir, draw, length, searchValue, start);
            return json;
        }
    }
}
