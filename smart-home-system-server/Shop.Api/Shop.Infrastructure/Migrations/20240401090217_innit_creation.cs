using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    public partial class innit_creation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                schema: "dbo",
                columns: table => new
                {
                    ProductCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Desc = table.Column<string>(type: "varchar(200)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(GetDate())"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.ProductCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "dbo",
                columns: table => new
                {
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Street = table.Column<string>(type: "varchar(50)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "dbo",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                schema: "dbo",
                columns: table => new
                {
                    ShoppingCartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(GetDate())"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.ShoppingCartId);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "dbo",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "varchar(500)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(GetDate())"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_ProductCategory_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalSchema: "dbo",
                        principalTable: "ProductCategory",
                        principalColumn: "ProductCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "dbo",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    OrderStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(GetDate())"),
                    TotalCost = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Address_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "dbo",
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Order_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CartItem",
                schema: "dbo",
                columns: table => new
                {
                    CartItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShoppingCartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItem_ShoppingCart_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalSchema: "dbo",
                        principalTable: "ShoppingCart",
                        principalColumn: "ShoppingCartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                schema: "dbo",
                columns: table => new
                {
                    OrderItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PriceAtPurchase = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "dbo",
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "392e10a6-af25-47bc-a99b-eb73a2f81b65", 0, "9fc5e16d-0af9-4337-b6c0-b3c48b59e374", "Macedonia", null, false, "Petar", "Petrov", false, null, null, null, null, null, false, "62a246b0-47af-42e5-a244-c0a0892c5f99", false, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ProductCategory",
                columns: new[] { "ProductCategoryId", "DeletedAt", "Desc", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("02ddad74-fd36-4fd5-abef-112beebc92d5"), null, null, null, "Smart Home" },
                    { new Guid("1745e8de-2eac-4ccb-b954-1d00435fe66c"), null, null, null, "EV Charging" },
                    { new Guid("7d6f45c8-a818-4336-8040-ea762e5c7990"), null, null, null, "Smart Heating" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Address",
                columns: new[] { "AddressId", "City", "Country", "PostalCode", "Street", "UserId" },
                values: new object[,]
                {
                    { new Guid("8a58c5f6-e9cb-4066-951d-f74a4d5c88d1"), "Kavadarci", "Macedonia", "1430", "Gorgi Sugare Br.90", "392e10a6-af25-47bc-a99b-eb73a2f81b65" },
                    { new Guid("d3db2f0c-19ee-4fb3-9ac4-475e2be5e47c"), "Skopje", "Macedonia", "1000", "Franklin Ruzvelt 50a 2/27", "392e10a6-af25-47bc-a99b-eb73a2f81b65" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Product",
                columns: new[] { "ProductId", "DeletedAt", "Description", "ImageUrl", "ModifiedAt", "Price", "ProductCategoryId", "ProductName", "StockQuantity" },
                values: new object[,]
                {
                    { new Guid("3c6b709a-cd4c-4fea-863c-6913f1fe5db1"), null, "One of the smallest home EV chargers around, yet powerful enough to fully charge the average EV battery from empty in under eight hours, the EO Mini Pro 3 is packed with in-built safety features. And with its sleek matte black finish, it certainly makes a style statement.", "https://images.ctfassets.net/mijf9lz5yt3u/u3QT41kxDTa6TnuDygqJC/550fedee527af538ed9045a6568a99fb/img-pdp_hero_ev_charger_eo_mini_pro_3_dimensions_2x.png", null, 1199, new Guid("02ddad74-fd36-4fd5-abef-112beebc92d5"), "Hive EV Charging with EO Mini Pro 3", 100 },
                    { new Guid("42afae17-36e2-42fd-a9c9-ea5da1253286"), null, "With safety and reliability at the heart of its design, the Alfen Eve Single S-Line is housed in a weatherproof white casing. Able to fully charge an average battery from empty in under eight hours, it always has the latest features thanks to automatic over-the-air updates.", "https://images.ctfassets.net/mijf9lz5yt3u/1hZsDEEbIvqKNvL0547SBb/38e173aaec714f66b84ae517a7b42a77/img-pdp_hero_ev_charger_alfen_eve_single_sline_1_2x.jpeg", null, 29, new Guid("1745e8de-2eac-4ccb-b954-1d00435fe66c"), "Hive EV Charging with Alfen Eve S-Line", 100 },
                    { new Guid("4d15a842-fd7a-4769-a325-e873a855238c"), null, "Our Hive Signal Booster makes sure you can connect your Hive devices to your hub wherever they are. It's ideal if you've got a big house or Hive devices in your basement and loft.", "https://images.ctfassets.net/mijf9lz5yt3u/3Zkuloon5cGr9lC6dmRCcj/82a2f096552a3679d8866d2dcf8d279f/img-pdp_hero_signal_booster_dimensions_2x.jpeg", null, 29, new Guid("02ddad74-fd36-4fd5-abef-112beebc92d5"), "Hive Signal Booster", 100 },
                    { new Guid("55a5f1c0-462b-4f7d-b673-647e1f546b37"), null, "Our essential Hive Hub is the brains of your smart home. It connects all your devices to the internet – and to each other. So you can control everything straight from your smartphone.", "https://www.britishgas.co.uk/aem6/content/dam/hive/product-landmark/images/Oct23/Hub-PDP-Hero.png", null, 60, new Guid("02ddad74-fd36-4fd5-abef-112beebc92d5"), "Hive Hub", 100 },
                    { new Guid("5e326ee6-e48e-4b82-9b0c-f6b6e13b3c94"), null, "Save up to £200 a year¹ with our best-selling original. It’s got all you need to lower your bills and shrink your carbon footprint.", "https://www.britishgas.co.uk/aem6/content/dam/hive/product-landmark/images/pdp-thermostat-hero1-temporary-pill@2x.png", null, 119, new Guid("7d6f45c8-a818-4336-8040-ea762e5c7990"), "Hive Thermostat", 50 },
                    { new Guid("6d729ff2-c3b3-420a-a9e7-5dbd345ec0ce"), null, "Supercharge your savings and shrink your carbon footprint with handy budgeting tools, 24/7 efficiency monitoring and personalised suggestions to help you use less energy every day.", "https://www.britishgas.co.uk/aem6/content/dam/hive/product-landmark/images/Oct23/pdp-heatingplus-hero-new@b.png", null, 19, new Guid("7d6f45c8-a818-4336-8040-ea762e5c7990"), "Hive Heating Plus", 100 },
                    { new Guid("75a266a8-1434-4dcd-872d-7707991f0749"), null, "Our Hive Window or Door Sensor is a smart sensor that lets you know everything’s okay at home. Check on our app to see if windows or doors are open or closed and get notifications if anything changes.Connect it with other Hive devices for even smarter control of your home. Like turning the heating off automatically if a window is opened.", "https://images.ctfassets.net/mijf9lz5yt3u/4q0tQOev1gbZbm865S1FkP/aa83fd4cb28f4228419556b62ec59245/img-pdp_hero_contact_sensor_2x.jpeg", null, 29, new Guid("02ddad74-fd36-4fd5-abef-112beebc92d5"), "Hive Window or Door Sensor", 100 },
                    { new Guid("76516a11-3a35-46d3-8980-d8d7e38ead59"), null, "Our Hive Motion Sensors let you know everything’s okay back home so you can relax wherever you are. Check if there’s been motion at home and get notifications the moment anything happens. Connect it with other Hive devices for even smarter control of your home. Like turning on a hall light when someone walks past.", "https://images.ctfassets.net/mijf9lz5yt3u/4inBTGozGS4AXJyJkYNfqr/70cc4b0538bc2fa24dedae8e89ac20ac/img-pdp_hero_motion_sensor_2x.jpeg", null, 29, new Guid("02ddad74-fd36-4fd5-abef-112beebc92d5"), "Hive Motion Sensor", 100 },
                    { new Guid("7ddfe475-0e4b-4529-b21e-873c91bff958"), null, "Control these E27  B22 smart light bulbs from your Hive app or with your voice. Tap them on or off, adjust the brightness in a swipe and save energy using schedules. You can even use our smart sensors to turn them on automatically when you open the door or walk into the room.", "https://images.ctfassets.net/mijf9lz5yt3u/6WkACGS9wvpAOQh2tvzTlP/306bce1547e9d634105ddf62351fdb50/img-pdp_hero_e27_dimmable_2x.jpeg", null, 19, new Guid("02ddad74-fd36-4fd5-abef-112beebc92d5"), "E27 B22 Smart Light Bulb", 100 },
                    { new Guid("914a7eaf-1f86-43fa-8ff2-fde40a2d5d91"), null, "Save up to £200 a year¹ with our best-selling original. It’s got all you need to lower your bills and shrink your carbon footprint.", "https://www.britishgas.co.uk/aem6/content/dam/hive/product-landmark/images/thermostat-mini-hero-feb-sale.png", null, 79, new Guid("7d6f45c8-a818-4336-8040-ea762e5c7990"), "Hive Thermostat Mini", 100 },
                    { new Guid("92e5fdaf-b601-4fdf-ac06-07cc51bf70c2"), null, "Control these E14 candlelight bulbs from your Hive app or with your voice. Tap them on or off, adjust the brightness in a swipe and save energy using schedules. You can even use our smart sensors to turn them on automatically when you open the door or walk into the room.", "https://images.ctfassets.net/mijf9lz5yt3u/2zRGkm83nRH3G4pBsbEDdB/4f2d7abbf3dfb34762ff4aa50ac05d57/img-pdp_hero_e14_dimmable_2x.jpeg", null, 19, new Guid("02ddad74-fd36-4fd5-abef-112beebc92d5"), "E14 Smart Light Bulb", 100 },
                    { new Guid("ab51a5a3-b28a-41a1-b4bd-ff18df66377c"), null, "Monitor power-hungry appliances and only ever use the energy you need with a Hive Plug. Simply connect it like a normal adaptor and transform any device in seconds.", "https://www.britishgas.co.uk/aem6/content/dam/hive/product-landmark/images/Oct23/Plug-Hero.png", null, 39, new Guid("02ddad74-fd36-4fd5-abef-112beebc92d5"), "Hive Plug", 100 },
                    { new Guid("c8c51472-8d32-4a32-933d-efebed3fa29e"), null, "Save on wasted energy and create a fully automated home with Hive Motion Sensors. Connect them to your smart lights, plugs and more to get them working seamlessly around you.", "https://www.britishgas.co.uk/aem6/content/dam/hive/product-landmark/images/Oct23/Motion-Sensor.png", null, 29, new Guid("02ddad74-fd36-4fd5-abef-112beebc92d5"), "Hive Motion Sensors", 100 },
                    { new Guid("c9725e3b-2306-4cf8-96d6-9efeaa924fd0"), null, "Specifically designed for both the Hive Thermostat and Hive Thermostat Mini, our premium stand keeps your smart thermostat secure – wherever you choose to put it.", "https://www.britishgas.co.uk/aem6/content/dam/hive/product-landmark/images/Oct23/Thermostat-Stand.png", null, 29, new Guid("7d6f45c8-a818-4336-8040-ea762e5c7990"), "Hive Thermostat Stand", 100 },
                    { new Guid("ea78d2e6-26ac-49c0-a7e4-550f595e6d23"), null, "Set the perfect temperature in every room with smart radiator valves. Then save energy and money by never heating an empty room again.", "https://www.britishgas.co.uk/aem6/content/dam/hive/product-landmark/images/Oct23/TRV.png", null, 59, new Guid("7d6f45c8-a818-4336-8040-ea762e5c7990"), "Hive Radiator Valves", 100 },
                    { new Guid("f2ca12fe-7d65-4e94-9772-41bca2a8c214"), null, "With a Hive Thermostat Frame your thermostat blends perfectly into your home, with colours matched to the Dulux™ signature colour range.", "https://images.ctfassets.net/mijf9lz5yt3u/1ybin0sD7OOgPQghmdeOgD/d678a444cb007e0f0113748db3a2a199/img-pdp_hero_frame_lifestyle_2x.jpeg", null, 500, new Guid("7d6f45c8-a818-4336-8040-ea762e5c7990"), "Hive Thermostat Frame", 100 },
                    { new Guid("f5d0d37b-ae21-4c37-be28-a902b02bbedf"), null, "Control these GU10 spotlight bulbs from your Hive app or with your voice. Tap them on or off, adjust the brightness in a swipe and save energy using schedules. You can even use our smart sensors to turn them on automatically when you open the door or walk into the room.", "https://images.ctfassets.net/mijf9lz5yt3u/1KSdKT77RpgCnl0430G1v2/7fdfa2a2eeb808051e18b8ff05deef2e/img-pdp_hero_gu10_dimmable_2x.jpeg", null, 14, new Guid("02ddad74-fd36-4fd5-abef-112beebc92d5"), "GU10 Smart Light Bulb", 100 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Order",
                columns: new[] { "OrderId", "AddressId", "OrderStatus", "PaymentMethod", "TotalCost", "UserId" },
                values: new object[] { new Guid("4b55da49-e4fd-4744-8e99-34e290673dd9"), new Guid("d3db2f0c-19ee-4fb3-9ac4-475e2be5e47c"), "Pending", "test", 160, "392e10a6-af25-47bc-a99b-eb73a2f81b65" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "OrderItem",
                columns: new[] { "OrderItemId", "OrderId", "PriceAtPurchase", "ProductId", "Quantity" },
                values: new object[] { new Guid("4d03df58-cfce-42d0-afa5-8ab781fd382a"), new Guid("4b55da49-e4fd-4744-8e99-34e290673dd9"), 300, new Guid("6d729ff2-c3b3-420a-a9e7-5dbd345ec0ce"), 3 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "OrderItem",
                columns: new[] { "OrderItemId", "OrderId", "PriceAtPurchase", "ProductId", "Quantity" },
                values: new object[] { new Guid("bd22ec0a-0a45-4138-85c5-79a2ca979d0e"), new Guid("4b55da49-e4fd-4744-8e99-34e290673dd9"), 100, new Guid("914a7eaf-1f86-43fa-8ff2-fde40a2d5d91"), 1 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "OrderItem",
                columns: new[] { "OrderItemId", "OrderId", "PriceAtPurchase", "ProductId", "Quantity" },
                values: new object[] { new Guid("d2417907-704a-44a7-8d2e-61cfab5e0f2d"), new Guid("4b55da49-e4fd-4744-8e99-34e290673dd9"), 200, new Guid("5e326ee6-e48e-4b82-9b0c-f6b6e13b3c94"), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserId",
                schema: "dbo",
                table: "Address",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "dbo",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "dbo",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "dbo",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "dbo",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "dbo",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "dbo",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "dbo",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ProductId",
                schema: "dbo",
                table: "CartItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ShoppingCartId",
                schema: "dbo",
                table: "CartItem",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_AddressId",
                schema: "dbo",
                table: "Order",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                schema: "dbo",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                schema: "dbo",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                schema: "dbo",
                table: "OrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductCategoryId",
                schema: "dbo",
                table: "Product",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_UserId",
                schema: "dbo",
                table: "ShoppingCart",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CartItem",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "OrderItem",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ShoppingCart",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProductCategory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "dbo");
        }
    }
}
