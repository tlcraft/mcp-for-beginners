<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6d6315e03f591fb5a39be91da88585dc",
  "translation_date": "2025-05-17T10:58:49+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/typescript/README.md",
  "language_code": "bg"
}
-->
# Изпълнение на този пример

Този пример включва наличието на LLM на клиента. LLM изисква от вас или да го стартирате в Codespaces, или да настроите личен достъп токен в GitHub, за да работи.

## -1- Инсталирайте зависимостите

```bash
npm install
```

## -3- Стартирайте сървъра

```bash
npm run build
```

## -4- Стартирайте клиента

```sh
npm run client
```

Трябва да видите резултат, подобен на:

```text
Asking server for available tools
MCPClient started on stdin/stdout
Querying LLM:  What is the sum of 2 and 3?
Making tool call
Calling tool add with args "{\"a\":2,\"b\":3}"
Tool result:  { content: [ { type: 'text', text: '5' } ] }
```

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI услуга за превод [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматичните преводи може да съдържат грешки или неточности. Оригиналният документ на неговия роден език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Не носим отговорност за неправилни разбирания или интерпретации, произтичащи от използването на този превод.