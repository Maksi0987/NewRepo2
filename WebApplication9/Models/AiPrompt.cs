using System.ComponentModel.DataAnnotations.Schema; 

namespace WebApplication9.Models
{
    public class AiPrompt
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? PromptText { get; set; }
        public string? NeuralNetwork { get; set; }

        [Column(TypeName = "decimal(18,2)")] 
        public decimal Price { get; set; }
    }
}