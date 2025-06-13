<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "cd973a4e381337c6a3ac2443e7548e63",
  "translation_date": "2025-06-13T00:38:31+00:00",
  "source_file": "05-AdvancedTopics/mcp-scaling/README.md",
  "language_code": "ms"
}
-->
## Вертикальное масштабирование и оптимизация ресурсов

Вертикальное масштабирование направлено на оптимизацию одного экземпляра MCP-сервера для более эффективной обработки большего количества запросов. Это можно достичь путем тонкой настройки конфигураций, использования эффективных алгоритмов и грамотного управления ресурсами. Например, можно настроить пулы потоков, таймауты запросов и лимиты памяти для повышения производительности.

Рассмотрим пример оптимизации MCP-сервера для вертикального масштабирования и управления ресурсами.

## Распределённая архитектура

Распределённые архитектуры предполагают работу нескольких узлов MCP совместно для обработки запросов, совместного использования ресурсов и обеспечения резервирования. Такой подход улучшает масштабируемость и отказоустойчивость, позволяя узлам взаимодействовать и координироваться через распределённую систему.

Рассмотрим пример реализации распределённой архитектуры MCP-сервера с использованием Redis для координации.

## Что дальше

- [5.8 Security](../mcp-security/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil perhatian bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, disyorkan terjemahan profesional oleh manusia. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.