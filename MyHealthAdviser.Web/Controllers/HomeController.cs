using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using MyHealthAdviser.Web.Models;
using System.IO;
using System.Net;
using System.Xml;

namespace MyHealthAdviser.Web.Controllers
{
   
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Hospitals near you";

            string placeApiUrl = ConfigurationManager.AppSettings["GooglePlaceAPIUrl"];
            string SearchText = "Hospital";

            try
            {
                var geoLocation = geoCode();


                placeApiUrl = ConfigurationManager.AppSettings["GooglePlaceAPIUrl"];
                placeApiUrl = placeApiUrl + "?query=" + SearchText + "&key=" + ConfigurationManager.AppSettings["GooglePlaceAPIKey"]+ 
                    "&location="+geoLocation.Latitude +"," +geoLocation.Longitude+ "& radius=5000";

                dynamic results = new System.Net.WebClient().DownloadString(placeApiUrl);

                

                XDocument doc = XDocument.Parse(results);
                var names = doc.Descendants("name");
                var address = doc.Descendants("formatted_address");
                
                List<HospitalEntity> hospitallist = new List<HospitalEntity>();
                foreach (var name in names)
                {
                    HospitalEntity hospital = new HospitalEntity();
                    hospital.name = name.Value;
                    //hospital.address = address[]
                    hospitallist.Add(hospital);
                }
               

                //return Json(list, JsonRequestBehavior.AllowGet);
                ViewBag.ListOfHospital = hospitallist;

                return View();
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

       
        public ActionResult Contact()
        {
            ViewBag.Message = "Your Multiplex near by";

            string placeApiUrl = ConfigurationManager.AppSettings["GooglePlaceAPIUrl"];
            string SearchText = "Multiplex";

            try
            {
                var geoLocation = geoCode();


                placeApiUrl = ConfigurationManager.AppSettings["GooglePlaceAPIUrl"];
                placeApiUrl = placeApiUrl + "?query=" + SearchText + "&key=" + ConfigurationManager.AppSettings["GooglePlaceAPIKey"] +
                    "&location=" + geoLocation.Latitude + "," + geoLocation.Longitude + "& radius=5000";

                dynamic results = new System.Net.WebClient().DownloadString(placeApiUrl);



                XDocument doc = XDocument.Parse(results);
                var names = doc.Descendants("name");
                var address = doc.Descendants("formatted_address");

                List<MultiplexEntity> multiplexlist = new List<MultiplexEntity>();
                foreach (var name in names)
                {
                    MultiplexEntity multiplex = new MultiplexEntity();
                    multiplex.name = name.Value;
                    //hospital.address = address[]
                    //  multiplexlist.Add(multiplex1);
                    multiplexlist.Add(multiplex);
                }


                //return Json(list, JsonRequestBehavior.AllowGet);
                ViewBag.ListOfMultiplex = multiplexlist;

                return View();
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }







          
        }



        [NonAction]
        public AdressLocation geoCode()
        {
            //to Read the Stream
            StreamReader sr = null;
            AdressLocation loc = new AdressLocation();
            //The Google Maps API Either return JSON or XML. We are using XML Here
            //Saving the url of the Google API 
            string url = String.Format("http://maps.googleapis.com/maps/api/geocode/xml?address=" +
            "Marathahalli,Bangalore" + "&sensor=false");

            //to Send the request to Web Client 
            WebClient wc = new WebClient();
            try
            {
                sr = new StreamReader(wc.OpenRead(url));
            }
            catch (Exception ex)
            {
                throw new Exception("The Error Occured" + ex.Message);
            }

            try
            {
                XmlTextReader xmlReader = new XmlTextReader(sr);
                bool latread = false;
                bool longread = false;
                

                while (xmlReader.Read())
                {
                    xmlReader.MoveToElement();
                    switch (xmlReader.Name)
                    {
                        case "lat":

                            if (!latread)
                            {
                                xmlReader.Read();

                                loc.Latitude = xmlReader.Value.ToString();
                                latread = true;

                            }
                            break;
                        case "lng":
                            if (!longread)
                            {
                                xmlReader.Read();
                                loc.Longitude = xmlReader.Value.ToString();
                                longread = true;
                            }

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An Error Occured" + ex.Message);
            }
            return loc;
        }

       

    }
    public class AdressLocation
    {

        //Properties
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Address { get; set; }

    }

}

