﻿
using SwachBharat.CMS.Bll.Services;
using SwachBharat.CMS.Bll.ViewModels.ChildModel.Model;
using SwachBharat.CMS.Bll.ViewModels.MainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwachBharat.CMS.Dal.DataContexts;

namespace SwachBharat.CMS.Bll.Repository.MainRepository
{
    public class MainRepository:IMainRepository
    {
        MainService mainService;
        public MainRepository()
        {
            mainService = new MainService();
        }


        #region State
        public AppStateVM GetStateDetailsById(int teamId)
        {
            AppStateVM stateVM = InitBaseViewModel<AppStateVM>(); 
            stateVM = mainService.GetStateDetailsById(teamId);
            return stateVM;
        }

        public AppStateVM GetStateById(int Id)
        {
            AppStateVM stateVM = InitBaseViewModel<AppStateVM>();
            stateVM = mainService.GetStateDetailsById(Id);
            return stateVM;
        } 
        public void SaveState(AppStateVM state)
        { 
           mainService.SaveStateDetail(state); 
        }

        public void DeleteState(int teamId)
        {
            mainService.DeleteStateRecord(teamId);
        }
        #endregion
    
        #region District
        public AppDistrictVM GetDistrictById(int teamId)
        {
           return mainService.GetDictrictById(teamId);
            
        }
        public void SaveDistrict(AppDistrictVM details)
        {
            mainService.SaveDictrictDetails(details);
        }
        public void DeleteDistrict(int teamId)
        {
            mainService.DeleteDictrictRecord(teamId);
        }
        #endregion 
          
        #region Taluka
        public AppTalukaVM GetTalukaById(int teamId,string name)
        {
            return mainService.GetTalukaById(teamId,name);
        } 
        public void SaveTaluka(AppTalukaVM state)
        {
            mainService.SaveTalukaDetails(state);
        }
        public void DeleteTaluka(int teamId)
        {
            mainService.DeleteTalukaRecord(teamId);
        }


        #endregion

        public T InitBaseViewModel<T>() where T : BaseVM
        {
            var obj = (T)Activator.CreateInstance(typeof(T));
            // obj.languageList = screenService.ListLanguage();
            return obj;
        }

        //public int GetAppIdForApp(string appName)
        //{
        //    return mainService.GetAppIdForApp(appName);
        //}
        //public void SaveApplicationDetails(AppDetailsVM appDetailsVM)
        //{
        //    mainService.SaveApplicationDetails(appDetailsVM);
        //}

        //public IEnumerable<VMApplication> GetAppId()
        //{
        //    return mainService.GetAppId();
        //}
        //public IEnumerable<SubscriptionVM> GetSubscriptionId()
        //{
        //    return mainService.GetSubscriptionId();
        //}
        //public bool AddApptoUser(string UserId, int AppId, int SubscriptionId)
        //{
        //    return mainService.AddApptoUser(UserId, AppId, SubscriptionId);
        //}
        public string GetDatabaseFromAppID(int AppId)
        {
            return mainService.GetDatabaseFromAppID(AppId);
        }
        public AppDetailsVM GetApplicationDetails(int AppId)
        {
            return mainService.GetApplicationDetails(AppId);
        }
        public int GetUserAppId(string UserId)
        {
            return mainService.GetUserAppId(UserId);
        }

        //Addedv By Saurabh (27 May 2019)

        public List<AppDetail> GetAppName()
        {
            return mainService.GetAppName();
        }

        #region Game
        public List<GameMaster> GetGameList()
        {
            return mainService.GetGameList();
        }

        public InfotainmentDetailsVW GetInfotainmentDetailsById(int ID)
        {
            return mainService.GetInfotainmentDetailsById(ID);
        }

        public void SaveGameDetails(InfotainmentDetailsVW data)
        {
            if (data.GameDetailsId <= 0)
            {
                data.GameDetailsId = 0;
            }
            mainService.SaveGameDetails(data);
        }

        #endregion

    }
}
