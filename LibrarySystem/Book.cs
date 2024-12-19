using System;

namespace LibrarySystem
{
    public class Book
    {
        public string Title { get; set; } = string.Empty; // Default to avoid nullable warning
        public string Author { get; set; } = string.Empty; // Default to avoid nullable warning
        public string Status { get; set; } = "On Shelf"; // Default status
        public DateTime? DueDate { get; set; } // Nullable due date for books not checked out

        public override string ToString()
        {
            string dueDateText = DueDate.HasValue ? DueDate.Value.ToString("MM/dd/yyyy") : "N/A";
            return $"Title: {Title}, Author: {Author}, Status: {Status}, Due Date: {dueDateText}";
        }

        public bool CheckOut()
        {
            if (Status == "Checked Out") return false;
            Status = "Checked Out";
            DueDate = DateTime.Now.AddDays(14); // Set due date to 2 weeks from today
            return true;
        }

        public void ReturnBook()
        {
            Status = "On Shelf";
            DueDate = null;
        }
    }
}