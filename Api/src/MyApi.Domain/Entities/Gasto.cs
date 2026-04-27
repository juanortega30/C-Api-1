using System;

namespace Api.src.MyApi.Domain.Entities;

public class Gasto
{
    public Guid Id { get; set; }
    public required string Descripcion { get; set; }
    public decimal gasto { get; set; }

    
}
