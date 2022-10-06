using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class AboutManager
    {
        Repository<About> repoabout = new Repository<About>();
        public  List<About> GetAll()
        {
            return repoabout.List();
        }
        public int UpdateAboutBM(About a)
        {
            About about = repoabout.find(p=>p.AboutID==a.AboutID);
            about.AboutContent1 = a.AboutContent1;
            about.AboutContent2 = a.AboutContent2;
            about.AboutID = a.AboutID;
            about.AboutImage1 = a.AboutImage1;
            about.AboutImage2 = a.AboutImage2;
            return repoabout.Update(about);
        }
    }
}
