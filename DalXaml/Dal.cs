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
    class DalXml : IDAL
    {

        private static readonly DalXml instance = new DalXml();
        static DalXml(){}
        private DalXml(){}
        public static DalXml Instance { get { return instance; } }

        #region Station
        //טעינת הקובץ
        public static string stationPath = @"Station.xml";
        XElement stationRoot = XElement.Load(stationPath);



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

        public static void saveListToXML(List<Bus> list, string path)
        {
            XmlSerializer x = new XmlSerializer(list.GetType());
            FileStream fs = new FileStream(path, FileMode.Create);
            x.Serialize(fs, list);
        }

        public static List<Bus> loadListBusFromXML(string path)
        {
            List<Bus> list;
            XmlSerializer x = new XmlSerializer(typeof(List<Bus>));
            FileStream fs = new FileStream(path, FileMode.Open);
            list = (List<Bus>)x.Deserialize(fs);
            return list;
        }
        void IDAL.activeBus(string busNum)
        {
            throw new NotImplementedException();
        }

        void IDAL.addBus(string busNam, DateTime? startDate)
        {
            throw new NotImplementedException();
        }

        void IDAL.DeleteBus(string BusId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Bus> IDAL.getAllBuses()
        {
            throw new NotImplementedException();
        }

        int IDAL.BusAlreadyExists(string busNam)
        {
            throw new NotImplementedException();
        }

        Bus IDAL.getBus(string id)
        {
            throw new NotImplementedException();
        }

        Bus IDAL.isBus(Bus x)
        {
            throw new NotImplementedException();
        }

        void IDAL.updateBus(Bus bustoUpdate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region AdjacentStatision

        public static void saveListToXML(List<AdjacentStatision> list, string path)
        {
            XmlSerializer x = new XmlSerializer(list.GetType());
            FileStream fs = new FileStream(path, FileMode.Create);
            x.Serialize(fs, list);
        }

        public static List<AdjacentStatision> loadListAdjacentStatisionFromXML(string path)
        {
            List<AdjacentStatision> list;
            XmlSerializer x = new XmlSerializer(typeof(List<AdjacentStatision>));
            FileStream fs = new FileStream(path, FileMode.Open);
            list = (List<AdjacentStatision>)x.Deserialize(fs);
            return list;
        }

        void IDAL.AddAdjacentStatision(int stop1, int stop2, string distnase, TimeSpan time)
        {
            throw new NotImplementedException();
        }

        bool IDAL.CheckAdjacentStatision(int stop1, int stop2)
        {
            throw new NotImplementedException();
        }

        void IDAL.EditAdjacentStatision(int stop1, int stop2, double dis, TimeSpan time)
        {
            throw new NotImplementedException();
        }

        IEnumerable<AdjacentStatision> IDAL.getAdjacentStatisions()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Lins

        public static void saveListToXML(List<LineBus> list, string path)
        {
            XmlSerializer x = new XmlSerializer(list.GetType());
            FileStream fs = new FileStream(path, FileMode.Create);
            x.Serialize(fs, list);
        }

        public static List<LineBus> loadListLinsFromXML(string path)
        {
            List<LineBus> list;
            XmlSerializer x = new XmlSerializer(typeof(List<LineBus>));
            FileStream fs = new FileStream(path, FileMode.Open);
            list = (List<LineBus>)x.Deserialize(fs);
            return list;
        }

        void IDAL.AddLine(int newLineNum, string area, int firstStop, int lastStop)
        {
            throw new NotImplementedException();
        }

        void IDAL.EditLine(int oldLineNum, int lineNum, string area)
        {
            throw new NotImplementedException();
        }

        IEnumerable<LineBus> IDAL.getLins()
        {
            throw new NotImplementedException();
        }

        void IDAL.RemoveLine(int lineNum)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Station Of Line

        public static void saveListToXML(List<StopOfLine> list, string path)
        {
            XmlSerializer x = new XmlSerializer(list.GetType());
            FileStream fs = new FileStream(path, FileMode.Create);
            x.Serialize(fs, list);
        }

        public static List<StopOfLine> loadListStopOfLineFromXML(string path)
        {
            List<StopOfLine> list;
            XmlSerializer x = new XmlSerializer(typeof(List<StopOfLine>));
            FileStream fs = new FileStream(path, FileMode.Open);
            list = (List<StopOfLine>)x.Deserialize(fs);
            return list;
        }
        void IDAL.AddStopOfLine(int stopNum, int lineNum, int after)
        {
            throw new NotImplementedException();
        }

        void IDAL.RemoveStopFromLine(StopOfLine stop)
        {
            throw new NotImplementedException();
        }

        IEnumerable<StopOfLine> IDAL.GetStopsOfLine()
        {
            throw new NotImplementedException();
        }

        void IDAL.RemoveStopLine(int code)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region User

        public static void saveListToXML(List<User> list, string path)
        {
            XmlSerializer x = new XmlSerializer(list.GetType());
            FileStream fs = new FileStream(path, FileMode.Create);
            x.Serialize(fs, list);
        }

        public static List<User> loadListUserFromXML(string path)
        {
            List<User> list;
            XmlSerializer x = new XmlSerializer(typeof(List<User>));
            FileStream fs = new FileStream(path, FileMode.Open);
            list = (List<User>)x.Deserialize(fs);
            return list;
        }

        void IDAL.addUser(User user)
        {
            throw new NotImplementedException();
        }

        void IDAL.ChangePass(string userName, string newPass)
        {
            throw new NotImplementedException();
        }

        bool IDAL.dalIsUser(string userName, string password, bool isMang)
        {
            throw new NotImplementedException();
        }

        void IDAL.deliteUser(string userName)
        {
            throw new NotImplementedException();
        }

        void IDAL.editUser(User user)
        {
            throw new NotImplementedException();
        }

        List<User> IDAL.getUsers()
        {
            throw new NotImplementedException();
        }
        #endregion






        void IDAL.InitializeData()
        {
            throw new NotImplementedException();
        }


    }
}
