using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class VendorRepositoryTests
    {
        [TestMethod()]
        public void RetrieveValueTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var expected = 242;

            //Actual
            var actual = repository.RetrieveValue<int>("select ", 242);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveValueStringTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var expected = "Labas";

            //Actual
            var actual = repository.RetrieveValue<string>("select ", "Labas");

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveValueObjectTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var vendor = new Vendor();
            var expected = vendor;

            //Actual
            var actual = repository.RetrieveValue<Vendor>("select ", vendor);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var expected = new List<Vendor>(){
                new Vendor() { VendorId = 1, CompanyName = "ACB" },
                new Vendor() { VendorId = 2, CompanyName = "ZXC" }
            };

            //actual
            var actual = repository.Retrieve();

            //assert
            CollectionAssert.AreEqual(expected, actual.ToList());
        }

        [TestMethod()]
        public void RetrieveWithIteratorTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var expected = new List<Vendor>(){
                new Vendor() { VendorId = 1, CompanyName = "ACB" },
                new Vendor() { VendorId = 2, CompanyName = "ZXC" }
            };

            //actual
            var vendorIterartor = repository.RetrieveWithIterator();
            foreach (var item in vendorIterartor)
            {
                Console.WriteLine(item);
            }

            var actual = vendorIterartor.ToList();

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveAllTest()
        {
            var repository = new VendorRepository();
            var expected = new List<Vendor>()
            {
                new Vendor() { VendorId = 22, CompanyName = "Amalgamated Toys", Email= "a@abc.com" },
                new Vendor() { VendorId = 35, CompanyName = "Car Toys", Email= "abc@abc.com" },
                new Vendor() { VendorId = 28, CompanyName = "Toys Block Inc", Email= "block@abc.com" },                
                new Vendor() { VendorId = 42, CompanyName = "Toys for Fun", Email= "fun@abc.com" }
            };

            var vendors = repository.RetrieveAll();

            var vendorQuery = from vendor in vendors
                              where vendor.CompanyName.Contains("Toys")
                              orderby vendor.CompanyName
                              select vendor;

            //vendorQuery2 = vendors.Where(FilterCompanies).OrderBy(OrderCompsniesByName);

            var vendorQuery2 = vendors.Where(v => v.CompanyName
                               .Contains("Toys")).OrderBy(v=>v.CompanyName);

               //private bool FilterCompanies(Vendor vendor)=>
               //         vendor.CompanyName.Contains("Toys");
               // //cia tas pats kas Where lambda

               // private string OrderCompsniesByName(Vendor vendor) =>
               //         vendor.CompanyName;
               // cia tas pats kad orderby lambda
            

        


            CollectionAssert.AreEqual(expected, vendorQuery.ToList());
            CollectionAssert.AreEqual(expected, vendorQuery2.ToList());
        }
        /*
[TestMethod()]
public void RetrieveWithKeyTest()
{
//Arrange
var repository = new VendorRepository();
var expected = new Dictionary<string, Vendor>(){
{"acb", new Vendor() { VendorId = 1, CompanyName = "acb" } },
{"zxc", new Vendor() { VendorId = 2, CompanyName = "zxc" } }
};

//actual
var actual = repository.RetrieveWithKey();

//assert
CollectionAssert.AreEqual(actual, expected);
}
*/
    }
}