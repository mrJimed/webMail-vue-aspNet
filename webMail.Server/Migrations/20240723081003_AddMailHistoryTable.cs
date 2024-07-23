using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webMail.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddMailHistoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mail_history",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    create_dt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    subject = table.Column<string>(type: "varchar", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false),
                    to_email = table.Column<string>(type: "varchar", nullable: false),
                    sender = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mail_history", x => x.id);
                    table.ForeignKey(
                        name: "FK_mail_history_users_sender",
                        column: x => x.sender,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mail_history_sender",
                table: "mail_history",
                column: "sender");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mail_history");
        }
    }
}
