public class DeveloperTeamRepository
{
    private DeveloperRepository _devRepo; //lets you call elements from Developer Repositiry

    private readonly List<DeveloperTeam> _devTeamDb = new List<DeveloperTeam>();
    private int _count;

    //Crud operations 

    //Create -> add to the database 
        public DeveloperTeamRepository(DeveloperRepository devRepo)
        {
            _devRepo = devRepo;
            SeedData();
        }

        public bool AddTeamToDb(DeveloperTeam team)
        {
            if (team is null)
            {
                return false;
            }
            else
            {
                _count++;
                team.Id = _count;
                _devTeamDb.Add(team);
                return true;
            }
        }

     // Reads - reads list 
        public List<DeveloperTeam> GetDeveloperTeams()
        {
            return _devTeamDb;
        }

        public DeveloperTeam GetDeveloperTeam(int devTeamId)
        {
            foreach (DeveloperTeam team in _devTeamDb)
            {
                if (team.Id == devTeamId)
                {
                    return team;
                }
            }
            return null;
        }

    // Update 
        public bool UpdateDevTeam(int devTeamId, DeveloperTeam updatedTeamData)
        {
            var teamInDB = GetDeveloperTeam(devTeamId);

            if (teamInDB != null)
            {
                teamInDB.TeamName = updatedTeamData.TeamName;
                teamInDB.Developers = updatedTeamData.Developers;
                return true;
            }
            return false;
        }

    //Delete 
        public bool DeleteDeveloperTeam(int devTeamId)
        {
            var teamInDB = GetDeveloperTeam(devTeamId);
            return _devTeamDb.Remove(teamInDB);
        }

        //Challenge:
        //we need the teamId and we need List<Developers> to add
            public bool AddMultiDevsToTeam(int devTeamId, List<Developer> devs)
            {
                var teamInDB = GetDeveloperTeam(devTeamId);
                if (teamInDB != null && devs != null)
                {
                    teamInDB.Developers.AddRange(devs);
                    return true;
                }
                else
                {
                    return false;
                }
            }

    // Data - teams 
        private void SeedData()
        {

            var akuma = _devRepo.GetDeveloper(1); //Akuma
            var ryu = _devRepo.GetDeveloper(2); //Ryu

            var teamA = new DeveloperTeam("Front-End", new List<Developer>
            {
            akuma,
            ryu
            });

            var bison = _devRepo.GetDeveloper(3); //M. Bison
            var chun = _devRepo.GetDeveloper(4); // Chun Li

            var teamB = new DeveloperTeam("Back-End", new List<Developer>
            {
                bison,
                chun
            });

            AddTeamToDb(teamA);
            AddTeamToDb(teamB);
        }
}



// public class TeamRepository
//     {
//         private readonly List<Team> _teamDb = new List<Team>(); 
    
//         //zero to start 

//         private int _teamcount; 

//         //Crud operations 

//         //Create -> add to the database 
//         public bool AddTeamToDatabase(Team team) 
//         {
//             if (team is null)
//             {
//                 return false;
//             }
//             else  
//             {
//                 _teamcount++;
//                 team.team_Id = _teamcount;
//                 _teamDb.Add(team);
//                 return true; 
//             }
//         }
    
    
//         public List<Team> GetTeams()
//         {
//             return _teamDb;
//         }

//         public Team GetTeam(int teamId)
//         {
//             foreach (Team team in _teamDb) 
//             {
//                 if (team.team_Id == teamId)
//                  {
//                     return team;
//                 }
//             }
//             return null;
//         }


// // Update 

//     public bool UpdateTeam(int teamId, Team updatedTeamData) 
//     {
//         Team teamInDb = GetTeam(teamId); 

//         //if there is actually author data...
//         if (teamInDb != null) 
//         {
//             teamInDb.GroupName = updatedTeamData.GroupName;
//             teamInDb.Group_length = updatedTeamData.Group_length;
//             return true; 
//         }
//         return false; 
//     }

//     //Delete 
//     public bool DeleteTeam (int teamId)
//     {
//         Team team = GetTeam(teamId);
//         if (team != null) 
//         {
//             _teamDb.Remove(team);
//             return true; 
//         }
//         return false; 
//     }
//     }

