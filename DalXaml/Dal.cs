using DaLApi;
using DO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Dal
{
    public sealed class DalXml : IDAL
    {
        XElement stationRoot;
        public static string stationPath = @"Stations.xml";


        private static readonly DalXml instance;
        static DalXml(){
            instance = new DalXml();
        }
        private DalXml(){

             stationRoot = XElement.Load(stationPath);

        }
        public static DalXml Instance { get { return instance; } }

        public static void saveListToXML<T>(List<T> list, string filePath)
        {
            try
            {
                FileStream file = new FileStream(filePath, FileMode.Create);
                XmlSerializer x = new XmlSerializer(list.GetType());
                x.Serialize(file, list);
                file.Close();
            }
            catch (Exception ex)
            {
                throw new Exception($"fail to create xml file: {filePath}");
            }
        }
        public static List<T> loadListFromXML<T>(string filePath)
        {
            try
            {
                if (File.Exists( filePath))
                {
                    List<T> list;
                    XmlSerializer x = new XmlSerializer(typeof(List<T>));
                    FileStream file = new FileStream( filePath, FileMode.Open);
                    list = (List<T>)x.Deserialize(file);
                    file.Close();
                    return list;
                }
                else
                    return new List<T>();
            }
            catch (Exception ex)
            {
                throw new Exception( $"fail to load xml file: {filePath}", ex);
            }
        }

        #region Station
        //טעינת הקובץ



        void IDAL.addStation(int code, string name, double longtitude, double latitude)
        {
            XElement Code = new XElement("Code", code);
            XElement Name = new XElement("Name", name);
            XElement Longtitude = new XElement("Longtitude", longtitude);
            XElement Latitude = new XElement("Latitude", latitude);
            XElement IsActive = new XElement("IsActive", true);
            stationRoot.Add(new XElement("station", Code, Name, Longtitude, Latitude, IsActive));
        }

        void IDAL.EditStation(int code, string name, double latitude, double longtitude, int oldNum)
        {
            XElement stationToEdit = (from station in stationRoot.Elements()
                                      where int.Parse(station.Element("Code").Value) == oldNum
                                      select station).FirstOrDefault();
            stationToEdit.Element("Code").Value = code.ToString();
            stationToEdit.Element("Name").Value = name;
            stationToEdit.Element("Longtitude").Value = longtitude.ToString();
            stationToEdit.Element("Latitude").Value = latitude.ToString();
            stationToEdit.Element("IsActive").Value = "true";
            stationRoot.Save(stationPath);
        }

        IEnumerable<Station> IDAL.getStations()
        {
            IEnumerable<Station> stations = from stop in stationRoot.Elements()
                                            select
                                            new Station(
                                                int.Parse(stop.Element("Code").Value),
                                                stop.Element("Name").Value,
                                                double.Parse(stop.Element("Longtitude").Value),
                                                double.Parse(stop.Element("Latitude").Value));
            return stations;
        }


        void IDAL.RemoveStop(int code)
        {
            XElement stationToRemove = (from station in stationRoot.Elements()
                                        where int.Parse(station.Element("Code").Value) == code
                                        select station).FirstOrDefault();
            stationToRemove.Remove();
            stationRoot.Save(stationPath);
        }
        #endregion

        #region Buses


        void IDAL.activeBus(string busNum)
        {
            throw new NotImplementedException();
        }

        void IDAL.addBus(string busNam, DateTime? startDate)
        {
            List<Bus> buses = new List<Bus>();
            string path = "Buses.xml";
            buses = loadListFromXML<Bus>(path);
            buses.Add(new Bus(busNam, startDate));
            //לבדוק אם כותה בצורה טובה
            saveListToXML<Bus>( buses, path);
        }

        void IDAL.DeleteBus(string BusId)
        {
            List<Bus> buses = new List<Bus>();
            string path = "Buses.xml";
            buses = loadListFromXML<Bus>(path);
            buses.RemoveAt(buses.FindIndex(x => x.Id == BusId));
            //לבדוק אם כותה בצורה טובה
            saveListToXML<Bus>(buses, path);
        }

        IEnumerable<Bus> IDAL.getAllBuses()
        {
            List<Bus> buses = new List<Bus>();
            string path = "Buses.xml";
            buses = loadListFromXML<Bus>(path);
            return buses;
        }

        int IDAL.BusAlreadyExists(string busNam)
        {
                List<Bus> buses = new List<Bus>();
                string path = "Buses.xml";
            buses = loadListFromXML<Bus>(path);
                if (buses.Any(x=>x.Id==busNam))
                {
                    return 0;
                }
                else if (buses.Any(x => x.Id == busNam && x.IsActive ==false))
                {
                    return 2;
                }
                return 1;
        }

        Bus IDAL.getBus(string id)
        {
            List<Bus> buses = new List<Bus>();
            string path = "Buses.xml";
            buses = loadListFromXML<Bus>(path);
            return buses.Find(x => x.Id == id);
        }



        void IDAL.updateBus(Bus bustoUpdate)
        {
            List<Bus> buses = new List<Bus>();
            string path = "Buses.xml";
            buses = loadListFromXML<Bus>(path);
            buses[buses.FindIndex(x => x.Id == bustoUpdate.Id)] = bustoUpdate;
        }
        #endregion

        #region AdjacentStatision


        void IDAL.AddAdjacentStatision(int stop1, int stop2, string distnase, TimeSpan time)
        {
            List<AdjacentStatision> adjacentStatision = new List<AdjacentStatision>();
            string path = "AdjacentStatision.xml";
            adjacentStatision = loadListFromXML<AdjacentStatision>(path);
            adjacentStatision.Add(new AdjacentStatision(stop1,stop2,double.Parse(distnase),time));
            //לבדוק אם כותה בצורה טובה
            saveListToXML<AdjacentStatision>(adjacentStatision, path);
        }

        bool IDAL.CheckAdjacentStatision(int stop1, int stop2)
        {
            List<AdjacentStatision> adjacentStatision = new List<AdjacentStatision>();
            string path = "AdjacentStatision.xml";
            adjacentStatision = loadListFromXML<AdjacentStatision>(path);
            if (adjacentStatision.Any(x => x.Station_1 == stop1 && x.Station_2 == stop2)) ;
            {
                return true;
            }
        }

        void IDAL.EditAdjacentStatision(int stop1, int stop2, double dis, TimeSpan time)
        {
            List<AdjacentStatision> adjacentStatision = new List<AdjacentStatision>();
            string path = "AdjacentStatision.xml";
            adjacentStatision = loadListFromXML<AdjacentStatision>(path);
            adjacentStatision[adjacentStatision.FindIndex(x => x.Station_1 == stop1 && x.Station_2 == stop2)] = new AdjacentStatision(stop1,stop2,dis,time);
        }

        IEnumerable<AdjacentStatision> IDAL.getAdjacentStatisions()
        {
            string path = "AdjacentStatision.xml";
            return  loadListFromXML<AdjacentStatision>(path);
        }
        #endregion

        #region Lins

        void IDAL.AddLine(int newLineNum, string area, int firstStop, int lastStop)
        {
            List<LineBus> lines = new List<LineBus>();
            string path = "Lines.xml";
            lines = loadListFromXML<LineBus>(path);
            lines.Add(new LineBus(newLineNum,GetAreas(area),firstStop,lastStop));
            //לבדוק אם כותה בצורה טובה
            saveListToXML<LineBus>(lines, path);
        }

        void IDAL.EditLine(int oldLineNum, int lineNum, string area)
        {
            List<LineBus> lines = new List<LineBus>();
            string path = "Lines.xml";
            lines = loadListFromXML<LineBus>(path);
            lines[lines.FindIndex(x => x.Id == oldLineNum)].Id = lineNum;
            lines[lines.FindIndex(x => x.Id == oldLineNum)].Area = GetAreas(area);
            //לבדוק אם כותה בצורה טובה
            saveListToXML<LineBus>(lines, path);
        }

        IEnumerable<LineBus> IDAL.getLins()
        {
            string path = "Lines.xml";
            return loadListFromXML<LineBus>(path);
        }

        void IDAL.RemoveLine(int lineNum)
        {
            List<LineBus> lines = new List<LineBus>();
            string path = "Lines.xml";
            lines = loadListFromXML<LineBus>(path);
            lines.RemoveAt(lines.FindIndex(x => x.Id == lineNum));
        }

        #endregion

        #region Station Of Line


        void IDAL.AddStopOfLine(int stopNum, int lineNum, int after)
        {
            List<StopOfLine> stopsOfLine = new List<StopOfLine>();
            string path = "StopsOfLine.xml";
            stopsOfLine = loadListFromXML<StopOfLine>(path);
            stopsOfLine.Add(new StopOfLine(lineNum,stopNum,after));
            //TODOלבדוק אם כותה בצורה טובה 
            saveListToXML<StopOfLine>(stopsOfLine, path);
        }

        void IDAL.RemoveStopFromLine(StopOfLine stop)
        {
            List<StopOfLine> stopsOfLine = new List<StopOfLine>();
            string pathStop = "StopsOfLine.xml";
            stopsOfLine = loadListFromXML<StopOfLine>(pathStop);
            stopsOfLine.Remove(stop);
            foreach (var item in stopsOfLine)
            {
                if (item.OfLine == stop.OfLine && item.StatIndex > stop.StatIndex)
                {
                    item.StatIndex--;
                }
            }
            saveListToXML<StopOfLine>(stopsOfLine, pathStop);
        }

        IEnumerable<StopOfLine> IDAL.GetStopsOfLine()
        {
            string path = "StopsOfLine.xml";
            return loadListFromXML<StopOfLine>(path);
            
        }

        void IDAL.RemoveStopLine(int code)
        {
            List<StopOfLine> stopsOfLine = new List<StopOfLine>();
            string path = "StopsOfLine.xml";
            stopsOfLine = loadListFromXML<StopOfLine>(path);
            for (int i = 0; i < stopsOfLine.Count(); i++)
            {
                if (stopsOfLine[i].Id == code)
                {
                    stopsOfLine.RemoveAt(i);
                }
            }
            saveListToXML<StopOfLine>(stopsOfLine, path);
        }
        #endregion

        #region User



        void IDAL.addUser(User user)
        {
            List<User> users = new List<User>();
            string path = "user.xml";
            users = loadListFromXML<User>(path);
            users.Add(new User(user.UserName,user.Password,user.Admin));
            //TODOלבדוק אם כותה בצורה טובה 
            saveListToXML<User>(users, path);
        }

        void IDAL.ChangePass(string userName, string newPass)
        {
            List<User> users = new List<User>();
            string path = "user.xml";
            users = loadListFromXML<User>(path);
            users[users.FindIndex(x => x.UserName == userName)].Password = newPass;
        }

        bool IDAL.dalIsUser(string userName, string password, bool isMang)
        {
            List<User> users = new List<User>();
            string path = "user.xml";
            users = loadListFromXML<User>(path);
            int u = users.FindIndex(x => x.UserName == userName && x.Password == password && x.Admin == isMang);
            if (u == -1)
            {
                return false;
            }
            return true;
        }

        void IDAL.deliteUser(string userName)
        {
            List<User> users = new List<User>();
            string path = "user.xml";
            users = loadListFromXML<User>(path);
            users.RemoveAt(users.FindIndex(x => x.UserName == userName));
        }

        void IDAL.editUser(User user)
        {
            List<User> users = new List<User>();
            string path = "user.xml";
            users = loadListFromXML<User>(path);
            users[users.FindIndex(x => x.UserName == user.UserName)] = user;
            saveListToXML<User>(users, path);

        }

        List<User> IDAL.getUsers()
        {
            List<User> users = new List<User>();
            string path = "user.xml";
            users = loadListFromXML<User>(path);
            return users;
        }
        #endregion


        void IDAL.InitializeData()
        {
            throw new NotImplementedException();
        }

        public static Areas GetAreas(string a)
        {
            switch (a)
            {
                case "General":
                    return Areas.General;
                case "North":
                    return Areas.North;
                case "South":
                    return Areas.South;
                case "Center":
                    return Areas.Center;
                case "Jerusalem":
                    return Areas.Jerusalem;
                default:
                    return Areas.General;
            }
        }

        public Bus isBus(Bus x)
        {
            throw new NotImplementedException();
        }
    }
}
