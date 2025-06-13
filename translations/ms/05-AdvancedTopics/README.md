<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b1cffc51b82049ac3d5e88db0ff4a0a1",
  "translation_date": "2025-06-13T00:36:22+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "ms"
}
-->
# موضوعات پیشرفته در MCP

این فصل به بررسی مجموعه‌ای از موضوعات پیشرفته در پیاده‌سازی Model Context Protocol (MCP) می‌پردازد، از جمله یکپارچه‌سازی چندرسانه‌ای، مقیاس‌پذیری، بهترین روش‌های امنیتی و یکپارچه‌سازی سازمانی. این موضوعات برای ساخت برنامه‌های MCP مقاوم و آماده برای تولید که بتوانند نیازهای سیستم‌های مدرن هوش مصنوعی را برآورده کنند، حیاتی هستند.

## مرور کلی

این درس مفاهیم پیشرفته در پیاده‌سازی Model Context Protocol را بررسی می‌کند، با تمرکز بر یکپارچه‌سازی چندرسانه‌ای، مقیاس‌پذیری، بهترین روش‌های امنیتی و یکپارچه‌سازی سازمانی. این موضوعات برای ساخت برنامه‌های MCP با کیفیت تولید که قادر به مدیریت نیازهای پیچیده در محیط‌های سازمانی باشند، ضروری هستند.

## اهداف یادگیری

در پایان این درس، قادر خواهید بود:

- قابلیت‌های چندرسانه‌ای را در چارچوب‌های MCP پیاده‌سازی کنید
- معماری‌های مقیاس‌پذیر MCP را برای سناریوهای با تقاضای بالا طراحی کنید
- بهترین روش‌های امنیتی مطابق با اصول امنیتی MCP را به کار ببرید
- MCP را با سیستم‌ها و چارچوب‌های هوش مصنوعی سازمانی یکپارچه کنید
- عملکرد و قابلیت اطمینان را در محیط‌های تولید بهینه کنید

## دروس و پروژه‌های نمونه

| لینک | عنوان | توضیحات |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | یکپارچه‌سازی با Azure | یاد بگیرید چگونه MCP Server خود را روی Azure یکپارچه کنید |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | نمونه چندرسانه‌ای MCP | نمونه‌هایی برای پاسخ‌های صوتی، تصویری و چندرسانه‌ای |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | نمونه MCP OAuth2 | اپلیکیشن ساده Spring Boot که OAuth2 با MCP را به عنوان Authorization و Resource Server نشان می‌دهد. صدور امن توکن، نقاط انتهایی محافظت‌شده، استقرار در Azure Container Apps و یکپارچه‌سازی مدیریت API را نمایش می‌دهد. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | زمینه‌های ریشه‌ای | بیشتر درباره زمینه ریشه‌ای و نحوه پیاده‌سازی آن بیاموزید |
| [5.5 Routing](./mcp-routing/README.md) | مسیریابی | انواع مختلف مسیریابی را یاد بگیرید |
| [5.6 Sampling](./mcp-sampling/README.md) | نمونه‌گیری | نحوه کار با نمونه‌گیری را یاد بگیرید |
| [5.7 Scaling](./mcp-scaling/README.md) | مقیاس‌پذیری | درباره مقیاس‌پذیری بیاموزید |
| [5.8 Security](./mcp-security/README.md) | امنیت | MCP Server خود را ایمن کنید |
| [5.9 Web Search sample](./web-search-mcp/README.md) | جستجوی وب MCP | سرور و کلاینت Python MCP که با SerpAPI برای جستجوی وب، اخبار، محصولات و پرسش و پاسخ در زمان واقعی یکپارچه شده‌اند. ارکستراسیون چندابزاره، یکپارچه‌سازی API خارجی و مدیریت خطای قوی را نشان می‌دهد. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | پخش زنده | پخش داده‌های زنده در دنیای امروز که کسب‌وکارها و برنامه‌ها نیاز به دسترسی فوری به اطلاعات برای تصمیم‌گیری به موقع دارند، ضروری شده است. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | جستجوی وب | جستجوی وب در زمان واقعی؛ چگونه MCP با ارائه رویکردی استاندارد برای مدیریت زمینه در میان مدل‌های هوش مصنوعی، موتورهای جستجو و برنامه‌ها، جستجوی وب زنده را متحول می‌کند. |

## منابع اضافی

برای به‌روزترین اطلاعات در مورد موضوعات پیشرفته MCP، به موارد زیر مراجعه کنید:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## نکات کلیدی

- پیاده‌سازی‌های چندرسانه‌ای MCP قابلیت‌های هوش مصنوعی را فراتر از پردازش متن گسترش می‌دهند
- مقیاس‌پذیری برای استقرارهای سازمانی حیاتی است و می‌توان آن را از طریق مقیاس‌گذاری افقی و عمودی مدیریت کرد
- اقدامات امنیتی جامع داده‌ها را محافظت کرده و کنترل دسترسی صحیح را تضمین می‌کنند
- یکپارچه‌سازی سازمانی با پلتفرم‌هایی مانند Azure OpenAI و Microsoft AI Foundry قابلیت‌های MCP را افزایش می‌دهد
- پیاده‌سازی‌های پیشرفته MCP از معماری‌های بهینه و مدیریت منابع دقیق بهره‌مند می‌شوند

## تمرین

یک پیاده‌سازی MCP با کیفیت سازمانی برای یک مورد استفاده خاص طراحی کنید:

1. نیازهای چندرسانه‌ای مورد استفاده خود را شناسایی کنید
2. کنترل‌های امنیتی لازم برای محافظت از داده‌های حساس را ترسیم کنید
3. معماری مقیاس‌پذیری طراحی کنید که بتواند بارهای متغیر را مدیریت کند
4. نقاط یکپارچه‌سازی با سیستم‌های هوش مصنوعی سازمانی را برنامه‌ریزی کنید
5. گلوگاه‌های احتمالی عملکرد و راهکارهای کاهش آن‌ها را مستندسازی کنید

## منابع بیشتر

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## مرحله بعد

- [5.1 MCP Integration](./mcp-integration/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil perhatian bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab terhadap sebarang salah faham atau tafsiran yang salah yang timbul daripada penggunaan terjemahan ini.