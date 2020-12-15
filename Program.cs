using System;

namespace assignment_five
{
    class Program
    {
        static void Main(string[] args)
        {
          
          string dogOwner;
          double dogWeight;
          string dogName;
          int days;
          string serviceCode;

          Estimate oneEstimate = new Estimate();

          Estimate [] listOfEstimates = new Estimate[3];

          for(var i = 0; i < listOfEstimates.Length; i++ ){

              Console.WriteLine("Enter the dog owner's name");
              dogOwner = Console.ReadLine();

              Console.WriteLine("Enter the dog's name");
              dogName = Console.ReadLine();

              Console.WriteLine("Enter the dog's weight:");
              dogWeight = Convert.ToDouble(Console.ReadLine());

              Console.WriteLine("Enter the number of days:");
              days = Convert.ToInt32(Console.ReadLine());

              Console.WriteLine("\nA = Bathing & Grooming");
              Console.WriteLine("c = Bathing");
              Console.WriteLine("\nSelect an option from the list of services above");
              serviceCode = Console.ReadLine();

              listOfEstimates[i] = new Estimate(days, serviceCode, dogOwner, dogName, dogWeight);

              Console.WriteLine(listOfEstimates[i]);
            }
        }
 
    }

     class Estimate
    {
        public string dogOwner { get; set; }
        public string dogName { get; set; }
        public double dogWeight { get; set; }
        public int days { get; set; }
        public int cost = 0;

        public const int overNightStay = 75;
        public const int codeA = 169;
        public const int codeC = 112;
        public string addOnCode { get; set; }
        

        //default constructor
        public Estimate(){

        }

        //constructor
        public Estimate(int numOfdays, string serviceCode, string owner, string name, double weight)
        {
            days = numOfdays;
            addOnCode = serviceCode;
            dogOwner = owner;
            dogName = name;
            dogWeight = weight;
            generateCost();
        }


        //working method
        public  void generateCost(){
            string code = this.addOnCode.ToUpper();
            while(code != "A" && code != "C"){
                Console.WriteLine("You have entered an invalid code");
                Console.WriteLine("\nA = Bathing & Grooming");
                Console.WriteLine("C = Bathing");

                Console.WriteLine("\nSelect an option from the list of services above");
                this.addOnCode = Console.ReadLine();
                code = this.addOnCode.ToUpper();
                
            }

            Console.WriteLine("Do you want overnight stay for your dog? Y/N");
            string opt = Console.ReadLine();
            if(opt.ToUpper() == "Y"){ 

                this.cost += overNightStay * days;
                
                if (code == "A"){
                this.cost += this.days * codeA;
                
                }else if(code == "C"){
                    this.cost += this.days * codeC;
                }
            }else if (opt.ToUpper() == "N"){
                
                if (code == "A"){
                    this.cost += this.days * codeA;
                
                }else if(code == "C"){
                    this.cost += this.days * codeC;
                }
            }


        }

        
        public override string ToString(){
            return String.Format("This is an Estimate for {0} \nDog Weight = {1}lbs \nDog Name = {2} \nThe Total cost is ${3}",this.dogOwner, this.dogWeight, this.dogName, this.cost);
        }
    }
}
