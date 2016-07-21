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
                    result = ctx.Scores.Take(10).OrderBy(s => s.Score1).ToList();
                }
            }
            catch(Exception ex)
            {
                int breakpoint = 1;
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
