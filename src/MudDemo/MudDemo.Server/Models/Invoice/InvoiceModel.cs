using System;

namespace MudDemo.Server.Models.Invoice;

public class InvoiceModel
{
    public Guid InvoiceId { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public InvoiceStatus Status { get; set; }
}