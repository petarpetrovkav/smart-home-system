using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities;

namespace Shop.Infrastructure.DataLayer.EntityMaps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.ToTable(nameof(Product));

            entity.Property(d => d.ProductId).HasColumnOrder(1);
            entity.Property(d => d.ProductCategoryId).HasColumnOrder(2);
            entity.Property(d => d.ProductName).HasColumnOrder(3).HasMaxLength(100);

            entity.Property(d => d.Description).HasColumnOrder(4).HasColumnType("varchar(500)");
            entity.Property(d => d.Price).HasColumnOrder(5);
            entity.Property(d => d.StockQuantity).HasColumnOrder(6);
            entity.Property(d => d.ImageUrl).HasColumnOrder(7).HasColumnType("varchar(500)");
            entity.Property(d => d.CreatedAt).HasColumnOrder(8).ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("(GetDate())");
            entity.Property(d => d.ModifiedAt).HasColumnOrder(9);
            entity.Property(d => d.DeletedAt).HasColumnOrder(10);



            Product[] products = new Product[]
            {
                new Product
                {
                    ProductId = Guid.Parse("5e326ee6-e48e-4b82-9b0c-f6b6e13b3c94"),
                    ProductCategoryId = Guid.Parse("7d6f45c8-a818-4336-8040-ea762e5c7990"),
                    ProductName = "Hive Thermostat",
                    Description = "Save up to £200 a year¹ with our best-selling original. It’s got all you need to lower your bills and shrink your carbon footprint.",
                    Price = 119,
                    StockQuantity = 50,
                    ImageUrl = "https://www.britishgas.co.uk/aem6/content/dam/hive/product-landmark/images/pdp-thermostat-hero1-temporary-pill@2x.png",
                },
                new Product
                {
                    ProductId = Guid.Parse("914a7eaf-1f86-43fa-8ff2-fde40a2d5d91"),
                    ProductCategoryId = Guid.Parse("7d6f45c8-a818-4336-8040-ea762e5c7990"),
                    ProductName = "Hive Thermostat Mini",
                    Description = "Save up to £200 a year¹ with our best-selling original. It’s got all you need to lower your bills and shrink your carbon footprint.",
                    Price = 79,
                    StockQuantity = 100,
                    ImageUrl = "https://www.britishgas.co.uk/aem6/content/dam/hive/product-landmark/images/thermostat-mini-hero-feb-sale.png",
                },
                new Product
                {
                    ProductId= Guid.Parse("6d729ff2-c3b3-420a-a9e7-5dbd345ec0ce"),
                    ProductCategoryId = Guid.Parse("7d6f45c8-a818-4336-8040-ea762e5c7990"),
                    ProductName = "Hive Heating Plus",
                    Description = "Supercharge your savings and shrink your carbon footprint with handy budgeting tools, 24/7 efficiency monitoring and personalised suggestions to help you use less energy every day.",
                    Price = 19,
                    StockQuantity = 100,
                    ImageUrl = "https://www.britishgas.co.uk/aem6/content/dam/hive/product-landmark/images/Oct23/pdp-heatingplus-hero-new@b.png",
                },
                new Product
                {
                    ProductId= Guid.Parse("ea78d2e6-26ac-49c0-a7e4-550f595e6d23"),
                    ProductCategoryId = Guid.Parse("7d6f45c8-a818-4336-8040-ea762e5c7990"),
                    ProductName = "Hive Radiator Valves",
                    Description = "Set the perfect temperature in every room with smart radiator valves. Then save energy and money by never heating an empty room again.",
                    Price = 59,
                    StockQuantity = 100,
                    ImageUrl = "https://www.britishgas.co.uk/aem6/content/dam/hive/product-landmark/images/Oct23/TRV.png",
                },
                new Product
                {
                    ProductId= Guid.Parse("f2ca12fe-7d65-4e94-9772-41bca2a8c214"),
                    ProductCategoryId = Guid.Parse("7d6f45c8-a818-4336-8040-ea762e5c7990"),
                    ProductName = "Hive Thermostat Frame",
                    Description = "With a Hive Thermostat Frame your thermostat blends perfectly into your home, with colours matched to the Dulux™ signature colour range.",
                    Price = 500,
                    StockQuantity = 100,
                    ImageUrl = "https://images.ctfassets.net/mijf9lz5yt3u/1ybin0sD7OOgPQghmdeOgD/d678a444cb007e0f0113748db3a2a199/img-pdp_hero_frame_lifestyle_2x.jpeg",
                },
                new Product
                {
                    ProductId= Guid.Parse("c9725e3b-2306-4cf8-96d6-9efeaa924fd0"),
                    ProductCategoryId = Guid.Parse("7d6f45c8-a818-4336-8040-ea762e5c7990"),
                    ProductName = "Hive Thermostat Stand",
                    Description = "Specifically designed for both the Hive Thermostat and Hive Thermostat Mini, our premium stand keeps your smart thermostat secure – wherever you choose to put it.",
                    Price = 29,
                    StockQuantity = 100,
                    ImageUrl = "https://www.britishgas.co.uk/aem6/content/dam/hive/product-landmark/images/Oct23/Thermostat-Stand.png",
                },
                new Product
                {
                    ProductId= Guid.Parse("7ddfe475-0e4b-4529-b21e-873c91bff958"),
                    ProductCategoryId = Guid.Parse("02ddad74-fd36-4fd5-abef-112beebc92d5"),
                    ProductName = "E27 B22 Smart Light Bulb",
                    Description = "Control these E27  B22 smart light bulbs from your Hive app or with your voice. Tap them on or off, adjust the brightness in a swipe and save energy using schedules. You can even use our smart sensors to turn them on automatically when you open the door or walk into the room.",
                    Price = 19,
                    StockQuantity = 100,
                    ImageUrl = "https://images.ctfassets.net/mijf9lz5yt3u/6WkACGS9wvpAOQh2tvzTlP/306bce1547e9d634105ddf62351fdb50/img-pdp_hero_e27_dimmable_2x.jpeg",
                },
                new Product
                {
                    ProductId= Guid.Parse("f5d0d37b-ae21-4c37-be28-a902b02bbedf"),
                    ProductCategoryId = Guid.Parse("02ddad74-fd36-4fd5-abef-112beebc92d5"),
                    ProductName = "GU10 Smart Light Bulb",
                    Description = "Control these GU10 spotlight bulbs from your Hive app or with your voice. Tap them on or off, adjust the brightness in a swipe and save energy using schedules. You can even use our smart sensors to turn them on automatically when you open the door or walk into the room.",
                    Price = 14,
                    StockQuantity = 100,
                    ImageUrl = "https://images.ctfassets.net/mijf9lz5yt3u/1KSdKT77RpgCnl0430G1v2/7fdfa2a2eeb808051e18b8ff05deef2e/img-pdp_hero_gu10_dimmable_2x.jpeg",
                },
                new Product
                {
                    ProductId= Guid.Parse("92e5fdaf-b601-4fdf-ac06-07cc51bf70c2"),
                    ProductCategoryId = Guid.Parse("02ddad74-fd36-4fd5-abef-112beebc92d5"),
                    ProductName = "E14 Smart Light Bulb",
                    Description = "Control these E14 candlelight bulbs from your Hive app or with your voice. Tap them on or off, adjust the brightness in a swipe and save energy using schedules. You can even use our smart sensors to turn them on automatically when you open the door or walk into the room.",
                    Price = 19,
                    StockQuantity = 100,
                    ImageUrl = "https://images.ctfassets.net/mijf9lz5yt3u/2zRGkm83nRH3G4pBsbEDdB/4f2d7abbf3dfb34762ff4aa50ac05d57/img-pdp_hero_e14_dimmable_2x.jpeg",
                },
                new Product
                {
                    ProductId= Guid.Parse("76516a11-3a35-46d3-8980-d8d7e38ead59"),
                    ProductCategoryId = Guid.Parse("02ddad74-fd36-4fd5-abef-112beebc92d5"),
                    ProductName = "Hive Motion Sensor",
                    Description = "Our Hive Motion Sensors let you know everything’s okay back home so you can relax wherever you are. Check if there’s been motion at home and get notifications the moment anything happens. Connect it with other Hive devices for even smarter control of your home. Like turning on a hall light when someone walks past.",
                    Price = 29,
                    StockQuantity = 100,
                    ImageUrl = "https://images.ctfassets.net/mijf9lz5yt3u/4inBTGozGS4AXJyJkYNfqr/70cc4b0538bc2fa24dedae8e89ac20ac/img-pdp_hero_motion_sensor_2x.jpeg",
                },
                new Product
                {
                    ProductId= Guid.Parse("c8c51472-8d32-4a32-933d-efebed3fa29e"),
                    ProductCategoryId = Guid.Parse("02ddad74-fd36-4fd5-abef-112beebc92d5"),
                    ProductName = "Hive Motion Sensors",
                    Description = "Save on wasted energy and create a fully automated home with Hive Motion Sensors. Connect them to your smart lights, plugs and more to get them working seamlessly around you.",
                    Price = 29,
                    StockQuantity = 100,
                    ImageUrl = "https://www.britishgas.co.uk/aem6/content/dam/hive/product-landmark/images/Oct23/Motion-Sensor.png",
                },
                new Product
                {
                    ProductId= Guid.Parse("75a266a8-1434-4dcd-872d-7707991f0749"),
                    ProductCategoryId = Guid.Parse("02ddad74-fd36-4fd5-abef-112beebc92d5"),
                    ProductName = "Hive Window or Door Sensor",
                    Description = "Our Hive Window or Door Sensor is a smart sensor that lets you know everything’s okay at home. Check on our app to see if windows or doors are open or closed and get notifications if anything changes.Connect it with other Hive devices for even smarter control of your home. Like turning the heating off automatically if a window is opened.",
                    Price = 29,
                    StockQuantity = 100,
                    ImageUrl = "https://images.ctfassets.net/mijf9lz5yt3u/4q0tQOev1gbZbm865S1FkP/aa83fd4cb28f4228419556b62ec59245/img-pdp_hero_contact_sensor_2x.jpeg",
                },
                new Product
                {
                    ProductId= Guid.Parse("ab51a5a3-b28a-41a1-b4bd-ff18df66377c"),
                    ProductCategoryId = Guid.Parse("02ddad74-fd36-4fd5-abef-112beebc92d5"),
                    ProductName = "Hive Plug",
                    Description = "Monitor power-hungry appliances and only ever use the energy you need with a Hive Plug. Simply connect it like a normal adaptor and transform any device in seconds.",
                    Price = 39,
                    StockQuantity = 100,
                    ImageUrl = "https://www.britishgas.co.uk/aem6/content/dam/hive/product-landmark/images/Oct23/Plug-Hero.png",
                },
                new Product
                {
                    ProductId= Guid.Parse("55a5f1c0-462b-4f7d-b673-647e1f546b37"),
                    ProductCategoryId = Guid.Parse("02ddad74-fd36-4fd5-abef-112beebc92d5"),
                    ProductName = "Hive Hub",
                    Description = "Our essential Hive Hub is the brains of your smart home. It connects all your devices to the internet – and to each other. So you can control everything straight from your smartphone.",
                    Price = 60,
                    StockQuantity = 100,
                    ImageUrl = "https://www.britishgas.co.uk/aem6/content/dam/hive/product-landmark/images/Oct23/Hub-PDP-Hero.png",
                },
                new Product
                {
                    ProductId= Guid.Parse("4d15a842-fd7a-4769-a325-e873a855238c"),
                    ProductCategoryId = Guid.Parse("02ddad74-fd36-4fd5-abef-112beebc92d5"),
                    ProductName = "Hive Signal Booster",
                    Description = "Our Hive Signal Booster makes sure you can connect your Hive devices to your hub wherever they are. It's ideal if you've got a big house or Hive devices in your basement and loft.",
                    Price = 29,
                    StockQuantity = 100,
                    ImageUrl = "https://images.ctfassets.net/mijf9lz5yt3u/3Zkuloon5cGr9lC6dmRCcj/82a2f096552a3679d8866d2dcf8d279f/img-pdp_hero_signal_booster_dimensions_2x.jpeg",
                },
                new Product
                {
                    ProductId= Guid.Parse("3c6b709a-cd4c-4fea-863c-6913f1fe5db1"),
                    ProductCategoryId = Guid.Parse("02ddad74-fd36-4fd5-abef-112beebc92d5"),
                    ProductName = "Hive EV Charging with EO Mini Pro 3",
                    Description = "One of the smallest home EV chargers around, yet powerful enough to fully charge the average EV battery from empty in under eight hours, the EO Mini Pro 3 is packed with in-built safety features. And with its sleek matte black finish, it certainly makes a style statement.",
                    Price = 1199,
                    StockQuantity = 100,
                    ImageUrl = "https://images.ctfassets.net/mijf9lz5yt3u/u3QT41kxDTa6TnuDygqJC/550fedee527af538ed9045a6568a99fb/img-pdp_hero_ev_charger_eo_mini_pro_3_dimensions_2x.png",
                },
                new Product
                {
                    ProductId= Guid.Parse("42afae17-36e2-42fd-a9c9-ea5da1253286"),
                    ProductCategoryId = Guid.Parse("1745e8de-2eac-4ccb-b954-1d00435fe66c"),
                    ProductName = "Hive EV Charging with Alfen Eve S-Line",
                    Description = "With safety and reliability at the heart of its design, the Alfen Eve Single S-Line is housed in a weatherproof white casing. Able to fully charge an average battery from empty in under eight hours, it always has the latest features thanks to automatic over-the-air updates.",
                    Price = 29,
                    StockQuantity = 100,
                    ImageUrl = "https://images.ctfassets.net/mijf9lz5yt3u/1hZsDEEbIvqKNvL0547SBb/38e173aaec714f66b84ae517a7b42a77/img-pdp_hero_ev_charger_alfen_eve_single_sline_1_2x.jpeg",
                },
            };

            entity.HasData(products);

        }
    }
}