<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:20:44+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "fa"
}
-->
# مطالعه موردی: نمایش REST API در API Management به عنوان یک سرور MCP

Azure API Management سرویسی است که یک دروازه (Gateway) روی نقاط پایانی API شما فراهم می‌کند. نحوه کار آن به این صورت است که Azure API Management مانند یک پراکسی جلوی APIهای شما عمل می‌کند و می‌تواند تصمیم بگیرد با درخواست‌های ورودی چه کاری انجام دهد.

با استفاده از آن، مجموعه‌ای از قابلیت‌ها را اضافه می‌کنید مانند:

- **امنیت**، می‌توانید از همه چیز از کلیدهای API، JWT تا managed identity استفاده کنید.
- **محدودیت نرخ درخواست‌ها**، قابلیت عالی این است که بتوانید تعیین کنید چند تماس در یک واحد زمانی مشخص عبور کنند. این کمک می‌کند تا همه کاربران تجربه خوبی داشته باشند و همچنین سرویس شما با درخواست‌های زیاد غرق نشود.
- **مقیاس‌پذیری و تعادل بار**. می‌توانید چندین نقطه پایانی تنظیم کنید تا بار را متعادل کنید و همچنین می‌توانید تصمیم بگیرید چگونه "تعادل بار" انجام شود.
- **قابلیت‌های هوش مصنوعی مانند کش معنایی، محدودیت توکن و مانیتورینگ توکن و بیشتر**. این‌ها قابلیت‌های عالی‌ای هستند که پاسخگویی را بهبود می‌بخشند و همچنین به شما کمک می‌کنند هزینه توکن‌هایتان را کنترل کنید. [اینجا بیشتر بخوانید](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities).

## چرا MCP + Azure API Management؟

Model Context Protocol به سرعت در حال تبدیل شدن به استانداردی برای برنامه‌های هوش مصنوعی عامل‌محور و نحوه نمایش ابزارها و داده‌ها به صورت یکپارچه است. Azure API Management انتخاب طبیعی است وقتی که نیاز دارید APIها را "مدیریت" کنید. سرورهای MCP اغلب با APIهای دیگر ادغام می‌شوند تا درخواست‌ها را به یک ابزار حل کنند، برای مثال. بنابراین ترکیب Azure API Management و MCP بسیار منطقی است.

## مرور کلی

در این مورد استفاده خاص، یاد می‌گیریم چگونه نقاط پایانی API را به عنوان یک سرور MCP نمایش دهیم. با انجام این کار، می‌توانیم به راحتی این نقاط پایانی را بخشی از یک برنامه عامل‌محور کنیم و در عین حال از قابلیت‌های Azure API Management بهره ببریم.

## ویژگی‌های کلیدی

- شما متدهای نقطه پایانی را که می‌خواهید به عنوان ابزار نمایش داده شوند انتخاب می‌کنید.
- قابلیت‌های اضافی که دریافت می‌کنید بستگی به تنظیمات شما در بخش سیاست‌ها برای API دارد. اما در اینجا نشان می‌دهیم چگونه می‌توانید محدودیت نرخ درخواست را اضافه کنید.

## مرحله پیش‌نیاز: وارد کردن یک API

اگر قبلاً API در Azure API Management دارید که عالی است، می‌توانید این مرحله را رد کنید. اگر ندارید، این لینک را ببینید، [وارد کردن API به Azure API Management](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api).

## نمایش API به عنوان سرور MCP

برای نمایش نقاط پایانی API، مراحل زیر را دنبال کنید:

1. به Azure Portal و آدرس زیر بروید <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
   به نمونه API Management خود بروید.

1. در منوی سمت چپ، APIs > MCP Servers > + Create new MCP Server را انتخاب کنید.

1. در بخش API، یک REST API را برای نمایش به عنوان سرور MCP انتخاب کنید.

