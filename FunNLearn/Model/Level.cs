using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunNLearn.Model
{
    public class Level
    {
        public int LevelNumber {  get; set; }
        public string LevelDescription { get; set; }
        public string LevelDifficulty { get; set; }
        public Func<Task<bool>> LevelTask { get; set; }
        public string SuccessMessage { get; set; }
        public bool isLocked {  get; set; }
    }
}
