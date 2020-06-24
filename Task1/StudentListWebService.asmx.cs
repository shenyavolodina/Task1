using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Web.Services;
using System.Web.Hosting;
using System.Xml.Serialization;
using System.IO;
using Task1.Models;

namespace Task1
{
    /// <summary>
    /// Summary description for StudentListWebService
    /// </summary>
    [WebService(Name = "MyWebService", Description = "This Web Service is used to find students in XML file", Namespace = "http://www.mycompany.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class StudentListWebService : System.Web.Services.WebService
    {
        private Student[] newpeople;
        public StudentListWebService()
        {
            
            var pathToFile = HostingEnvironment.MapPath("~/StudentXML.xml");
            XmlSerializer formatter = new XmlSerializer(typeof(Student[]));
            using (FileStream fs = new FileStream(pathToFile, FileMode.OpenOrCreate))
            {
                newpeople = (Student[])formatter.Deserialize(fs);
            }

        }

        [WebMethod]
        public Student[] GetStudentsGraterThan(float mark)
        {
            return newpeople.Where(s=>s.AvgMark > mark).ToArray();
        }
        [WebMethod]
        public Student[] GetStudentsLowerThan(float mark)
        {
            return newpeople.Where(s => s.AvgMark < mark).ToArray();
        }
        [WebMethod]
        public Student[] GetStudentsInRange(float minMark, float maxMark)
        {
            return newpeople.Where(s => s.AvgMark >= minMark && s.AvgMark <= maxMark).ToArray();
        }

    }
}
