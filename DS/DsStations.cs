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
            stations.Add(new Station(863578, "וייצמן/מרבד הקסמים", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(457888, "העצמאות/ששת הימים", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(345221, "העצמאות/ראובן", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(789004, "העצמאות/וייצמן", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(388751, "בי''ס בר לב/בן יהודה", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(009856, "האילנות/מנחם בגין", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(667302, "האילנות/אלון", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(366792, "ספר גוונים/ארז", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(400897, "חיים הרצוג/דולב", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(113224, "מנחם בגין/יצחק רבין", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(448990, "יצחק רבין/פנחס ספיר", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(333432, "דרך הפרחים/יסמין", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(234350, "התאנה/האלון", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(837027, "התאנה/הגפן", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(449800, "דרך הפארק/הרב נריה", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(277628, "מנחם בגין/יעקב חזן", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(465033, "גורודסקי/יחיאל פלדי", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(676429, "מנוחה ונחלה/יהודה גורודיסקי", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(090805, "עוקשי/לוי אשכול", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(245559, "הגאון בן איש חי/צאלון", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(111332, "הראשונים/כביש 5700", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(777786, "בית הלוי ה", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(440000, "החבורה/דב הוז", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(335875, "כנף/ברוש", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(444098, "רשות שדות התעופה/העליה", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(772410, "ההרחבה/הותיקים", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(334442, "ההרחבה ב", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(109623, "ההרחבה/ א", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(129563, "הגפן/ההרחבה", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(123007, "הגפן/מורד התאנה", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(444980, "הערבה", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(110433, "הרותם/הדגניות", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(334096, "הרצל/גולני", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(229077, "מחנה צריפין/מועדון", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(489276, "הולצמן/המדע", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(289990, "מרכז לבריאות הנפש לב השרון", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(349867, "הגלעד/כרמל", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(555665, "חיים בר לב/שדרות יצחק רבין", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(909087, "שבזי/ויצמן", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(300090, "שבזי/שבת אחים", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(000333, "אלי כהן/לוחמי הגטאות", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(200567, "הכלנית/הנרקיס", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(009999, "האירוס/הכלנית", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(456788, "ויצמן/הבנים", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(232321, "הדס/אלי כהן", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(889209, "ל/משה שרת", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(232846, "חנה אברך/וולקני", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(404687, "מרכזית לוד/הורדה", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(300199, "פריד/ששת הימים", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
            stations.Add(new Station(567223, "הנחשול/הדייגים", (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3)));
        }
       




    }
}
