using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DO;



namespace DaLApi
{
    public interface IDAL
    {
        void InitializeData();
        IEnumerable<Station> getStations();
        #region station
        void addStation(int code, string name, double longtitude, double latitude);
        #endregion

        #region Bus

        int BusAlreadyExists(string busNam);
        void addBus(string busNam, DateTime? startDate);
        void AddAdjacentStatision(int stop1, int stop2, string distnase, TimeSpan time);
        Bus getBus(string id);
        IEnumerable<Bus> getAllBuses();
        void updateBus(Bus bustoUpdate);
        void AddLine(int newLineNum, string area, int firstStop, int lastStop);
        void DeleteBus(string BusId);
        void activeBus(string busNum);
        Bus isBus(Bus x);
        #endregion

        #region User
        bool dalIsUser(string userName, string password, bool isMang);
        List<User> getUsers();
        void addUser(User user);
        void editUser(User user);
        void deliteUser(string userName);
        #endregion

        #region Line

        void RemoveStopLine(int code);
        bool CheckAdjacentStatision(int stop1, int stop2);
        void EditAdjacentStatision(int stop1, int stop2, double dis, TimeSpan time);
        void EditLine(int oldLineNum,int lineNum, string area);
        void AddStopOfLine(int stopNum, int lineNum,int after);
        IEnumerable<AdjacentStatision> getAdjacentStatisions(/*Predicate<AdjacentStatision> predicate*/);
        void RemoveStopFromLine(StopOfLine stop);
        IEnumerable<StopOfLine> GetStopsOfLine();
        void RemoveLine(int lineNum);
        IEnumerable<LineBus> getLins();
        void RemoveStop(int code);
        void EditStation(int code, string name, double latitude, double longtitude,int oldNum);
        void ChangePass(string userName, string newPass);
        #endregion


    }
    static class DalConfig
    {
        internal static string DalName;
        internal static Dictionary<string, string> DalPackages;
        static DalConfig()
        {
            XElement dalConfig = XElement.Load(@"config.xml");
            DalName = dalConfig.Element("dal").Value;
            DalPackages = (from pkg in dalConfig.Element("dal-packages").Elements()
                           select pkg
            ).ToDictionary(p => "" + p.Name, p => p.Value);
        }
    }
    public class DalConfigException : Exception
    {
        public DalConfigException(string msg) : base(msg) { }
        public DalConfigException(string msg, Exception inr) : base((""), inr) { }
    }

    public static class DalFactory
    {
        public static IDAL GetDal()
        {
            string dalType = DalConfig.DalName;
            string dalPkg = DalConfig.DalPackages[dalType];

            if (dalPkg == null) throw new DalConfigException($"wrong DL type:{dalType}");

            try { Assembly.Load(dalPkg); }

            catch (Exception ex)
            {
                throw new DalConfigException($" faild loading{dalPkg}.dll", ex);
                //throw new DalConfigException(" faild loading.dll");
            }

            Type type = Type.GetType($"Dal.{dalPkg}, {dalPkg}");

            if (type == null) throw new DalConfigException($"class name is not the same as assembly name: {dalPkg}");

            try
            {
                IDAL dal = (IDAL)type.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static).GetValue(null) as IDAL;

                if (dal == null) throw new DalConfigException($"class{dalPkg} instance is not intialized");
                return dal;
            }
            catch (NullReferenceException ex)
            {
                throw new DalConfigException($"class{dalPkg} is not a singelton", ex);

            }

        }
    }
}
