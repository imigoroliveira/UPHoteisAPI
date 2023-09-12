namespace UPHoteisAPI.Models;

public class Reservation
{
  public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string Status { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerAddress { get; set; }
    public string? CustomerContact { get; set; }
    public string? ReservedItemDescription { get; set; } = null;

     public Reservation()
    {
        Id = 0;
        StartDate = DateTime.Now;
        EndDate = DateTime.Now.AddDays(1);
        Quantity = 1;
        Price = 0.0M;
        Status = "Pending";
        CustomerName = null;
        CustomerAddress = null;
        CustomerContact = null;
        ReservedItemDescription = null;
    }
    public Reservation(int id, DateTime startDate, DateTime endDate, int quantity, decimal price, string status, string customerName, string customerAddress, string customerContact, string reservedItemDescription)
    {
        Id = id;
        StartDate = startDate;
        EndDate = endDate;
        Quantity = quantity;
        Price = price;
        Status = status;
        CustomerName = customerName;
        CustomerAddress = customerAddress;
        CustomerContact = customerContact;
        ReservedItemDescription = reservedItemDescription;
    }
}