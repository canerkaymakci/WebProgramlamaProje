﻿using System;
using WebProgramlamaProje.Models.Domain;

namespace WebProgramlamaProje.Repository.Abstract
{
	public interface ITicketService: IBaseRepository<Ticket>
	{

        Task<bool> CreateRangeAsync(IEnumerable<Ticket> tickets);

    }
}

