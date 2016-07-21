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

            using (SnaketronEntities ctx = new SnaketronEntities())
            {
                result = ctx.Scores.Take(10).OrderBy(s => s.Score1).ToList();
            }

            return result;
        }

        [HttpPost]
        public void AddScore(Score score)
        {
            score.DateSubmitted = DateTime.Now;

            using (SnaketronEntities ctx = new SnaketronEntities())
            {
                ctx.Scores.Add(score);
                ctx.SaveChanges();
            }
        }
    }
}
