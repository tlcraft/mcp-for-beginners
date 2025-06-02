<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e650db55873b456296a9c620069e2f71",
  "translation_date": "2025-06-02T11:17:11+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "bg"
}
-->
### -2- Създаване на проект

Сега, когато сте инсталирали SDK-то, нека създадем проект:

### -3- Създаване на файлове за проекта

### -4- Създаване на код за сървъра

### -5- Добавяне на инструмент и ресурс

Добавете инструмент и ресурс, като добавите следния код:

### -6 Финален код

Нека добавим последния необходим код, за да може сървърът да стартира:

### -7- Тестване на сървъра

Стартирайте сървъра със следната команда:

### -8- Стартиране с помощта на инспектора

Инспекторът е чудесен инструмент, който може да стартира сървъра ви и ви позволява да взаимодействате с него, за да проверите дали работи. Нека го стартираме:

> [!NOTE]
> може да изглежда различно в полето "command", тъй като съдържа командата за стартиране на сървър с вашия конкретен runtime/

Трябва да видите следния потребителски интерфейс:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.bg.png)

1. Свържете се със сървъра, като изберете бутона Connect  
   След като се свържете със сървъра, трябва да видите следното:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.bg.png)

2. Изберете "Tools" и "listTools", трябва да видите появил се бутон "Add", изберете "Add" и попълнете стойностите на параметрите.

   Трябва да видите следния отговор, т.е. резултат от инструмента "add":

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.bg.png)

Поздравления, успяхте да създадете и стартирате първия си сървър!

### Официални SDK-та

MCP предоставя официални SDK-та за няколко езика:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Поддържан в сътрудничество с Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Поддържан в сътрудничество със Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Официалната TypeScript реализация
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Официалната Python реализация
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Официалната Kotlin реализация
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Поддържан в сътрудничество с Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Официалната Rust реализация

## Основни изводи

- Настройването на MCP среда за разработка е лесно с езиково-специфични SDK-та
- Създаването на MCP сървъри включва създаване и регистриране на инструменти с ясни схеми
- Тестването и отстраняването на грешки са ключови за надеждни MCP реализации

## Примери

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Задача

Създайте прост MCP сървър с инструмент по ваш избор:  
1. Реализирайте инструмента на предпочитания от вас език (.NET, Java, Python или JavaScript).  
2. Дефинирайте входни параметри и стойности за връщане.  
3. Стартирайте инструмента inspector, за да се уверите, че сървърът работи както трябва.  
4. Тествайте реализацията с различни входни данни.

## Решение

[Решение](./solution/README.md)

## Допълнителни ресурси

- [MCP GitHub хранилище](https://github.com/microsoft/mcp-for-beginners)

## Какво следва

Следва: [Започване с MCP клиенти](/03-GettingStarted/02-client/README.md)

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI преводаческа услуга [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля имайте предвид, че автоматизираните преводи могат да съдържат грешки или неточности. Оригиналният документ на неговия роден език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за никакви недоразумения или неправилни тълкувания, произтичащи от използването на този превод.