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
            gasto = expense.gasto
        };
        _expense.Add(newExpense);

        return CreatedAtAction(nameof(RegisterExpense), new { id = newExpense.Id }, newExpense);
    }


    [HttpGet]
    public IActionResult GetExpenses()
    {
        return Ok(_expense);
    }



// 3. GET con filtro (Busca por descripción)
    [HttpGet("search/{description}")]
    public IActionResult GetExpenseByDescription(string description)
    {
        
        var filteredExpenses = _expense
            .Where(e => e.Description.Contains(description, StringComparison.OrdinalIgnoreCase))
            .ToList();

        return Ok(filteredExpenses);
    }

    // 4. PUT: Actualizar un gasto existente por su ID
    [HttpPut("{id}")]
    public IActionResult UpdateExpense(Guid id, [FromBody] ExpenseDTO updatedExpense)
    {
        var existingExpense = _expense.FirstOrDefault(e => e.Id == id);
        
        if (existingExpense == null)
        {
            return NotFound("Gasto no encontrado.");
        }

        // Actualizamos los datos
        existingExpense.Description = updatedExpense.Description;
        existingExpense.gasto = updatedExpense.gasto;

        return Ok(existingExpense);
    }

    // 5. DELETE: Eliminar un gasto por su ID
    [HttpDelete("{id}")]
    public IActionResult DeleteExpense(Guid id)
    {
        var existingExpense = _expense.FirstOrDefault(e => e.Id == id);
        
        if (existingExpense == null)
        {
            return NotFound("Gasto no encontrado.");
        }

        _expense.Remove(existingExpense);
        
        return Ok(new { message = "Gasto eliminado correctamente." });
    }
}
