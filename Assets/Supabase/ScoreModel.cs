using System;
using Postgrest.Attributes;
using Postgrest.Models;

namespace Zou.Unity.ScoreModel
{
    [Table("scores")]
    public class ScoreModel : BaseModel
    {
        [PrimaryKey("id", false)] public int Id { get; set; }
        // created-at can be null because it is set by the database
        [Column("created_at", ignoreOnInsert:true)] public DateTime CreatedAt { get; set; }
        [Column("score")] public int Score { get; set; }
        [Column("user_name")] public string UserName { get; set; }
    }
}