using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebSurvey.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FoodType",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    FoodName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodType", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    FullNames = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ContactNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    SurveyQuestion = table.Column<string>(type: "varchar(254)", maxLength: 254, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FaveriteFood",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    PersonId = table.Column<string>(type: "varchar(128)", nullable: false),
                    FoodTypeId = table.Column<string>(type: "varchar(128)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaveriteFood", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaveriteFood_FoodType_FoodTypeId",
                        column: x => x.FoodTypeId,
                        principalTable: "FoodType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FaveriteFood_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Survey",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    PersonId = table.Column<string>(type: "varchar(128)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Survey_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    QuestionId = table.Column<string>(type: "varchar(128)", nullable: false),
                    Choice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answer_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SurveyResponse",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    SurveyId = table.Column<string>(type: "varchar(128)", nullable: true),
                    QuestionId = table.Column<string>(type: "varchar(128)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyResponse_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SurveyResponse_Survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Survey",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "FoodType",
                columns: new[] { "Id", "FoodName" },
                values: new object[,]
                {
                    { "33a0750f-943e-46c0-8027-97709fdc4964", "Pizza" },
                    { "6656db56-52c3-42e2-829c-5714f13a7358", "Pasta" },
                    { "98081994-871b-4312-a06a-93f9651c6d38", "Pap and Wors" },
                    { "da1c824c-82a6-46bd-a21a-0c0a038e6172", "Other" }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "ContactNumber", "DateOfBirth", "Email", "FullNames" },
                values: new object[,]
                {
                    { "07731156-43e2-4f5e-b06f-a686df76b62b", "444555", new DateTime(1997, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "ndaba.ndabenhle@mail.com", "Ndabenhle Ndaba" },
                    { "33ed7e2d-48f1-4fdb-97e4-3fe0ede9f607", "1112233", new DateTime(1998, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "ndlovu.sakhile@mail.com", "Sakhile Ndlovu" },
                    { "3950a04c-b7e5-4ded-a898-41e28b5dcb29", "2265598", new DateTime(1999, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "nkosi.anathi@mail.com", "Anathi Nkosi" },
                    { "af16d0fa-48e3-49bf-9a4c-79f737683b99", "4455864", new DateTime(2000, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "sibisi.thamsanqa@mail.com", "Thamsanqa Sibisi" }
                });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "SurveyQuestion" },
                values: new object[,]
                {
                    { "01d458f3-90d8-484c-8afb-a4da18da0cb5", "I like to listen to radio." },
                    { "20ff91ad-8fb6-43ac-af35-6b90e89b0b38", "I like to eat out." },
                    { "75ca4016-f6a8-4247-a16b-e355c8e43077", "I like to watch TV." },
                    { "d10badf2-92b1-4dea-ae50-1a00afff1b22", "I like to watch movies." }
                });

            migrationBuilder.InsertData(
                table: "Answer",
                columns: new[] { "Id", "Choice", "QuestionId" },
                values: new object[,]
                {
                    { "095ae3cb-6a87-4e2c-8beb-33049c76b5cd", 3, "01d458f3-90d8-484c-8afb-a4da18da0cb5" },
                    { "191bd139-83c0-4cc4-a968-92acde83de4d", 2, "01d458f3-90d8-484c-8afb-a4da18da0cb5" },
                    { "19bc8763-7bfc-4cf8-9bde-679e157af5a3", 5, "20ff91ad-8fb6-43ac-af35-6b90e89b0b38" },
                    { "1e9de402-2f16-454e-b9ef-c3554611b40f", 1, "d10badf2-92b1-4dea-ae50-1a00afff1b22" },
                    { "28124810-f760-4f04-85a1-a15d29ccb285", 3, "75ca4016-f6a8-4247-a16b-e355c8e43077" },
                    { "32e1ab9e-c4a7-407e-8683-89f86af59af6", 2, "d10badf2-92b1-4dea-ae50-1a00afff1b22" },
                    { "46f1be5e-4d86-4444-a839-dade250c7b6e", 5, "20ff91ad-8fb6-43ac-af35-6b90e89b0b38" },
                    { "5f36ae6a-e026-435a-87fe-5447ced78b4f", 2, "01d458f3-90d8-484c-8afb-a4da18da0cb5" },
                    { "70db3c34-d81a-43a3-8104-87c3f7445dbb", 4, "01d458f3-90d8-484c-8afb-a4da18da0cb5" },
                    { "722a577f-d7e1-49a6-bc1a-e754408c98e8", 5, "d10badf2-92b1-4dea-ae50-1a00afff1b22" },
                    { "78defed4-14a6-42bf-a07d-f3b175c941d3", 4, "20ff91ad-8fb6-43ac-af35-6b90e89b0b38" },
                    { "c7185c3a-76fc-4491-ab56-1205250341eb", 3, "d10badf2-92b1-4dea-ae50-1a00afff1b22" },
                    { "da423657-3e2d-4b23-86ce-dae9ba1465de", 3, "75ca4016-f6a8-4247-a16b-e355c8e43077" },
                    { "e2aa65dc-47f4-452e-8014-1b658cc38890", 2, "20ff91ad-8fb6-43ac-af35-6b90e89b0b38" },
                    { "e912d393-93a0-4180-b1ef-3d745483d730", 3, "75ca4016-f6a8-4247-a16b-e355c8e43077" },
                    { "e93e8e15-31c0-4b0c-b58a-43619c1abb4e", 1, "75ca4016-f6a8-4247-a16b-e355c8e43077" }
                });

            migrationBuilder.InsertData(
                table: "FaveriteFood",
                columns: new[] { "Id", "FoodTypeId", "PersonId" },
                values: new object[,]
                {
                    { "26b66a88-43e5-4dc7-a15b-40043ece342e", "98081994-871b-4312-a06a-93f9651c6d38", "33ed7e2d-48f1-4fdb-97e4-3fe0ede9f607" },
                    { "3ee6e9ce-6a5c-4a3c-943c-1c0c7149b977", "33a0750f-943e-46c0-8027-97709fdc4964", "af16d0fa-48e3-49bf-9a4c-79f737683b99" },
                    { "6d3fc311-608e-4be8-b614-5dd2028244d9", "98081994-871b-4312-a06a-93f9651c6d38", "3950a04c-b7e5-4ded-a898-41e28b5dcb29" },
                    { "819afaaa-c124-4314-adac-c36755c6b59d", "da1c824c-82a6-46bd-a21a-0c0a038e6172", "07731156-43e2-4f5e-b06f-a686df76b62b" },
                    { "877f9631-10f9-4955-bc46-283ae50d52dc", "98081994-871b-4312-a06a-93f9651c6d38", "07731156-43e2-4f5e-b06f-a686df76b62b" },
                    { "91a808e2-170b-4efd-b283-3725eb3ac100", "98081994-871b-4312-a06a-93f9651c6d38", "af16d0fa-48e3-49bf-9a4c-79f737683b99" },
                    { "94be6ad3-d1b7-4e50-90c1-65f1407a226d", "33a0750f-943e-46c0-8027-97709fdc4964", "33ed7e2d-48f1-4fdb-97e4-3fe0ede9f607" },
                    { "9afbcd83-8a22-46ff-b229-4d0e4f167bfc", "6656db56-52c3-42e2-829c-5714f13a7358", "07731156-43e2-4f5e-b06f-a686df76b62b" },
                    { "a7a7d1a2-3e11-409f-a497-d361c64b3e9a", "6656db56-52c3-42e2-829c-5714f13a7358", "3950a04c-b7e5-4ded-a898-41e28b5dcb29" },
                    { "bb8af322-55da-43b7-a465-bd157523b3ec", "da1c824c-82a6-46bd-a21a-0c0a038e6172", "3950a04c-b7e5-4ded-a898-41e28b5dcb29" },
                    { "e5f745f9-a92e-49ad-9c10-dcf517af1f1f", "33a0750f-943e-46c0-8027-97709fdc4964", "3950a04c-b7e5-4ded-a898-41e28b5dcb29" }
                });

            migrationBuilder.InsertData(
                table: "Survey",
                columns: new[] { "Id", "PersonId" },
                values: new object[,]
                {
                    { "98579242-3cdd-4df1-a3f6-ea8c093cc934", "af16d0fa-48e3-49bf-9a4c-79f737683b99" },
                    { "bdd4a411-1c29-41e3-ae62-f84758387745", "33ed7e2d-48f1-4fdb-97e4-3fe0ede9f607" },
                    { "ccc21cf6-4e8d-4872-9730-cb9383b3105c", "07731156-43e2-4f5e-b06f-a686df76b62b" },
                    { "f39c0c72-8415-42a4-b902-9315514a862b", "3950a04c-b7e5-4ded-a898-41e28b5dcb29" }
                });

            migrationBuilder.InsertData(
                table: "SurveyResponse",
                columns: new[] { "Id", "QuestionId", "SurveyId" },
                values: new object[,]
                {
                    { "05c8c19c-e2ce-4dfd-80d4-17dec1b636c3", "20ff91ad-8fb6-43ac-af35-6b90e89b0b38", "ccc21cf6-4e8d-4872-9730-cb9383b3105c" },
                    { "27912a65-009d-43a6-bc01-83980d4f8873", "01d458f3-90d8-484c-8afb-a4da18da0cb5", "f39c0c72-8415-42a4-b902-9315514a862b" },
                    { "5a85f487-9b38-46d7-9a3c-fc34bc28b4c2", "01d458f3-90d8-484c-8afb-a4da18da0cb5", "bdd4a411-1c29-41e3-ae62-f84758387745" },
                    { "5e63e667-fe34-4c0f-a298-c43c1aed8e38", "20ff91ad-8fb6-43ac-af35-6b90e89b0b38", "f39c0c72-8415-42a4-b902-9315514a862b" },
                    { "856b8293-6935-46b9-b75e-da0dc7125dde", "75ca4016-f6a8-4247-a16b-e355c8e43077", "bdd4a411-1c29-41e3-ae62-f84758387745" },
                    { "8dbc9e6f-b850-4807-a6f7-4b989409569e", "75ca4016-f6a8-4247-a16b-e355c8e43077", "98579242-3cdd-4df1-a3f6-ea8c093cc934" },
                    { "922fa0dc-11c9-4485-b509-8bb06fd3eb0b", "01d458f3-90d8-484c-8afb-a4da18da0cb5", "98579242-3cdd-4df1-a3f6-ea8c093cc934" },
                    { "9f769737-6035-462c-9eea-85febaab7d86", "01d458f3-90d8-484c-8afb-a4da18da0cb5", "ccc21cf6-4e8d-4872-9730-cb9383b3105c" },
                    { "b986a680-cb1b-4138-804d-b0f0d9c51243", "d10badf2-92b1-4dea-ae50-1a00afff1b22", "bdd4a411-1c29-41e3-ae62-f84758387745" },
                    { "c6684fe7-60c2-4d23-b133-780868427f96", "d10badf2-92b1-4dea-ae50-1a00afff1b22", "f39c0c72-8415-42a4-b902-9315514a862b" },
                    { "d284b9f1-ab67-4db2-bb24-c2e2954685d4", "75ca4016-f6a8-4247-a16b-e355c8e43077", "f39c0c72-8415-42a4-b902-9315514a862b" },
                    { "d99282c7-e63e-4bb6-a6f5-73e355f31def", "20ff91ad-8fb6-43ac-af35-6b90e89b0b38", "98579242-3cdd-4df1-a3f6-ea8c093cc934" },
                    { "f617e7ef-862b-4bf7-aa2d-34d049a24b78", "75ca4016-f6a8-4247-a16b-e355c8e43077", "ccc21cf6-4e8d-4872-9730-cb9383b3105c" },
                    { "f88603a2-4ac2-4157-804f-540507b98ea9", "d10badf2-92b1-4dea-ae50-1a00afff1b22", "ccc21cf6-4e8d-4872-9730-cb9383b3105c" },
                    { "fc7da992-8e45-4cef-b635-140d88c55cf1", "d10badf2-92b1-4dea-ae50-1a00afff1b22", "98579242-3cdd-4df1-a3f6-ea8c093cc934" },
                    { "fde11fad-eeea-42ad-ba67-022f97318ed1", "20ff91ad-8fb6-43ac-af35-6b90e89b0b38", "bdd4a411-1c29-41e3-ae62-f84758387745" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_QuestionId",
                table: "Answer",
                column: "QuestionId",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_FaveriteFood_FoodTypeId",
                table: "FaveriteFood",
                column: "FoodTypeId",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_FaveriteFood_PersonId",
                table: "FaveriteFood",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_PersonId",
                table: "Survey",
                column: "PersonId",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResponse_QuestionId",
                table: "SurveyResponse",
                column: "QuestionId",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResponse_SurveyId",
                table: "SurveyResponse",
                column: "SurveyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "FaveriteFood");

            migrationBuilder.DropTable(
                name: "SurveyResponse");

            migrationBuilder.DropTable(
                name: "FoodType");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Survey");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
