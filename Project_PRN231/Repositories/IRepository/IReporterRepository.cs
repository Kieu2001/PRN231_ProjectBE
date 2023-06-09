﻿using Project_PRN231.Models;

namespace Project_PRN231.Repositories.IRepository
{
    public interface IReporterRepository
    {
        IEnumerable<ReportTask> GetAllTask();
        List<ReportTask> GetReportTaskByUserId(int Id);
        ReportTask GetTaskById(int Id);
        void InsertReportTask(ReportTask reportTask);   
        void UpdateReportTask(ReportTask reportTask);
        void DeleteReportTask(ReportTask reportTask);
    }
}
