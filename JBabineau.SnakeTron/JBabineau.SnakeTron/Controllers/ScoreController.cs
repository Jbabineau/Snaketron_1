using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JBabineau.SnakeTron.Controllers
{
    public class ScoreController : ApiController
    {
        // Get: 
        public List<Score> GetScores()
        {
            List<Score> result = new List<Score>();
            try
            {
                using (SnaketronEntities ctx = new SnaketronEntities())
                {
                    result = ctx.Scores.Take(10).OrderByDescending(s => s.Score1).ToList();
                }
            }
            catch(Exception ex)
            {
                /* TESTING ONLY
                int breakpoint = 1;
                Score one = new Score { Id = 1, Score1 = 100, Blocks = 10, Kills = 1, Missed = 100, UserName = "Ralph", DateSubmitted = DateTime.Now };
                Score two = new Score { Id = 2, Score1 = 10, Blocks = 1, Kills = 5, Missed = 60, UserName = "Raph sucks", DateSubmitted = DateTime.Now.AddHours(-10) };
                result.Add(one);
                result.Add(two);
                */
            }

            return result;
        }

        [HttpPost]
        public void AddScore(Score score)
        {
            score.DateSubmitted = DateTime.Now;
            score.Id = 0;

            Score tempScore = new Score
            {
                UserName = score.UserName,
                Score1 = score.Score1,
                Kills = score.Kills,
                Blocks = score.Blocks,
                Missed = score.Missed,
                DateSubmitted = score.DateSubmitted
            };
            try {

                using (SnaketronEntities ctx = new SnaketronEntities())
                {
                    ctx.Scores.Add(tempScore);
                    ctx.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                int breakpoint = 1;
            }
        }
    }
}
