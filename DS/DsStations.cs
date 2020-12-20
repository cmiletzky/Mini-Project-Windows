﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace DS
{



    
   public class DsStations
    {
      static public  string[] stationListNames = {  "בי''ס בר לב/בן יהודה",
                                       "הרצל/צומת בילו",
                                       "הנחשול/הדייגים",
                                       " פריד/ששת הימים",
                                       ".מרכזית לוד/הורדה",
                                       "חנה אברך/וולקני",
                                       "ל/משה שרת",
                                       "/אלי כהן",
                                       "ויצמן/הבנים",
                                       "האירוס/הכלנית",
                                       "הכלנית/הנרקיס",
                                       "אלי כהן/לוחמי הגטאות",
                                       "שבזי/שבת אחים",
                                       "שבזי/ויצמן",
                                       "חיים בר לב/שדרות יצחק רבין",
                                       " לבריאות הנפש לב השרון",
                                       "מרכז לבריאות הנפש לב השרון",
                                       "הולצמן/המדע",
                                       "מחנה צריפין/מועדון",
                                       "הרצל/גולני",
                                       "הרותם/הדגניות",
                                       "הערבה",
                                       " הגפן/מורד התאנה",
                                       " הגפן/ההרחבה",
                                       "  ההרחבה א",
                                       "ההרחבה ב",
                                       "ההרחבה/הותיקים",
                                       "רשות שדות התעופה/העליה",
                                       "כנף/ברוש",
                                       "החבורה/דב הוז",
                                       "בית הלוי ה",
                                       "הראשונים/כביש 5700",
                                       " הגאון בן איש חי/צאלון",
                                       "עוקשי/לוי אשכול",
                                       "  מנוחה ונחלה/יהודה גורודיסקי",
                                       "גורודסקי/יחיאל פלדי",
                                       " מנחם בגין/יעקב חזן",
                                       "דרך הפארק/הרב נריה",
                                       "התאנה/הגפן",
                                       "התאנה/האלון",
                                       "דרך הפרחים/יסמין",
                                       "יצחק רבין/פנחס ספיר",
                                       "מנחם בגין/יצחק רבין",
                                       "חיים הרצוג/דולב",
                                       " ספר גוונים/ארז",
                                       " האילנות/אלון",
                                       " האילנות/מנחם בגין",
                                       "העצמאות/וייצמן",
                                       "העצמאות/וייצמן",
                                       "העצמאות/וייצמן",
                                       "וייצמן/מרבד הקסמים"};
       public static List<station> stations = new List<station>();
        //Initialize the list of stations with 40 stations
        public static void initializedStation()
        {
             Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 1; i < 51; i++)
            {
                station newStop = new station(i + 99999, stationListNames[i], (int)(r.NextDouble() * (33.3 - 31) + 31), (int)(r.NextDouble() * (35.5 - 34.3) + 34.3));
                stations.Add(newStop);
            }
        }




    }
}
