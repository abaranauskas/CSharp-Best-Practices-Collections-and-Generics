using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    public class VendorRepository
    {
        private List<Vendor> vendors;

        //public ICollection<Vendor> Retrieve()  //kai sis return type 
        //bus galima keisti naudoti add. jei nori neleisti nautojam sekanti
        public IEnumerable<Vendor> Retrieve()
        {
            if (vendors==null)
            {
                vendors = new List<Vendor>();
                vendors.Add(new Vendor() { VendorId = 1, CompanyName = "acb" });
                vendors.Add(new Vendor() { VendorId = 2, CompanyName = "zxc" });
            }

            

            foreach (var vendor in vendors)
            {
                vendor.CompanyName = vendor.CompanyName.ToUpper();
                //galima modifikuoti vendor properties bet ne pati vendor
                //jo nauju vendo nepakeisi loopinant foreach
                Console.WriteLine(vendor);
            }

            for (int i = 0; i < vendors.Count; i++)
            {
                Console.WriteLine(vendors[i]);
            }
            

            return vendors;
        }

        public IEnumerable<Vendor> RetrieveWithIterator()
        {
            this.Retrieve();

            foreach (var vendor in vendors)
            {
                Console.WriteLine($"Vendor Id: {vendor.VendorId}");
                yield return vendor;
            }
        }

        public IEnumerable<Vendor> RetrieveAll()
        {
            var vendors = new List<Vendor>
            {
                new Vendor() { VendorId = 1, CompanyName = "ABC Corp", Email= "abc@abc.com" },
                new Vendor() { VendorId = 2, CompanyName = "XYZ Inc", Email= "xyz@xyz.com" },
                new Vendor() { VendorId = 12, CompanyName = "EFG Ltd", Email= "efg@efg.com" },
                new Vendor() { VendorId = 17, CompanyName = "HIJ AG", Email= "hij@hijc.com" },
                new Vendor() { VendorId = 22, CompanyName = "Amalgamated Toys", Email= "a@abc.com" },
                new Vendor() { VendorId = 28, CompanyName = "Toys Block Inc", Email= "block@abc.com" },
                new Vendor() { VendorId = 31, CompanyName = "Home Product Inc", Email= "car@abc.com" },
                new Vendor() { VendorId = 35, CompanyName = "Car Toys", Email= "abc@abc.com" },
                new Vendor() { VendorId = 42, CompanyName = "Toys for Fun", Email= "fun@abc.com" }
            };

            return vendors;           
        }

        /*
        Vendor[] vendorsArr;
        public Vendor[] RetrieveArray()
        {
            if (vendorsArr == null)
            {
                vendorsArr = new Vendor[]{
                    new Vendor() { VendorId = 1, CompanyName = "acb" },
                    new Vendor() { VendorId = 2, CompanyName = "zxc" }
                };
            }
            
            foreach (var vendor in vendorsArr)
            {
                vendor.CompanyName = vendor.CompanyName.ToUpper();
                //galima modifikuoti vendor properties bet ne pati vendor
                //jo nauju vendo nepakeisi loopinant foreach
                Console.WriteLine(vendor);
            }

            for (int i = 0; i < vendorsArr.Length; i++)
            {
                Console.WriteLine(vendorsArr[i]);
            }


            return vendorsArr;
        }



        private Dictionary<string, Vendor> vendorsDictionary;

        public Dictionary<string, Vendor> RetrieveWithKey()
        {
            if (vendorsDictionary == null)
            {
                vendorsDictionary = new Dictionary<string, Vendor>();
            }

            vendorsDictionary.Add("acb", new Vendor() { VendorId = 1, CompanyName = "acb" });
            vendorsDictionary.Add("zxc", new Vendor() { VendorId = 2, CompanyName = "zxc" });

            Console.WriteLine(vendorsDictionary["zxc"]);

            if (vendorsDictionary.ContainsKey("kjhasd")) //tikrina ar toks key yra
            {
                Console.WriteLine(vendorsDictionary["kjhasd"]);
            }

            Vendor vendor;
            if (vendorsDictionary.TryGetValue("acb", out vendor)) 
                //tikrina ar toks key yra, jei yra istraukia value
            {
                Console.WriteLine(vendor);
            }

            foreach (var compName in vendorsDictionary.Keys)
                //iteration per key
            {
                Console.WriteLine(compName);
                //ismes visus key
                Console.WriteLine(vendorsDictionary[compName]);
                //ismes visas value
            }

            foreach (var vendoor in vendorsDictionary.Values)
                //iteration per values
            {
                Console.WriteLine(vendoor);
                Console.WriteLine(vendoor.CompanyName);
                //galima vaudoti value objecto prperties
            }

            foreach (var vendor1 in vendorsDictionary)
            {
                Console.WriteLine($"Cia yra dictionary elementas: {vendor1}");
                Console.WriteLine($"Cia gaunamas elemento key: {vendor1.Key}");
                Console.WriteLine($"Cia gaunasmas elemento value: {vendor1.Value}");
            }


            return vendorsDictionary;
        }
        */




        /// <summary>
        /// Retrieve one vendor.
        /// </summary>
        /// <param name="vendorId">Id of the vendor to retrieve.</param>
        public Vendor Retrieve(int vendorId)
        {
            // Create the instance of the Vendor class
            Vendor vendor = new Vendor();

            // Code that retrieves the defined customer

            // Temporary hard coded values to return 
            if (vendorId == 1)
            {
                vendor.VendorId = 1;
                vendor.CompanyName = "ABC Corp";
                vendor.Email = "abc@abc.com";
            }
            return vendor;
        }

        public T RetrieveValue<T>(string sql, T defaultValue)
            //where T: struct //sis neleis T buti stringu del
            //to reiktu overloadint metoda
        {
            T value = defaultValue;
            return value;
        }

        /// <summary>
        /// Save data for one vendor.
        /// </summary>
        /// <param name="vendor">Instance of the vendor to save.</param>
        /// <returns></returns>
        public bool Save(Vendor vendor)
        {
            var success = true;

            // Code that saves the vendor

            return success;
        }
    }
}