1. یک یا چند عملیات API را برای نمایش به عنوان ابزار انتخاب کنید. می‌توانید همه عملیات‌ها یا فقط عملیات‌های خاصی را انتخاب کنید.

    ![انتخاب متدها برای نمایش](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. روی **Create** کلیک کنید.

1. به منوی **APIs** و سپس **MCP Servers** بروید، باید موارد زیر را ببینید:

    ![مشاهده سرور MCP در پنل اصلی](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    سرور MCP ایجاد شده و عملیات API به عنوان ابزار نمایش داده شده‌اند. سرور MCP در پنل MCP Servers فهرست شده است. ستون URL نقطه پایانی سرور MCP را نشان می‌دهد که می‌توانید برای تست یا در یک برنامه کلاینت آن را فراخوانی کنید.

## اختیاری: پیکربندی سیاست‌ها

Azure API Management مفهوم اصلی سیاست‌ها را دارد که در آن قوانین مختلفی برای نقاط پایانی خود تنظیم می‌کنید، مانند محدودیت نرخ درخواست یا کش معنایی. این سیاست‌ها به صورت XML نوشته می‌شوند.

در اینجا نحوه تنظیم یک سیاست برای محدود کردن نرخ درخواست‌های سرور MCP آورده شده است:

1. در پورتال، زیر APIs، **MCP Servers** را انتخاب کنید.

1. سرور MCP که ایجاد کرده‌اید را انتخاب کنید.

1. در منوی سمت چپ، زیر MCP، **Policies** را انتخاب کنید.

1. در ویرایشگر سیاست، سیاست‌هایی که می‌خواهید روی ابزارهای سرور MCP اعمال شود را اضافه یا ویرایش کنید. سیاست‌ها به فرمت XML تعریف می‌شوند. برای مثال، می‌توانید سیاستی اضافه کنید که تماس‌ها به ابزارهای سرور MCP را محدود کند (در این مثال، ۵ تماس در هر ۳۰ ثانیه برای هر آدرس IP کلاینت). این XML باعث محدودیت نرخ می‌شود:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    تصویر ویرایشگر سیاست:

    ![ویرایشگر سیاست](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## امتحان کنید

بیایید مطمئن شویم سرور MCP ما به درستی کار می‌کند.

برای این کار از Visual Studio Code و GitHub Copilot و حالت Agent آن استفاده خواهیم کرد. سرور MCP را به یک فایل *mcp.json* اضافه می‌کنیم. با این کار، Visual Studio Code به عنوان یک کلاینت با قابلیت‌های عامل‌محور عمل می‌کند و کاربران نهایی می‌توانند یک درخواست تایپ کنند و با سرور تعامل داشته باشند.

بیایید ببینیم چگونه سرور MCP را در Visual Studio Code اضافه کنیم:

1. از دستور MCP: **Add Server** در Command Palette استفاده کنید.

1. وقتی خواسته شد، نوع سرور را انتخاب کنید: **HTTP (HTTP or Server Sent Events)**.

1. URL سرور MCP در API Management را وارد کنید. مثال: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (برای نقطه پایانی SSE) یا **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (برای نقطه پایانی MCP)، توجه کنید تفاوت بین پروتکل‌ها `/sse` یا `/mcp` است.

1. یک شناسه سرور به دلخواه وارد کنید. این مقدار مهم نیست اما به یادآوری اینکه این نمونه سرور چیست کمک می‌کند.

1. انتخاب کنید که پیکربندی را در تنظیمات workspace یا تنظیمات کاربر ذخیره کنید.

  - **تنظیمات workspace** - پیکربندی سرور فقط در فایل .vscode/mcp.json ذخیره می‌شود و فقط در workspace فعلی قابل دسترسی است.

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    یا اگر از HTTP streaming به عنوان پروتکل استفاده کنید، کمی متفاوت خواهد بود:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **تنظیمات کاربر** - پیکربندی سرور به فایل *settings.json* سراسری شما اضافه می‌شود و در همه workspaceها قابل استفاده است. پیکربندی شبیه به موارد زیر است:

    ![تنظیمات کاربر](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. همچنین باید پیکربندی هدر اضافه کنید تا مطمئن شوید به درستی به Azure API Management احراز هویت می‌شود. از هدر **Ocp-Apim-Subscription-Key** استفاده می‌کند.

    - اینجا نحوه اضافه کردن آن به تنظیمات آمده است:

    ![اضافه کردن هدر برای احراز هویت](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png)، این باعث می‌شود یک پنجره درخواست کلید API نمایش داده شود که می‌توانید آن را در Azure Portal برای نمونه Azure API Management خود پیدا کنید.

   - برای اضافه کردن آن به *mcp.json*، می‌توانید به این شکل اضافه کنید:

    ```json
    "inputs": [
      {
        "type": "promptString",
        "id": "apim_key",
        "description": "API Key for Azure API Management",
        "password": true
      }
    ]
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp",
            "headers": {
                "Ocp-Apim-Subscription-Key": "Bearer ${input:apim_key}"
            }
        }
    }
    ```

### استفاده از حالت Agent

حالا همه چیز در تنظیمات یا در *.vscode/mcp.json* آماده است. بیایید امتحان کنیم.

باید یک آیکون Tools مانند شکل زیر باشد که ابزارهای نمایش داده شده از سرور شما را فهرست می‌کند:

![ابزارهای سرور](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. روی آیکون ابزارها کلیک کنید و باید فهرستی از ابزارها را ببینید:

    ![ابزارها](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. یک درخواست در چت وارد کنید تا ابزار فراخوانی شود. برای مثال، اگر ابزاری برای دریافت اطلاعات درباره یک سفارش انتخاب کرده‌اید، می‌توانید از عامل درباره یک سفارش سوال کنید. این یک نمونه درخواست است:

    ```text
    get information from order 2
    ```

    اکنون یک آیکون ابزار به شما نمایش داده می‌شود که از شما می‌خواهد برای ادامه اجرای ابزار تایید کنید. انتخاب کنید تا ابزار اجرا شود، باید خروجی مانند شکل زیر ببینید:

    ![نتیجه درخواست](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **آنچه در بالا می‌بینید بستگی به ابزارهایی دارد که تنظیم کرده‌اید، اما ایده این است که پاسخ متنی مانند بالا دریافت کنید.**


## منابع

در اینجا نحوه یادگیری بیشتر آمده است:

- [آموزش Azure API Management و MCP](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [نمونه پایتون: امن‌سازی سرورهای MCP راه دور با استفاده از Azure API Management (آزمایشی)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [آزمایشگاه مجوزدهی کلاینت MCP](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [استفاده از افزونه Azure API Management برای VS Code جهت وارد کردن و مدیریت APIها](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [ثبت و کشف سرورهای MCP راه دور در Azure API Center](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) مخزن عالی که بسیاری از قابلیت‌های هوش مصنوعی با Azure API Management را نشان می‌دهد
- [کارگاه‌های AI Gateway](https://azure-samples.github.io/AI-Gateway/) شامل کارگاه‌هایی با استفاده از Azure Portal که راه بسیار خوبی برای شروع ارزیابی قابلیت‌های هوش مصنوعی است.

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نواقصی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا تفسیر نادرستی که از استفاده این ترجمه ناشی شود، نیستیم.