using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // Resident
            migrationBuilder.Sql("INSERT INTO Resident (FullName, TCNumber, Email, Phone, VehiclePlate) VALUES ('User1', '12345678901', 'user1@example.com', '1234567890', '34ABC123')");
            migrationBuilder.Sql("INSERT INTO Resident (FullName, TCNumber, Email, Phone, VehiclePlate) VALUES ('User2', '98765432109', 'user2@example.com', '9876543210', '06XYZ987')");

            // Manager
            migrationBuilder.Sql("INSERT INTO Manager (Username, Password) VALUES ('admin', 'admin123')");


            //Apartment 
            migrationBuilder.Sql("INSERT INTO Apartment (Block, Status, Type, Floor, ApartmentNumber, ResidentId) VALUES ('A', 'Dolu', '1+1', 3, '301', 1)");
            migrationBuilder.Sql("INSERT INTO Apartment (Block, Status, Type, Floor, ApartmentNumber, ResidentId) VALUES ('B', 'Dolu', '2+1', 2, '202', 2)");

            // Bill
            migrationBuilder.Sql("INSERT INTO Bill (ApartmentID, BillType, Month, Year, Amount) VALUES (1, 'Elektrik', 8, 2023, 200.00)");
            migrationBuilder.Sql("INSERT INTO Bill (ApartmentID, BillType, Month, Year, Amount) VALUES (2, 'Su', 8, 2023, 150.00)");


            // Dues
            migrationBuilder.Sql($"INSERT INTO Dues (Amount, Month, Year, ApartmentID) VALUES (200.00, 2, 2023, 1)");
            migrationBuilder.Sql($"INSERT INTO Dues (Amount, Month, Year, ApartmentID) VALUES (150.00, 3, 2023, 2)");


            // ResidentMessage
            migrationBuilder.Sql($"INSERT INTO ResidentMessage (Title, Content, Date, IsRead, SenderResidentId, ReceiverManagerId) VALUES ('Message re1', 'Hello admin', '{currentDate}', 0, 1, 1)");
            migrationBuilder.Sql($"INSERT INTO ResidentMessage (Title, Content, Date, IsRead, SenderResidentId, ReceiverManagerId) VALUES ('Message re2', 'Hello admin', '{currentDate}', 0, 2, 1)");

            // ManagerMessage
            migrationBuilder.Sql($"INSERT INTO ManagerMessage (Title, Content, Date, IsRead, SenderManagerId, ReceiverResidentId) VALUES ('Messageadmin', 'Hello re2', '{currentDate}', 0, 1, 2)");
            migrationBuilder.Sql($"INSERT INTO ManagerMessage (Title, Content, Date, IsRead, SenderManagerId, ReceiverResidentId) VALUES ('Messageadmin', 'Hello re1', '{currentDate}', 0, 1, 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
