﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Diagnostics;

namespace JBabineau.SnakeTron.Controllers
{
    public class ScoreController : ApiController
    {
        // Get: api/Score/GetName/{name}
        /// <summary>
        /// Gets the specified users top scores
        /// </summary>
        /// <param name="name"> UserName</param>
        /// <param name="amount">Amount of records to return.</param>
        /// <returns></returns>
        [HttpGet]
        public List<Score> GetName(string name, int amount)
        {
            List<Score> result = new List<Score>();
            try
            {
                using (SnaketronEntities ctx = new SnaketronEntities())
                {
                    result = ctx.Scores.Where(s => s.UserName.ToUpper() == name.ToUpper()).OrderByDescending(s => s.Score1).Take(amount).ToList();
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError($"Database Related error: {ex.Message}. Inner Exception: {ex.InnerException}.");
                // TODO: clean this up.
                /*TESTING ONLY
                int breakpoint = 1;
                Score one = new Score { Id = 1, Score1 = 100, Blocks = 10, Kills = 1, Missed = 100, UserName = "Ralph", DateSubmitted = DateTime.Now };
                Score two = new Score { Id = 2, Score1 = 10, Blocks = 1, Kills = 5, Missed = 60, UserName = "Raph sucks", DateSubmitted = DateTime.Now.AddHours(-10) };
                Score three = new Score { Id = 3, Score1 = 10, Blocks = 1, Kills = 5, Missed = 60, UserName = "Ralph", DateSubmitted = DateTime.Now.AddHours(-10) };
                Score four = new Score { Id = 4, Score1 = 5, Blocks = 10, Kills = 1, Missed = 100, UserName = "Ralph 123", DateSubmitted = DateTime.Now };
                Score five = new Score { Id = 5, Score1 = 1, Blocks = 1, Kills = 5, Missed = 60, UserName = "Ralph", DateSubmitted = DateTime.Now.AddHours(-10) };
                Score six = new Score { Id = 6, Score1 = 0, Blocks = 1, Kills = 5, Missed = 60, UserName = "Ralph", DateSubmitted = DateTime.Now.AddHours(-10) };
                result.Add(one);
                result.Add(two);
                result.Add(three);
                result.Add(four);
                result.Add(five);
                result.Add(six);


                result = result.Where(s => s.UserName == name).Take(10).OrderByDescending(s => s.Score1).ToList();
                */
            }

            return result;
        }

        // Get: api/Score/GetScores
        /// <summary>
        /// Gets the top scores.
        /// </summary>
        /// <param name="amount">Amount of records to retrun.</param>
        /// <returns></returns>
        [HttpGet]
        public List<Score> GetScores(int amount)
        {
            List<Score> result = new List<Score>();
            try
            {
                using (SnaketronEntities ctx = new SnaketronEntities())
                {
                    result = ctx.Scores.OrderByDescending(s => s.Score1).Take(amount).ToList();
                }
            }
            catch(Exception ex)
            {
                Trace.TraceError($"Database Related error: {ex.Message}. Inner Exception: {ex.InnerException}.");
                // TODO clean this up
                /* TESTING ONLY
                int breakpoint = 1;
                Score one = new Score { Id = 1, Score1 = 100, Blocks = 10, Kills = 1, Missed = 100, UserName = "Ralph", DateSubmitted = DateTime.Now };
                Score two = new Score { Id = 2, Score1 = 10, Blocks = 1, Kills = 5, Missed = 60, UserName = "Raph sucks", DateSubmitted = DateTime.Now.AddHours(-10) };
                result.Add(one);
                result.Add(two);

                result = result.Take(amount).OrderByDescending(s => s.Score1).ToList();*/
            }

            return result;
        }

        // Get: api/Score/GetBlocks
        /// <summary>
        /// Gets the top blocks.
        /// </summary>
        /// <param name="amount">Amount of records to return.</param>
        /// <returns></returns>
        [HttpGet]
        public List<Score> GetBlocks(int amount)
        {
            List<Score> result = new List<Score>();
            try
            {
                using (SnaketronEntities ctx = new SnaketronEntities())
                {
                    result = ctx.Scores.OrderByDescending(s => s.Blocks).Take(amount).ToList();
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError($"Database Related error: {ex.Message}. Inner Exception: {ex.InnerException}.");
                // TODO: Clean this up
                /*TESTING ONLY
                int breakpoint = 1;
                Score one = new Score { Id = 1, Score1 = 100, Blocks = 10, Kills = 1, Missed = 100, UserName = "Ralph", DateSubmitted = DateTime.Now };
                Score two = new Score { Id = 2, Score1 = 10, Blocks = 1, Kills = 5, Missed = 60, UserName = "Raph sucks", DateSubmitted = DateTime.Now.AddHours(-10) };
                result.Add(one);
                result.Add(two);
                result = result.Take(10).OrderByDescending(s => s.Blocks).ToList();*/
            }

            return result;
        }

        // Get: api/Score/Get/Kills
        /// <summary>
        /// Gets the top Kills.
        /// </summary>
        /// <param name="amount">Amount of records to return.</param>
        /// <returns></returns>
        [HttpGet]
        public List<Score> GetKills(int amount)
        {
            List<Score> result = new List<Score>();
            try
            {
                using (SnaketronEntities ctx = new SnaketronEntities())
                {
                    result = ctx.Scores.OrderByDescending(s => s.Kills).Take(amount).ToList();
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError($"Database Related error: {ex.Message}. Inner Exception: {ex.InnerException}.");
                // TODO: Clean this up.
                /*TESTING ONLY
                int breakpoint = 1;
                Score one = new Score { Id = 1, Score1 = 100, Blocks = 10, Kills = 1, Missed = 100, UserName = "Ralph", DateSubmitted = DateTime.Now };
                Score two = new Score { Id = 2, Score1 = 10, Blocks = 1, Kills = 5, Missed = 60, UserName = "Raph sucks", DateSubmitted = DateTime.Now.AddHours(-10) };
                result.Add(one);
                result.Add(two);
                result = result.Take(10).OrderByDescending(s => s.Kills).ToList();*/
            }

            return result;
        }

        // Get: api/Score/Get/Misses
        /// <summary>
        /// Gets the Top Misses (AKA: Suck Score)
        /// </summary>
        /// <param name="amount">Amount of records to return.</param>
        /// <returns></returns>
        [HttpGet]
        public List<Score> GetMisses(int amount)
        {
            List<Score> result = new List<Score>();
            try
            {
                using (SnaketronEntities ctx = new SnaketronEntities())
                {
                    result = ctx.Scores.OrderByDescending(s => s.Missed).Take(amount).ToList();
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError($"Database Related error: {ex.Message}. Inner Exception: {ex.InnerException}.");
                // TODO: CLean this up.
                /*TESTING ONLY
                int breakpoint = 1;
                Score one = new Score { Id = 1, Score1 = 100, Blocks = 10, Kills = 1, Missed = 100, UserName = "Ralph", DateSubmitted = DateTime.Now };
                Score two = new Score { Id = 2, Score1 = 10, Blocks = 1, Kills = 5, Missed = 60, UserName = "Raph sucks", DateSubmitted = DateTime.Now.AddHours(-10) };
                result.Add(one);
                result.Add(two);
                result = result.Take(10).OrderByDescending(s => s.Missed).ToList();
                */
            }

            return result;
        }

        // Post: api/Score/AddScore
        /// <summary>
        /// Submits a new High Score to the database.
        /// </summary>
        /// <param name="score">Score object</param>
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
                System.Diagnostics.Trace.TraceError($"Database Related error: {ex.Message}. Inner Exception: {ex.InnerException}.");
            }
        }
    }
}
