<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9730a53698bf9df8166d0080a8d5b61f",
  "translation_date": "2025-06-02T19:57:01+00:00",
  "source_file": "05-AdvancedTopics/mcp-scaling/README.md",
  "language_code": "ms"
}
-->
## Вертикальное масштабирование и оптимизация ресурсов

Вертикальное масштабирование направлено на оптимизацию одного экземпляра сервера MCP для эффективной обработки большего количества запросов. Это достигается путем тонкой настройки конфигураций, использования эффективных алгоритмов и грамотного управления ресурсами. Например, можно настроить пул потоков, тайм-ауты запросов и лимиты памяти для повышения производительности.

Рассмотрим пример оптимизации сервера MCP для вертикального масштабирования и управления ресурсами.

## Распределённая архитектура

Распределённые архитектуры предполагают работу нескольких узлов MCP совместно для обработки запросов, совместного использования ресурсов и обеспечения резервирования. Такой подход повышает масштабируемость и отказоустойчивость, позволяя узлам обмениваться данными и координироваться через распределённую систему.

Рассмотрим пример реализации распределённой архитектуры сервера MCP с использованием Redis для координации.

## Что дальше

- [Security](../mcp-security/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.