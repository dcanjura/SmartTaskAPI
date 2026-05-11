namespace SmartTaskAPI.Helpers
{
    public static class PriorityHelper
    {
        public static string CalculatePriority(DateTime dueDate)
        {
            var daysLeft = (dueDate.Date - DateTime.UtcNow.Date).Days;

            if (daysLeft <= 1)
                return "High";

            if (daysLeft <= 3)
                return "Medium";

            return "Low";
        }
    }
}