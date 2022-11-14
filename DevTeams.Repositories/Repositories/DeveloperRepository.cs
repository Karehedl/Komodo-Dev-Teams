public class DeveloperRepository
{
        //Fake database

    //C.R.U.D -> Create, Read , Update , and Delete  (methods)

    private readonly List<Developer> _devDb = new List<Developer>();
    private int _count;

    //Crud operations 

    //Create -> add to the database 
        public DeveloperRepository()
        {
            SeedData();
        }

        public bool AddDevToDb(Developer dev)
        {
            return (dev is null) ? false : AddToDatabase(dev);
        }

    //helper method -> Create
        private bool AddToDatabase(Developer dev)
        {
            AssignId(dev);
            _devDb.Add(dev);
            return true;
        }

    //helper method -> Create
        private void AssignId(Developer dev)
        {
            _count++;
            dev.Id = _count;
        }

    // Reads - reads list 
        public List<Developer> GetDevelopers()
        {
            return _devDb;
        }

        public Developer GetDeveloper(int id)
        {
            //LINQ
            return _devDb.SingleOrDefault(dev => dev.Id == id);

            //todo: this is the longer way...but still works, your choice..
            // foreach (Developer dev in _devDb)
            // {
            //     if(dev.Id ==id)
            //     return dev;
            // }
            // return null;
        }

    // Update 
        public bool UpdateDeveloperData(int devId, Developer updatedData)
        {
            Developer devInDb = GetDeveloper(devId);

            if (devInDb != null)
            {
                devInDb.FirstName = updatedData.FirstName;
                devInDb.LastName = updatedData.LastName;
                devInDb.HasPluralsight = updatedData.HasPluralsight;
                return true;
            }
            return false;
        }

    //Delete 
        public bool DeleteDeveloperData(int devId)
        {
            Developer devInDb = GetDeveloper(devId);
            return _devDb.Remove(devInDb);
        }

        //challenge -> Devs without pluralsight
            public List<Developer> DevsWithOutPluralsightLINQ()
            {
                //LINQ
                return _devDb.Where(dev => dev.HasPluralsight == false).ToList();
            }

            public List<Developer> DevsWithOutPluralsight()
            {
                List<Developer> devsWithoutPs = new List<Developer>();
                foreach (Developer dev in _devDb)
                {
                    if (dev.HasPluralsight == false)
                    {
                        devsWithoutPs.Add(dev);
                    }
                }
                return devsWithoutPs;
            }

    //Data
            private void SeedData()
            {
                var devA = new Developer("Akuma", "n/a", false);
                var devB = new Developer("Ryu", "n/a", true);
                var devC = new Developer("M.", "Bison", true);
                var devD = new Developer("Chun", "Li", false);
                var devE = new Developer("Cammy", "n/a", false);
                var devF = new Developer("Blanka", "n/a", false);
                var devG = new Developer("Guile", "n/a", false);
                var devH = new Developer("Daslim", "n/a", false);
                var devI = new Developer("Vega", "n/a", true);

                //add to db
                AddDevToDb(devA);
                AddDevToDb(devB);
                AddDevToDb(devC);
                AddDevToDb(devD);
                AddDevToDb(devE);
                AddDevToDb(devF);
                AddDevToDb(devG);
                AddDevToDb(devH);
                AddDevToDb(devI);
            }
        }





// public class DeveloperRepository
// {
// //Fake database

//  //C.R.U.D -> Create, Read , Update , and Delete  (methods)
//     private readonly List<Developer> _devsDb = new List<Developer>();
//     private int _count;



// //Crud operations 

// //Create -> add to the database 
//     public bool AddDeveloperToDatabase(Developer developer) 
//     {
//         if (developer is null)
//         {
//             return false;
//         }
//         else  
//         {
//             _count++;
//             developer.Id = _count;
//             _devsDb.Add(developer);
//             return true; 
//         }
//     }


// // Reads - reads list 
//     public List<Developer> GetDevelopers()
//             {
//                 return _devsDb;
//             }

//             public Developer GetDeveloper(int developerId)
//             {
//                 foreach (Developer developer in _devsDb) 
//                 {
//                     if (developer.Id == developerId)
//                     {
//                         return developer;
//                 }
//                 }

//                 return null;
//             }

// // Update 

//     public bool UpdateDeveloper(int developerId, Developer updatedDeveloperData) 
//     {
//         Developer developerInDb = GetDeveloper(developerId); 

//         //if there is actually author data...
//         if (developerInDb != null) 
//         {
//             developerInDb.FirstName = updatedDeveloperData.FirstName;
//             developerInDb.LastName = updatedDeveloperData.LastName;
//             developerInDb.HasPluralsightAccount = updatedDeveloperData.HasPluralsightAccount;
//             return true; 
//         }
//         return false; 
//     }



//  //Delete 
//     public bool DeleteDeveloper(int developerId)
//     {
//         Developer developer = GetDeveloper(developerId);
//         if (developer != null) 
//         {
//             _devsDb.Remove(developer);
//             return true; 
//         }
//         return false; 
//     }



// }


