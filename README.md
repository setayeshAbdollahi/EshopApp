 EshopApp – فروشگاه اینترنتی ساده

این پروژه یک فروشگاه اینترنتی ساده و ساختارمند است که با استفاده از معماری Clean Architecture طراحی شده و شامل امکانات پایه‌ای مدیریت فروشگاه، دسته‌بندی، محصولات، فاکتور و گزارش‌گیری می‌باشد.



 تکنولوژی‌های استفاده شده

- ASP.NET Core Web API (.NET 8)
- Entity Framework Core
- SQLite 
- Angular 17 (در فاز بعدی قابل اضافه شدن)
-  Clean Architecture (جداسازی لایه‌ها)



 ساختار پروژه

EshopApp/
├── EshopApp.API → کنترلرهای REST و نقطه شروع API
├── EshopApp.Application → UseCases، اینترفیس‌ها، DTOها
├── EshopApp.Domain → موجودیت‌ها (Entities)، ValueObjects
├── EshopApp.Infrastructure → ریپازیتوری‌ها، UnitOfWork، Query Helpers
├── EshopApp.Persistence → DbContext، پیکربندی مدل‌ها، Migrations
└── EshopApp.Shared → کلاس‌های پایه (BaseEntity، Result و ...)



 امکانات پیاده‌سازی شده

-اطلاعات پایه فروشگاه (StoreInfo)
-مدیریت دسته‌بندی‌ها (ساختار درختی)
- مدیریت محصولات
-صدور فاکتور فروش
-محاسبه جمع کل
-گزارش‌گیری از فاکتورها
-ثبت‌نام و ورود کاربران (ادمین، فروشنده)
-استفاده از MediatR (در صورت نیاز)

 نحوه اجرای پروژه

 1. ساخت دیتابیس و اعمال مایگریشن‌ها
cd EshopApp.API
dotnet ef database update --project ../EshopApp.Persistence --startup-project .
2. اجرای پروژه
dotnet run --project EshopApp.API
3. مشاهده Swagger
به آدرس زیر بروید:
http://localhost:5029/swagger/index.html
 راه‌اندازی سریع
آخرین نسخه .NET 8 SDK را نصب کنید.

پروژه را باز کرده و دستورات بالا را اجرا کنید.

می‌توانید APIها را با Swagger یا Postman تست کنید.

 توسعه‌دهنده
Setayesh Abdollahi
github:setayeshAbdollahi
