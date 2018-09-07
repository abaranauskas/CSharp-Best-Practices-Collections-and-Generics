using Acme.Common;
using static Acme.Common.LoggingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages products carried in inventory.
    /// </summary>
    public class Product
    {
        #region Constructors
        public Product()
        {
            //-----------------arrays[]-------------
            #region Array
            //var colorOptions1 = new string[4];
            //colorOptions1[0] = "Red";
            //colorOptions1[1] = "Expesso";
            //colorOptions1[2] = "White";
            //colorOptions1[3] = "Navy";
            //bloga praktika deklaruoti

            string[] colorOptions2 = { "Red", "Expresso", "White", "Navy" };
            //toks budas deklaruoti array vadnamas 
            //colection initializer (gera praktika naudoti)

            var brownIndex = Array.IndexOf(colorOptions2, "Expresso");
            //static method

            colorOptions2.SetValue("YelloW", 2);
            //instatnce method


            for (int i = 0; i < colorOptions2.Length; i++)
            {
                colorOptions2[i] = colorOptions2[i].ToUpper();
                //naudojant for galima modifikuoti elementa nebutina eiti 
                //per visus elementus. daugiau lankstumo
            }

            foreach (var color in colorOptions2)
            {
                //color = color.ToUpper();
                //foreahce jau negalima modifikuo sis loop read only
                //naudojant for each eos per visus elementus negalima 
                //tarkim kas antra ir pan

                Console.WriteLine($"The using foreach loop color is {color}.");

            }
            #endregion

            //-----------------List<T>-------------
            #region List

            //var colorOptions3 = new List<string>();

            //colorOptions3.Add("Red");
            //colorOptions3.Add("Expresso");
            //colorOptions3.Add("White");
            //colorOptions3.Add("Navy");

            var colorOptions3 = new List<string>()
                        { "Red", "Expresso", "White", "Navy" };
            //collection initializer


            colorOptions3.Insert(2, "Purple");
            //pirmas param indexas iterp i indexa 2 o kitus pastums zemyn

            colorOptions3.Remove("White");
            //kuo reciau naudoti Insert ir remoove jie leti
            //jei reikia daznai naudot reikia apsvarstyt kita/
            //naudoti kita kolekcijos tipa
            #endregion


            //-----------------Dictionary<TKey, TValue>-------------
            var states = new Dictionary<string, string>();

            states.Add("CA", "California");
            states.Add("WA", "Washington");
            states.Add("NY", "New York");
            //states.Add("CA", "California"); 
            //jei tas pats key bus run time error
            //states.Add(50, "California"); //strongly typed. compiler error


            //colection initializer of dictionary
            var states2 = new Dictionary<string, string>(){
                {"CA", "California" },
                {"WA", "Washington" },
                {"NY", "New York" }
            };

            Console.WriteLine(states2);

        }


        public Product(int productId,
                        string productName,
                        string description) : this()
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;
        }
        #endregion

        #region Properties
        public DateTime? AvailabilityDate { get; set; }

        public decimal Cost { get; set; }

        public string Description { get; set; }

        public int ProductId { get; set; }

        private string productName;
        public string ProductName
        {
            get {
                var formattedValue = productName?.Trim();
                return formattedValue;
            }
            set
            {
                if (value.Length < 3)
                {
                    ValidationMessage = "Product Name must be at least 3 characters";
                }
                else if (value.Length > 20)
                {
                    ValidationMessage = "Product Name cannot be more than 20 characters";

                }
                else
                {
                    productName = value;

                }
            }
        }

        private Vendor productVendor;
        public Vendor ProductVendor
        {
            get {
                if (productVendor == null)
                {
                    productVendor = new Vendor();
                }
                return productVendor;
            }
            set { productVendor = value; }
        }

        public string ValidationMessage { get; private set; }

        #endregion

        /// <summary>
        /// Calculates the suggested retail price
        /// </summary>
        /// <param name="markupPercent">Percent used to mark up the cost.</param>
        /// <returns></returns>
        //public decimal CalculateSuggestedPrice(decimal markupPercent) =>
        //this.Cost + (this.Cost * markupPercent / 100);

        public OperationResult<decimal> CalculateSuggestedPrice(decimal markupPercent)
        {
            var message = "";
            if (markupPercent<= 0m)
            {
                message = "Invalid Markup percentage!";
            } else if (markupPercent < 10)
            {
                message = "Bellow recomended Markup percentage!";
            }
            var value = this.Cost + (this.Cost * markupPercent / 100);

            var operationResult = new OperationResult<decimal>(value, message);
            return operationResult;
        }

        public override string ToString()
        {
            return this.ProductName + " (" + this.ProductId + ")";
        }
    }
}
