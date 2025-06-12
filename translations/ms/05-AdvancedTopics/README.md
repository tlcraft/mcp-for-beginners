<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "adaf47734a5839447b5c60a27120fbaf",
  "translation_date": "2025-06-11T16:07:17+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "ms"
}
-->
# موضوعات پیشرفته در MCP

این فصل به بررسی مجموعه‌ای از موضوعات پیشرفته در پیاده‌سازی Model Context Protocol (MCP) می‌پردازد، از جمله ادغام چندرسانه‌ای، مقیاس‌پذیری، بهترین روش‌های امنیتی و یکپارچه‌سازی سازمانی. این موضوعات برای ساخت برنامه‌های MCP قوی و آماده تولید که بتوانند نیازهای سیستم‌های هوش مصنوعی مدرن را برآورده کنند، حیاتی هستند.

## مرور کلی

این درس مفاهیم پیشرفته در پیاده‌سازی Model Context Protocol را بررسی می‌کند، با تمرکز بر ادغام چندرسانه‌ای، مقیاس‌پذیری، بهترین روش‌های امنیتی و یکپارچه‌سازی سازمانی. این موضوعات برای ساخت برنامه‌های MCP با کیفیت تولید که بتوانند نیازهای پیچیده در محیط‌های سازمانی را مدیریت کنند، ضروری هستند.

## اهداف یادگیری

تا پایان این درس، شما قادر خواهید بود:

- قابلیت‌های چندرسانه‌ای را در چارچوب‌های MCP پیاده‌سازی کنید
- معماری‌های مقیاس‌پذیر MCP را برای سناریوهای با تقاضای بالا طراحی کنید
- بهترین روش‌های امنیتی مطابق با اصول امنیتی MCP را به کار ببرید
- MCP را با سیستم‌ها و چارچوب‌های هوش مصنوعی سازمانی یکپارچه کنید
- عملکرد و قابلیت اطمینان را در محیط‌های تولید بهینه‌سازی کنید

## درس‌ها و پروژه‌های نمونه

| لینک | عنوان | توضیحات |
|------|-------|---------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | ادغام با Azure | یاد بگیرید چگونه MCP Server خود را روی Azure ادغام کنید |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | نمونه‌های چندرسانه‌ای MCP | نمونه‌هایی برای پاسخ صوتی، تصویری و چندرسانه‌ای |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | دمو MCP OAuth2 | برنامه ساده Spring Boot که OAuth2 را با MCP، هم به عنوان Authorization و هم Resource Server نشان می‌دهد. صدور توکن امن، نقاط پایانی محافظت شده، استقرار در Azure Container Apps و یکپارچه‌سازی مدیریت API را نمایش می‌دهد. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | زمینه‌های ریشه‌ای | بیشتر درباره زمینه ریشه‌ای و نحوه پیاده‌سازی آن‌ها بیاموزید |
| [5.5 Routing](./mcp-routing/README.md) | مسیریابی | انواع مختلف مسیریابی را یاد بگیرید |
| [5.6 Sampling](./mcp-sampling/README.md) | نمونه‌گیری | یاد بگیرید چگونه با نمونه‌گیری کار کنید |
| [5.7 Scaling](./mcp-scaling/README.md) | مقیاس‌پذیری | درباره مقیاس‌پذیری بیاموزید |
| [5.8 Security](./mcp-security/README.md) | امنیت | MCP Server خود را ایمن کنید |
| [5.9 Web Search sample](./web-search-mcp/README.md) | جستجوی وب MCP | سرور و کلاینت Python MCP که با SerpAPI برای جستجوی وب، اخبار، محصولات و پرسش و پاسخ در زمان واقعی ادغام شده است. هماهنگی چند ابزار، ادغام API خارجی و مدیریت خطای قوی را نشان می‌دهد. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | پخش زنده | پخش داده‌های زنده امروزه در دنیای داده‌محور ضروری شده است، جایی که کسب‌وکارها و برنامه‌ها به دسترسی فوری به اطلاعات برای تصمیم‌گیری به موقع نیاز دارند. |

## مراجع اضافی

برای به‌روزترین اطلاعات درباره موضوعات پیشرفته MCP، به منابع زیر مراجعه کنید:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## نکات کلیدی

- پیاده‌سازی‌های چندرسانه‌ای MCP قابلیت‌های هوش مصنوعی را فراتر از پردازش متن گسترش می‌دهند
- مقیاس‌پذیری برای استقرارهای سازمانی ضروری است و می‌توان از طریق مقیاس‌گذاری افقی و عمودی به آن دست یافت
- اقدامات امنیتی جامع داده‌ها را محافظت کرده و کنترل دسترسی مناسب را تضمین می‌کنند
- یکپارچه‌سازی سازمانی با پلتفرم‌هایی مانند Azure OpenAI و Microsoft AI Foundry قابلیت‌های MCP را افزایش می‌دهد
- پیاده‌سازی‌های پیشرفته MCP از معماری‌های بهینه و مدیریت منابع دقیق بهره‌مند می‌شوند

## تمرین

یک پیاده‌سازی MCP با استاندارد سازمانی برای یک مورد استفاده خاص طراحی کنید:

1. نیازهای چندرسانه‌ای مورد استفاده خود را شناسایی کنید
2. کنترل‌های امنیتی لازم برای محافظت از داده‌های حساس را مشخص کنید
3. معماری مقیاس‌پذیری طراحی کنید که بتواند بارهای متغیر را مدیریت کند
4. نقاط یکپارچه‌سازی با سیستم‌های هوش مصنوعی سازمانی را برنامه‌ریزی کنید
5. گلوگاه‌های احتمالی عملکرد و راهکارهای کاهش آن‌ها را مستندسازی کنید

## منابع اضافی

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## مرحله بعد

- [5.1 MCP Integration](./mcp-integration/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.