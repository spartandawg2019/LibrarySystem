using System;

namespace LibrarySystem
{
    public class Book
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty; 
        public string Status { get; set; } = "On Shelf";
        public DateTime? DueDate { get; set; }
        public override string ToString()
        {
            string dueDateText = DueDate.HasValue ? DueDate.Value.ToString("MM/dd/yyyy") : "N/A";
            return $"Title: {Title}, Author: {Author}, Status: {Status}, Due Date: {dueDateText}";
        }

        public bool CheckOut()
        {
            if (Status == "Checked Out") return false;
            Status = "Checked Out";
            DueDate = DateTime.Now.AddDays(14); 
            return true;
        }

        public void ReturnBook()
        {
            Status = "On Shelf";
            DueDate = null;
        }
    }
}