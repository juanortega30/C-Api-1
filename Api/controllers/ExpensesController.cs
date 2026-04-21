using System;
using Api.Models;
using Api.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.controllers;

[Route("api/[controller]")]
public class ExpencesController : ControllerBase
{
    private static readonly List<Expense> _expense = [];

    [HttpPost]
    
    public IActionResult RegisterExpense([FromBody] ExpenseDTO expense)
    {
        Expense newExpense = new Expense
        {
            Id = Guid.NewGuid(),
            Description = expense.Description,
            Amount = expense.Amount,
            Date = expense.Date,
            Category = expense.Category,
            PaymentMethod = expense.PaymentMethod
        };
        _expense.Add(newExpense);

        return CreatedAtAction(nameof(RegisterExpense), new { id = newExpense.Id }, newExpense);
    }


    [HttpGet]
    public IActionResult GetExpenses()
    {
        return Ok(_expense);
    }
};
