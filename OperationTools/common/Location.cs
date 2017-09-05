using DB_Entity_DAL.DB_Operations;
using DB_Entity_DAL.MedelsDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationTools.common
{
    public class ModelCountry
    {
        public int idCountry { get; set; }
        public string NameCountry { get; set; }
    }

    public class ModelRegions
    {
        public int idRegion {get;set;}
        public string NameRegion {get;set;}
    }

    public class ModelCity
    {
        public int idCity { get; set; }
        public string NameCity { get; set; }

    }

    public class Location
    {
        DB_Country dbCountry = new DB_Country();
        DB_Regions dbRegion = new DB_Regions();
        DB_City dbCity = new DB_City();
        public List<ModelCountry> GetAllCountries()
        {
            List<ModelCountry> modelC = null;
            List<Country> counties = dbCountry.GetallCountries();
            if(counties.Count != 0)
            {
                modelC = new List<ModelCountry>();
                for(int i=0;i<counties.Count;i++)
                {
                    modelC.Add(new ModelCountry {idCountry = counties[i].id , NameCountry = counties [i].name_country});
                }
            }


            return modelC;
        }

        public List<ModelRegions> GetAllRegions(int id)
        {
            List<Region> regions = dbRegion.GetRegionByIdCountry(id);
            List<ModelRegions> modelR = null;

            if(regions.Count != 0)
            {
                modelR = new List<ModelRegions>();

                for(int i=0;i<regions.Count;i++)
                {
                    modelR.Add(new ModelRegions{idRegion = regions[i].id , NameRegion = regions[i].name_region});
                }
            }

            return modelR;
       }

        public List<ModelCity> GetAllCity(int id)
        {
            List<ModelCity> modelC = null;
            List<City> city = dbCity.GetCityByIdRegion(id);

            if (city.Count != 0)
            {
                modelC = new List<ModelCity>();

                for (int i = 0; i < city.Count; i++)
                {
                    modelC.Add(new ModelCity { idCity = city[i].id, NameCity = city[i].name_sity });
                }
            }

            return modelC;
        }
    }
}
