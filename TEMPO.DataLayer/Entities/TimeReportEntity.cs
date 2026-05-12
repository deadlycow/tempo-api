  
  namespace TEMPO.DataLayer.Entities;
public class TimeReportEntity
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public DateTime Date { get; set; }
    public double HoursWorked { get; set; }
    public string? Description { get; set; }
}