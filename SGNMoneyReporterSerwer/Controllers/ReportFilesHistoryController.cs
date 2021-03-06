﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGNMoneyReporterSerwer.Data;
using SGNMoneyReporterSerwer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGNMoneyReporterSerwer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportFilesHistoryController : ControllerBase
    {
        private readonly IBankRepository _repository;
        private readonly IMapper _mapper;

        public ReportFilesHistoryController(IBankRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<FileHistoryModel>>> GetAll()
        {
            try
            {
                var result = await _repository.GetAllFilesHistoryAsync();
                return _mapper.Map<List<FileHistoryModel>>(result);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Błąd połączenia z bazą danych");
            }
        }
    }
}