using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Diceroller.Models
{
    public class DiceValues
    {
        public List<int> Result;
        public int Y;
        public DateTime Shas;
        public string Avg;
        public int Q;
        public int E;
    }
}
    public class toSQL
{
    [Key]
        public int Id { get; set; }
        public int RollResult { get; set; }
        public int EdgeCount { get; set; }
        public DateTime RollTime{ get; set; }
        public int DiceInRoll { get; set; }
}