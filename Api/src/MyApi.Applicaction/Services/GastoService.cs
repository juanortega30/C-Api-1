using System;
using System.Collections.Generic;
using Api.src.MyApi.Domain.Entities; // Esto arregla el error de "Gasto"
using Api.src.MyApi.Applicaction.DTO; // Esto arregla el error de "GastoDTO"

namespace Api.src.MyApi.Applicaction.Services;

public class GastoService
{
    private List<Gasto> _gastos; 

    public GastoService()
    {
        _gastos = new List<Gasto>();
    }

    public Gasto CrearGasto(GastoDTO gastoDto)
    {
        var gastoNuevo = new Gasto
        {
            Id = Guid.NewGuid(),
            Descripcion = gastoDto.Descripcion,
            gasto = gastoDto.gasto 
        };

        _gastos.Add(gastoNuevo);
        
        return gastoNuevo;
    }
}