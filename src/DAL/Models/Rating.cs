﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Rating : AuditableEntity
    {
        public Rating()
        {
            EventEvaluations = new JoinCollectionFacade<EventEvaluation, Rating, EventEvaluationRating>(this, EventEvaluationRatings);
            DayEvaluations = new JoinCollectionFacade<DayEvaluation, Rating, DayEvaluationRating>(this, DayEvaluationRatings);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Evaluation { get; set; }
        public float Score { get; set; }

        private ICollection<EventEvaluationRating> EventEvaluationRatings { get; } = new List<EventEvaluationRating>();
        private ICollection<DayEvaluationRating> DayEvaluationRatings { get; } = new List<DayEvaluationRating>();

        [NotMapped]
        public ICollection<EventEvaluation> EventEvaluations { get; set; }
        [NotMapped]
        public ICollection<DayEvaluation> DayEvaluations { get; set; }

    }
}
