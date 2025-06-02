<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "494d87e1c4b9239c70f6a341fcc59a48",
  "translation_date": "2025-06-02T19:21:32+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "ms"
}
-->
# موضوعات پیشرفته در MCP

این فصل به بررسی مجموعه‌ای از موضوعات پیشرفته در پیاده‌سازی Model Context Protocol (MCP) می‌پردازد، از جمله ادغام چندرسانه‌ای، مقیاس‌پذیری، بهترین شیوه‌های امنیتی و ادغام سازمانی. این موضوعات برای ساخت برنامه‌های MCP قوی و آماده برای تولید که بتوانند نیازهای سیستم‌های هوش مصنوعی مدرن را برآورده کنند، بسیار حیاتی هستند.

## مروری کلی

این درس مفاهیم پیشرفته در پیاده‌سازی Model Context Protocol را بررسی می‌کند و تمرکز آن بر ادغام چندرسانه‌ای، مقیاس‌پذیری، بهترین شیوه‌های امنیتی و ادغام سازمانی است. این موضوعات برای ساخت برنامه‌های MCP در سطح تولید که بتوانند نیازهای پیچیده در محیط‌های سازمانی را مدیریت کنند، ضروری هستند.

## اهداف یادگیری

تا پایان این درس، شما قادر خواهید بود:

- قابلیت‌های چندرسانه‌ای را در چارچوب‌های MCP پیاده‌سازی کنید
- معماری‌های مقیاس‌پذیر MCP را برای سناریوهای با تقاضای بالا طراحی کنید
- بهترین شیوه‌های امنیتی مطابق با اصول امنیتی MCP را اعمال کنید
- MCP را با سیستم‌ها و چارچوب‌های هوش مصنوعی سازمانی ادغام کنید
- عملکرد و قابلیت اطمینان را در محیط‌های تولید بهینه‌سازی کنید

## دروس و پروژه‌های نمونه

| لینک | عنوان | توضیحات |
|------|-------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | ادغام با Azure | یاد بگیرید چگونه MCP Server خود را روی Azure ادغام کنید |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | نمونه‌های چندرسانه‌ای MCP | نمونه‌هایی برای پاسخ‌های صوتی، تصویری و چندرسانه‌ای |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | دمو MCP OAuth2 | برنامه‌ای ساده با Spring Boot که OAuth2 را با MCP به عنوان Authorization و Resource Server نشان می‌دهد. نحوه صدور امن توکن، نقاط انتهایی محافظت شده، استقرار در Azure Container Apps و ادغام با API Management را نمایش می‌دهد. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | زمینه‌های ریشه‌ای | بیشتر با زمینه ریشه‌ای آشنا شوید و نحوه پیاده‌سازی آن‌ها را یاد بگیرید |
| [5.5 Routing](./mcp-routing/README.md) | مسیریابی | انواع مختلف مسیریابی را یاد بگیرید |
| [5.6 Sampling](./mcp-sampling/README.md) | نمونه‌گیری | نحوه کار با نمونه‌گیری را یاد بگیرید |
| [5.7 Scaling](./mcp-scaling/README.md) | مقیاس‌پذیری | درباره مقیاس‌پذیری بیاموزید |
| [5.8 Security](./mcp-security/README.md) | امنیت | MCP Server خود را امن کنید |
| [5.9 Web Search sample](./web-search-mcp/README.md) | جستجوی وب MCP | سرور و کلاینت MCP به زبان Python که با SerpAPI برای جستجوی وب، اخبار، محصولات و پرسش و پاسخ به صورت بلادرنگ ادغام شده است. هماهنگی چندابزاره، ادغام API خارجی و مدیریت خطاهای قوی را نشان می‌دهد. |

## منابع اضافی

برای به‌روزترین اطلاعات درباره موضوعات پیشرفته MCP به منابع زیر مراجعه کنید:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## نکات کلیدی

- پیاده‌سازی‌های چندرسانه‌ای MCP قابلیت‌های هوش مصنوعی را فراتر از پردازش متن گسترش می‌دهند
- مقیاس‌پذیری برای استقرارهای سازمانی ضروری است و می‌توان آن را از طریق مقیاس‌پذیری افقی و عمودی برطرف کرد
- اقدامات امنیتی جامع داده‌ها را محافظت کرده و دسترسی مناسب را تضمین می‌کنند
- ادغام سازمانی با پلتفرم‌هایی مانند Azure OpenAI و Microsoft AI Foundry قابلیت‌های MCP را ارتقا می‌دهد
- پیاده‌سازی‌های پیشرفته MCP از معماری‌های بهینه و مدیریت دقیق منابع بهره‌مند می‌شوند

## تمرین

یک پیاده‌سازی MCP در سطح سازمانی برای یک مورد استفاده خاص طراحی کنید:

1. نیازهای چندرسانه‌ای مورد استفاده خود را شناسایی کنید
2. کنترل‌های امنیتی لازم برای محافظت از داده‌های حساس را مشخص کنید
3. معماری مقیاس‌پذیری طراحی کنید که بتواند بارهای متغیر را مدیریت کند
4. نقاط ادغام با سیستم‌های هوش مصنوعی سازمانی را برنامه‌ریزی کنید
5. گلوگاه‌های احتمالی عملکرد و راهکارهای کاهش آن‌ها را مستند کنید

## منابع بیشتر

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## مرحله بعد

- [5.1 MCP Integration](./mcp-integration/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil perhatian bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.