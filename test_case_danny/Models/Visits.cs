using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace test_case_danny.Models
{
    [Table("Visits")]
    public class Visits
    {
        [PrimaryKey, AutoIncrement]
        [Column("ID")]
        public int ID { get; set; }
        [Column("LogDate")]
        public string LogDate { get; set; }
        [Column("LogTime")]
        public string LogTime { get; set; }
        [Column("UserLogin")]
        public string UserLogin { get; set; }
        [Column("ServerUrl")]
        public string ServerUrl { get; set; }
        [Column("SiteUrl")]
        public string SiteUrl { get; set; }
        [Column("WebUrl")]
        public string WebUrl { get; set; }
        [Column("DocumentPath")]
        public string DocumentPath { get; set; }

    }
}
