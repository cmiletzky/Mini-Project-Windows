using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace DS
{



    
   public class DsStations
    {
       public static List<DO.Station> stations = new List<DO.Station>();
        //Initialize the list of stations with 50 stations
        public DsStations()
        {
            Random r = new Random(DateTime.Now.Millisecond);
            stations.Add(new Station(863578, "וייצמן/מרבד הקסמים", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(457888, "העצמאות/ששת הימים", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(345221, "העצמאות/ראובן", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(789004, "העצמאות/וייצמן", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(388751, "בי''ס בר לב/בן יהודה", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(009856, "האילנות/מנחם בגין", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(667302, "האילנות/אלון", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(366792, "ספר גוונים/ארז", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(400897, "חיים הרצוג/דולב", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(113224, "מנחם בגין/יצחק רבין", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(448990, "יצחק רבין/פנחס ספיר", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(333432, "דרך הפרחים/יסמין", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(234350, "התאנה/האלון", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(837027, "התאנה/הגפן", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(449800, "דרך הפארק/הרב נריה", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(277628, "מנחם בגין/יעקב חזן", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(465033, "גורודסקי/יחיאל פלדי", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(676429, "מנוחה ונחלה/יהודה גורודיסקי", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(090805, "עוקשי/לוי אשכול", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(245559, "הגאון בן איש חי/צאלון", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(111332, "הראשונים/כביש 5700", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(777786, "בית הלוי ה", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(440000, "החבורה/דב הוז", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(335875, "כנף/ברוש", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(444098, "רשות שדות התעופה/העליה", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(772410, "ההרחבה/הותיקים", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(334442, "ההרחבה ב", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(109623, "ההרחבה/ א", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(129563, "הגפן/ההרחבה", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(123007, "הגפן/מורד התאנה", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(444980, "הערבה", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(110433, "הרותם/הדגניות", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(334096, "הרצל/גולני", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(229077, "מחנה צריפין/מועדון", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(489276, "הולצמן/המדע", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(289990, "מרכז לבריאות הנפש לב השרון", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(349867, "הגלעד/כרמל", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(555665, "חיים בר לב/שדרות יצחק רבין", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(909087, "שבזי/ויצמן", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(300090, "שבזי/שבת אחים", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(000333, "אלי כהן/לוחמי הגטאות", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(200567, "הכלנית/הנרקיס", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(009999, "האירוס/הכלנית", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(456788, "ויצמן/הבנים", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(232321, "הדס/אלי כהן", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(889209, "ל/משה שרת", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(232846, "חנה אברך/וולקני", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(404687, "מרכזית לוד/הורדה", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(300199, "פריד/ששת הימים", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(567223, "הנחשול/הדייגים", (double)(r.NextDouble() * (33.3 - 31) + 31), (double)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
        }
       




    }
}
