﻿using MeetingManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingManagementApp.DataAccess.Repository.IRepository
{
    public interface IMeetingRepository : IRepository<Meeting>
    {
        void Update(Meeting obj);
        void Save();
    }
}
