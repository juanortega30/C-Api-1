using System;

namespace Api.Models;

public class Expense
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal gasto { get; set; }    
}

